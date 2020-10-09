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

            
            baseActivityState = EventManager.instance.panneCourantActive;
        }

        // Update is called once per frame
        void Update()
        {
            IsActive = EventManager.instance.panneCourantActive; ;

            if (IsActive != baseActivityState)
            {
                lightsOff();
            }
            if (IsActive == baseActivityState)
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

