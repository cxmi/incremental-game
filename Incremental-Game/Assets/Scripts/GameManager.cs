using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject wiConvert;
    public TextMeshProUGUI convertCost;

    
    public GameObject wiArm;

    public TextMeshProUGUI armCost;
  
    public float wiCrucifyOwned = 0;
    public TextMeshProUGUI crucifyCost;
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
        //convertCost.text = "testing";
        costOfNext = new int[System.Enum.GetValues(typeof(InvestmentType)).Length];
        numberOwned = new int[System.Enum.GetValues(typeof(InvestmentType)).Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickToBuy(Button clickedButton)
    {
        //string name = transform.parent.name;
        clickedButtonParent = clickedButton.transform.parent.name;
        string name = clickedButtonParent;
        //Debug.Log(name);

        switch (name)
        {
            case "Convert":
                //wiConvertOwned += 1;
                numberOwned[(int)InvestmentType.Convert] += 1;
                ButtonManager bmanager = clickedButton.GetComponent<ButtonManager>();
                if (bmanager == null)
                {
                    Debug.Log("No Button manager");
                }
                bmanager.investment.UpdateCost(this, (int)InvestmentType.Convert, numberOwned);
                //bmanager.investment.wiKarmaCost = costOfNext[(int)InvestmentType.Convert];
                float newCost = costOfNext[(int)InvestmentType.Convert];
                Debug.Log(newCost);
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

    // public void DetermineButton(Button clickedButton)
    // {
    //     clickedButtonParent = clickedButton.transform.parent.name;
    //     //Debug.Log(clickedButtonParent);
    // }
}
