using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFeedBack : MonoBehaviour
{
    public static EventFeedBack instance;

    public bool panneCourantActive = false;

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
        
    }


    public void PanneDeCourant()
    {
        //(olha se calhar seria melhor de meter os efeitos visuais aqui tbm)

        //bool set true
        //warning pop-up
        //warning pop-off    bem quer dizer tecnicamente seria melhor se eu fizer uma funçao para gerir o pop-up/off
        //um feedback que fica crlh, um GameObject 
        //depois temos de verificar se o problema foi resolvido ou nao
            //bem aqui temos um problema boy
                //okok entao podemos ter dois bools para cada problema (14 bools ouch)
                //verificar se um bool ta ativado
                //se ele nao for entao bora destruir o gameobject
    }
}
