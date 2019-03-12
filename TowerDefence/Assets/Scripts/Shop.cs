using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TurretPriceList
{
    public GameObject prefab;
    public int cost;
    public int upgradeCost;
}

public class Shop : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField]
    private Button standardTurretBtn;
    [SerializeField]
    private Button missileTurretBtn;
    [SerializeField]
    private Button laserTurretBtn;

    [Header("Texts")]
    [SerializeField]
    private Text moneyText;
    [SerializeField]
    private Text livesText;

    [Header("Turrets")]
    [SerializeField]
    private TurretPriceList standardTurret;
    [SerializeField]
    private TurretPriceList missileTurret;
    [SerializeField]
    private TurretPriceList laserTurret;

    private void Start()
    {
        standardTurretBtn.onClick.AddListener(SetStandardTurret);
        missileTurretBtn.onClick.AddListener(SetMissileTurret);
        laserTurretBtn.onClick.AddListener(SetLaserTurret);
    }

    private void Update() {
        moneyText.text = PlayerStats.Money.ToString();
        livesText.text = PlayerStats.Lives.ToString();
    }

    private void SetStandardTurret()
    {
        BuildManager.instance.SetTurretToBuild(standardTurret);
    }
    private void SetMissileTurret()
    {
        BuildManager.instance.SetTurretToBuild(missileTurret);
    }
    private void SetLaserTurret()
    {
        BuildManager.instance.SetTurretToBuild(laserTurret);
    }

    private void OnDestroy() {
        standardTurretBtn.onClick.RemoveAllListeners();
        missileTurretBtn.onClick.RemoveAllListeners();
        laserTurretBtn.onClick.RemoveAllListeners();
    }
}
