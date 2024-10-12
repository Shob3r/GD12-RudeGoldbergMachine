using UnityEngine;

public class DestroyFadeIn : MonoBehaviour
{
    private void OnDisable()
    {
        Destroy(gameObject);
    }
}