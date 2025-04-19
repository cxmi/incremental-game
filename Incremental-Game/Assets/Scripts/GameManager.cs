using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float karma;
    public TextMeshProUGUI karmaText;
    
    [HideInInspector] public float karmaPerSecond;
    public TextMeshProUGUI karmaPerSecondText;

    public float deathsPerSecond;
    public float totalDeaths;
    public TextMeshProUGUI totalDeathsText;
    public TextMeshProUGUI deathsPerSecondText;
    
    [HideInInspector] public float karmaPerWorshipper;
    public TextMeshProUGUI karmaPerWorshipperText;
    
    [HideInInspector] public float totalWorshippers;
    public TextMeshProUGUI totalWorshippersText;
    //public float newWorshippers;
    
    public float worshippersPerSecond;
    public TextMeshProUGUI worshippersPerSecondText;

    public float gold;
    [HideInInspector] public float goldPerWorshipper;
    [HideInInspector] public float goldPerSecond;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI goldPerWorshipperText;
    public TextMeshProUGUI goldPerSecondText;
    
    //Convert variables
    //public GameObject wiConvert;
    public TextMeshProUGUI convertCostText;
    [HideInInspector] public float convertCost;

    //Arm Evangelists variables
    //public GameObject wiArm;
    public TextMeshProUGUI armCostText;
    [HideInInspector] public float armCost;
  
    //Crucify variables
    //public float wiCrucifyOwned = 0;
    public TextMeshProUGUI crucifyCostText;
    [HideInInspector] public float crucifyCost;
    
    //megachurch variables
    public TextMeshProUGUI megachurchCostText;
    [HideInInspector] public float megachurchCost;
    [HideInInspector] public float megachurchGold;
    
    //Tithe variables
    public TextMeshProUGUI titheText;
    public float titheCost;
    public float titheGoldAddition;
    
    //Indulgence variables
    public TextMeshProUGUI indulgenceText;
    public float indulgenceCost;
    public float indulgenceGoldAddition;
    
    //Tax variables
    public TextMeshProUGUI taxText;
    public float taxCost;
    
    //Extort variables
    public TextMeshProUGUI extortText;
    public float extortCost;
    
    //Annex variables
    public TextMeshProUGUI annexText;
    public float annexCost;
    public float annexGoldCost;
    
    //Crusade variables
    public TextMeshProUGUI crusadeText;
    public float crusadeCost;
    public float crusadeGoldCost;
    
    //Execute variables
    public TextMeshProUGUI executeText;
    public float executeCost;
    
    //Martyr variables
    public TextMeshProUGUI martyrText;
    public float martyrCost;
    
    [HideInInspector] public string clickedButtonParent;

    [HideInInspector] public enum InvestmentType
    {
        Convert,
        Arm,
        Crucify,
        Megachurch,
        Tithe,
        Indulgence,
        Tax,
        Extort,
        Annex,
        Crusade,
        Execute,
        Martyr
    }
    
    [HideInInspector] public int[] costOfNext;
    [HideInInspector] public int[] numberOwned;
    [HideInInspector] public int[] goldCostOfNext;

    private SOManager scriptObjectManager;
    private GameObject scriptObjectGameObject;
    
    //public float wiArmOwned = 0;
    //public GameObject wiCrucify;
    //public float wiConvertOwned = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scriptObjectGameObject = GameObject.Find("ScriptObjectHandler");
        scriptObjectManager = scriptObjectGameObject.GetComponent<SOManager>();
        
        //declare starting base costs
        convertCost = scriptObjectManager.scObConvert.wiKarmaCost; 
        convertCostText.text = "Cost: " + convertCost.ToString() + " karma";
        
        armCost = scriptObjectManager.scObArm.wiKarmaCost;
        armCostText.text = "Cost: " + armCost.ToString() + " karma";
        
        crucifyCost = scriptObjectManager.scObCrucify.wiKarmaCost;
        crucifyCostText.text = "Cost: " + crucifyCost.ToString() + " karma";
        
        megachurchCost = scriptObjectManager.scObMegachurch.wiKarmaCost;
        megachurchGold = scriptObjectManager.scObMegachurch.wiGoldCost;
        megachurchCostText.text = "Cost: " + megachurchCost.ToString() + " karma & " + megachurchGold.ToString() + " gold";

        titheCost = scriptObjectManager.scTithe.wiKarmaCost;
        titheGoldAddition = scriptObjectManager.scTithe.goldPerPurchase;
        titheText.text = "Cost: " + titheCost.ToString() + " karma";
        
        indulgenceCost = scriptObjectManager.scIndulgence.wiKarmaCost;
        indulgenceGoldAddition = scriptObjectManager.scIndulgence.goldPerPurchase;
        indulgenceText.text = "Cost: " + indulgenceCost.ToString() + " karma";
        
        taxCost = scriptObjectManager.scTax.wiKarmaCost;
        taxText.text = "Cost: " + taxCost.ToString() + " karma";
        
        extortCost = scriptObjectManager.scExtort.wiKarmaCost;
        extortText.text = "Cost: " + extortCost.ToString() + " karma";
        
        annexCost = scriptObjectManager.scAnnex.wiKarmaCost;
        annexGoldCost = scriptObjectManager.scAnnex.wiGoldCost;
        annexText.text = "Cost: " + annexCost.ToString() + " karma & " + annexGoldCost.ToString() + " gold";
        
        crusadeCost = scriptObjectManager.scCrusade.wiKarmaCost;
        crusadeGoldCost = scriptObjectManager.scCrusade.wiGoldCost;
        crusadeText.text = "Cost: " + crusadeCost.ToString() + " karma & " + crusadeGoldCost.ToString() + " gold";
        
        executeCost = scriptObjectManager.scExecute.wiKarmaCost;
        executeText.text = "Cost: " + executeCost.ToString() + " karma";
        
        martyrCost = scriptObjectManager.scMartyr.wiKarmaCost;
        martyrText.text = "Cost: " + martyrCost.ToString() + " karma";
        
        
        //update the karma amount every second
        InvokeRepeating("UpdateKarma", 0f, 1f);
        InvokeRepeating("UpdateWorshippers", 0f, 1f);
        InvokeRepeating("UpdateGoldRate", 0f, 1f);
        InvokeRepeating("UpdateDeaths", 0f, 1f);

        
        //set karma gen rate per worshipper
        karmaPerWorshipper = 1f;
        
        //convertCost.text = "testing";
        costOfNext = new int[System.Enum.GetValues(typeof(InvestmentType)).Length];
        numberOwned = new int[System.Enum.GetValues(typeof(InvestmentType)).Length];
        goldCostOfNext = new int[System.Enum.GetValues(typeof(InvestmentType)).Length];

    }

    // Update is called once per frame
    void Update()
    {
        
        karmaPerSecondText.text = "Karma per second: " + karmaPerSecond.ToString("N0");
        karmaText.text = "Karma: " + karma.ToString("N0");
        
        totalWorshippersText.text = "Total Worshippers: " + totalWorshippers.ToString("N0");
        worshippersPerSecondText.text = "Worshippers per second: " + worshippersPerSecond.ToString("N0");
        
        goldText.text = "Gold: " + gold.ToString("N0");
        goldPerWorshipperText.text = "Gold per worshipper: " + goldPerWorshipper.ToString("N0");
        goldPerSecondText.text = "Gold per second: " + goldPerSecond.ToString("N0");
        
        totalDeathsText.text = "Total Deaths: " + totalDeaths.ToString("N0");
        deathsPerSecondText.text = "Deaths per second: " + deathsPerSecond.ToString("N0");

        //worshipp.text = "Worshippers: " + totalWorshippers.ToString("N0");

        
        
 

        //buy logic

        //karmaPerSecond = numberOwned[(int)InvestmentType.Convert];
    }

    void UpdateKarma()
    {
        karma += karmaPerSecond;
    }
    

    void UpdateGoldRate()
    {
        gold += goldPerSecond;
    }

    void UpdateWorshippers()
    {
        
        totalWorshippers += worshippersPerSecond;
    }

    void UpdateDeaths()
    {
        if (totalWorshippers >= 0)
        {
            totalDeaths += deathsPerSecond;
            totalWorshippers = totalWorshippers - deathsPerSecond;
        }
    }
    void BuyWithKarma()
    {
        //karma -= costOfNext;
    }
    public void ClickToBuy(Button clickedButton)
    {
        //string name = transform.parent.name;
        clickedButtonParent = clickedButton.transform.parent.name;
        string name = clickedButtonParent;
        //Debug.Log(name);
        //get the button manager attached to the button
        ButtonManager bmanager = clickedButton.GetComponent<ButtonManager>();
        switch (name)
        {
            case "Convert":
                
                    //clickedButton.interactable = true;
                    //wiConvertOwned += 1;
                    karma -= convertCost;
                    
                    numberOwned[(int)InvestmentType.Convert] += 1;

                    //ideally should check if bmanager is null but whatever

                    // using the int value for Convert in the enum, use UpdateCost() function in scriptable object
                    bmanager.investment.UpdateCost(this, (int)InvestmentType.Convert, numberOwned);

                    //update karma per second
                    bmanager.investment.UpdateKarmaPerSecond(this, (int)InvestmentType.Convert, numberOwned);

                    convertCost = costOfNext[(int)InvestmentType.Convert];
                    //Debug.Log(newCost);

                    //convertCost = newCost;
                    //write out the new cost
                    convertCostText.text = "Cost: " + convertCost.ToString() + " karma";
                

                break;
            case "Arm":
                //wiArmOwned += 1;
                karma -= armCost;
                numberOwned[(int)InvestmentType.Arm] += 1;
                bmanager.investment.UpdateCost(this, (int)InvestmentType.Arm, numberOwned);
                bmanager.investment.UpdateKarmaPerSecond(this, (int)InvestmentType.Arm, numberOwned);
                armCost = costOfNext[(int)InvestmentType.Arm];
                armCostText.text = "Cost: " + armCost.ToString() + " karma";

                
                break;
            case "Crucify":
                //wiCrucifyOwned += 1;
                karma -= crucifyCost;
                numberOwned[(int)InvestmentType.Crucify] += 1;
                //numberOwned[(int)InvestmentType.Crucify] += 1;
                bmanager.investment.UpdateCost(this, (int)InvestmentType.Crucify, numberOwned);
                bmanager.investment.UpdateKarmaPerSecond(this, (int)InvestmentType.Crucify, numberOwned);
                crucifyCost = costOfNext[(int)InvestmentType.Crucify];
                crucifyCostText.text = "Cost: " + crucifyCost.ToString() + " karma";
                break;
            
            case "Megachurch":
                //wiCrucifyOwned += 1;
                karma -= megachurchCost;
                gold -= megachurchCost;
                numberOwned[(int)InvestmentType.Megachurch] += 1;
                bmanager.investment.UpdateCost(this, (int)InvestmentType.Megachurch, numberOwned);
                bmanager.investment.UpdateGold(this, (int)InvestmentType.Megachurch, numberOwned);

                bmanager.investment.UpdateKarmaPerSecond(this, (int)InvestmentType.Megachurch, numberOwned);
                
                megachurchCost = costOfNext[(int)InvestmentType.Megachurch];
                megachurchGold = goldCostOfNext[(int)InvestmentType.Megachurch];
                megachurchCostText.text = "Cost: " + megachurchCost.ToString() + 
                                          " karma & " + megachurchGold.ToString() + " gold";
                break;
            case "Tithe":
                karma -= titheCost;
                numberOwned[(int)InvestmentType.Tithe] += 1;
                bmanager.investment.UpdateCostGoldGenerator(this, (int)InvestmentType.Tithe, numberOwned);
                bmanager.investment.UpdateGoldTotal(this, (int)InvestmentType.Tithe, numberOwned);

                titheCost = costOfNext[(int)InvestmentType.Tithe];
                //goldPerWorshipper = 
                titheText.text = "Cost: " + titheCost.ToString() + " karma";


                break;
            case "Indulgence":
                karma -= indulgenceCost;
                numberOwned[(int)InvestmentType.Indulgence] += 1;
                bmanager.investment.UpdateCostGoldGenerator(this, (int)InvestmentType.Indulgence, numberOwned);
                bmanager.investment.UpdateGoldTotal(this, (int)InvestmentType.Indulgence, numberOwned);

                indulgenceCost = costOfNext[(int)InvestmentType.Indulgence];
                indulgenceText.text = "Cost: " + indulgenceCost.ToString() + " karma";


                break;
            case "Tax":
                karma -= taxCost;
                numberOwned[(int)InvestmentType.Tax] += 1;
                bmanager.investment.UpdateGoldPerSecond(this, (int)InvestmentType.Tax, numberOwned);
                bmanager.investment.UpdateCostGoldGenerator(this, (int)InvestmentType.Tax, numberOwned);
                taxCost = costOfNext[(int)InvestmentType.Tax];
                taxText.text = "Cost: " + taxCost.ToString() + " karma";
                break;
            case "Extort":
                karma -= extortCost;
                numberOwned[(int)InvestmentType.Extort] += 1;
                bmanager.investment.UpdateGoldPerSecond(this, (int)InvestmentType.Extort, numberOwned);
                bmanager.investment.UpdateCostGoldGenerator(this, (int)InvestmentType.Extort, numberOwned);
                extortCost = costOfNext[(int)InvestmentType.Extort];
                extortText.text = "Cost: " + extortCost.ToString() + " karma";
                break;
            case "Annex":
                karma -= annexCost;
                gold -= annexGoldCost;
                numberOwned[(int)InvestmentType.Annex] += 1;
                bmanager.investment.UpdateDeathsPerSecond(this, (int)InvestmentType.Annex, numberOwned);
                bmanager.investment.UpdateKarmaPerSecond(this, (int)InvestmentType.Annex, numberOwned);
                bmanager.investment.UpdateCost(this, (int)InvestmentType.Annex, numberOwned);
                bmanager.investment.UpdateGold(this, (int)InvestmentType.Annex, numberOwned);
                annexGoldCost = goldCostOfNext[(int)InvestmentType.Annex];
                annexCost = costOfNext[(int)InvestmentType.Annex];
                annexText.text = "Cost: " + annexCost.ToString() + " karma & " 
                                 + annexGoldCost.ToString() + " gold";
                
                break;
            case "Crusade":
                karma -= crusadeCost;
                gold -= crusadeGoldCost;
                numberOwned[(int)InvestmentType.Crusade] += 1;
                bmanager.investment.UpdateDeathsPerSecond(this, (int)InvestmentType.Crusade, numberOwned);
                bmanager.investment.UpdateKarmaPerSecond(this, (int)InvestmentType.Crusade, numberOwned);
                bmanager.investment.UpdateCost(this, (int)InvestmentType.Crusade, numberOwned);
                bmanager.investment.UpdateGold(this, (int)InvestmentType.Crusade, numberOwned);
                crusadeGoldCost = goldCostOfNext[(int)InvestmentType.Crusade];
                crusadeCost = costOfNext[(int)InvestmentType.Crusade];
                crusadeText.text = "Cost: " + crusadeCost.ToString() + " karma & " 
                                   + crusadeGoldCost.ToString() + " gold";
                
                break;
            case "Execute":
                karma -= executeCost;
                numberOwned[(int)InvestmentType.Execute] += 1;
                bmanager.investment.UpdateDeathsPerSecond(this, (int)InvestmentType.Execute, numberOwned);
                bmanager.investment.UpdateKarmaPerSecond(this, (int)InvestmentType.Execute, numberOwned);
                bmanager.investment.UpdateCost(this, (int)InvestmentType.Execute, numberOwned);

                executeCost = costOfNext[(int)InvestmentType.Execute];
                executeText.text = "Cost: " + executeCost.ToString() + " karma";
                
                break;
            case "Martyr":
                karma -= martyrCost;
                numberOwned[(int)InvestmentType.Martyr] += 1;
                bmanager.investment.UpdateDeathsPerSecond(this, (int)InvestmentType.Martyr, numberOwned);
                bmanager.investment.UpdateKarmaPerSecond(this, (int)InvestmentType.Martyr, numberOwned);
                bmanager.investment.UpdateCost(this, (int)InvestmentType.Martyr, numberOwned);
                martyrCost = costOfNext[(int)InvestmentType.Martyr];
                martyrText.text = "Cost: " + martyrCost.ToString() + " karma";
                
                break;
            default:
                break;
        }
    }

    public void DoGood()
    {
        karma += 1;
    }

 
    
    
    // public void DetermineButton(Button clickedButton)
    // {
    //     clickedButtonParent = clickedButton.transform.parent.name;
    //     //Debug.Log(clickedButtonParent);
    // }
}
