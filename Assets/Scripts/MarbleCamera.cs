using System;
using System.Collections;
using UnityEngine;

public class MarbleCamera : MonoBehaviour
{
    public GameObject marble;
    public float minDistance = 1.5f;
    public float moveTime = 0.5f;

    private void Start()
    {
        StartCoroutine(moveCameraTowardsMarble());
    }

    private IEnumerator moveCameraTowardsMarble()
    {
            float currentMovetime = 0f;
            while (GetDistanceToMarble() >= minDistance)
            {
                currentMovetime += Time.deltaTime;
                transform.localPosition = Vector3.Lerp(gameObject.transform.position, marble.transform.position, currentMovetime / moveTime);
                yield return null;
            }
    }
    
    private float GetDistanceToMarble()
    {
        return Vector3.Distance(gameObject.transform.position, marble.transform.position);
    }
}