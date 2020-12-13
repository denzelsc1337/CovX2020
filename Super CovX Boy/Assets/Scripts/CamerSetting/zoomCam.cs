using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class zoomCam : MonoBehaviour
{

    public GameObject controls;
    public bool zoomActive;
    [SerializeField] private string sceneName;
    public CinemachineVirtualCamera cn;
    private Cinemachine.CinemachineVirtualCamera cm;
    

    public Camera cam;
    

    public float speedZoom;


    private void Awake()
    {
        cm = GetComponent<CinemachineVirtualCamera>();
       
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //CoxBoyController.input;
            Debug.Log("Level Complete");
            controls.SetActive(false);
            CoxBoyController.cancelControls();
            //StartCoroutine(LoadAsynchronously(sceneName));
            CoxBoyController.animator.enabled = false;
            
            zoomActive = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //varGameObject.active = false;
            CoxBoyController.input.y = 0f;
            zoomActive = false;
            CoxBoyController.GiveBackControls();
            CoxBoyController.animator.enabled = true;
        }
    }

    void LateUpdate()
    {
        if (zoomActive)
        {
            cinematicBars.Instance.showBars();
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 2, speedZoom);
        }
        else
        {
            cinematicBars.Instance.hideBars();
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5, speedZoom);
        }
    }
    //IEnumerator LoadAsynchronously (string sceneName)
    //{
    //    yield return new WaitForSeconds(4);
    //    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
    //    while (!operation.isDone)
    //    {
    //        Debug.Log(operation.progress);
    //        yield return null;
    //    }
    //}


}
