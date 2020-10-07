using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ManagerPlayer;
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


        private float nearDistance = 10000000f;

        private void Start()
        {
            for (int i = 0; i < PlayerManager.Instance.turret.Length; i++)
            {
                float distance = Vector3.Distance(transform.position, PlayerManager.Instance.turret[i].transform.position);
                
                if (distance < nearDistance)
                {
                    nearDistance = distance;
                    ReferenceTurret = PlayerManager.Instance.turret[i];
                }
            }

            //ReferenceTurret = GameObject.FindGameObjectWithTag("Player");
        }

        void Update()
        {
            
            dir = ReferenceTurret.transform.position - transform.position; //on calcule le vecteur allant du kamikaze à la tourelle

            transform.rotation = Quaternion.LookRotation(dir);  // on ajuste la rotation du kamikaze pour qu'il regarde sa cible

            transform.position += dir.normalized * MoveSpeed * Time.deltaTime;  //déplacement du kamikaze

    }
}

