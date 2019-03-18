using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ShootController : MonoBehaviour
{
    [SerializeField]
    private float interactDistance;

    [SerializeField]
    private Transform camPos;

    [SerializeField]
    private Image interactImage;

    [SerializeField]
    private Transform bulletHitPrefab;
    [SerializeField]
    private Player player;

    void Start()
    {
       interactImage.gameObject.SetActive(false); 
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,interactDistance))
        {
            interactImage.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                if(hit.collider.tag == "Wall")
                {
                    var shoot = Instantiate(bulletHitPrefab,hit.point,Quaternion.identity);
                }
                else if(hit.collider.tag == "Obstacles")
                {
                    var obst = hit.collider.GetComponent<Obstale>();
                    obst.Hit();
                    Debug.Log(hit.collider.name);
                }
                else if(hit.collider.tag == "Enemies")
                {
                    var enemy = hit.collider.GetComponent<Enemy>();
                    enemy.Hit();
                    Debug.Log(hit.collider.name);
                }
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                if(hit.collider.tag == "MedKit")
                {
                    var pack = hit.collider.GetComponent<HealthPack>();
                    if(player.health+pack.Health < 100)
                    {
                        pack.Heal();
                        Destroy(hit.collider.gameObject);
                    }
                    else
                        Debug.Log("Cant use medkit!");
                }
            }
        }
        else 
            interactImage.gameObject.SetActive(false);
    
    }
}

