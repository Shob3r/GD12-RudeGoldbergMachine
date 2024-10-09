using UnityEngine;

public class SetGameSpeed : MonoBehaviour
{
    [Range(0, 1)]
    public float gameSpeed = 1f;

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }
}
