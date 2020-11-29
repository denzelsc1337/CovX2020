using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cronometro : MonoBehaviour
{
    private Text timerText;
    public decimal time;

    void Awake()
    {
        timerText = GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        time = System.Math.Round((decimal)Time.timeSinceLevelLoad, 2);
        timerText.text = time.ToString();
        //timerText.text =
        //System.Math.Round((decimal)Time.timeSinceLevelLoad,
        //2).ToString();
    }
}
