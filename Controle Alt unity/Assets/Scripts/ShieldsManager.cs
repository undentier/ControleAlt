using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Deutschmann Lucas
/// 
/// Gestion du shield
/// </summary>
/// 
namespace Ressources
{
    
    public class ShieldsManager : MonoBehaviour
    {
        public GameObject ShieldLeft;
        public GameObject ShieldRight;

        // Start is called before the first frame update
        void Start()
        {
            ShieldLeft.SetActive(false);
            ShieldRight.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            
            if (Input.GetButtonDown("ShieldLeft"))
            {
                ShieldLeft.SetActive(true);
                ShieldRight.SetActive(false);
            }

            if (Input.GetButtonDown("ShieldRight"))
            {
                ShieldRight.SetActive(true);
                ShieldLeft.SetActive(false);
            }
        }

        
    }
}

