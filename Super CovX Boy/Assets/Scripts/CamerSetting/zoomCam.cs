using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomCam : MonoBehaviour
{
    public bool zoomActive;

    public Vector3[] target;

    public Camera cam;

    public float speedZoom;


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
            zoomActive = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            zoomActive = false;
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
