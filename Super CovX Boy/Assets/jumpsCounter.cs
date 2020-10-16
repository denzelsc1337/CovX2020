using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class jumpsCounter : MonoBehaviour
{

    public static float jumpValue = 0;
    Text jump;
    // Start is called before the first frame update
    void Start()
    {
        jump = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        jump.text = "" + jumpValue;
    }
}
