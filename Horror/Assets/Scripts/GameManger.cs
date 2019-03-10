using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManger : MonoBehaviour
{
[SerializeField]
private UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController rigidbody;

[SerializeField]
private GamePanel gamePanel;
private bool IsEnd;
private float score = 0;
private int countOfChanges = 0;


private void Start(){
}
private void Update(){
        if(!IsEnd){
	        score = 0;
        }
    }
}
