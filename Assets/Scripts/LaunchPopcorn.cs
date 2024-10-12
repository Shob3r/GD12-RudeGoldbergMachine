using UnityEngine;

public class LaunchPopcorn : MonoBehaviour
{
    public float forceToApply = 5f;
    public Vector3 launchDirection;

    private Rigidbody popcornRigidBody;

    private void Start()
    {
        popcornRigidBody = GetComponent<Rigidbody>();
    }

    public void AnimatorLaunchPopcorn()
    {
        Vector3 normalizedLaunchDirection = launchDirection.normalized;
        popcornRigidBody.AddForce(normalizedLaunchDirection * forceToApply, ForceMode.Impulse);
    }
}
