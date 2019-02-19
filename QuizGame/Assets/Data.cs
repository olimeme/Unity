using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Data : MonoBehaviour
{
    private string gameDataFileName = "/Database/Questions.json";

    [SerializeField]
    private GameManager gameManager;

    private void Start(){
        LoadGameData();
    }

    private void LoadGameData()
    {        	
        string filePath = Application.dataPath +  gameDataFileName;

        if(File.Exists(filePath))
        {            
            string dataAsJson = File.ReadAllText(filePath);             
            var data = JsonUtility.FromJson<GameData>(dataAsJson);
			Shuffle(data.array);
            gameManager.Init(data);
        }
        else
        {
            Debug.LogError("Cannot load game data! Path = " + filePath);			
        }
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
	
}