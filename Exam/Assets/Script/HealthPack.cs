using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private Player player;
    
    public void Heal()
    {
        player.health += health;
    }
    public int Health
    {
        get{return health;}
        set{health = value;}
    }
}
