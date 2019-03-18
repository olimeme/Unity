using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstale : MonoBehaviour
{
    [SerializeField]
    private int health;

    public void Hit()
    {
        health-=10;
    }
    private void Update() {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
