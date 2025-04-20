using UnityEngine;
using UnityEngine.UI;

public class ActiveUIManager : MonoBehaviour
{
    private bool religionFounded = false;

    
    public GameObject startReligion;
    [HideInInspector] public GameObject worshipperStats;
    public GameObject goldStats;
    [HideInInspector] public GameObject worshipperPanel;
    [HideInInspector] public GameObject convertPrefab;
    [HideInInspector] public GameObject armPrefab;
    [HideInInspector] public GameObject crucifyPrefab;
    public GameObject expandPanel;
    public GameObject deathPanel;
    public GameObject megachurchPrefab;
    public GameObject tithePrefab;
    public GameObject indulgencePrefab;
    public GameObject taxPrefab;
    public GameObject extortPrefab;
    public GameObject annexPrefab;
    public GameObject crusadePrefab;
    public GameObject holyWarPrefab;
    public GameObject executePrefab;
    public GameObject martyrPrefab;
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
    private Button titheButton;
    private Button indulgenceButton;
    private Button taxButton;
    private Button extortButton;
    private Button annexButton;
    private Button crusadeButton;
    private Button executeButton;
    private Button martyrButton;
    
    private bool seenArm = false;
    private bool seenCrucify = false;
    private bool seenMegachurch = false;
    private bool seenTithe = false;
    private bool seenTax = false;
    private bool seenExtort = false;
    private bool seenAnnex = false;
    private bool seenCrusade = false;
    private bool startedHolyWar = false;
    private bool seenExecute = false;
    private bool seenMartyr = false;

    
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
        titheButton = tithePrefab.GetComponentInChildren<Button>();
        indulgenceButton = indulgencePrefab.GetComponentInChildren<Button>();
        taxButton = taxPrefab.GetComponentInChildren<Button>();
        extortButton = extortPrefab.GetComponentInChildren<Button>();
        annexButton = annexPrefab.GetComponentInChildren<Button>();
        crusadeButton = crusadePrefab.GetComponentInChildren<Button>();
        executeButton = executePrefab.GetComponentInChildren<Button>();
        martyrButton = martyrPrefab.GetComponentInChildren<Button>();
        
        //deactivate some prefabs ahead of time
        indulgencePrefab.SetActive(false);
        taxPrefab.SetActive(false);
        extortPrefab.SetActive(false);
        crusadePrefab.SetActive(false);
        executePrefab.SetActive(false);
        martyrPrefab.SetActive(false);
        holyWarPrefab.SetActive(false);
        annexPrefab.SetActive(false);

        
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
       

            if (!religionFounded)
            {
                worshipperStats.SetActive(false);
                goldStats.SetActive(false);
                worshipperPanel.SetActive(false);
                goldPanel.SetActive(false);
                expandPanel.SetActive(false);
                deathPanel.SetActive(false);
            
            }
            else
            {
                worshipperStats.SetActive(true);
                worshipperPanel.SetActive(true);
            }
            

            //------------GATING LOGIC-----------
            //-----------Ensures you have at least 1 of something before the next item appears--------
            
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

            //show megachurch and reveal gold panel after buying Crucify
            if (gm.numberOwned[(int)GameManager.InvestmentType.Crucify] > 0
                || gm.karma >= gm.megachurchCost
                || seenMegachurch)
            {
                megachurchPrefab.SetActive(true);
                seenMegachurch = true;
                seenTithe = true;
                goldPanel.SetActive(true);
                goldStats.SetActive(true);
            }
            else
            {
                megachurchPrefab.SetActive(false);
                goldPanel.SetActive(false);
            }
            
            //show indulgences and taxes after buying Tithe
            if (gm.numberOwned[(int)GameManager.InvestmentType.Tithe] > 0
                || seenTax)
            {
                indulgencePrefab.SetActive(true);
                taxPrefab.SetActive(true);
                seenTax = true;
            }
            else
            {
                indulgencePrefab.SetActive(false);
                taxPrefab.SetActive(false);
            }
            
            //show extort after buying tax or indulgence
            if (gm.numberOwned[(int)GameManager.InvestmentType.Tax] > 0
                || gm.numberOwned[(int)GameManager.InvestmentType.Indulgence] > 0
                || seenExtort)
            {
                extortPrefab.SetActive(true);
                seenExtort = true;
            }
            else
            {
                extortPrefab.SetActive(false);
            }
            
            //show war panel after extorting once

            if (gm.numberOwned[(int)GameManager.InvestmentType.Extort] > 0)
            {
                if (!startedHolyWar)
                {
                    holyWarPrefab.SetActive(true);
                }
                else
                {
                    holyWarPrefab.SetActive(false);

                }
                expandPanel.SetActive(true);
            }
            else
            {
                expandPanel.SetActive(false);
            }
            
            
            
        






            //----------BUTTON ACTIVATION LOGIC----------
            //---------Checks if you have enough karma or gold to buy------------

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
            if (gm.karma < gm.megachurchCost || gm.gold < gm.megachurchGold)
            {
                megachurchButton.interactable = false;
            }
            else
            {
                megachurchButton.interactable = true;
            }
            
            // tithe
            if (gm.karma < gm.titheCost)
            {
                titheButton.interactable = false;
            }
            else
            {
                titheButton.interactable = true;
            }
            
            //indulgence

            if (gm.karma < gm.indulgenceCost)
            {
                indulgenceButton.interactable = false;
            }
            else
            {
                indulgenceButton.interactable = true;
            }
            
            //tax

            if (gm.karma < gm.taxCost)
            {
                taxButton.interactable = false;
            }
            else
            {
                taxButton.interactable = true;
            }
            
            //extort

            if (gm.karma < gm.extortCost)
            {
                extortButton.interactable = false;
            }
            else
            {
                extortButton.interactable = true;
            }
            
            //annex

            if (gm.karma < gm.annexCost || gm.gold < gm.annexGoldCost) 
            {
                annexButton.interactable = false;
            }
            else
            {
                annexButton.interactable = true;
            }
            
            //crusade

            if (gm.karma < gm.crusadeCost || gm.gold < gm.crusadeGoldCost)
            {
                crusadeButton.interactable = false;
            }
            else
            {
                crusadeButton.interactable = true;
            }
            
            //execute

            if (gm.karma < gm.executeCost)
            {
                executeButton.interactable = false;
            }
            else
            {
                executeButton.interactable = true;
            }
            
            //martyr

            if (gm.karma < gm.martyrCost)
            {
                martyrButton.interactable = false;
            }
            else
            {
                martyrButton.interactable = true;
            }



    }
    public void StartReligion()
    {
        religionFounded = true;
        startReligion.SetActive(false);
    }

    public void DeclareWar()
    {
        startedHolyWar = true;
    }



}
