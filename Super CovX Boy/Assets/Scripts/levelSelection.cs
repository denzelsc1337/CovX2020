using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelSelection : MonoBehaviour
{
    public bool isUnlocked = false;
    public Image lockImage;
    public Image[] mascImages;//one masc image
    public Sprite[] mascSprite;

    void Update()
    {
        UpdateLevelButton();
        unlockLevel();
    }
    private void UpdateLevelButton()
    {
        if (isUnlocked)
        {
            lockImage.gameObject.SetActive(false);//no se vera la imagen bloqueada
            for (int i = 0; i < mascImages.Length; i++)
            {
                mascImages[i].gameObject.SetActive(true);
            }

            //for (int i = 0; i < PlayerPrefs.GetInt("Lv" +gameObject.name); i++)
            //{
            //    mascImages[i].sprite = mascSprite[i];
            //}
        }
        else
        {
            lockImage.gameObject.SetActive(true);//vera la imagen bloqueada
            for (int i = 0; i < mascImages.Length; i++)
            {
                mascImages[i].gameObject.SetActive(false);
            }
        }
    }

    private void unlockLevel()
    {
        int previousLvlIndex = int.Parse(gameObject.name)-1;
        if (PlayerPrefs.GetInt("Lv"+ previousLvlIndex)>0)
        {
            isUnlocked = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
