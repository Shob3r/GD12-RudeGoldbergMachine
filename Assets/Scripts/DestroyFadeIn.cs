using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFadeIn : MonoBehaviour
{
    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
