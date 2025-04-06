using UnityEngine;

[CreateAssetMenu(fileName = "WorshipperIncreasers", menuName = "Scriptable Objects/WorshipperIncreasers")]
public class WorshipperIncreasers : ScriptableObject
{
    public string wiName = "Name";
    public string wiDescription = "Description";
    public float wiWorshippersPerSecond = 0f;
    public float wiKarmaCost = 0f;
    public float wiGoldCost = 0f;

    //pass in (int)InvestmentType.Convert and  int[] numberOwned;
    public void UpdateCost(GameManager gm, int enumPlace, int[] owned)
    {
        float costNextFloat = wiKarmaCost * Mathf.Pow(1.08f, owned[enumPlace]);
        gm.costOfNext[enumPlace] = (int)Mathf.Round(costNextFloat);
       
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
}
