using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCRIPTDEMERDE : MonoBehaviour
{
    public AK.Wwise.Event decollageAudio;
    public GameObject stars;

    private Rigidbody rb;
    bool canStart = true;


    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        stars.SetActive(false);
    }

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canStart)
        {
            StartCoroutine(StartGame());
        }
    }


    IEnumerator StartGame()
    {
        canStart = false;
        decollageAudio.Post(gameObject);
        rb.AddForce(-100, 0, 0);
        yield return new WaitForSeconds(17);
        stars.SetActive(true);
        rb.AddForce(-10000, 0, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
