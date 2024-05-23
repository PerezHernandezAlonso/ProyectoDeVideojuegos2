using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;
    public Transform target; // The target the camera will follow (e.g., the player)
    public float fixedYPosition = 10f; // The fixed Y position for the camera
    public float smoothSpeed = 0.125f; // Smoothing speed
    private GameObject perritoDetective;

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        perritoDetective = GameObject.Find("PerritoDetective");
        target = perritoDetective.GetComponent<Transform> ();
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Desired position
            Vector3 desiredPosition = new Vector3(target.position.x, fixedYPosition, transform.position.z);
            // Smooth position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Update the camera's position
            transform.position = smoothedPosition;
        }
    }
}