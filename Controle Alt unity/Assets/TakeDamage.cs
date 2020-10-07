using ManagerPlayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TakeDamage : MonoBehaviour
{
    
    public int AsteroidDmg;
    public int KamikazeDmg;
    public int bulletDamage;

    public GameObject fxExplosion;
    

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Asteroid")
        {
            PlayerManager.Instance.hp -= AsteroidDmg;
            Destroy(other.gameObject);
        }

        if (other.tag == "Kamikaze")
        {
            PlayerManager.Instance.hp -= KamikazeDmg;
            

            GameObject explosion = Instantiate(fxExplosion, transform.position, transform.rotation);
            Destroy(explosion, 3f);
      
            Destroy(other.gameObject);
        }

        if (other.tag == "Bullet")
        {
            PlayerManager.Instance.hp -= bulletDamage;

            Destroy(other.gameObject);
        }
    }
}
