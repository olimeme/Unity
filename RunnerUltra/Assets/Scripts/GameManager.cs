using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private GamePanel gamePanel;

	[SerializeField]
	private Text scoreText;
	
	[SerializeField]
	private Player player;
	
	private float score = 0;

	private void Start(){
		player.onGameOver += GameOver;
		player.onWin += Win;
	}

	private void Update(){
		score = player.transform.position.z;
		scoreText.text = score.ToString("0");
	}

	private void Win(){
		var bestScore = UpdateScore();
		gamePanel.Init("YOU WON", score, bestScore);
	}

	private void GameOver(){
		var bestScore = UpdateScore();
		gamePanel.Init("YOU LOSE", score, bestScore);
	}

	private float UpdateScore(){
		var bestScore = PlayerPrefs.GetFloat("Score");
		if(score > bestScore){
			bestScore = score;
			PlayerPrefs.SetFloat("Score", bestScore);
		}
		return bestScore;
	}
}
