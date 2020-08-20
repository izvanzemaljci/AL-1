using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{   
    public static int batteryCount;
    public static int chipCount;
    public static bool doorCollided;
    public static bool sufficientMemory;
    public static bool sufficientPower;

    private void Start() {
        batteryCount = 0;
        chipCount = 0;
        doorCollided = false;
        sufficientPower = false;
        sufficientPower = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Battery") {
            batteryCount++;
            Destroy(other.gameObject);
        } else if(other.gameObject.name == "Chip") {
            chipCount++;
            Destroy(other.gameObject);
        } 

        if(other.gameObject.name == "Door") {
            doorCollided = true;
        }

        if(doorCollided && chipCount > 0 && batteryCount >= 5){
            sufficientMemory = true;
            sufficientPower = true;
            
            Destroy(other.gameObject); //move in y or change sprite instead and destroy collider?
            
            batteryCount -= 5;
            if(batteryCount < 0)
                batteryCount = 0;
        } else if(doorCollided && chipCount < 1 && batteryCount < 5){
            sufficientMemory = false;
            sufficientPower = true;
        } else if(doorCollided && batteryCount < 5 && chipCount < 1){
            sufficientPower = false;
            sufficientMemory = true;
        } else {
            sufficientPower = false;
            sufficientMemory = false;
        }
        
    }
    
}
