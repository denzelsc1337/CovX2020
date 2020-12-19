using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject mapSelectionPanel;
    public GameObject[] levelSelectionPanel;

    [Header("Cantidad de mascarillas")]
    public int masc;
    private int old_mask;

    public Text mascarillas;
    public mapSelection[] mapSelections;
    public Text[] questMascTexts;
    public Text[] lockedMascTexts;
    public Text[] unlockMascTexts;

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
            //DontDestroyOnLoad(gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        old_mask = PlayerPrefs.GetInt("mascarillas");
        mascarillas.text = old_mask.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMascUI();
        UpdateLockedMascUI();
        UpdateUnlockMascUI();

    }

    private void UpdateLockedMascUI()
    {
        for (int i = 0; i < mapSelections.Length; i++)
        {
            questMascTexts[i].text = mapSelections[i].questNum.ToString();

            if (mapSelections[i].isUnlock == false)//si uno de los mapas esta bloqueado
            {
                lockedMascTexts[i].text = masc.ToString() + "/" + mapSelections[i].endLevel * 3;
            }

        }
    }
    private void UpdateUnlockMascUI()
    {
        for (int i = 0; i < mapSelections.Length; i++)
        {
            unlockMascTexts[i].text = masc.ToString() + "/" + mapSelections[i].endLevel * 3;
        }
    }
    //Actualizar conteo de mascarillas
    private void UpdateMascUI()
    {
        masc = PlayerPrefs.GetInt("Lv" + 1) + PlayerPrefs.GetInt("Lv" + 2) ;
        mascarillas.text = masc.ToString();
    }

    public  void PressMapButton(int _mapIndex)
    {
        if (mapSelections[_mapIndex].isUnlock == true)//se podra entrar a ese mapa
        {
            levelSelectionPanel[_mapIndex].gameObject.SetActive(true);
            mapSelectionPanel.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("No puedes entrar ahi :D");
        }
    }

    public void backButton()
    {
        mapSelectionPanel.gameObject.SetActive(true);
        for (int i = 0; i < mapSelections.Length; i++)
        {
            levelSelectionPanel[i].gameObject.SetActive(false);
        }
    }
    //public void SceneTransition(string _sceneName)
    //{

    //    SceneManager.LoadScene(_sceneName);
    //}

    public void backMapSelection()
    {
        mapSelectionPanel.gameObject.SetActive(true);
        for (int i = 0; i < mapSelections.Length; i++)
        {
            levelSelectionPanel[i].gameObject.SetActive(false);
        }
        SceneManager.LoadScene("chapter selection");
    }


}

