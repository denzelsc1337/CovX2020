using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showfps : MonoBehaviour
{
    public float deltatime = 0.0f;
    public float color_r = 0f;
    public float color_g = 0f;
    public int size = 0;
    public float color_b = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deltatime += (Time.unscaledDeltaTime - deltatime) * 0.1f;
    }

    private void OnGUI()
    {
        int w = Screen.width, 
            h = Screen.height;

        GUIStyle estilo = new GUIStyle();

        Rect rect = new Rect(0.0f, 0.0f, w, h * 2/100);


        //texto
        estilo.alignment = TextAnchor.UpperLeft;
        estilo.fontSize = size;
        estilo.normal.textColor = new Color(color_r, color_g, color_b);

        //conteo fps
        float milisec = deltatime * 1000.0f;
        float fpe_eses = 1.0f / deltatime;

        //formato
        string txt = string.Format("{0:0.0} ms \n({1:0.}fps)", milisec, fpe_eses);

        //agregar instancia del rect y del estilo en el label
        GUI.Label(rect,txt, estilo);

    }
}
