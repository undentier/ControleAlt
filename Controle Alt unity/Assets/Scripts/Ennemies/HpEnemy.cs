using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpEnemy : MonoBehaviour
{
    public int hp;

    public GameObject fx;

    void Update()
    {
       if (hp <= 0)
        {
            GameObject explosion =  Instantiate(fx, transform.position, transform.rotation);
            Destroy(explosion, 3f);
            Destroy(gameObject);
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet")
        {
            hp -= other.GetComponent<PlayerBullet>().damage;
            Destroy(other.gameObject);
        }
    }

}
