using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

public class Spawner : MonoBehaviour
{
    #region Variable
    [Header ("SpawnPoint des kamikazes")]
    public GameObject[] kamikazeSpawnerPoint;

    [Header ("SpawnPoint des shooters")]
    public GameObject[] shooterSpawnPoint;

    [Header ("Prefab des ennemis")]
    public GameObject kamikazeObject;
    public GameObject shoterObject;

    private int kamikaze;
    private int shoter;

    private bool canCoroutine = true;

    private bool kamikazeFinish;
    private bool shooterFinish;
    #endregion

    void Update()
    {
        GestionLancementWave();

        EndOfWave();
    }

    void EndOfWave()
    {
        if (shooterFinish == true)
        {
            if (kamikazeFinish == true)
            {
                shooterFinish = false;
                kamikazeFinish = false;

                WaveManager.Instance.canSpawn = false;
                WaveManager.Instance.canNextWave = true;

                canCoroutine = true;
            }
        }
    }

    void GestionLancementWave()
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

                    StartCoroutine(SpawnerKamikaze());

                    StartCoroutine(SpawnerShooter());
                }
            }
        }
    }


    IEnumerator SpawnerKamikaze()
    {
        for (int i = 0; i < kamikaze ; i++)
        {
            int wichPointK = Random.Range(0, kamikazeSpawnerPoint.Length);

            GameObject kamikazeShip = Instantiate(kamikazeObject, kamikazeSpawnerPoint[wichPointK].transform.position, transform.rotation);
            WaveManager.Instance.counter.Add(kamikazeShip);

            yield return new WaitForSeconds(WaveManager.Instance.timeBtwSpawn);
        }

        kamikazeFinish = true;
    }

    IEnumerator SpawnerShooter()
    {
        for (int i = 0; i < shoter; i++)
        {
            int wichPointS = Random.Range(0, shooterSpawnPoint.Length);

            GameObject shooterShip = Instantiate(shoterObject, shooterSpawnPoint[wichPointS].transform.position, transform.rotation);
            WaveManager.Instance.counter.Add(shooterShip);

            yield return new WaitForSeconds(WaveManager.Instance.timeBtwSpawn);
        }

        shooterFinish = true;

    }

}
