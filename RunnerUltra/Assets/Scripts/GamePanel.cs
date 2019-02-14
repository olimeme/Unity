using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour {

	[SerializeField]
	private Transform root;

	[SerializeField]
	private Text curScoreText, bestScoreText, headerText;

	[SerializeField]
	private Button retryBtn, quitBtn;

    [SerializeField]
    private Animator anim;

    private void Start(){
		retryBtn.onClick.AddListener(Retry);
		quitBtn.onClick.AddListener(Quit);
		//root.gameObject.SetActive(false);
	}

	public void Init(string message, float curScore, float bestScore){
        // show panel
        //root.gameObject.SetActive(true);
        anim.SetTrigger("gameOver");
		//init text
		headerText.text = message;
		curScoreText.text = "YOUR SCORE " + curScore.ToString("0");
		bestScoreText.text = "BEST SCORE " + bestScore.ToString("0");
	}

	private void Retry(){
		// reload level
		Debug.Log("Retry pressed");
	}

	private void Quit(){
		Application.Quit();
	}

	private void OnDestroy(){
		retryBtn.onClick.RemoveAllListeners();
		quitBtn.onClick.RemoveAllListeners();
	}
}
