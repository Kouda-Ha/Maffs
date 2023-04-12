using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MathsGame : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            GetComponent<GrabCamera>().GrabCameraFrom(col.gameObject);
        }
    }
}
