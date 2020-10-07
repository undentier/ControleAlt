using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldInteraction : MonoBehaviour
{
    public GameObject Bar;
    public int AsteroidDmg;
    public int KamikazeDmg;
    public int bulletDamage;
   



    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Asteroid")
        {
            Bar.GetComponent<shieldBar>().Shield -= AsteroidDmg;
            Destroy(other.gameObject);
        }

        if (other.tag == "Kamikaze")
        {
            Bar.GetComponent<shieldBar>().Shield -= KamikazeDmg;
            
            Destroy(other.gameObject);
        }

        if (other.tag == "Bullet")
        {
            Bar.GetComponent<shieldBar>().Shield -= bulletDamage;

            Destroy(other.gameObject);
        }
    }
}
