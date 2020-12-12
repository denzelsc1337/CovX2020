using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class zoomCam : MonoBehaviour
{
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
            Debug.Log("Level Complete");
            SceneManager.LoadScene(sceneName);
            CoxBoyController.cancelControls();
            
            zoomActive = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            zoomActive = false;
            CoxBoyController.GiveBackControls();
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

}
