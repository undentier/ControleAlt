using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script fait par Guillaume Rogé et permet de :
/// - Détécter une Input
/// - Déplacer le player dans une direction donné
/// </summary>

namespace PlayerMouvement
{
    public class ShipMouvement : MonoBehaviour
    {
        #region Variables
        [Header("Speed player")]
        public float speed;

        private Rigidbody shipRb;
        #endregion

        void Start()
        {
            shipRb = gameObject.GetComponent<Rigidbody>();
        }

        void Update()
        {
            Mouvement();
        }


        void Mouvement()
        {
            if (Input.GetButtonDown("Up"))
            {
                shipRb.velocity = speed * Vector3.up * Time.fixedDeltaTime;
            }

            if (Input.GetButtonUp("Up"))
            {
                shipRb.velocity = Vector3.zero;
            }


            if (Input.GetButtonDown("Down"))
            {
                shipRb.velocity = speed * Vector3.down * Time.fixedDeltaTime;
            }

            if (Input.GetButtonUp("Down"))
            {
                shipRb.velocity = Vector3.zero;
            }
        }
    }
}
