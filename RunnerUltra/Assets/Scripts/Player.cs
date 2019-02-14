using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {

	[SerializeField]
	private Rigidbody rigidbody;

	[SerializeField]
	private float speed;

	[SerializeField]
	private float sideSpeed;

	public Action onGameOver, onWin;
	
	private void Update () {
		rigidbody.AddForce(0, 0, speed * Time.deltaTime);

		if(Input.GetKey(KeyCode.A)){
			rigidbody.AddForce(-sideSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}else if(Input.GetKey(KeyCode.D)){
			rigidbody.AddForce(sideSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
	}

	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Obstacle"){
			// disable this component
			this.enabled = false;

			if(onGameOver != null){
				onGameOver();
			}
		}
	}

	private void OnTriggerEnter(Collider other) {
		if(other.tag == "Coin"){
			//destroy other object
			Destroy(other.gameObject);
			Debug.Log("Pick up coin");
		}else if(other.tag == "Finish")
		{
			if(onWin != null){
				onWin();
			}
		}
	}
}
