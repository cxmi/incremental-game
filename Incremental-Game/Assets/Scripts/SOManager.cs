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
    
    public WorshipperIncreasers scTithe;
    public TextMeshProUGUI titheTitle;
    public TextMeshProUGUI titheDescription;
    
    public WorshipperIncreasers scIndulgence;
    public TextMeshProUGUI indulgenceTitle;
    public TextMeshProUGUI indulgenceDescription;
    
    public WorshipperIncreasers scTax;
    public TextMeshProUGUI taxTitle;
    public TextMeshProUGUI taxDescription;
    
    public WorshipperIncreasers scExtort;
    public TextMeshProUGUI extortTitle;
    public TextMeshProUGUI extortDescription;
    
    public WorshipperIncreasers scAnnex;
    public TextMeshProUGUI annexTitle;
    public TextMeshProUGUI annexDescription;
    
    public WorshipperIncreasers scExecute;
    public TextMeshProUGUI executeTitle;
    public TextMeshProUGUI executeDescription;
    
    public WorshipperIncreasers scMartyr;
    public TextMeshProUGUI martyrTitle;
    public TextMeshProUGUI martyrDescription;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        convertTitle.text = scObConvert.wiName;
        convertDescription.text = scObConvert.wiDescription;

        armTitle.text = scObArm.wiName;
        armDescription.text = scObArm.wiDescription;
        
        crucifyTitle.text = scObCrucify.wiName;
        crucifyDescription.text = scObCrucify.wiDescription;
        
        crusadeTitle.text = scCrusade.wiName;
        crusadeDescription.text = scCrusade.wiDescription;
        
        megachurchTitle.text = scObMegachurch.wiName;
        megachurchDescription.text = scObMegachurch.wiDescription;

        titheTitle.text = scTithe.wiName;
        titheDescription.text = scTithe.wiDescription;
        
        indulgenceTitle.text = scIndulgence.wiName;
        indulgenceDescription.text = scIndulgence.wiDescription;
        
        taxTitle.text = scTax.wiName;
        taxDescription.text = scTax.wiDescription;
        
        extortTitle.text = scExtort.wiName;
        extortDescription.text = scExtort.wiDescription;
        
        annexTitle.text = scAnnex.wiName;
        annexDescription.text = scAnnex.wiDescription;
        
        executeTitle.text = scExecute.wiName;
        executeDescription.text = scExecute.wiDescription;
        
        martyrTitle.text = scMartyr.wiName;
        martyrDescription.text = scMartyr.wiDescription;
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
