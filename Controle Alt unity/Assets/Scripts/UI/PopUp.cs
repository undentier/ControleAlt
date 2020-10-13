using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopUp : MonoBehaviour
{
    public float interval = 1f;
    public float startDelay = 0.5f;
    bool currentState = true;
    bool defaultState = true;
    bool isBlinking = false;

    public SpriteRenderer popUpW;

    private void Start()
    {
        //play sound

        popUpW.enabled = defaultState;
        StartBlink();
        Destroy(gameObject, 3);
    }

    public void StartBlink()
    {
        if (isBlinking)
        {
            return;
        }

        if (popUpW != null)
        {
            isBlinking = true;
            InvokeRepeating("ToggleState", startDelay, interval);
        }
    }

    public void ToggleState()
    {
        popUpW.enabled = !popUpW.enabled;
    }
}
