using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    public string input;
    public float fireRate;
    public float cooldownSpeed;
    public int turretIndex;

    public GameObject objectBullet;

    public Transform shootPoint;

    private bool canShoot;
    private bool stopCoroutine;
    private bool stopCd;
    bool surchauffe;
    public int heat;
    public int maxHeat;
    public bool fullyCooled = true;
    bool coroutineIsRunning;

    [Space(10)]
    [Header("Audio")]
    public AK.Wwise.Event TurretShootAudio;

    void Start()
    {
        canShoot = false;
    }

    
    void Update()
    {

        if (heat <= maxHeat  && fullyCooled)
        {
            if (Input.GetButton(input))
            {
                canShoot = true;

            }
            if (canShoot == true)
            {
                if (stopCoroutine == false)
                {
                    StartCoroutine(Fire());
                }
            }
            if (canShoot == false)
            {
                if (stopCd == false)
                {
                    StartCoroutine(CoolingDown());
                } 
            }
        }
        else
        {
            fullyCooled = false;
            if (coroutineIsRunning == false)
            {
                StartCoroutine(CoolingDown());
            }
            
            if (heat == 0)
            {
                fullyCooled = true;
            }
            canShoot = false;
            
        }
        
    }

    IEnumerator CoolingDown()
    {
        if (heat > 0)
        {
            coroutineIsRunning = true;
            heat -= 1;
            Debug.Log("okidoki");
            stopCd = true;
            yield return new WaitForSeconds(cooldownSpeed);
            stopCd = false;
            coroutineIsRunning = false;
        }
        
    }

    IEnumerator Fire()
    {
        heat++;
        stopCoroutine = true;
        GameObject bullet = Instantiate(objectBullet, shootPoint.transform.position, shootPoint.transform.rotation);
        TurretShootAudio.Post(gameObject);
        yield return new WaitForSeconds(fireRate);
        stopCoroutine = false;
    }
}