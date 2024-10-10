using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ToggleGameObjectOnCollision : ObjectCollisionActions
{
    public GameObject[] gamObjectsToToggle;
    public bool toggleOnce = true;

    private bool hasToggled = false;
    

    protected override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
        if (!hasToggled)
        {
            if (toggleOnce) hasToggled = true;
            foreach (GameObject g in gamObjectsToToggle)
            {
                g.SetActive(!g.gameObject.activeSelf);
            }
        }
    }
}
