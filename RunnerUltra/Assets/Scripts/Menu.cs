using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

[SerializeField]
	private Button playButton, quitButton, optionsButton;

	private void Start(){
		playButton.onClick.AddListener(Play);
		quitButton.onClick.AddListener(Quit);
		optionsButton.onClick.AddListener(Options);		
	}

	private void Play(){
		SceneManager.LoadScene("Level1");
	}

	private void Options(){
		SceneManager.LoadScene("Options");
	}
	private void Quit(){
		Application.Quit();
	}

	private void OnDestroy() {
		playButton.onClick.RemoveAllListeners();
		quitButton.onClick.RemoveAllListeners();
		optionsButton.onClick.RemoveAllListeners();
	}
}
