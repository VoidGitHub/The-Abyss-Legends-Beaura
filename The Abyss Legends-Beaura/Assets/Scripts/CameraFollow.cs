using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
 
     public Transform target;
 
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
 
    void Start()
    {
       
                

    }

    // Update is called once per frame
    void LateUpdate()
    {
           Follow();
    }
    public void Follow() {
                 transform.position = target.position + offset;
    }

   


}


