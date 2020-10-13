using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Text inputFieldText;
    public Text errorText;
    
    private void Start()
    {
        errorText.enabled = false;
    }

    public void NewGame(string sceneName)
    {
        if (inputFieldText.text.Length > 0)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            errorText.enabled = true;
            Debug.Log("Pas de nom");
        }
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
