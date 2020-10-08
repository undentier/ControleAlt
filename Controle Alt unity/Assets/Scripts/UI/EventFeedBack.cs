using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFeedBack : MonoBehaviour
{
    public static EventFeedBack instance;

    #region Bools
    [Header("Events bools")]
    public bool panneCourantActive = false;
    public bool panneReacteurActive = false;
    public bool fuiteActive = false;
    public bool enrayementActive = false;
    public bool signalVideoActive = false;
    public bool surchauffeActive = false;
    #endregion 

    [Space]
    public GameObject popUp;

    #region Picto refs
    [Space]
    [Header("Picto refs")]
    public GameObject panneDeCourantPicto;
    public GameObject panneReacteurPicto;
    public GameObject fuitePicto;
    public GameObject enrayementPicto;
    public GameObject signalVideoPicto;
    public GameObject surchauffePicto;
    #endregion

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


        //panne de courant
        if (panneCourantActive == false)
        {
            panneDeCourantPicto.SetActive(false);
        }
        else if (panneCourantActive)
        {
            panneDeCourantPicto.SetActive(true);
        }

        //panne de réacteur
        if (panneReacteurActive == false)
        {
            panneReacteurPicto.SetActive(false);
        }
        else if (panneReacteurActive)
        {
            panneReacteurPicto.SetActive(true);
        }

        //fuite
        if (fuiteActive == false)
        {
            fuitePicto.SetActive(false);
        }
        else if (fuiteActive)
        {
            fuitePicto.SetActive(true);
        }

        //enrayement
        if (enrayementActive == false)
        {
            enrayementPicto.SetActive(false);
        }
        else if (enrayementActive)
        {
            enrayementPicto.SetActive(true);
        }

        //signal video
        if (signalVideoActive == false)
        {
            signalVideoPicto.SetActive(false);
        }
        else if (signalVideoActive)
        {
            signalVideoPicto.SetActive(true);
        }

        //surchauffe
        if (surchauffeActive == false)
        {
            surchauffePicto.SetActive(false);
        }
        else if (surchauffeActive)
        {
            surchauffePicto.SetActive(true);
        }

    }

    public void PanneDeCourant()
    {
        //effet
        Instantiate(popUp); //warning pop-up
        panneCourantActive = true;    
    }

    public void PanneDeReacteur()
    {
        //effet
        Instantiate(popUp); //warning pop-up
        //bool set true
    }

    public void Fuite()
    {
        //effet
        Instantiate(popUp); //warning pop-up
        //bool set true
    }

    public void Enrayement()
    {
        //effet
        Instantiate(popUp); //warning pop-up
        //bool set true
    }

    public void SignalVideo()
    {
        //effet
        Instantiate(popUp); //warning pop-up
        //bool set true
    }

    public void Surchauffe()
    {
        //effet
        Instantiate(popUp); //warning pop-up
        //bool set true
    }
}
