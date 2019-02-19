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
private GameData data;
[SerializeField]
private Text questionText;
[SerializeField]
private Button falseButton, trueButton,retryButton,quitButton;
[SerializeField]
private Transform gameRoot,statisticsRoot;
[SerializeField]
private Text amountText,correctText,incorrectText,procentText;

[System.Serializable]
public class Question
{
	public int id;
	public string name_ru;
	public bool right_answer;
}

[System.Serializable]
public class GameData{
	public List<Question> array;
}
private int currentQuestionIndex;
private int correctAnswers = 0;
private string gameDataFileName = "/Database/Questions.json";
private int incorrectAnswers = 0;

	private void Start(){
		currentQuestionIndex = 0;
		falseButton.onClick.AddListener(FalseButtonClick);
		trueButton.onClick.AddListener(TrueButtonClick);
		retryButton.onClick.AddListener(Retry);
		quitButton.onClick.AddListener(Quit);
		LoadGameData();
		questionText.text = data.array[currentQuestionIndex].name_ru;
	}

	private void FalseButtonClick(){
		int amountOfQuestions = (int)data.array.Count;
		if(IsCorrect(currentQuestionIndex,false))
			correctAnswers++;
		else
			incorrectAnswers++;
		currentQuestionIndex++;
		if(currentQuestionIndex == amountOfQuestions)
		{
			statisticsRoot.gameObject.SetActive(true);
			gameRoot.gameObject.SetActive(false);
			amountText.text = "Количество вопросов: " + amountOfQuestions;
			correctText.text = "Количетсво правильных ответов: " + correctAnswers;
			incorrectText.text = "Количетсво неправильных ответов: " + incorrectAnswers;
			procentText.text = "Процент правильных ответов: " + (float)((correctAnswers*100/amountOfQuestions)) +"%";
		}
		else
			questionText.text = data.array[currentQuestionIndex].name_ru;
		Debug.Log(data.array);
	}
	private void TrueButtonClick(){
		int amountOfQuestions = (int)data.array.Count;
		if(IsCorrect(currentQuestionIndex,true))	
			correctAnswers++;
		else
			incorrectAnswers++;

		currentQuestionIndex++;
		if(currentQuestionIndex == amountOfQuestions)
		{
			statisticsRoot.gameObject.SetActive(true);
			gameRoot.gameObject.SetActive(false);
			amountText.text = "Количество вопросов: " + amountOfQuestions;
			correctText.text = "Количетсво правильных ответов: " + correctAnswers;
			incorrectText.text = "Количетсво неправильных ответов: " + incorrectAnswers;
			procentText.text = "Процент правильных ответов: " + (float)((correctAnswers*100/amountOfQuestions)) +"%";
		}
		else
			questionText.text = data.array[currentQuestionIndex].name_ru;
		Debug.Log(data.array);
	}

	 private void LoadGameData()
    {        	
        string filePath = Application.dataPath +  gameDataFileName;

        if(File.Exists(filePath))
        {            
            string dataAsJson = File.ReadAllText(filePath);             
            data = JsonUtility.FromJson<GameData>(dataAsJson);
			Shuffle(data.array);
        }
        else
        {
            Debug.LogError("Cannot load game data! Path = " + filePath);			
        }
    }

	private void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);	
	}

	private void Quit()
	{
		Application.Quit();
	}
	private void Shuffle(List<Question> alpha)  
	{  
    	for (int i = 0; i < alpha.Count; i++) {
         Question temp = alpha[i];
         int randomIndex = Random.Range(i, alpha.Count);
         alpha[i] = alpha[randomIndex];
         alpha[randomIndex] = temp;
     }
	}
	private void ShowQuestion(int index)
    {        
        questionText.text = data.array[index].name_ru;
    }

	private bool IsCorrect(int index, bool answer){
		return data.array[index].right_answer == answer;
	}
}
