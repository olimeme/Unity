using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour {

[SerializeField]
private Rigidbody rigitBody;
[SerializeField]
private float speed; 
public float Speed {get {return speed;} set{speed = value;}}
[SerializeField]
private float sideSpeed;
[SerializeField]
private float jumpSpeed;
private int jumpCount = 0;
public Action onGameOver;
public Action onGameWin;

	private void Start () {
		//rigitBody.AddForce(0,0,9000);
	}
	
	private void Update () {
	rigitBody.AddForce(0,0,speed * Time.deltaTime,ForceMode.VelocityChange);	
	
	if(transform.position.y < 0){		
		if(onGameOver != null){				
				onGameOver();				
			}				
	}

	if(Input.GetKey(KeyCode.A)){
		rigitBody.AddForce(-sideSpeed * Time.deltaTime,0,0,ForceMode.VelocityChange);
	}else if(Input.GetKey(KeyCode.D)){
		rigitBody.AddForce(sideSpeed * Time.deltaTime,0,0,ForceMode.VelocityChange);
	}else if(Input.GetKey(KeyCode.Space)){
		 if (jumpCount < 1) 
     { 
		rigitBody.AddForce(0,jumpSpeed * Time.deltaTime,0,ForceMode.VelocityChange);
		jumpCount++;
	 } 
	}

	
	}
	private void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Obstacle"){
			this.enabled = false;
			if(onGameOver != null){				
				onGameOver();
			}
		}
		else if(other.gameObject.tag == "Ground"){
			jumpCount = 0;
		}	
		else if(other.gameObject.tag == "Finish"){
			this.enabled = false;
			if(onGameWin != null){
				onGameWin();
			}				
		}
	}

	private void OnTriggerEnter(Collider other) {
		if(other.tag == "Finish"){
			this.enabled = false;
			if(onGameWin != null){
				onGameWin();
			}				
	}
	}
}