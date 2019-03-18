using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text enemies;
    [SerializeField]
    private Text health;
    [SerializeField]
    private Image green;
    [SerializeField]
    private Image red;
    [SerializeField]
    private Player player;
    [SerializeField]
    private WinPanel root;

    void Update()
    {
        var gos = GameObject.FindGameObjectsWithTag("Enemies");
        enemies.text ="Enemies Left:" + gos.Length;
        health.text ="Health:" + player.health;
        if(gos.Length == 0)
        {
            root.InitWin();
            enemies.gameObject.SetActive(false);
            health.gameObject.SetActive(false);
        }
    }
}
