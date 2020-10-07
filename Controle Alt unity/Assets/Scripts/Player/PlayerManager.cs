using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ManagerPlayer
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;

        public GameObject[] turret;

        public int hp;
        public int maxHp;
        public int shield;
        public int maxShield;


        void Start()
        {
            hp = maxHp;
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }


        void Update()
        {

        }
    }
}
