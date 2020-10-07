using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Deutschmann Lucas 
/// 
/// Comportement des ennemis kamikazes
/// </summary>
namespace Ennemis
{
    
    public class Kamikaze : MonoBehaviour
    {
        public GameObject ReferenceTurret; //la tourelle ciblée par le kamikaze
        Vector3 dir; //le vecteur entre la tourelle et le kamikaze
        public float MoveSpeed; //Vitesse de déplacement du kamikaze (modifiable)
        
        

        private void Start()
        {
            // ReferenceTurret = Gamemanager.instance. blablabbla ...
        }

        void Update()
        {
            
            dir = ReferenceTurret.transform.position - transform.position; //on calcule le vecteur allant du kamikaze à la tourelle

            transform.rotation = Quaternion.LookRotation(dir);  // on ajuste la rotation du kamikaze pour qu'il regarde sa cible

            transform.position += dir.normalized * MoveSpeed * Time.deltaTime;  //déplacement du kamikaze
        }

        private void OnCollisionEnter(Collision collision)  //detection de la collision avec le Player
        {
            if (collision.collider.tag == "Player")
            {
                Explode();
            }
        }

        void Explode() //explosion du kamikaze
        {
            Destroy(gameObject);
        }
        
    }
}

