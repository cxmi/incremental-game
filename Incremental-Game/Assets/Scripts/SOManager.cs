using TMPro;
using UnityEngine;

public class SOManager : MonoBehaviour
{
    
    public WorshipperIncreasers scObConvert;
    public TextMeshProUGUI convertTitle;
    public TextMeshProUGUI convertDescription;
    
    public WorshipperIncreasers scObArm;
    public TextMeshProUGUI armTitle;
    public TextMeshProUGUI armDescription;
    
    public WorshipperIncreasers scObCrucify;
    public TextMeshProUGUI crucifyTitle;
    public TextMeshProUGUI crucifyDescription;
    
    public WorshipperIncreasers scObHoly;
    public TextMeshProUGUI holyTitle;
    public TextMeshProUGUI holyDescription;
    
    public WorshipperIncreasers scCrusade;
    public TextMeshProUGUI crusadeTitle;
    public TextMeshProUGUI crusadeDescription;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        convertTitle.text = scObConvert.wiName;
        convertDescription.text = scObConvert.wiDescription;

        armTitle.text = scObArm.wiName;
        armDescription.text = scObArm.wiDescription;
        
        crucifyTitle.text = scObCrucify.wiName;
        crucifyDescription.text = scObCrucify.wiDescription;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
