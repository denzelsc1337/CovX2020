using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Mmenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.anyKey == true)
        {
            Mmenu.SetActive(true);
            gameObject.SetActive(false);
        }*/
        //EffectsSounds.instance.PlaySong(EffectsSounds.instance.menuMusic);
    }


    public void GameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Salir");
    }


}
