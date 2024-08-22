using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 50f;

    void Update()
    {
        // Tourner l'objet autour de l'axe Y
        transform.Rotate(Vector2.up, rotationSpeed * Time.deltaTime, Space.Self);
    }
}
