using UnityEngine;
using UnityEngine.SceneManagement;

public class selectionMap : MonoBehaviour
{
    int indexY = 0;
    int index = 0;
    public int totalY;
    public int totalx;
    public float yOffset;
    public float xOffset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (index < totalx)
            {
                index++;
                Vector2 position = transform.position;
                position.x += xOffset;
                transform.position = position;
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (index > 0)
            {
                index--;
                Vector2 position = transform.position;
                position.x -= xOffset;
                transform.position = position;
            }

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (index==3 & indexY < totalY)
            {
                indexY++;
                Vector2 position = transform.position;
                position.y -= yOffset;
                transform.position = position;
            }

        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (indexY > 0)
            {
                indexY--;
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
                Debug.Log("no");
            }
            else if (index == 1)
            {
                //achievments scene
                SceneManager.LoadScene("Level 1");
                Debug.Log("mapa_1");
            }
            else if (index == 2)
            {
                SceneManager.LoadScene("Level 2");
                Debug.Log("mapa_2");
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
//DONE :D
