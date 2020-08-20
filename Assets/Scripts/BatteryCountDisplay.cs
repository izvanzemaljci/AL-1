using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryCountDisplay : MonoBehaviour
{
    public Text batteryText;
    
    void Update()
    {
        batteryText.text = CollisionController.batteryCount + "/5";
    }
}
