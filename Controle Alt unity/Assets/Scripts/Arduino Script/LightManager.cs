using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class LightManager : MonoBehaviour
{
    UduinoManager u;
    public static LightManager Instance;

    [Header ("Pins")]
    public int redLed;
    public int greenLed;
    public int blueLed;

    [Space]
    public bool getHit;
    public bool finishWave;
    public bool powerOff;

    void Start()
    {
        Singleton();

        UduinoManager.Instance.pinMode(redLed, PinMode.Output);
        UduinoManager.Instance.pinMode(greenLed, PinMode.Output);
        UduinoManager.Instance.pinMode(blueLed, PinMode.Output);
    }

    
    void Update()
    {
        if (getHit == true)
        {
            getHit = false;
            StartCoroutine(GetHit());
        }

        if (finishWave == true)
        {
            finishWave = false;
            StartCoroutine(FinishWave());
        }

        if (powerOff == true)
        {
            //PowerOff();
        }
    }

    void Singleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void ColorRGB(int redValue, int greenValue, int blueValue)
    {
        UduinoManager.Instance.digitalWrite(redLed, redValue);
        UduinoManager.Instance.digitalWrite(greenLed, greenValue);
        UduinoManager.Instance.digitalWrite(blueLed, blueValue);
    }


    IEnumerator GetHit()
    {
        for (int i = 0; i < 5; i++)
        {
            ColorRGB(255, 0, 0);
            yield return new WaitForSeconds(0.3f);
            ColorRGB(0, 0, 0);
            yield return new WaitForSeconds(0.3f);
        }
    }

    IEnumerator FinishWave()
    {
        ColorRGB(0, 255, 0);
        yield return new WaitForSeconds(5f);
        ColorRGB(0, 0, 0);
    }

    void PowerOff()
    {
       // if ()
    }
    
}
