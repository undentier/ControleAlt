using ManagerPlayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShieldInteraction : MonoBehaviour
{
    
    public int AsteroidDmg;
    public int KamikazeDmg;
    public int bulletDamage;
   



    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Asteroid")
        {
            PlayerManager.Instance.shield -= AsteroidDmg;
            Destroy(other.gameObject);
        }

        if (other.tag == "Kamikaze")
        {
            PlayerManager.Instance.shield -= KamikazeDmg;
            
            Destroy(other.gameObject);
        }

        if (other.tag == "Bullet")
        {
            PlayerManager.Instance.shield -= bulletDamage;

            Destroy(other.gameObject);
        }
    }
}
