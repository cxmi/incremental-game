using UnityEngine;
using UnityEngine.UI;

public class ActiveUIManager : MonoBehaviour
{
    [HideInInspector] public Button startReligion;
    [HideInInspector] public GameObject worshipperStats;
    [HideInInspector] public GameObject goldStats;
    [HideInInspector] public GameObject worshipperPanel;
    [HideInInspector] public GameObject convertPrefab;
    [HideInInspector] public GameObject armPrefab;
    [HideInInspector] public GameObject crucifyPrefab;
    public GameObject megachurchPrefab;
    public GameObject goldPanel;
    //public GameObject tithePrefab;
    //public GameObject indulgencesPrefab;
    private GameManager gm;
    private Button convertButton;
    private Button armButton;
    private Button crucifyButton;
    private Button megachurchButton;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GetComponent<GameManager>();

        convertButton = convertPrefab.GetComponentInChildren<Button>();
        armButton = armPrefab.GetComponentInChildren<Button>();
        crucifyButton = crucifyPrefab.GetComponentInChildren<Button>();
        megachurchButton = megachurchPrefab.GetComponentInChildren<Button>();


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
        
                
        //megachurch
        if (gm.karma < gm.megachurchCost || gm.gold < gm.megachurchCost)
        {
            megachurchButton.interactable = false;
        }
        else
        {
            megachurchButton.interactable = true;
        }
        
        
        
        
        
    }
}
