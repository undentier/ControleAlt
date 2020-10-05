using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class Teste : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.pinMode(2, PinMode.Output);
        StartCoroutine(LoopArduino());
    }

    IEnumerator LoopArduino()
    {
        yield return null;
    }
}
