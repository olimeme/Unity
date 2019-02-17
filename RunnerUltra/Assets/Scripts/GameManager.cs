
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

[SerializeField]
private Player player;
[SerializeField]
private GamePanel gamePanel;
private bool IsEnd;
private float score = 0;
private int countOfChanges = 0;


private void Start(){
	player.onGameOver += GameOver;
	player.onGameWin += GameWin;
}

private void GameWin(){
	float bestScore = PlayerPrefs.GetFloat("Score");
	if(score > bestScore){
		bestScore = score;
		PlayerPrefs.SetFloat("Score", bestScore);
	}
	player.transform.position = new Vector3(0,1,0);
	IsEnd = true;
	gamePanel.InitWin(score,bestScore,IsEnd);
}
private void GameOver(){
	float bestScore = PlayerPrefs.GetFloat("Score");
	if(score > bestScore){
		bestScore = score;
		PlayerPrefs.SetFloat("Score", bestScore);
	}
	player.transform.position = new Vector3(0,1,0);
	IsEnd = true;
	gamePanel.InitLose(score,bestScore,IsEnd);
}
private void Update(){
	if(!IsEnd){
	score = player.transform.position.z/100;
	if((int)score % 5 ==0 && countOfChanges == 0)
	{
		player.Speed = (player.Speed + 5); 
		countOfChanges = 1;
	}
	else if((int)score % 5 != 0)
	 countOfChanges = 0;
	}
}


}
