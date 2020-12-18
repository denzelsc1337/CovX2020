using UnityEngine;

public class singleLevel : MonoBehaviour
{
    public static singleLevel instance;
    private int levelMascNum = 0;
    public int levelIndex;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    public void startLevel()
    {
        levelMascNum = CoxBoyController.masks;
        if (levelMascNum > PlayerPrefs.GetInt("Lv" + levelIndex)) // key: Lv1; Value:Mascs number
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, levelMascNum);
        }
        Debug.Log("Saving data is " + PlayerPrefs.GetInt("Lv" + levelIndex));
    }
    public void back()
    {
        UIManager.instance.backMapSelection();
    }


}
