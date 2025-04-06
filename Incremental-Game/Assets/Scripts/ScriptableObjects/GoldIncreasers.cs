using UnityEngine;

[CreateAssetMenu(fileName = "GoldIncreasers", menuName = "Scriptable Objects/GoldIncreasers")]
public class GoldIncreasers : ScriptableObject
{
    public string giName = "Name";
    public string giDescription = "Description";
    public float giGoldPerSecond = 0f;
    public float giKarmaCost = 0f;

}
