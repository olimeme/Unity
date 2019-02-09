using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Player player;

    [SerializeField]
    private double score;

    private void Start() {
    }
    private void Update()
    {
        score = (int)player.transform.position.z;
        scoreText.text = "Score: " + score;
        if((int)score == 5)
            player.SetSpeed(player.GetSpeed() + 5);
    }
}
