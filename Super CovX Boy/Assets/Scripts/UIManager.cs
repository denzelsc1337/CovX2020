using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject mapSelectionPanel;
    public GameObject[] levelSelectionPanel;

    [Header("Cantidad de mascarillas")]
    public int masc;

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
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

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

    private void UpdateMascUI()
    {
        mascarillas.text = masc.ToString();
    }
}

