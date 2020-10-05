using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    [Header("Enemy Attributes")]
    [SerializeField] float speed = 5f;
    [SerializeField] float rotateSpeed = 50f;
    [SerializeField] bool canRotate;
    bool canMove = true;

    [Space]
    [Header("Enemy Stats")]
    public float bound_X = -11f;

    private void Start()
    {
        if (canRotate)
        {
            if (Random.Range(0, 2) > 0)
            {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
                rotateSpeed *= -1f;
            }
            else
            {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed = 20f);
            }
        }
    }

    private void Update()
    {
        MoveEnemy();
        RotateEnemy();
    }

    void MoveEnemy()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            if (temp.x < bound_X)
                Destroy(gameObject, 1);


        }
    }

    void RotateEnemy()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime), Space.World);
        }
    }

    private void DestroyEnemy()
    {

        Destroy(gameObject, 0.1f);
    }
}
