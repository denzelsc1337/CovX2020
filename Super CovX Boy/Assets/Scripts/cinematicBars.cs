using System.Collections;
using UnityEngine;

public class cinematicBars : MonoBehaviour
{
    public static cinematicBars Instance { get; private set; }

    [SerializeField] private GameObject cnmtcBarContainerGo;
    [SerializeField] private Animator cinematicBarsAnimator;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showBars()
    {
        cnmtcBarContainerGo.SetActive(true);
    }

    public void hideBars()
    {
        if (cnmtcBarContainerGo.activeSelf) StartCoroutine(HideBarsAndDisableGo()); 
    }

    private IEnumerator HideBarsAndDisableGo()
    {
        cinematicBarsAnimator.SetTrigger("hideBars");
        yield return new WaitForSeconds(0.5f);
        cnmtcBarContainerGo.SetActive(false);
    }
}
