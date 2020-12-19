using UnityEngine;
using UnityEngine.UI;

public class randomPhrase : MonoBehaviour
{
    public Text fraseRandom;
    

    // Start is called before the first frame update
    void Start()
    {
        tips();

    }

    public void tips()
    {
        string[] tips = new string[] {
          "no olvides lavarte las manos constantenmete",
          "Manten siempre la mascarilla por encima y no por debajo de la nariz",
          "Manten tu distancia, 2 metros como minimo :D",
          "No frotes tus manos contra tu cara si has tenido contacto con monedas,\n" +
          "barandas o algun material que tenga contacto con otras personas",
          "Usa desinfectantes y al llegar de algun lugar siempre aleja la ropa que llevas puesta de la que no has usado",
          "Si presentas fiebre, tos seca y dificultad para respirar\n" +
          " acude a tu centro de salud mas cercano",
          "SAGAAAAAAAAAAAAAAAASTIIIIIIIIIIIII!!!",
          "Porque te quiero abrazar más adelante, me distancio ahora"};
        string pickFrase = tips[Random.Range(0, tips.Length)];
        /*enviar aqui texto
        enviar aqui texto*/
        fraseRandom.text = pickFrase.ToString();
        Debug.Log(pickFrase);
    }

  
    // Update is called once per frame
    void Update()
    {

    }


}
//index = Random.Range(0, myArray.Length);