using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Matis Duperray
/// 
/// Rotation des tourelles
/// </summary>
namespace Spaceship
{
    public class TurretAIM : MonoBehaviour
    {
        #region Variables
        //Comme on aura 4 tourelles qui auront toutes des inputs différent, j'utilise des strings pour savoir quels boutons utiliser.
        public string rightInput;
        public string leftInput;

        [Space(10)]
        public float maxRotation = 90f;
        public float rotationSpeed = 15f;

        float currentRotation;
        #endregion

        private void Start()
        {
            currentRotation = 0;
        }

        void Update()
        {
            TurretOrientation();
        }


        void TurretOrientation()
        {
            float rotationValue = rotationSpeed * Time.deltaTime;

            if (Input.GetButton(rightInput))
            {
                if(currentRotation < maxRotation)
                {
                    transform.Rotate(0, rotationValue, 0);
                    currentRotation += rotationValue;
                }
            }
            if (Input.GetButton(leftInput))
            {
                if (currentRotation > -maxRotation)
                {
                    transform.Rotate(0, -rotationValue, 0);
                    currentRotation -= rotationValue;
                }
            }
        }

    }
}

