using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingShipController : MonoBehaviour
{
    [Header("Shooter References")]
    Rigidbody rb;
    public Transform shootPoint;
    [SerializeField] GameObject bullet;
    Transform target;



    [Space]
    [Header("Shooter Stats - Move Section")]
    [SerializeField] float stopDis = 10f;
    [SerializeField] float shooterRadar;
    [SerializeField] float shooterRange;
    [SerializeField] float shooterSpeed = 5;
    [SerializeField] float retreatDis;



    [Space]
    [Header("Shooter Stats - Shoot Section")]
    float timeBtwShots;
    public float startTimeBtwShots;

    Vector3 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    private void Update()
    {

        float distance = Vector3.Distance(transform.position, target.position);  //on compare la postion entre le shooter et le joueur

        if (distance > stopDis && distance > shooterRadar) //si la distance entre les deux vaisseaux est supérieur à la zone d'arrêt et la zone de detection de l'enemy
        {
            
            transform.position = Vector3.MoveTowards(transform.position, target.position, shooterSpeed * Time.deltaTime); //il avance en direction du joueur

        }
        else if (distance > stopDis && distance > retreatDis) //si l'enemy est proche du joueur mais pas au point de devoir reculer alors il s'arrête
        {
            rb.velocity = Vector3.zero;
        }
        else if (distance > retreatDis) //sinon il recule
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, -shooterSpeed * Time.deltaTime); //recule vers la direction opposé du joueur
        }

        if (timeBtwShots <= 0 && distance < shooterRange)  //on check si le joueur est en range + si le cooldown permet de tirer
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

            //ajouter le son
            //mmmh pourquoi pas petite lumière
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }


        //rotate le ship par rapport au transform du joueur
        direction = target.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);

    }

    //ici on trace juste une sphere rouge pour checker sa zone de detection
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopDis);
    }


}
