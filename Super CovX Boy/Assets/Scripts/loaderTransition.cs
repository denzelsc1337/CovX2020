using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loaderTransition : MonoBehaviour
{
    public Animator animation;
    public float transitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }*/
    }

    public void LoadNextLevel()
    {


        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));


    }

    public void BackLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }


    IEnumerator LoadLevel(int levelIndex)
    {
        //play animation
        if (Input.GetKeyDown("A"))
            animation.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(transitionTime);
        //load scene
        SceneManager.LoadScene(levelIndex);
    }
}

