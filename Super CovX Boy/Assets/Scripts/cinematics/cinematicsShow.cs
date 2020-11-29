using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class cinematicsShow : MonoBehaviour
{
    // Start is called before the first frame update
    public int nextLevel;
    gameManager gm;

    void Start()
    {
        

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gm.loadNextLevel(nextLevel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
}
