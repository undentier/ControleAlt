using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Deutschmann Lucas
/// 
/// Panne d'electricité
/// </summary>

namespace Panne
{
    public class PanneElectrique : MonoBehaviour
    {
        public float Opacity;
        bool panne;
        bool IsActive;
        bool baseActivityState;
        public string inputPlayer1;
        public string inputPlayer2;
        public Image panel;

        Color newColor;
        Color baseColor;
        // Start is called before the first frame update
        void Start()
        {
            baseColor = panel.color;
            newColor = panel.color;
            newColor.a = Opacity;

            IsActive = GetComponent<RandomEventGeneration>().isActive;
            baseActivityState = GetComponent<RandomEventGeneration>().isActive;
        }

        // Update is called once per frame
        void Update()
        {
            IsActive = GetComponent<RandomEventGeneration>().isActive;

            if (IsActive != baseActivityState)
            {
                lightsOff();
            }
            if (Input.GetKey(inputPlayer1) && Input.GetKey(inputPlayer2))
            {
                FixLights();
            }


            if (panne)
            {
                panel.color = newColor;
            }
            else
            {
                panel.color = baseColor;
            }


        }

        void lightsOff()
        {
            panne = true;

        }
        void FixLights()
        {
            panne = false;
        }
    }
}

