using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GamePanel : MonoBehaviour
{
    [SerializeField]
	private Transform root;

	[SerializeField]
	private Text curScoreText, bestScoreText, headerText;

	[SerializeField]
	private Button retryBtn, quitBtn,nextLevelBtn;

    private void Start(){
		retryBtn.onClick.AddListener(Retry);
		quitBtn.onClick.AddListener(Quit);
		nextLevelBtn.onClick.AddListener(NextLevel);
		root.gameObject.SetActive(false);
	}

    private void Retry(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);		
	}
	private void NextLevel(){
		SceneManager.LoadScene("level2");
	}
	private void Quit(){
		Application.Quit();
	}
	private void OnDestroy(){
		retryBtn.onClick.RemoveAllListeners();
		quitBtn.onClick.RemoveAllListeners();
	}

    public void InitWin(float curScore, float bestScore, bool isEnd){
		root.gameObject.SetActive(true);
		headerText.text = "YOU WON";
		isEnd = false;
		if(SceneManager.GetActiveScene().name != "Level2")
			nextLevelBtn.gameObject.SetActive(true);
		else
			nextLevelBtn.gameObject.SetActive(false);
		curScoreText.text = "YOUR SCORE " + curScore.ToString("0");
		bestScoreText.text = "BEST SCORE " + bestScore.ToString("0");
	}

	public void InitLose(float curScore, float bestScore, bool isEnd){
		root.gameObject.SetActive(true);
		headerText.text = "YOU DIED";
		isEnd = false;
		curScoreText.text = "YOUR SCORE " + curScore.ToString("0");
		bestScoreText.text = "BEST SCORE " + bestScore.ToString("0");
	}
}
