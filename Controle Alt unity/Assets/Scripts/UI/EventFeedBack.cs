using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFeedBack : MonoBehaviour
{
    public static EventFeedBack instance;

    public bool panneCourantActive = false;



    public GameObject popUp;

    public GameObject panneDeCourantPicto;

    private void Awake()
    {
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }


    private void Update()
    {
        Picto(); //on vérifie h24 si y'a un bail

        if (Input.GetKeyDown(KeyCode.F))
        {
            PanneDeCourant();
        }
    }


    public void Picto()
    {
        //check les bools pour savoir si on nique ou pas tel picto

        if (panneCourantActive == false)
        {
            panneDeCourantPicto.SetActive(false);
        }
        else if (panneCourantActive)
        {
            panneDeCourantPicto.SetActive(true);
        }
    }

    public void PanneDeCourant()
    {
        //(olha se calhar seria melhor de meter os efeitos visuais aqui tbm)
        Instantiate(popUp);    //warning pop-up
        panneCourantActive = true;    //bool set true
        



        Debug.Log("Event is on");
    }
}
