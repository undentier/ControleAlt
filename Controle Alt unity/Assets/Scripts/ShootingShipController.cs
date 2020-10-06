using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingShipController : MonoBehaviour
{
    [Header("Shooter References")]
    Rigidbody rb;
    [SerializeField] float shooterSpeed = 5;
    bool shootingPhase = false;
    public float lookRadius = 10f;
    Transform target;
    public float stopDistance = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //target = FindGame
      
    }

    private void Update()
    {

        if (shootingPhase == false)
        {
            rb.velocity = transform.forward * shooterSpeed;
            
            if (Vector3.Distance(transform.position, target.position) > stopDistance)
            {

            }
        }
        else if (shootingPhase)
        {

        }




    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }


}
