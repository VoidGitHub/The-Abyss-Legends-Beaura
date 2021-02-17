using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    public float Health = 100;
    public float Damage = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetButtonDown("Fire1")) {
            
            Health -= Damage;
       }
       if (Health <= 0) {
           Destroy(gameObject);
       }
    }

}

