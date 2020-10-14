using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ManagerPlayer;



//pour appeler les fonctions des problèmes il faut juste une ref pour le scrip (EventManager eventManager) et puis dans la fonction Start: eventManager = EventManager.instance; Enfin il y a juste à eventManager.LaFonctionQueTuVeux

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    [Space(10)]
    [Header("Fuite refs")]
    float timer = 0f;
    public float delayAmount;

    [Space]
    [Header("Panne de Courant refs")]
    public GameObject darkPanel;

    #region Bools
    [Space(10)]
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

    int funcToChoose;


    [Space(10)]
    [Header("Audio")]
    public AK.Wwise.Event alarmGazAudio;
    public AK.Wwise.Event alarmComAudio;
    public AK.Wwise.Event alarmEngineAudio;




    //private ShipMouvement _playerScript;
    public GameObject player;

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

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //_playerScript = player.GetComponent<ShipMouvement>();
    }


    private void Update()
    {
        Picto();

        if (Input.GetKeyDown(KeyCode.F))
        {
            RandomEvent();
        }


        //effet fuite
        timer += Time.deltaTime;
        if (timer > delayAmount && fuiteActive && PlayerManager.Instance.shield != 0)
        {
            timer = 0f;
            PlayerManager.Instance.shield--;


        }
        else if(timer > delayAmount && fuiteActive && PlayerManager.Instance.shield == 0)
        {
            timer = 0f;
            PlayerManager.Instance.hp--;
            if (PlayerManager.Instance.hp == 0)
            {
                Debug.Log("Ouuuuhlala c'est la défaite");
            }
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



    #region function pour problèmes
    public void PanneDeCourant()
    {
        darkPanel.SetActive(true);
        Instantiate(popUp); //warning pop-up
        panneCourantActive = true;
        //play sound
    }

    public void PanneDeReacteur()
    {
        //wow incroyable visual vient de me donner un cancer phase terminal fds je veux juste accéder à la bool Canmove du script de guigui crlh
        Instantiate(popUp); //warning pop-up
        panneReacteurActive = true;
        alarmEngineAudio.Post(gameObject);
    }

    public void Fuite()
    {
        //effet (il dans le update hihi)
        Instantiate(popUp); //warning pop-up
        fuiteActive = true;
        alarmGazAudio.Post(gameObject);
    }

    public void Enrayement()
    {
        //effet
        Instantiate(popUp); //warning pop-up
        enrayementActive = true;
        //play sound
    }

    public void SignalVideo()
    {
        //effet
        Instantiate(popUp); //warning pop-up
        signalVideoActive = true;
        alarmComAudio.Post(gameObject);
    }

    public void Surchauffe()
    {
        //effet
        Instantiate(popUp); //warning pop-up
        surchauffeActive = true;
        //play sound
    }

    #endregion


    public void RandomEvent()
    {
        funcToChoose = Random.Range(0, 6);

        switch (funcToChoose)
        {
            case 0:
                if (!panneCourantActive)
                {
                    PanneDeCourant();
                }

                break;
                
                
                

            case 1:
                if (!panneReacteurActive)
                {
                    PanneDeReacteur();
                }

                
                break;
                
                

            case 2:
                if (!fuiteActive)
                {
                    Fuite();
                }
                
                
                break;
                
                
                

            case 3:
                if (!enrayementActive)
                {
                    Enrayement();
                }
                
                break;
                
                

            case 4:
                if (!signalVideoActive)
                {
                    SignalVideo();
                }
               
                
                break;
                
                
                

            case 5:
                if (!surchauffeActive)
                {
                    Surchauffe();
                }
                
                break;
                
                
                
        }
    }

    
}
