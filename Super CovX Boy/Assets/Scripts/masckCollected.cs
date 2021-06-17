using UnityEngine;

public class masckCollected : MonoBehaviour
{
    [Header("Cantidad de mascarillas")]
    public int questMascarillas;
    public static int masks;
    public GameObject portalFinal;
    public GameObject portalFinal_2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            masks += 1;
            
            //GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            if (masks >= questMascarillas)
            {
                portalFinal.gameObject.SetActive(true);
            }
            else
            {
                portalFinal.gameObject.SetActive(false);
            }
            Destroy(gameObject, 0.2f);
            Debug.Log("contando");
        }

    }


}
