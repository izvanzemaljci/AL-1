using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChipCountDisplay : MonoBehaviour
{
    public Text chipText;
    
    void Update()
    {
        chipText.text = CollisionController.chipCount + "/3";
    }
}