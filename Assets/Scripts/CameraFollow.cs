using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // El jugador que la cámara seguirá
    public float smoothSpeed = 0.125f; // Suavidad del movimiento
    public Vector3 offset;         // Distancia de la cámara respecto al jugador

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
