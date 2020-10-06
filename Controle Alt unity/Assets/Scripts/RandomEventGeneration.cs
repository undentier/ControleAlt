using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panne;
public class RandomEventGeneration : MonoBehaviour
{
    public bool isActive;
    public string input;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(input))
        {
            isActive = true;
        }
        if (Input.GetKeyUp(input))
        {
            isActive = false;
        }
    }
}
