using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCRIPTDEMERDE : MonoBehaviour
{
    public AK.Wwise.Event decollageAudio;

    // Start is called before the first frame update
    void Start()
    {
        decollageAudio.Post(gameObject);
    }

}
