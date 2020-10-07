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


        [Space(10)]
        [Header("Audio")]
        public AK.Wwise.Event rotationAudio;

        bool isPlayingRotationAudio = false;

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

            if (Input.GetButton(rightInput) || Input.GetButton(leftInput))//Je fais ca pour que le son boucle pas à l'infini sans donner la priorité à l'une des deux touches de déplacements.
            {
                if (Input.GetButton(rightInput))//bouton pour rotate droite
                {
                    if (currentRotation < maxRotation)//La tourelle peut elle encore tourner ?
                    {
                        if (isPlayingRotationAudio == false)//play Audio
                        {
                            rotationAudio.Post(gameObject);
                            isPlayingRotationAudio = true;
                        }
                        
                        transform.Rotate(0, rotationValue, 0);
                        currentRotation += rotationValue;
                    }
                    else//Stop Audio
                    {
                        rotationAudio.Stop(gameObject);
                        isPlayingRotationAudio = false;
                    }
                }
                if (Input.GetButton(leftInput))//bouton rotate gauche
                {
                    if (currentRotation > -maxRotation)//La tourelle peut elle encore tourner ?
                    {
                        if (isPlayingRotationAudio == false)//Play Audio
                        {
                            rotationAudio.Post(gameObject);
                            isPlayingRotationAudio = true;
                        }

                        transform.Rotate(0, -rotationValue, 0);
                        currentRotation -= rotationValue;
                    }
                    else//Stop Audio
                    {
                        rotationAudio.Stop(gameObject);
                        isPlayingRotationAudio = false;
                    }
                }
            }
            else if (Input.GetButton(rightInput) && Input.GetButton(leftInput))//Le joueur appuie sur les deux boutons et ducoup la tourelle ne bouge plus
            {
                rotationAudio.Stop(gameObject);
                isPlayingRotationAudio = false;
            }
            else//Le joueur n'appuie sur aucun bouton, stop Audio
            {
                rotationAudio.Stop(gameObject);
                isPlayingRotationAudio = false;
            }

            
        }

    }
}

