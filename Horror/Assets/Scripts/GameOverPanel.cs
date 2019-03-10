using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField]
	private Transform root;

	[SerializeField]
	private Text headerText;

	[SerializeField]
	private Button quitBtn;

     private void Start(){
		quitBtn.onClick.AddListener(Quit);
		root.gameObject.SetActive(false);
	}

    public void InitWin()
    {
		root.gameObject.SetActive(true);
		quitBtn.gameObject.SetActive(true);
    }

	private void Quit(){
		Application.Quit();
	}
	private void OnDestroy(){
		quitBtn.onClick.RemoveAllListeners();
	}
}
