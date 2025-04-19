using UnityEngine;

[CreateAssetMenu(fileName = "WorshipperIncreasers", menuName = "Scriptable Objects/WorshipperIncreasers")]
public class WorshipperIncreasers : ScriptableObject
{
    public string wiName = "Name";
    public string wiDescription = "Description";
    public float wiWorshippersPerSecond = 0f;
    public float wiKarmaCost = 0f;
    public float wiGoldCost = 0f;
    public float goldPerPurchase = 0f;
    public float goldPerSecond = 0f;
    public float deathsPerSecond = 0f;
    

    //pass in (int)InvestmentType.Convert and  int[] numberOwned;
    public void UpdateCost(GameManager gm, int enumPlace, int[] owned)
    {
        float costNextFloat = wiKarmaCost * Mathf.Pow(1.08f, owned[enumPlace]);
        gm.costOfNext[enumPlace] = (int)Mathf.Round(costNextFloat);
       
    }
    
    //special karma cost formula just for gold generators 
    public void UpdateCostGoldGenerator(GameManager gm, int enumPlace, int[] owned)
    {
        float costNextFloat = wiKarmaCost * Mathf.Pow(1.88f, owned[enumPlace]);
        gm.costOfNext[enumPlace] = (int)Mathf.Round(costNextFloat);
       
    }
    
    //update gold cost of things that require gold, like megachurches
    public void UpdateGold(GameManager gm, int enumPlace, int[] owned)
    {
        float goldNextFloat = wiGoldCost * Mathf.Pow(1.11f, owned[enumPlace]);
        gm.goldCostOfNext[enumPlace] = (int)Mathf.Round(goldNextFloat);
       
    }
    
    public void UpdateKarmaPerSecond(GameManager gm, int enumPlace, int[] owned)
    {
        //Debug.Log(owned[enumPlace] * wiWorshippersPerSecond * gm.karmaPerWorshipper);
        //this updates the Karma per second 
        //gm.worshippersPerSecond = gm.worshippersPerSecond + owned[enumPlace] * wiWorshippersPerSecond;
        gm.worshippersPerSecond = gm.worshippersPerSecond + wiWorshippersPerSecond;

        //gm.karmaPerSecond = gm.karmaPerSecond + owned[enumPlace] * wiWorshippersPerSecond * gm.karmaPerWorshipper;
        gm.karmaPerSecond = gm.karmaPerSecond + wiWorshippersPerSecond * gm.karmaPerWorshipper;

    }

    //updates gold amount for things that give a set, lump-sum of gold
    public void UpdateGoldTotal(GameManager gm, int enumPlace, int[] owned)
    {
        gm.gold += gm.totalWorshippers * goldPerPurchase;
        //gm.goldPerSecond = gm.goldPerSecond + goldPerPurchase * gm.totalWorshippers;
    }

    public void UpdateGoldPerSecond(GameManager gm, int enumPlace, int[] owned)
    {
        gm.goldPerSecond = gm.goldPerSecond + goldPerSecond;
    }
}
