using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class LightManager : MonoBehaviour
{
    UduinoManager u;
    public static LightManager Instance;

    public int redLed;
    public int greenLed;
    public int blueLed;

    public bool getHit;

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


    
}
