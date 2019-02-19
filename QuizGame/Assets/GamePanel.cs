using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
	private Button trueBtn, falseBtn;

    [SerializeField]
	private Text questionText;

    void Start()
    {
        trueBtn.onClick.AddListener(delegate{SwitchButtonHandler(0);});
		falseBtn.onClick.AddListener(delegate{SwitchButtonHandler(1);});
    }

    public void Init(string message){
		questionText.text = message;
	}

    void SwitchButtonHandler(int idx)
    {
    }
}
