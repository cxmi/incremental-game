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
    
    //public float wiArmOwned = 0;
    //public GameObject wiCrucify;
    //public float wiConvertOwned = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("UpdateKarma", 0f, 1f);

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

        //buy logic

        //karmaPerSecond = numberOwned[(int)InvestmentType.Convert];
    }

    void UpdateKarma()
    {
        karma += karmaPerSecond;
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
                
                float newCost = costOfNext[(int)InvestmentType.Convert];
                Debug.Log(newCost);
                
                //write out the new cost
                convertCostText.text = "Cost: " + newCost.ToString() + " karma";
                
                break;
            case "Arm":
                //wiArmOwned += 1;
                numberOwned[(int)InvestmentType.Arm] += 1;
                break;
            case "Crucify":
                //wiCrucifyOwned += 1;
                numberOwned[(int)InvestmentType.Crucify] += 1;
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
