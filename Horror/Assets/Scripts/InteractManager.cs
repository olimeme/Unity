using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractManager : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private float interactDistance;

    [SerializeField]
    private Transform camPos;

    [SerializeField]
    private FlashLight flashLight;
    
    [SerializeField]
    private Image interactImage;
    void Start()
    {
       interactImage.gameObject.SetActive(false); 
    }

    void Update()
    {
        Ray ray = new Ray(camPos.position,camPos.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,interactDistance,layerMask))
        {
            interactImage.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(hit.collider.tag == "Battery")
                {
                    if(flashLight.Charge(1.5f))
                        Destroy(hit.collider.gameObject);
                    else 
                        return;
                }
                else if(hit.collider.tag == "Candle")
                {//получаем скрипт  Candle  у свечи
                    var candle = hit.collider.GetComponent<Candle>();;
                    candle.SetActive();
                }
                else if(hit.collider.tag == "Key")
                {
                    var key = hit.collider.GetComponent<Key>();
                    key.PickUp();
                }
            }
            else 
                interactImage.gameObject.SetActive(false);
        }
    
    }
}
