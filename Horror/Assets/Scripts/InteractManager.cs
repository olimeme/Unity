using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractManager : MonoBehaviour
{
    [SerializeField]
    private float interactDistance;

    [SerializeField]
    private Transform camPos;

    [SerializeField]
    private LayerMask layer;    
    
    [SerializeField]
    private FlashLight flashLight;
    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = new Ray(camPos.position,camPos.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,interactDistance))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(hit.collider.tag == "Battery")
                {
                    flashLight.Charge(1.5f);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    
    }
}
