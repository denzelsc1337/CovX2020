using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class diePlayer : MonoBehaviour
{
    public int respawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(respawn);
            respawn++;
        }

        switch (respawn)
        {
            case 1: Debug.Log("bravo six going dark..."); break;
            case 2: Debug.Log("again?"); break;
            case 3: Debug.Log("omae wa mou shindeiru :D"); break;
            default:
                break;
        }
    }


}
