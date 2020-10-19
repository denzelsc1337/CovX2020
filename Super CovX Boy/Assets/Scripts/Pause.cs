using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour    
{
    public static bool gameP;
    public static bool boolseguroP;

    public GameObject MenuP, SeguroP, OptionsP;

    private void Start()
    {
        MenuP.SetActive(false);
        SeguroP.SetActive(false);
    }

    public void SwitchPause()
    {
        if (gameP)
        {
            Resume();
        }
        else
        {
            Paused();
        }
    }

    void Resume()
    {
        MenuP.SetActive(false);
        Time.timeScale = 1;
        gameP = false;
    }
    void Paused()
    {
        MenuP.SetActive(true);
        Time.timeScale = 0;
        gameP = true;
    }

    /*
    public void mPrincipal(string name)
    {
        SceneManager.LoadScene(name);
    }*/

    public void OptionsPanel()
    {
        OptionsP.SetActive(true);
    }

    public void SalirOptions()
    {
        OptionsP.SetActive(false);
    }

    public void SalirPanel()
    {
        SeguroP.SetActive(true);
    }

    public void SalirNO()
    {
        SeguroP.SetActive(false);
    }

    public void SalirSI()
    {
        Application.Quit();
        Debug.Log("Saliste");
    }

}
