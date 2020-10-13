using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixEventsManager : MonoBehaviour
{
    EventManager eventManager;

    bool longInput1 = false;
    bool longInput2 = false;
    float downTimeJ1, upTimeJ1, pressTimeJ1 = 0;
    float downTimeJ2, upTimeJ2, pressTimeJ2 = 0;
    float countDown = 3f;
    bool readyJ1 = false;
    bool readyJ2 = false;


    private void Start()
    {
        eventManager = EventManager.instance;
    }

    private void Update()
    {
        #region Fuite Solution
        //comment résoudre le problème de la fuite
        if (eventManager.fuiteActive)
        {
            //j1
            if (Input.GetKeyDown(KeyCode.V) && !readyJ1)  
            {
                downTimeJ1 = Time.time;
                pressTimeJ1 = downTimeJ1 + countDown;
                readyJ1 = true;
            }
            if (Input.GetKeyUp(KeyCode.V))
            {
                Debug.Log("Too soon boy");
                readyJ1 = false;
            }
            if(Time.time >= pressTimeJ1 && readyJ1 == true)
            {
                readyJ1 = false;
                longInput1 = true;
                Debug.Log("Allez laaaaaaaaaaaa je veux bouffer");
            }

            //j2
            if (Input.GetKeyDown(KeyCode.V) && !readyJ2)
            {
                downTimeJ2 = Time.time;
                pressTimeJ2 = downTimeJ2 + countDown;
                readyJ2 = true;
            }
            if (Input.GetKeyUp(KeyCode.V))
            {
                Debug.Log("Too soon boy");
                readyJ2 = false;
            }
            if (Time.time >= pressTimeJ2 && readyJ2 == true)
            {
                readyJ2 = false;
                longInput2 = true;
                Debug.Log("Allez laaaaaaaaaaaa je veux bouffer le retour remastered");
            }

            //epic win
            if(longInput1 && longInput2)
            {
                eventManager.fuiteActive = false;
                Debug.Log("g envie de chialer");
            }        
        }
        #endregion
    }


}
