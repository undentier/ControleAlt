using ManagerPlayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShieldInteraction : MonoBehaviour
{
    
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
            PlayerManager.Instance.shield -= AsteroidDmg;
            KamikazShieldAudio.Post(gameObject);
            Destroy(other.gameObject);
        }

        if (other.tag == "Kamikaze")
        {
            PlayerManager.Instance.shield -= KamikazeDmg;
            
            KamikazShieldAudio.Post(gameObject);
            Destroy(other.gameObject);
        }

        if (other.tag == "Bullet")
        {
            PlayerManager.Instance.shield -= bulletDamage;

            laserShieldAudio.Post(gameObject);
            Destroy(other.gameObject);
        }
    }
}
