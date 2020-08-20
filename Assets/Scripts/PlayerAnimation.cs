using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    int lastDirection;

    public string[] staticDirections = {"Static Top", "Static Top Left", 
                                        "Static Left", "Static Bottom Left", 
                                        "Static Bottom", "Static Bottom Right", 
                                        "Static Right", "Static Top Right"};
    
    public string[] moveDirections = {"Move Top", "Move Top Left", 
                                        "Move Left", "Move Bottom Left", 
                                        "Move Bottom", "Move Bottom Right", 
                                        "Move Right", "Move Top Right"};
    
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 _direction)
    {
        string[] directions = null;
        if(_direction.magnitude < 0.01)
        {
            directions = staticDirections;
        } else {
            directions = moveDirections;
            lastDirection = DirectionToIndex(_direction);
        }

        anim.Play(directions[lastDirection]);
    }

    private int DirectionToIndex(Vector2 _direction)
    {
        Vector2 normalizedDirection = _direction.normalized;
        float step = 360/8;
        float offset = step/2;
        float angle = Vector2.SignedAngle(Vector2.up, normalizedDirection);

        angle += offset;
        if(angle < 0)
        {
            angle += 360;
        }

        float stepCount = angle/step;
        return Mathf.FloorToInt(stepCount);
    }
}
