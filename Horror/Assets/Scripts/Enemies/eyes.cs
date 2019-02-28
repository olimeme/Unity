using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyes : MonoBehaviour
{
    [SerializeField]
    private Enemy idiSudaRodnoi;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            idiSudaRodnoi.CheckSight();
            Debug.Log(other.gameObject.name);
        }        
    }
}
