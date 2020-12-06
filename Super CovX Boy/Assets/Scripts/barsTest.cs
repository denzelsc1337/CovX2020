using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barsTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            //show bars
            cinematicBars.Instance.showBars();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //hide bars
            cinematicBars.Instance.hideBars();
        }
    }
}
