using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pressStart : MonoBehaviour
{
    public string sceneName;
    public Animator musicAnim;
    public float waitime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(loadscene());
        }
    }

    IEnumerator loadscene()
    {
        musicAnim.SetTrigger("fadeOut");
        yield return new WaitForSeconds(waitime);
        SceneManager.LoadScene(sceneName);

    }


}
