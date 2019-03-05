using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController rigidbody;
    
    public bool isAlive = true;
    public void KillPlayer()
    {
        rigidbody.enabled = false;
        isAlive = false;
    }
}
