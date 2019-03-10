using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
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

    [SerializeField]
    private Player player;

    [SerializeField]
    private GameOverPanel gameoverMenu;

    const int maxKeyAmount = 3; 
    void Start()
    {
       interactImage.gameObject.SetActive(false); 
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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
                else if(hit.collider.tag == "Key")
                {
                    var key = hit.collider.GetComponent<Key>();
                    key.PickUp();
                    player.AddKey();
                    if(player.GetKeys() == maxKeyAmount)
                    {
                        Application.Quit();
                        Debug.Log("GAMEOVER");
                        gameoverMenu.InitWin();
                    }
                }
            }
        }
        else 
            interactImage.gameObject.SetActive(false);
    
    }
}
