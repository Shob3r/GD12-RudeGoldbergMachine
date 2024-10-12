using UnityEngine;

public class ToggleGameObjectOnCollision : ObjectCollisionActions
{
    public GameObject[] gamObjectsToToggle;
    public bool toggleOnce = true;

    private bool hasToggled;


    protected override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
        if (!hasToggled)
        {
            if (toggleOnce) hasToggled = true;
            foreach (var g in gamObjectsToToggle) g.SetActive(!g.gameObject.activeSelf);
        }
    }
}