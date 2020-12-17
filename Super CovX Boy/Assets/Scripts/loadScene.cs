using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadScene : MonoBehaviour
{
    public string nameScene;
    public Image barFill;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsynchronously(nameScene));
    }


    IEnumerator LoadAsynchronously(string nameScenes)
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(nameScenes);
        while (!loading.isDone)
        {
            barFill.fillAmount = loading.progress;
            //Debug.Log(progress);
            yield return null;
        }
    }

}
