using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBulletController : MonoBehaviour
{
    public float speed;


    public int damage;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }
}
