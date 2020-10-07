using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldInteraction : MonoBehaviour
{
    public GameObject Bar;
    public int AsteroidDmg;
    public int KamikazeDmg;
    public int bulletDamage;

    [Space(10)]
    [Header("Audio")]
    public AK.Wwise.Event laserShieldAudio;
    public AK.Wwise.Event KamikazShieldAudio;


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Asteroid")
        {
            Bar.GetComponent<shieldBar>().Shield -= AsteroidDmg;
            KamikazShieldAudio.Post(gameObject);
            Destroy(other.gameObject);
        }

        if (other.tag == "Kamikaze")
        {
            Bar.GetComponent<shieldBar>().Shield -= KamikazeDmg;
            KamikazShieldAudio.Post(gameObject);
            Destroy(other.gameObject);
        }

        if (other.tag == "Bullet")
        {
            Bar.GetComponent<shieldBar>().Shield -= bulletDamage;
            laserShieldAudio.Post(gameObject);
            Destroy(other.gameObject);
        }
    }
}
