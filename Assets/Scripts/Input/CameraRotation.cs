using UnityEngine;
// Yoinked from a previous project, works well enough to use here
public class PlayerCamera : MonoBehaviour
{
    private Camera mainCamera;
    private CameraInput experienceCamera;

    // Is assigned to later in Update()
    private Vector2 mouseDelta;

    private float rotationSpeedX = 1.0f;
    private float rotationSpeedY = 1.0f;

    private const float maxPitch = 85.0f;
    private const float minPitch = -80.0f;

    private float currentPitch;

    private void Start()
    {
        experienceCamera = new CameraInput();
        // Unless changed later, the camera will be a child of the player model
        mainCamera = GetComponentInChildren<Camera>();
        experienceCamera.Enable();
    }

    private void Update()
    {
        // If the game is paused, do not run the camera rotation method
        if (Time.timeScale == 0)
        {
            return;
        }
        // Reads information being fed through the Look action in PlayerInput and assigns it to mouseDelta 
        // OnFoot.Look() is a pass through value 
        // This works on any input device (i.e. Mouse, Controller, Fire TV Stick, etc)

        OnPlayerLook(experienceCamera.Default.Look.ReadValue<Vector2>());
    }

    
    private void OnPlayerLook(Vector2 lookMouseDelta)
    {
        // Thanks to Phind AI (GPT) for doing the Quaternion stuff because I can't wrap my head around it yet
        float rotationX = lookMouseDelta.x * rotationSpeedX;
        float rotationY = -lookMouseDelta.y * rotationSpeedY;

        // Clamp the maximum Y rotation on the camera to minPitch (-85 degrees) and maxPitch (80 degrees)
        currentPitch = Mathf.Clamp(currentPitch + rotationY, minPitch, maxPitch);
        rotationY = currentPitch;

        // From what I understand of this math, it converts the rotation to something that can be used in transform.Rotate (Quaternion)
        mainCamera.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);
        transform.Rotate(0, rotationX, 0);

        // Reset Z rotation
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }

    // The next two methods are for the main menu to work, not much else has to be said about it
    public void SetSensitivity(float newRotationSpeed)
    {
        // I have no clue but if I don't divide the new rotation speed by 100 then it will make the sensitivity so high that the game becomes unplayable
        rotationSpeedX = newRotationSpeed / 100;
        rotationSpeedY = newRotationSpeed / 100;
    }

    public void SetFieldOfView(int newFieldOfView)
    {
        mainCamera.fieldOfView = newFieldOfView;
    }

    private void OnDestroy()
    {
        experienceCamera.Disable();
    }
}