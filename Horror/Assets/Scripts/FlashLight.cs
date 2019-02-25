using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    [SerializeField]
    private Light flashlight;
    [SerializeField]
    private Image indicator;
    private float maxBatteryLife;
    private float curBatteryLife;
    [SerializeField]
    private float lightDrain = 0.1f;
    void Start()
    {
        maxBatteryLife = flashlight.intensity;
        curBatteryLife = maxBatteryLife;
    }

    void Update()
    {
        if(flashlight.enabled == true)
        {
            if(curBatteryLife > 0)
            {
                curBatteryLife-=lightDrain*Time.deltaTime;
                var indicatorWidth = curBatteryLife/maxBatteryLife;
                flashlight.intensity = curBatteryLife;
                var indicatorScale = indicator.transform.localScale;
                indicator.transform.localScale = new Vector3(indicatorWidth,indicatorScale.y,indicatorScale.z);
            }
            else
            {
                curBatteryLife = 0;
                flashlight.enabled = false;
            }
        }
        else
        {
            
        }
        if(Input.GetKeyDown(KeyCode.F) && curBatteryLife > 0)
        {
            if(flashlight.enabled == true)
                flashlight.enabled = false;
            else 
                flashlight.enabled = true;
        }
    }

    public bool Charge(float value)
    {
        if((curBatteryLife+value)<maxBatteryLife)
        {
            curBatteryLife+=value;
            return true;
        }
        else 
            return false;
    }
}
