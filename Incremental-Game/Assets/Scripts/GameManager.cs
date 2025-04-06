using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float karma;
    public TextMeshProUGUI karmaText;
    
    public float karmaPerSecond;
    public TextMeshProUGUI karmaPerSecondText;
    
    public float karmaPerWorshipper;
    public TextMeshProUGUI karmaPerWorshipperText;
    
    public float totalWorshippers;
    public TextMeshProUGUI totalWorshippersText;
    public float newWorshippers;
    
    public float worshippersPerSecond;
    public TextMeshProUGUI worshippersPerSecondText;
    
    
    //Convert variables
    public GameObject wiConvert;
    public TextMeshProUGUI convertCostText;
    public float convertCost;

    //Arm Evangelists variables
    public GameObject wiArm;
    public TextMeshProUGUI armCostText;
    public float armCost;
  
    //Crucify variables
    public float wiCrucifyOwned = 0;
    public TextMeshProUGUI crucifyCostText;
    public float crucifyCost;
    
    public string clickedButtonParent;

    public enum InvestmentType
    {
        Convert,
        Arm,
        Crucify
    }
    
    public int[] costOfNext;
    public int[] numberOwned;

    private SOManager scriptObjectManager;
    
    //public float wiArmOwned = 0;
    //public GameObject wiCrucify;
    //public float wiConvertOwned = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //declare starting base costs
        convertCost = 10f;
        convertCostText.text = "Cost: " + convertCost.ToString() + " karma";
        armCost = 105f;
        armCostText.text = "Cost: " + armCost.ToString() + " karma";
        crucifyCost = 666f;
        crucifyCostText.text = "Cost: " + crucifyCost.ToString() + " karma";
        
        //update the karma amount every second
        InvokeRepeating("UpdateKarma", 0f, 1f);
        InvokeRepeating("UpdateWorshippers", 0f, 1f);

        
        //set karma gen rate per worshipper
        karmaPerWorshipper = 1f;
        
        //convertCost.text = "testing";
        costOfNext = new int[System.Enum.GetValues(typeof(InvestmentType)).Length];
        numberOwned = new int[System.Enum.GetValues(typeof(InvestmentType)).Length];
    }

    // Update is called once per frame
    void Update()
    {
        
        karmaPerSecondText.text = "Karma per second: " + karmaPerSecond.ToString("N0");
        karmaText.text = "Karma: " + karma.ToString("N0");
        
        totalWorshippersText.text = "Worshippers: " + totalWorshippers.ToString("N0");
        worshippersPerSecondText.text = "Worshippers per second: " + worshippersPerSecond.ToString("N0");

        //worshipp.text = "Worshippers: " + totalWorshippers.ToString("N0");


 

        //buy logic

        //karmaPerSecond = numberOwned[(int)InvestmentType.Convert];
    }

    void UpdateKarma()
    {
        karma += karmaPerSecond;
    }

    void UpdateWorshippers()
    {
        
        totalWorshippers += worshippersPerSecond;
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
                //wiConvertOwned += 1;
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
                numberOwned[(int)InvestmentType.Arm] += 1;
                bmanager.investment.UpdateCost(this, (int)InvestmentType.Arm, numberOwned);
                bmanager.investment.UpdateKarmaPerSecond(this, (int)InvestmentType.Arm, numberOwned);
                armCost = costOfNext[(int)InvestmentType.Arm];
                armCostText.text = "Cost: " + armCost.ToString() + " karma";

                
                break;
            case "Crucify":
                //wiCrucifyOwned += 1;
                numberOwned[(int)InvestmentType.Crucify] += 1;
                numberOwned[(int)InvestmentType.Crucify] += 1;
                bmanager.investment.UpdateCost(this, (int)InvestmentType.Crucify, numberOwned);
                bmanager.investment.UpdateKarmaPerSecond(this, (int)InvestmentType.Crucify, numberOwned);
                crucifyCost = costOfNext[(int)InvestmentType.Crucify];
                crucifyCostText.text = "Cost: " + crucifyCost.ToString() + " karma";
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
