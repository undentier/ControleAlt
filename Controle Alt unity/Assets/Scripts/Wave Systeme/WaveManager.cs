using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script fait par Guillaume Rogé et sert à :
/// - Permet de stock tout les variables lier au wave 
/// - Detecte le nombre d'ennemis encore en vie
/// - Gere le lancement des vagues et des spawner
/// </summary>

namespace Manager
{
    public class WaveManager : MonoBehaviour
    {
        public static WaveManager Instance;

        #region Variables

        [Header ("Nombre d'ennemis à spawn")]
        public int numberKamikaze;
        public int numberShoter;

        [Header ("Temps entre chaque spawn d'ennemi")]
        public float timeBtwSpawn;

        [Header ("Temps entre chaque alerte")]
        public float timeBtwEmergency;

        [Header ("Chance qu'une alerte arrive")]
        public float chanceOfEmergency;

        [Header ("Nombre d'ennemi qui spawneront en plus")]
        public int kamikazeAdd;
        public int shoterAdd;

        [Header ("Chance qu'une alerte arrive en plus entre chaque vague")]
        public float EmergencyChanceAdd;

        [Header ("Temps en moins entre chaque vague pour avoir une alerte")]
        public float EmergencyTimeAdd;

        [Header ("Temps d'attente entre chaque wave")]
        public float timeBtwWave;

        [Header("Bool pour le systeme")]
        public bool waveActive = false;
        public bool canSpawn = false;
        public bool start;
        public bool canNextWave = false;

        [Header ("Numéro de la vague actuel")]
        public int numberOfWave;

        [Header ("Ennemi en vie")]
        public List<GameObject> counter = new List<GameObject>();
        #endregion

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
            counter.RemoveAll(list_item => list_item == null);

            StartGame();

            EnnemiDetection();

            StartWave();
        }


        void StartGame()
        {
            if (Input.GetButtonDown("Start"))
            {
                if (start == false)
                {
                    start = true;
                }
            }
        }

        void EnnemiDetection()
        {
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

        void StartWave()
        {
            if (start == true)
            {
                if (waveActive == false)
                {
                    waveActive = true;
                    StartCoroutine(ActiveWave());
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
