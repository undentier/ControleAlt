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



    [Space(10)]
    [Header("Audio")]
    public AK.Wwise.Event laserDamageAudio;
    public AK.Wwise.Event explosionDamageAudio;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Asteroid")
        {
            PlayerManager.Instance.hp -= AsteroidDmg;
            explosionDamageAudio.Post(gameObject);

            Destroy(other.gameObject);
        }

        if (other.tag == "Kamikaze")
        {
            PlayerManager.Instance.hp -= KamikazeDmg;
            

            GameObject explosion = Instantiate(fxExplosion, transform.position, transform.rotation);
            explosionDamageAudio.Post(gameObject);
            Destroy(explosion, 3f);
      
            Destroy(other.gameObject);
        }

        if (other.tag == "Bullet")
        {
            PlayerManager.Instance.hp -= bulletDamage;
            laserDamageAudio.Post(gameObject);

            Destroy(other.gameObject);
        }
    }
}
