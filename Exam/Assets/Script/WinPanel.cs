using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinPanel : MonoBehaviour
{
    [SerializeField]
	private Transform root;

	[SerializeField]
	private Button quitBtn,retry;

     private void Start(){
		quitBtn.onClick.AddListener(Quit);
		retry.onClick.AddListener(Retry);
		root.gameObject.SetActive(false);
	}

    public void InitWin()
    {
		root.gameObject.SetActive(true);
    }

	private void Quit(){
		Application.Quit();
	}
    private void Retry(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);		
	}
	private void OnDestroy(){
		quitBtn.onClick.RemoveAllListeners();
		retry.onClick.RemoveAllListeners();
	}
}
