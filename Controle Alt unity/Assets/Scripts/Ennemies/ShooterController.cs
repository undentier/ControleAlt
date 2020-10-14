using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [SerializeField] float speed;

    //l'axe ou il s'arrête
    public float bound_X;

    public Transform attackPoint;
    bool canShoot = false;
    public GameObject shooterBullet;

    float timeBtwShots;
    public float startTimeBtwShots;


    private void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    private void Update()
    {
        MoveEnemy();

        if (canShoot && timeBtwShots <= 0)
        {
            Debug.Log("ah bah on tire hein");
            Instantiate(shooterBullet, attackPoint.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void MoveEnemy()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;

        //en gros ici on check sa position en x (à l'endroit où on veut qu'il s'arrête)
        if (temp.x < bound_X)
        {
            speed = 0;
            canShoot = true;
        }

    }

}
