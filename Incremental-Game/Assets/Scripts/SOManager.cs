using TMPro;
using UnityEngine;

public class SOManager : MonoBehaviour
{
    
    [HideInInspector] public WorshipperIncreasers scObConvert;
    [HideInInspector] public TextMeshProUGUI convertTitle;
    [HideInInspector] public TextMeshProUGUI convertDescription;
    
    [HideInInspector] public WorshipperIncreasers scObArm;
    [HideInInspector] public TextMeshProUGUI armTitle;
    [HideInInspector] public TextMeshProUGUI armDescription;
    
    [HideInInspector] public WorshipperIncreasers scObCrucify;
    [HideInInspector] public TextMeshProUGUI crucifyTitle;
    [HideInInspector] public TextMeshProUGUI crucifyDescription;

    [HideInInspector] public WorshipperIncreasers scObMegachurch;
    [HideInInspector] public TextMeshProUGUI megachurchTitle;
    [HideInInspector] public TextMeshProUGUI megachurchDescription;
    
    public WorshipperIncreasers scObHoly;
    public TextMeshProUGUI holyTitle;
    public TextMeshProUGUI holyDescription;
    
    public WorshipperIncreasers scCrusade;
    public TextMeshProUGUI crusadeTitle;
    public TextMeshProUGUI crusadeDescription;
    
    [HideInInspector] public GoldIncreasers scTithe;
    [HideInInspector] public TextMeshProUGUI titheTitle;
    [HideInInspector] public TextMeshProUGUI titheDescription;
    
    [HideInInspector] public GoldIncreasers scIndulgence;
    [HideInInspector] public TextMeshProUGUI indulgenceTitle;
    [HideInInspector] public TextMeshProUGUI indulgenceDescription;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        convertTitle.text = scObConvert.wiName;
        convertDescription.text = scObConvert.wiDescription;

        armTitle.text = scObArm.wiName;
        armDescription.text = scObArm.wiDescription;
        
        crucifyTitle.text = scObCrucify.wiName;
        crucifyDescription.text = scObCrucify.wiDescription;
        
        megachurchTitle.text = scObMegachurch.wiName;
        megachurchDescription.text = scObMegachurch.wiDescription;

        titheTitle.text = scTithe.giName;
        titheDescription.text = scTithe.giDescription;
        
        indulgenceTitle.text = scIndulgence.giName;
        indulgenceDescription.text = scIndulgence.giDescription;
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
