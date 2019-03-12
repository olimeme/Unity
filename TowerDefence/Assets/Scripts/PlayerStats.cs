using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    [SerializeField]
    private int startMoney;
    [SerializeField]
    private int lives;
    private void Start()
    {
        Money = startMoney;
        Lives = lives;
    }

    private void Update()
    {
        if(Lives == 0)
        {
            lives = 0;
            return;
        }
    }
}
