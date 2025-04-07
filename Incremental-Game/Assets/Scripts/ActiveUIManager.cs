using UnityEngine;
using UnityEngine.UI;

public class ActiveUIManager : MonoBehaviour
{
    private bool religionFounded = false;
    
    public GameObject startReligion;
    [HideInInspector] public GameObject worshipperStats;
    [HideInInspector] public GameObject goldStats;
    [HideInInspector] public GameObject worshipperPanel;
    [HideInInspector] public GameObject convertPrefab;
    [HideInInspector] public GameObject armPrefab;
    [HideInInspector] public GameObject crucifyPrefab;
    public GameObject megachurchPrefab;
    public GameObject goldPanel;
    //public GameObject tithePrefab;
    //public GameObject indulgencesPrefab;
    private GameObject gameManagerHolder;
    private GameManager gm;
    
    private SOManager scriptObjectManager;
    private GameObject scriptObjectGameObject;
    
    private Button convertButton;
    private Button armButton;
    private Button crucifyButton;
    private Button megachurchButton;
    
    private bool seenArm = false;
    private bool seenCrucify = false;
    private bool seenMegachurch = false;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManagerHolder = GameObject.Find("GameManagerHolder");
        gm = gameManagerHolder.GetComponent<GameManager>();
        
        scriptObjectGameObject = GameObject.Find("ScriptObjectHandler");
        scriptObjectManager = scriptObjectGameObject.GetComponent<SOManager>();

        convertButton = convertPrefab.GetComponentInChildren<Button>();
        armButton = armPrefab.GetComponentInChildren<Button>();
        crucifyButton = crucifyPrefab.GetComponentInChildren<Button>();
        megachurchButton = megachurchPrefab.GetComponentInChildren<Button>();

        
    }

    // Update is called once per frame
    void Update()
    {
        //---------PANEL HIDE LOGIC----------
        
        //hide start religion until karma reaches 5
        if (gm.karma >= 5 && !religionFounded)
        {
            startReligion.SetActive(true);
        }
        else
        {
            startReligion.SetActive(false);
        }
        
        //HIDE panels until religion is founded
        //TODO: uncomment this once ready to go live
        //
        
        // if (!religionFounded)
        // {
        //     worshipperStats.SetActive(false);
        //     goldStats.SetActive(false);
        //     worshipperPanel.SetActive(false);
        //     goldPanel.SetActive(false);
        //
        // }
        // else
        // {
        //     worshipperStats.SetActive(true);
        //     worshipperPanel.SetActive(true);
        // }
        
        //end TODO
        
        //------------GATING LOGIC-----------
        if (gm.numberOwned[(int)GameManager.InvestmentType.Convert] > 1 || seenArm)
        {
            armPrefab.SetActive(true);
            seenArm = true;
        }
        else
        {
            armPrefab.SetActive(false);
        }
        
        if (gm.numberOwned[(int)GameManager.InvestmentType.Arm] > 1 
            || gm.karma >= gm.crucifyCost 
            || seenCrucify)
        {
            crucifyPrefab.SetActive(true);
            seenCrucify = true;
        }
        else
        {
            crucifyPrefab.SetActive(false);
        }
        
        if (gm.numberOwned[(int)GameManager.InvestmentType.Crucify] > 1 
            || gm.karma >= gm.megachurchCost
            || seenMegachurch)
        {
            megachurchPrefab.SetActive(true);
            seenMegachurch = true;
        }
        else
        {
            megachurchPrefab.SetActive(false);
        }
        
        //----------BUTTON ACTIVATION LOGIC----------
        
        //convert
        if (gm.karma < gm.convertCost)
        {
            convertButton.interactable = false;
        }
        else
        {
            convertButton.interactable = true;
        }
        
        //arm
        if (gm.karma < gm.armCost)
        {
            armButton.interactable = false;
        }
        else
        {
            armButton.interactable = true;
        }
        
        //crucify
        if (gm.karma < gm.crucifyCost)
        {
            crucifyButton.interactable = false;
        }
        else
        {
            crucifyButton.interactable = true;
        }
        
                
        //megachurch
        if (gm.karma < gm.megachurchCost || gm.gold < gm.megachurchCost)
        {
            megachurchButton.interactable = false;
        }
        else
        {
            megachurchButton.interactable = true;
        }
        
        
        
        
        
    }
    public void StartReligion()
    {
        religionFounded = true;
        startReligion.SetActive(false);
    }
}
