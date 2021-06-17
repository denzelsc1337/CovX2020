using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonNavigation : MonoBehaviour
{
   

     int index = 0;
    public int total = 3;
    public float yOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (index < total)
            {
                index++;
                Vector2 position = transform.position;
                position.y -= yOffset;
                transform.position = position;
            }

        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (index > 0)
            {
                index--;
                Vector2 position = transform.position;
                position.y += yOffset;
                transform.position = position;
            }

        }
   

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (index == 0)
            {
                //gameScene(escena);
                SceneManager.LoadScene("chapter selection");
            }
            else if (index == 1)
            {
                //achievments scene
                SceneManager.LoadScene("Achievments");
            }
            else if (index == 2)
            {
                Debug.Log("Perfil");
            }
            else if (index == 3)
            {
                Debug.Log("Opciones");
            }
            else if (index == 4)
            {
                Debug.Log("Salir");
            }
            
        }
    }

}
