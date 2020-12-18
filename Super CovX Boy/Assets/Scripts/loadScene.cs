using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadScene : MonoBehaviour
{
    public GameObject escenaGame;
    public GameObject panelLoad;
    public string nameScene;
    public Image barFill;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsynchronously());
    }


    IEnumerator LoadAsynchronously()
    {
        AsyncOperation loading = new AsyncOperation();
        yield return new WaitForSeconds(5.5f);
        escenaGame.SetActive(true);
        panelLoad.SetActive(false);
        //AsyncOperation loading = SceneManager.LoadSceneAsync(nameScenes);
        //panelLoad.SetActive(false);
        //escenaGame.SetActive(true);
        //while (!loading.isDone)
        //{
            
        //    barFill.fillAmount = loading.progress;
        //    //escenaGame.SetActive(false);
        //    //Debug.Log(progress);
        //    yield return null;
        //}
    }

}
