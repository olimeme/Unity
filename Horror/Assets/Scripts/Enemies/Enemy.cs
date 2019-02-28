using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    [Header("Nav Mesh Settings")]
    [SerializeField]
    private Transform player;

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
    }

    public void CheckSight()
    {
        if(isAlive == false)
            return;

        RaycastHit hit;
        if(Physics.Linecast(triggerZone.position,player.position, out hit))
        {
            navMesh.SetDestination();
        }
    }

    private void GoToRandomPoint()
    {
        //генерируем случайную точку в сфере
        Vector3 randomPos = Random.insideUnitSphere * searchRadius;
        NavMeshHit navHit;
        NavMesh.SamplePosition(transform.position + randomPos,out navHit,searchRadius,NavMesh.AllAreas);
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
