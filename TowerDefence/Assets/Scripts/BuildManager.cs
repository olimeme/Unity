using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretPriceList turretToBuild;

    private Node selectedNode;
    [SerializeField]
    private NodeUI nodeUI;
    private void Awake() {
        if(instance != null)
        {
            Debug.Log("More than on build manager on scene");
            return;
        }
        instance = this;
    }

    public TurretPriceList GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(TurretPriceList turret)
    {
        turretToBuild = turret;
        nodeUI.Hide();
    }

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DiselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DiselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
}
