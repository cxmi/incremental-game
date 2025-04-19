using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugScript : MonoBehaviour
{
    public bool useHider = false;
    public GameObject hider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (useHider)
        {
            hider.SetActive(true);
        }
        else
        {
            hider.SetActive(false);
        }
    }

}
