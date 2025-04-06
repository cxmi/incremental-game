using UnityEngine;

[CreateAssetMenu(fileName = "WorshipperIncreasers", menuName = "Scriptable Objects/WorshipperIncreasers")]
public class WorshipperIncreasers : ScriptableObject
{
    public string wiName = "Name";
    public string wiDescription = "Description";
    public float wiWorshippersPerSecond = 0f;
    public float wiKarmaCost = 0f;
    public float wiGoldCost = 0f;

    public void UpdateCost(GameManager gm)
    {
        
    }
}
