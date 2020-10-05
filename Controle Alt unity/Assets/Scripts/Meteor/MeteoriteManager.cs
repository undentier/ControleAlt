using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyBoundary
{
    public float miniZ, maxiZ;
}

public class MeteoriteManager : MonoBehaviour
{
    [Header("References")]
    public EnemyBoundary eBoundary;
    [SerializeField] GameObject[] asteroids;

    [Space]
    [Header("Stats")]
    public float timer = 2f;

    private void Start()
    {
        Invoke("Spawner", timer);
    }


    void Spawner()
    {
        float pos_Z = Random.Range(eBoundary.miniZ, eBoundary.maxiZ);
        Vector3 temp = transform.position;
        temp.z = pos_Z;

        if (Random.Range(0, 2) > 0)
        {
            Instantiate(asteroids[Random.Range(0, asteroids.Length)], temp, Quaternion.identity);
        }

        Invoke("Spawner", timer);
    }
    
}
