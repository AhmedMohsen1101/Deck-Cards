using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    public void LoadScene(int value)
    {
        SceneManager.LoadSceneAsync(value);
    }
    public void LoadScene(string value)
    {
        SceneManager.LoadSceneAsync(value);
    }
}
