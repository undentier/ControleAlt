using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollSpaceBG : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    float xScroll;

    private Rigidbody rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        xScroll = Time.deltaTime * scrollSpeed;

        rb.AddForce(-xScroll, 0f, 0f);
    }
}
