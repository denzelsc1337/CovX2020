using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class selectorDevice : MonoBehaviour
{
    private GameObject controls;
    bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        this.controls = GameObject.FindWithTag("controls");
        controls.SetActive(false);

#if UNITY_ANDROID
    controls.SetActive(true);
#endif

#if UNITY_STANDALONE_WIN
      controls.SetActive(false);
#endif
    }

    // Update is called once per frame
    void Update()
    {

    }
}
