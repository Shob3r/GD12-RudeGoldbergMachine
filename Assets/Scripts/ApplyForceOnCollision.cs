using UnityEngine;

public class ApplyForceOnCollision : ObjectCollisionActions
{
    [Tooltip("Input force is calculated as force^3 when the game is running to prevent needing to input massive numbers")]
    public float force = 25f;
    protected override void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        if (DoesColliderHaveRigidBody(other.gameObject))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * Mathf.Pow(force, 3f));
            return;
        }
        if(enableDebugMessages) Debug.LogWarning($"{other.gameObject.name} Does not have a RigidBody attached to it!");
    }

    private bool DoesColliderHaveRigidBody(GameObject collidedObject)
    {
        return collidedObject.GetComponent<Rigidbody>() != null;
    }
}
