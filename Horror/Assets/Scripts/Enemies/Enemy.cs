using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    [Header("Nav Mesh Settings")]
    [SerializeField]
    private Player player;

    [SerializeField]
    private NavMeshAgent navMesh;

    [SerializeField]
    private Animator anime;


    [Header("Enemy settings")]
    [SerializeField]
    private float searchRadius;
    [SerializeField]
    private float waitTime;
    private float wait;

    [SerializeField]
    private Transform triggerZone;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private Transform deathCam;

    [SerializeField]
    private Transform deathCamPosition;

    private bool highAlert = false;
    private float alertLevel = 0;
    
    //состояние врага
    private string state = "idle";
    private bool isAlive = true;

    private void Start()
    {
        navMesh.speed = 1;
        anime.speed = 1;    
    }
    private void Update()
    {
        if(isAlive == false)
            return;

        anime.SetFloat("Speed", navMesh.velocity.magnitude);
        
        if(player.GetKeys() == 2)
        {
            state = "killed";
        }

        if(state == "idle")
        {
            GoToRandomPoint();
        }

        if(state =="walk")
        {
            CheckDistance();
        }

        if(state == "search")
        {
            Search();
        }

        if(state == "chase")
        {
            ChaseForPlayer();
        }

        if(state == "hunt")
        {
            CheckDistance();
        }

        if(state == "killed")
        {
            navMesh.transform.position = new Vector3(85,0,483);
            state = "chase";
        }

        if(state == "kill")
        {
            deathCam.position = Vector3.Slerp(deathCam.position,deathCamPosition.position,10f * Time.deltaTime);
            deathCam.rotation = Quaternion.Slerp(deathCam.rotation,deathCamPosition.rotation,10f * Time.deltaTime);
            anime.speed = 0.4f;
        }
    }

    private void ChaseForPlayer()
    {
        navMesh.SetDestination(player.transform.position);
        float distance = Vector3.Distance(transform.position,player.transform.position);
        var remainingDistance = navMesh.remainingDistance;
        var stoppingDistance = navMesh.stoppingDistance;
        if(distance > 10){
            state = "hunt";
            highAlert = true;
            alertLevel = 20;
        }else if(remainingDistance <= stoppingDistance && navMesh.pathPending == false)
        {
            var playerconntroller = player.GetComponent<PlayerController>();
            if(playerconntroller.isAlive == true)
            {
                state = "kill";
                KillPlayer();
            }
        }
    }

    private void KillPlayer()
    {
        //start animation
        anime.SetTrigger("kill");
        //start player event
        var playerconntroller = player.GetComponent<PlayerController>();
        playerconntroller.KillPlayer();
        //turning on the camera 
        deathCam.gameObject.SetActive(true);
        //and set it a position of player camera
        deathCam.transform.position = Camera.main.transform.position;
        deathCam.transform.rotation = Camera.main.transform.rotation;
        //later turn off the camera 
        Camera.main.gameObject.SetActive(false);
        
        audioSource.pitch = 0.8f;
        audioSource.Play();
        Invoke("RestartLevel",1.5f);
    }

    private void RestartLevel()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void CheckSight()
    {
        if(isAlive == false)
            return;

        RaycastHit hit;
        if(Physics.Linecast(triggerZone.position,player.transform.position, out hit))
        {
            if(hit.collider.tag == "Player")
            {
                if(state != "kill")
                {
                    state = "chase";
                    navMesh.speed = 2;
                    anime.speed = 2;
                    audioSource.pitch = 1.2f;
                    audioSource.Play();
                }
            }
        }
    }

    private void GoToRandomPoint()
    {
        //генерируем случайную точку в сфере
        Vector3 randomPos = Random.insideUnitSphere * searchRadius;
        NavMeshHit navHit;
        NavMesh.SamplePosition(transform.position + randomPos,out navHit,searchRadius,NavMesh.AllAreas);
        if(highAlert)
        {
            NavMesh.SamplePosition(player.transform.position,out navHit,searchRadius,NavMesh.AllAreas);
            alertLevel -= 5;
            if(alertLevel <= 0)
            {
                highAlert = false;
                navMesh.speed = 1;
                anime.speed = 1;
            }
        }
        navMesh.SetDestination(navHit.position);
        state = "walk";
    }

    private void Search()
    {
        if(wait <= 0)
        {
            state = "idle";
            return;
        }
        wait -= Time.deltaTime;
        transform.Rotate(0,120f * Time.deltaTime,0);
    }

    private void CheckDistance()
    {
        var remainingDistance = navMesh.remainingDistance;
        var stoppingDistance = navMesh.stoppingDistance;
        //когда достигли цели
        if(remainingDistance <= stoppingDistance && navMesh.pathPending == false)
        {
            state = "search";
            wait = waitTime;
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,searchRadius);   
    }
}
