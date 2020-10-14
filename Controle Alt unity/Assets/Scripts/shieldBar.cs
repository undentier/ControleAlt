using ManagerPlayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shieldBar : MonoBehaviour
{
    public Slider ShieldBar;
    public string input;
    public string input2;
    
    // Start is called before the first frame update
    void Start()
    {
        ShieldBar.maxValue = PlayerManager.Instance.maxShield;      
    }

    // Update is called once per frame
    void Update()
    {
        ShieldBar.value = PlayerManager.Instance.shield;
        
        if (Input.GetKeyUp(input) && PlayerManager.Instance.shield > 0)
        {
            PlayerManager.Instance.shield -= 3;
            //StartCoroutine(CheckCD(Shield));
        }
        if (Input.GetKeyUp(input2) && PlayerManager.Instance.shield < PlayerManager.Instance.maxShield)
        {
            PlayerManager.Instance.shield += 1;
        }
    }


    //IEnumerator CheckCD(int baseShield)
    //{
    //    yield return new WaitForSeconds(3);
    //    if (baseShield == Shield)
    //    {
    //        StartCoroutine(CDShield(Shield));
    //    }
    //}

    //IEnumerator CDShield(int startShield)
    //{

    //    for (int i = startShield; i < MaxShield; i++)
    //    {
    //        Shield += 1;
    //        yield return new WaitForSeconds(1);
    //    }
    //}
}
