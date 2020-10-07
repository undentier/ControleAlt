using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [Space]
    [Header("Bullet References")]
    Transform player;
    

    [Space]
    [Header("Bullet Stats")]
    [SerializeField] float bulletSpeed;
    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(gameObject, 10);   

        rb = GetComponent<Rigidbody>();
        moveDirection = (player.transform.position - transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);

    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            //créer des problèmes / retire des points de vie
            Destroy(gameObject);
        }
    }
}
