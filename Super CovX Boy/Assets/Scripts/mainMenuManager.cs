using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void backScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene); 
    }

    public void quitGame()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else
        {
            Debug.Log("saliendo");
            Application.Quit();
        }  
    }
}
