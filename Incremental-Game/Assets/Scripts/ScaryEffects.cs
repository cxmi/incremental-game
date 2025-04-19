using System.Collections;
using TMPro;
using UnityEngine;

public class ScaryEffects : MonoBehaviour
{
    public TextMeshProUGUI endingText;
    public float duration = 6f;
    public float startSpacing = 0f;
    public float endSpacing = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(AnimateTextSpacing());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator AnimateTextSpacing()
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            // Lerp from startSpacing to endSpacing
            endingText.characterSpacing = Mathf.Lerp(startSpacing, endSpacing, t);

            yield return null;
        }
    }
}
