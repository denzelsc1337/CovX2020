using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    public float time;
    private int width, height;
    private Rect rect;
    private GUIStyle labelStyle;
    private string currentTime;
    public float color_r = 0f;
    public float color_g = 0f;
    public int size = 0;
    public float color_b = 0f;



    void Update()
    {
        time += Time.deltaTime;
    }

    void Awake()
    {
        width = Screen.width;
        height = Screen.height;
        rect = new Rect(10, 10, width - 20, height - 20);
    }

    void OnGUI()
    {
        int w = Screen.width,
             h = Screen.height;

        GUIStyle estilo = new GUIStyle();

        Rect rect = new Rect(0.0f, 0.0f, w, h * 2 / 100);


        //texto
        estilo.alignment = TextAnchor.UpperLeft;
        estilo.fontSize = size;
        estilo.normal.textColor = new Color(color_r, color_g, color_b);


        //formato
        string txt = string.Format("\n\n\n{00:00:00}", time);

        //agregar instancia del rect y del estilo en el label
        GUI.Label(rect, txt, estilo);
    }

}
