using TMPro;
using UnityEngine;

public class NotEnoughScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameManager gm;
    public TextMeshProUGUI notEnoughText;
    void Start()
    {
        notEnoughText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.totalWorshippers <= 0)
        {
            notEnoughText.text = "not enough worshippers to kill!";
        }
        else
        {
            notEnoughText.text = "";
        }
    }
}
