using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mostrarMaskNeed : MonoBehaviour
{
    public Text mascNecesarias;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mascNecesarias.text = masckCollected.masks.ToString();
    }
}
