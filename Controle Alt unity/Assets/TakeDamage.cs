﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public GameObject Bar;
    public int AsteroidDmg;
    public int KamikazeDmg;
    public int bulletDamage;
    

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Asteroid")
        {
            Bar.GetComponent<HPBar>().HP -= AsteroidDmg;
            Destroy(other.gameObject);
        }

        if (other.tag == "Kamikaze")
        {
            Bar.GetComponent<HPBar>().HP -= KamikazeDmg;
            


            Destroy(other.gameObject);
        }

        if (other.tag == "Bullet")
        {
            Bar.GetComponent<HPBar>().HP -= bulletDamage;

            Destroy(other.gameObject);
        }
    }
}
