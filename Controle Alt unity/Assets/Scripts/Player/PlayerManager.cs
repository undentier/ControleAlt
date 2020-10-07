using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ManagerPlayer
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;

        public GameObject[] turret;

        public int Hp;


        void Start()
        {
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
