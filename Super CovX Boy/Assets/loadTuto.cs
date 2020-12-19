using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadTuto : MonoBehaviour
{
    public GameObject tutoBegin;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsynchronously());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation loading = new AsyncOperation();
        yield return new WaitForSeconds(5.5f);
        Debug.Log("tutorial activo");
        tutoBegin.SetActive(true);
        yield return new WaitForSeconds(5.5f);
        tutoBegin.SetActive(false);
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
