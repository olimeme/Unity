using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField]
    private Transform root;
    [SerializeField]
    private Button retryButton,quitButton;
    [SerializeField]
    private Text amountText,correctText,incorrectText,procentText;

    private void Start()
    {
		retryButton.onClick.AddListener(Retry); 
		quitButton.onClick.AddListener(Quit); 
    }

    private void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);	
	}

	private void Quit()
	{
		Application.Quit();
	}

    public void PrintStatistics(int amountOfQuestions,int correctAnswers,int incorrectAnswers)
    {
        root.gameObject.SetActive(true);
        amountText.text = "Количество вопросов: " + amountOfQuestions;
        correctText.text = "Количетсво правильных ответов: " + correctAnswers;
        incorrectText.text = "Количетсво неправильных ответов: " + incorrectAnswers;
        procentText.text = "Процент правильных ответов: " + (float)((correctAnswers*100/amountOfQuestions)) +"%";
    }
}
