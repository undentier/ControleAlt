using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    public string input;
    public float fireRate;

    public GameObject objectBullet;

    private bool canShoot;
    private bool stopCoroutine;


    [Space(10)]
    [Header("Audio")]
    public AK.Wwise.Event TurretShootAudio;

    void Start()
    {
        canShoot = false;
    }

    
    void Update()
    {
        if (Input.GetButton(input))
        {
            canShoot = true;
            
        }
        else
        {
            canShoot = false;
        }

        if (canShoot == true)
        {
            if (stopCoroutine == false)
            {
                StartCoroutine(Fire());
            }
        }
    }


    IEnumerator Fire()
    {
        stopCoroutine = true;
        GameObject bullet = Instantiate(objectBullet, gameObject.transform.position, gameObject.transform.rotation);
        TurretShootAudio.Post(gameObject);
        yield return new WaitForSeconds(fireRate);
        stopCoroutine = false;
    }

}
