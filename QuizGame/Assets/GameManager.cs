using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using System.Reflection;
using UnityEngine.SceneManagement;
using System.Threading;

public class GameManager : MonoBehaviour {
[SerializeField]
private Text questionText;
[SerializeField]
private Button falseBtn, trueBtn;
[SerializeField]
private Transform gameRoot;

private Data gameData;
private GameData data;
[SerializeField]
private GameOverPanel gameoverPanel;

private int currentQuestionIndex;
private int correctAnswers = 0;
private int incorrectAnswers = 0;

	private void Start(){
		currentQuestionIndex = 0;
		trueBtn.onClick.AddListener(delegate{Game(0);});
		falseBtn.onClick.AddListener(delegate{Game(1);});
	}

	public void Init(GameData data)
	{
		this.data = data;
        questionText.text = data.array[currentQuestionIndex].name_ru;
		Debug.Log(questionText.text);
	}

	private void Game(int idx)
	{
		bool answer = true;
        int amountOfQuestions = (int)data.array.Count;
        if(idx == 0)
            answer = true;
        else 
            answer = false;

		if(IsCorrect(currentQuestionIndex,answer))	
			correctAnswers++;
		else
			incorrectAnswers++;

		currentQuestionIndex++;
		
        if(currentQuestionIndex == amountOfQuestions)
		{
			gameoverPanel.PrintStatistics(amountOfQuestions,correctAnswers,incorrectAnswers);	
        	gameRoot.gameObject.SetActive(false);
		}
		else
			questionText.text = data.array[currentQuestionIndex].name_ru;
		Debug.Log(data.array);
	}
	
	private bool IsCorrect(int index, bool answer){
		return data.array[index].right_answer == answer;
	}
}
