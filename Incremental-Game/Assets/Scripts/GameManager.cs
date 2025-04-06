using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject wiConvert;
    public TextMeshProUGUI convertCost;
    public float wiConvertOwned = 0;
    public GameObject wiArm;
    public float wiArmOwned = 0;
    public TextMeshProUGUI armCost;
    public GameObject wiCrucify;
    public float wiCrucifyOwned = 0;
    public TextMeshProUGUI crucifyCost;
    public string clickedButtonParent;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //convertCost.text = "testing";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickToBuy()
    {
        //string name = transform.parent.name;
        string name = clickedButtonParent;
        Debug.Log(name);

        switch (name)
        {
            case "Convert":
                wiConvertOwned += 1;
                break;
            case "Arm":
                wiArmOwned += 1;
                break;
            case "Crucify":
                wiCrucifyOwned += 1;
                break;
            default:
                break;
        }
    }

    public void DetermineButton(Button clickedButton)
    {
        clickedButtonParent = clickedButton.transform.parent.name;
        //Debug.Log(clickedButtonParent);
    }
}
