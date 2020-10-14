using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomActivation : MonoBehaviour
{
    public ParticleSystem ps;

    void Start()
    {
        StartCoroutine(CoolDown());
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(Random.Range(1, 10));
        ps.Stop();
        yield return new WaitForSeconds(Random.Range(1, 10));
        ps.Play();
        StartCoroutine(CoolDown());
    }
}
