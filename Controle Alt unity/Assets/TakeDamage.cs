using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public GameObject Bar;
    public int AsteroidDmg;
    public int KamikazeDmg;
    public int bulletDamage;

    public GameObject fxExplosion;
    

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

            GameObject explosion = Instantiate(fxExplosion, transform.position, transform.rotation);
            Destroy(explosion, 3f);
      
            Destroy(other.gameObject);
        }

        if (other.tag == "Bullet")
        {
            Bar.GetComponent<HPBar>().HP -= bulletDamage;

            Destroy(other.gameObject);
        }
    }
}
