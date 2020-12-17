using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counterMasks : MonoBehaviour
{
    public Text mask_text;
    private int old_mask;
    // Start is called before the first frame update
    void Start()
    {

        old_mask = PlayerPrefs.GetInt("mascarillas");
       // mask_text.text = old_mask.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
