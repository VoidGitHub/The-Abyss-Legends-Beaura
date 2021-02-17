using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
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
        transform.position = target.position + offset;
    }




}