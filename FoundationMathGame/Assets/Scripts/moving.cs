using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Moving script. This is for the enemy model to do their walking animation
// when they move around the navmesh, and stop the animation when they aren't moving.
public class moving : MonoBehaviour
{
    public RandomMovement rmScript;
    public Animator Anim;

    // Update is called once per frame
    void Update()
    {
        // If moving, set walking animation to true
        if(rmScript.isMoving)
        {
            Anim.SetBool("isWalking", true);
        }
        // If not moving, set walking animation to false
        else if(rmScript.isMoving == false)
        {
            Anim.SetBool("isWalking", false);
        }
    }
}
