using UnityEngine;
using UnityEngine.SceneManagement;

public class EndUIActions : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
