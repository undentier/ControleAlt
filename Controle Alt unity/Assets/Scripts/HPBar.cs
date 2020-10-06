using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider hpBar;
    public string input;
    public string input2;
    public int MaxHP;
    public int HP;


    // Start is called before the first frame update
    void Start()
    {
        hpBar.maxValue = MaxHP;
        HP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.value = HP;

        if (Input.GetKeyUp(input) && HP > 0)
        {
            HP -= 1;
        }
        if (Input.GetKeyUp(input2) && HP < MaxHP)
        {
            HP += 1;
        }
    }
}
