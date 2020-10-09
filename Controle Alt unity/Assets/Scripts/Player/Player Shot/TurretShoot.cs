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

    private bool canShoot;
    private bool stopCoroutine;
    private bool stopCd;
    bool surchauffe;
    int heat;
    public int maxHeat;
    bool fullyCooled;


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
            if (heat == 0)
            {
                fullyCooled = true;
            }
            StartCoroutine(CoolingDown());

            canShoot = false;
            
        }
        
    }

    IEnumerator CoolingDown()
    {
        if (heat > 0)
        {
            heat--;
            stopCd = true;
            yield return new WaitForSeconds(cooldownSpeed);
            stopCd = false;
        }
        
    }

    IEnumerator Fire()
    {
        heat++;
        stopCoroutine = true;
        GameObject bullet = Instantiate(objectBullet, gameObject.transform.position, gameObject.transform.rotation);
        TurretShootAudio.Post(gameObject);
        yield return new WaitForSeconds(fireRate);
        stopCoroutine = false;
    }
}