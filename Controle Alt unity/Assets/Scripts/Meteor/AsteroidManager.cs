using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyBoundary
{
    public float miniZ, maxiZ;
}

public class AsteroidManager : MonoBehaviour
{
    [Header("References")]
    public EnemyBoundary eBoundary;
    [SerializeField] GameObject[] asteroids;
    [SerializeField] GameObject shooter;

    //[Space]
    //[Header("Stats")]
   // public float timer = 2f; //le fameux timer pour varier les spawns, il peut être modulable pour augmenter la difficulté mais vu qu'on part sur un système de vague jsp pourquoi j'écris ça

    

    private void Start()
    {
        Invoke("Spawner", WaveManager.Instance.timer);
    }


    void Spawner()
    {

        //ici je crée juste une range dans l'axe Z pour être sûr que les enemis spawnent pas en dehors de la cam
        float pos_Z = Random.Range(eBoundary.miniZ, eBoundary.maxiZ);
        Vector3 temp = transform.position;
        temp.z = pos_Z;

        if (Random.Range(0, 2) > 0)
        {
            Instantiate(asteroids[Random.Range(0, asteroids.Length)], temp, Quaternion.identity);
        }
        /*else
        {
            Instantiate(shooter, temp, Quaternion.Euler(0f, -90f, 0f));
        }*/

        Invoke("Spawner", WaveManager.Instance.timer);
    }
    
}
