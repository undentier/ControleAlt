using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnerPoint;

    public bool canCoroutine = true;


    private int kamikaze;
    private int shoter;


    public GameObject kamikazeObject;
    public GameObject shoterObject;
       
    void Start()
    {

    }


    void Update()
    {
        if (WaveManager.Instance.start == true)
        {
            if (WaveManager.Instance.canSpawn == true)
            {
                if (canCoroutine == true)
                {
                    canCoroutine = false;

                    kamikaze = WaveManager.Instance.numberKamikaze;
                    shoter = WaveManager.Instance.numberShoter;

                    StartCoroutine(SpawnerSysteme());
                }
            }
        }
    }

    IEnumerator SpawnerSysteme()
    {
        for (int i = 0; i < (kamikaze+shoter) ; i++)
        {
            int wichPoint = Random.Range(0, spawnerPoint.Length);

            GameObject ship = Instantiate(kamikazeObject, spawnerPoint[wichPoint].transform.position, transform.rotation);
            WaveManager.Instance.counter.Add(ship);

            yield return new WaitForSeconds(WaveManager.Instance.timeBtwSpawn);
        }

        canCoroutine = true;

        WaveManager.Instance.canSpawn = false;
        WaveManager.Instance.canNextWave = true;
    }

}
