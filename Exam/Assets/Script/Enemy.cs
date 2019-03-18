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
    private int health;
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
        if(health <= 0)
        {
            anime.SetTrigger("die");
            anime.speed = 0.7f;
            Invoke("Die",1f);
        }

        if(isAlive == false)
            return;

        anime.SetFloat("Speed", navMesh.velocity.magnitude);
        
        if(state == "idle")
        {
            GoToRandomPoint();
        }

        if(state =="walk")
        {
            CheckDistance();
        }

        if(state == "chase")
        {
            ChaseForPlayer();
        }

        if(state == "shoot")
        {
            ShootPlayer();
        }

    }

    public void Hit()
    {
        health-=20;
    }

    private void ShootPlayer()
    {
    }
    private void Die()
    {
        Destroy(this.gameObject);
    }
    private void ChaseForPlayer()
    {
    }

    private void KillPlayer()
    {
    }

    private void RestartLevel()
    {
    }

    public void CheckSight()
    {
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
    }

    private void CheckDistance()
    {
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,searchRadius);   
    }
}
