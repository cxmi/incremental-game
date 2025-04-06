using UnityEngine;
using UnityEngine.UI;

public class ActiveUIManager : MonoBehaviour
{
    public Button startReligion;
    public GameObject worshipperStats;
    public GameObject goldStats;
    public GameObject worshipperPanel;
    public GameObject convertPrefab;
    public GameObject armPrefab;
    public GameObject crucifyPrefab;
    public GameObject goldPanel;
    public GameObject tithePrefab;
    public GameObject indulgencesPrefab;
    public GameManager gm;
    private Button convertButton;
    private Button armButton;
    private Button crucifyButton;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GetComponent<GameManager>();

        convertButton = convertPrefab.GetComponentInChildren<Button>();
        armButton = armPrefab.GetComponentInChildren<Button>();
        crucifyButton = crucifyPrefab.GetComponentInChildren<Button>();


    }

    // Update is called once per frame
    void Update()
    {
        //Button Activation Logic
        
        //convert
        if (gm.karma < gm.convertCost)
        {
            convertButton.interactable = false;
        }
        else
        {
            convertButton.interactable = true;
        }
        
        //arm
        if (gm.karma < gm.armCost)
        {
            armButton.interactable = false;
        }
        else
        {
            armButton.interactable = true;
        }
        
        //crucify
        if (gm.karma < gm.crucifyCost)
        {
            crucifyButton.interactable = false;
        }
        else
        {
            crucifyButton.interactable = true;
        }
        
        
        
        
        
    }
}
