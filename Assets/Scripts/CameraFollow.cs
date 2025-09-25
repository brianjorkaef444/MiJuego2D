using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // Jugador que la cámara seguirá
    public float smoothSpeed = 0.125f;  // Suavidad del movimiento
    public Vector3 offset = new Vector3(0, 0, -10); // Offset de la cámara

    void LateUpdate()
    {
        if (target == null) return; // Evita errores si no hay target asignado

        // Calcula la posición deseada sumando el offset
        Vector3 desiredPosition = target.position + offset;

        // Mantener la cámara siempre en Z = -10 (para 2D)
        desiredPosition.z = -10f;

        // Suaviza el movimiento
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Asigna la posición final
        transform.position = smoothedPosition;
    }
}
