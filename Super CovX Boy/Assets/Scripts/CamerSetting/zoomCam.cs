using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class zoomCam : MonoBehaviour
{
    public Text fraseRandom;
    public Text jumps;
    public Text deaths;
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
            deaths.text = CoxBoyController.deaths.ToString();
            jumps.text = CoxBoyController.jumps.ToString();
            CoxBoyController.phrases();
            zoomActive = true;
            levelCompleted();
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


    public void levelCompleted()
    {
        string[] complete = new string[] {
          "Tan gozuuuuuuuuuu",
          "aea mongol",
          "tsssssssss",
          "engañao de la vida",
          "aea chupapinga. Pobre mongol",
          "Blanquiñosooooooo",
          "Hay talento falta apoyo",
          "tles?",
          "la sise",
          "que te he hecho loco",
          "gayeta y aua",
          "compartir" };
        string pickFrase_2 = complete[Random.Range(0, complete.Length)];
        /*enviar aqui texto
        enviar aqui texto*/
        fraseRandom.text = pickFrase_2.ToString();
        Debug.Log(pickFrase_2);
    }

}
