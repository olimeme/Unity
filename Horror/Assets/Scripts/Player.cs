using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigitBody;
    private int Keys = 0;
    public void AddKey()
    {
        Keys++;
    }
    public int GetKeys()
    {
        return Keys;
    }
    private void OnTriggerEnter(Collider other)
    {
    if(other.tag == "Finish")
    {
        //Application.Quit();
        Debug.Log("finish");
    }
    }
}
