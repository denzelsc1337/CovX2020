using UnityEngine;
using UnityEngine.UI;

public class masckCollected : MonoBehaviour
{
    [Header("Cantidad de mascarillas")]
    public int questMascarillas;
    public static int masks;
    public GameObject portalFinal;

    public Text mascNecesarias;
    public void Start()
    {
        //mascNecesarias.text = questMascarillas.ToString();   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            //GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            masks += 1;
            singleLevel.instance.startLevel(masks);
            if (masks >= questMascarillas)
            {
                portalFinal.gameObject.SetActive(true);
            }
            else
            {
                portalFinal.gameObject.SetActive(false);
            }

            Destroy(gameObject,0.2f);


            Debug.Log("contando");
        }

    }


}
