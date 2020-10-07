using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shieldBar : MonoBehaviour
{
    public Slider ShieldBar;
    public string input;
    public string input2;
    public int MaxShield;
    public int Shield;
    // Start is called before the first frame update
    void Start()
    {
        ShieldBar.maxValue = MaxShield;
        Shield = MaxShield;
    }

    // Update is called once per frame
    void Update()
    {
        ShieldBar.value = Shield;
        
        if (Input.GetKeyUp(input) && Shield > 0)
        {
            Shield -= 1;
            StartCoroutine(CheckCD(Shield));
        }
        if (Input.GetKeyUp(input2) && Shield < MaxShield)
        {
            Shield += 1;
        }
    }

    IEnumerator CheckCD(int baseShield)
    {
        yield return new WaitForSeconds(3);
        if (baseShield == Shield)
        {
            StartCoroutine(CDShield(Shield));
        }
    }

    IEnumerator CDShield(int startShield)
    {

        for (int i = startShield; i < MaxShield; i++)
        {
            Shield += 1;
            yield return new WaitForSeconds(1);
        }
    }
}
