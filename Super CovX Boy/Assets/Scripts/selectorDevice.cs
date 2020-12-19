using UnityEngine;

public class selectorDevice : MonoBehaviour
{
    public GameObject imageMobile;
    public GameObject imagePC;
    public GameObject controls;
    bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        //this.controls = GameObject.FindWithTag("controls");
        //controls.SetActive(false);

#if UNITY_ANDROID || UNITY_IOS
        controls.SetActive(true);
        imageMobile.SetActive(true);
        imagePC.SetActive(false);
#endif

#if UNITY_STANDALONE_WIN
        controls.SetActive(false);
        imageMobile.SetActive(false);
        imagePC.SetActive(true);
#endif
    }

    // Update is called once per frame
    void Update()
    {

    }
}
