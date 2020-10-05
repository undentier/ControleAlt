using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMouvement : MonoBehaviour
{
    public float speed;

    private Rigidbody shipRb;


    void Start()
    {
        shipRb = gameObject.GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Up"))
        {
            shipRb.velocity = speed * Vector3.left * Time.fixedDeltaTime;
        }

        if (Input.GetButtonUp("Up"))
        {
            shipRb.velocity = Vector3.zero;
        }


        if (Input.GetButtonDown("Down"))
        {
            shipRb.velocity = speed * Vector3.right * Time.fixedDeltaTime;
        }

        if (Input.GetButtonUp("Down"))
        {
            shipRb.velocity = Vector3.zero;
        }
    }
}
