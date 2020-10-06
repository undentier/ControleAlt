using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class WaveManager : MonoBehaviour
    {
        public static WaveManager Instance;

        public List<GameObject> counter = new List<GameObject>();

        public bool waveActive = false;
        public bool canSpawn = false;
        public bool start;
        public bool canNextWave = false;

        public int numberKamikaze;
        public int numberShoter;

        public int numberOfWave;

        public float timeBtwSpawn;

        public float timeBtwEmergency;
        public float chanceOfEmergency;

        public int kamikazeAdd;
        public int shoterAdd;

        public float EmergencyChanceAdd;
        public float EmergencyTimeAdd;

        public float timeBtwWave;

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
            if (Input.GetButtonDown("Fire"))
            {
                if (start == false)
                {
                    start = true;
                }
            }

            counter.RemoveAll(list_item => list_item == null);


            if (start == true)
            {
                if (waveActive == false)
                {
                    waveActive = true;
                    StartCoroutine(ActiveWave());
                }
            }

            if (counter.Count == 0)
            {
                if (start == true)
                {
                    if (waveActive == true)
                    {
                        if (canNextWave == true)
                        {
                            canNextWave = false;
                            waveActive = false;
                        }
                    }
                }
            }
        }

        IEnumerator ActiveWave()
        {
            yield return new WaitForSeconds(timeBtwWave);

            numberOfWave += 1;

            numberKamikaze += kamikazeAdd;
            numberShoter += shoterAdd;

            canSpawn = true;
        }
    }
}
