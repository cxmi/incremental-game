using UnityEngine;

[CreateAssetMenu(fileName = "KarmaIncreasers", menuName = "Scriptable Objects/KarmaIncreasers")]
public class KarmaIncreasers : ScriptableObject
{
    public string kiName = "Name";
    public string kiDescription = "Description";
    public float kiWorshipperCost = 0f;
    public float kiKarmaPerSecond = 0f;
}
