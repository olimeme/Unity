using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private GameObject turretObject;
    private TurretPriceList turret;
    [SerializeField]
    private Color hoverColor;
    private Color startColor;
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        startColor = renderer.material.color;
    }

    private void OnMouseEnter()
    {
        var turretToBuild = BuildManager.instance.GetTurretToBuild();
        if(turretToBuild == null)
            return;

        if(PlayerStats.Money < turretToBuild.cost)
            renderer.material.color = Color.red;
        else
            renderer.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        renderer.material.color = startColor;
    }

    private void OnMouseDown() {
        if(turret !=null)
        {
            Debug.Log("Cant build here");
            return;
        }    
        turret = BuildManager.instance.GetTurretToBuild();
        
        if(turret == null)
        {
            return;
        }

        if(PlayerStats.Money < turret.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        if(turret != null)
        {
            turretObject = Instantiate(turret.prefab,transform.position + new Vector3(0,0.5f,0),transform.rotation);
            PlayerStats.Money -= turret.cost;
        } 
    }
}
