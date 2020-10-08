using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
public class Emergency : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (WaveManager.Instance.emergencyState)
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
        }
    }


    void Breach()
    {

    }

    void Electrical()
    {

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
