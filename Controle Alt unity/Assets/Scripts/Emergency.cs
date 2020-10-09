using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using ManagerPlayer;
using UnityEngine.UI;

public class Emergency : MonoBehaviour
{

    public int breachDamage;
    bool canTakeDamage = true;
    public float cd;
    public Image panel;
    public float opacity;
    Color myColor;
    Color baseColor;
    // Start is called before the first frame update
    void Start()
    {
        myColor = panel.color;
        baseColor = panel.color;
        myColor.a = opacity;
    }

    // Update is called once per frame
    void Update()
    {
        if (WaveManager.Instance.isInEmergency)
        {
            switch (WaveManager.Instance.emergencyIndex)
            {
                case 1:
                    Breach();
                    break;
                case 2:
                    Electrical();
                    break;
                case 3:
                    TurretBroken();
                    break;
                case 4:
                    Overheat();
                    break;
                case 5:
                    VideoSignal();
                    break;
                default:
                    break;
            }
            WaveManager.Instance.isInEmergency = false;
        }

        if (Input.GetButton("Electrical1") && Input.GetButton("Electrical2"))
        {
            panel.color = baseColor;
        }
        if (EventManager.instance.fuiteActive)
            Breach();
    }


    void Breach()
    {
        if (canTakeDamage)
        {
            PlayerManager.Instance.shield--;
            PlayerManager.Instance.hp--;
            StartCoroutine(BreachDamageCd());
        }
        
    }

    IEnumerator BreachDamageCd()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(cd);
        canTakeDamage = true;
    }

    void Electrical()
    {
        panel.color = myColor;
        
    }

    void TurretBroken()
    {
        
    }

    void Overheat()
    {
        
    }

    void VideoSignal()
    {
        
    }

    
}
