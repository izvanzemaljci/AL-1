using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menu;
    
    void Start() {
        menu.SetActive(CollisionController.doorCollided);
    }

    void Update(){
        menu.SetActive(CollisionController.doorCollided);
    }
}
