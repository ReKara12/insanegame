using UnityEngine;

// Simple 2D top-down camera follow.
// Attach this to the Main Camera and assign the target (usually the Player).
// For more advanced behaviour you can switch to Cinemachine, but this does the job quickly.
[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    [Tooltip("Transform the camera will follow (typically the Player).")]
    public Transform target;

    [Tooltip("Offset between camera and target in world units.")]
    public Vector3 offset = new Vector3(0, 0, -10f);

    [Tooltip("How quickly camera moves to the target position.")]
    public float smoothTime = 0.15f;

    private Vector3 _velocity;

    private void Start()
    {
        if (target == null)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) target = player.transform;
        }
    }

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref _velocity, smoothTime);
    }
}
