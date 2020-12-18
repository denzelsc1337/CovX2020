using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class levelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject barras;
    public Slider slider;
    public Text progresstext;

   public void LoadLevel(string nameScene)
    {
        StartCoroutine(LoadAsynchronously(nameScene));
    }

    IEnumerator LoadAsynchronously(string nameScene)
    {
        //yield return new WaitForSeconds(4);
        AsyncOperation operation = SceneManager.LoadSceneAsync(nameScene);
        //loadingScreen.SetActive(true);
        //yield return new WaitForSeconds(3);
        barras.SetActive(false);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progresstext.text = progress * 100f + "%";
            Debug.Log(progress);
            yield return null;
        }
    }
}
