using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform wayPointTop, wayPointMidTop, wayPointMid, wayPointMidDown, wayPointDown;
    [Space(10)]
    public Transform limitPointTop, limitPointDown;

    [Space(20)]

    public float playerSpeed = 50f, playerAcceleration = 2.5f;
    private float activePlayerSpeed;

    private int wayPointDestination = 0, actualWayPoint = 0; //de -2 à 2, en partant du bas vers le haut
    public float movementCooldown = 2;
    bool canMove = true;

    //--------------------------------------------------------------------------------------------------------------


    // Update is called once per frame
    void Update()
    {
        FluidMovement();
        //SelectWayPoint();
    }




    void SelectWayPoint()
    {
        if(Input.GetKeyDown("up"))
        {
            if (actualWayPoint < 2 && canMove)
            {
                Debug.Log("Request Up Movement");

                wayPointDestination++;
                canMove = false;
                StartCoroutine(MoveCooldown());
            }
        }
        if(Input.GetKeyDown("down"))
        {
            if (actualWayPoint > (-2) && canMove)
            {
                Debug.Log("Request Down Movement");

                wayPointDestination--;
                canMove = false;
                StartCoroutine(MoveCooldown());
            }
        }

        if (actualWayPoint != wayPointDestination)
        {
            switch(wayPointDestination)
            {
                case (2):
                    Debug.Log("Move to Top");
                    MoveToWayPoint(wayPointTop); 
                    break;

                case (1):
                    Debug.Log("Move to MidTop");
                    MoveToWayPoint(wayPointMidTop);
                    break;

                case (0):
                    Debug.Log("Move to Mid");
                    MoveToWayPoint(wayPointMid);
                    break;

                case (-1):
                    Debug.Log("Move to MidDown");
                    MoveToWayPoint(wayPointMidDown);
                    break;

                case (-2):
                    Debug.Log("Move to Down");
                    MoveToWayPoint(wayPointDown);
                    break;

            }
        }


    }//Mouvement voie par voie du vaisseau
    void MoveToWayPoint(Transform wayPoint)
    {
        Debug.Log("Destination not reached");
        if (transform.position.x == wayPoint.position.x)
        {
            activePlayerSpeed = 0;
            playerAcceleration = 10000;
        }
        else if (transform.position.x < wayPoint.position.x) // Le vaisseau est au dessus
        {
            playerAcceleration = 3;

            Debug.Log("Moving down");
            activePlayerSpeed = Mathf.Lerp(activePlayerSpeed, playerSpeed, playerAcceleration * Time.deltaTime);

            transform.position += transform.right * activePlayerSpeed * Time.deltaTime;
        }
        else if (transform.position.x > wayPoint.position.x) // Le vaisseau est en dessous
        {
            playerAcceleration = 3;

            Debug.Log("Moving up");
            activePlayerSpeed = Mathf.Lerp(activePlayerSpeed, -playerSpeed, playerAcceleration * Time.deltaTime);

            transform.position += transform.right * activePlayerSpeed * Time.deltaTime;
        }

    }
    IEnumerator MoveCooldown()
    {
        yield return new WaitForSeconds(movementCooldown);
        canMove = true;
    }


    void FluidMovement()
    {
        activePlayerSpeed = Mathf.Lerp(activePlayerSpeed, Input.GetAxisRaw("Vertical") * playerSpeed, playerAcceleration * Time.deltaTime);
        transform.position += transform.right * activePlayerSpeed * Time.deltaTime;


    }//Mouvement libre du vaisseau
}
