using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody;

    [SerializeField]
    private float speed; 

    [SerializeField]
    private float sideSpeed;

    public void SetSpeed(float value){
		sideSpeed = value;
    }
	public float GetSpeed(){
		return sideSpeed;
    }

    [SerializeField]
    private GameManager manager;
    
    private void Start()
    {
    }

    private void Update()   
    {
        rigidbody.AddForce(0,0,speed*Time.deltaTime);

        if(Input.GetKey(KeyCode.W))
        {
            rigidbody.AddForce(0,0,sideSpeed *Time.deltaTime,ForceMode.VelocityChange);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(0,0,-sideSpeed *Time.deltaTime,ForceMode.VelocityChange);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(sideSpeed *Time.deltaTime,0,0,ForceMode.VelocityChange);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(-sideSpeed *Time.deltaTime,0,0,ForceMode.VelocityChange);
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddForce(0,speed *Time.deltaTime,0,ForceMode.VelocityChange);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag =="PushBack")
            rigidbody.AddForce(0,0,-8,ForceMode.VelocityChange);
        if(other.gameObject.tag =="LiftUp")
            rigidbody.AddForce(0,10,0,ForceMode.VelocityChange);
    }

}