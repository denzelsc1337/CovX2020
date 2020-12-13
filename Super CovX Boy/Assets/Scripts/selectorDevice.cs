using UnityEngine;

public class selectorDevice : MonoBehaviour
{
    public GameObject controls;
    bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        //this.controls = GameObject.FindWithTag("controls");
        //controls.SetActive(false);

#if UNITY_ANDROID || UNITY_IOS
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
