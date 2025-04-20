using System.Collections;
using TMPro;
using UnityEngine;

public class DeathExpander : MonoBehaviour
{
    private TextMeshProUGUI text;

    public float duration = 50f;
    //public float value;
    public GameManager gm;

    public float minFontSize = 14f;
    public float maxFontSize = 80f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.totalDeaths >= 25000)
        {
            StartCoroutine(AnimateDeath());
        }
    }
    
    private IEnumerator AnimateDeath()
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            // Lerp from startSpacing to endSpacing
            text.fontSize = Mathf.Lerp(minFontSize, maxFontSize, t);

            yield return null;
        }
    }
}
