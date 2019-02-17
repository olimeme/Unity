using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour {

	[SerializeField]
	private Button saveButton;

	private void Start(){
		saveButton.onClick.AddListener(Save);	
	}

	private void Save(){
		SceneManager.LoadScene("Menu");
	}

	private void OnDestroy() {
		saveButton.onClick.RemoveAllListeners();
	}
}
