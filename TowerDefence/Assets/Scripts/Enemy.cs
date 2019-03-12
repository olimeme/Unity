using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Transform targetPoint;
    private int pointIndex = 0;

    private void Start(){
        targetPoint = Points.points[0];
    }

    private void Update(){
        transform.position = Vector3.MoveTowards(
            transform.position, 
            targetPoint.position, 
            speed * Time.deltaTime
        );

        var distance = Vector3.Distance(transform.position, targetPoint.position);
        if(distance <= 0.4f){
            GetNextPoint();
        }
    }

    private void GetNextPoint(){
        if(pointIndex >= Points.points.Length-1){
            PlayerStats.Lives -= 1;
            Destroy(gameObject);
            return;
        }
        pointIndex++;
        targetPoint = Points.points[pointIndex];
    }
}
