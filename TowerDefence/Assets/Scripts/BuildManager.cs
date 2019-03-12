using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretPriceList turretToBuild;
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
    }
}
