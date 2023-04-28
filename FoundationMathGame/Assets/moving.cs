using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public RandomMovement rmScript;
    public Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rmScript.isMoving)
        {
            Anim.SetBool("isWalking", true);
        }
        else if(rmScript.isMoving == false)
        {
            Anim.SetBool("isWalking", false);
        }
    }
}
