using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public GameObject closeOptions;
    public GameObject buttons;
    
    // Start is called before the first frame update
    void Start()
    {
        closeOptions.SetActive(false);
    }

   

    public void OptionsMenu()
    {
        buttons.SetActive(false);
        closeOptions.SetActive(true);
    }

    public void CloseOptionsMenu()
    {

        buttons.SetActive(true);
        closeOptions.SetActive(false);
    }
}
