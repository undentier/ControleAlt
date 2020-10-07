using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    private Rigidbody bulletRb;

    public int damage;

    void Start()
    {
        bulletRb = gameObject.GetComponent<Rigidbody>();

        bulletRb.AddForce(gameObject.transform.forward * speed);

        Destroy(gameObject, 3f);
    }
}
