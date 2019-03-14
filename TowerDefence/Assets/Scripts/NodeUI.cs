using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;
    [SerializeField]
    private Transform root;
    [SerializeField]
    private Button upgradeBtn,sellBtn;

    [SerializeField]
    private Text upgradeBtnText;
    [SerializeField]
    private Text sellBtnText;
    private void Start() {
        root.gameObject.SetActive(false);    
        upgradeBtn.onClick.AddListener(Upgrade);
        sellBtn.onClick.AddListener(Sell);
    }

    private void Upgrade()
    {
        if(target == null)
            return;
        target.UpgradeTurret();
        BuildManager.instance.DiselectNode();
    }

    private void Sell()
    {

    }
    public void SetTarget(Node target)
    {
        this.target = target;
        transform.position = target.transform.position + new Vector3(2,6,0);
        if(target.IsUpgraded == false)
        {
            upgradeBtnText.text  = "Upgrade \n $" + target.Turret.upgradeCost;
            sellBtnText.text = "Sell \n $" + target.Turret.sellingCost;
            upgradeBtn.interactable = true;
        }
        else
        {
            upgradeBtnText.text = "Upgraded";
            sellBtnText.text = "Sell \n $" + target.Turret.sellingCost;
            upgradeBtn.interactable = false;
        }
        root.gameObject.SetActive(true);
    }

    public void Hide()
    {
        root.gameObject.SetActive(false);
    }
}
