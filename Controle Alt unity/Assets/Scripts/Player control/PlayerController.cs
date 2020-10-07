using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float minY, maxY;
}

public class PlayerController : MonoBehaviour
{
    [Space]
    [Header("PlayerStats")]
    [SerializeField] Vector3 movement;


    [Space]
    [Header("Player Attributes")]
    [SerializeField] float moveSpeed = 1.0f;

    [Space]
    [Header("Player References")]
    Rigidbody rb;
    public Boundary boundary;

    EventFeedBack eventFB;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

       
    }

    private void Update()
    {
        MovePlayer();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    //la fonction n'est pas adaptee, je teste juste les bondaries
    void MovePlayer()
    {
        movement.z = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        /*rb.position = new Vector3
               Mathf.Clamp(rb.position.z, boundary.minZ, boundary.maxZ);*/
          
               
    }
}
