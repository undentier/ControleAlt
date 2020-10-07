using ManagerPlayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPBar : MonoBehaviour
{
    public Slider hpBar;
    public string input;
    public string input2;
    


    // Start is called before the first frame update
    void Start()
    {
        hpBar.maxValue = PlayerManager.Instance.maxHp;
        
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.value = PlayerManager.Instance.hp;

        if (Input.GetKeyUp(input) && PlayerManager.Instance.hp > 0)
        {
            PlayerManager.Instance.hp -= 1;
        }
        if (Input.GetKeyUp(input2) && PlayerManager.Instance.hp < PlayerManager.Instance.maxHp)
        {
            PlayerManager.Instance.hp += 1;
        }
    }
}
