using UnityEngine;

public class RotateMissile : MonoBehaviour
{
    public float rotationSpeed = 100f; // Vitesse de rotation en degrés par seconde

    void Update()
    {
        // Applique une rotation locale autour de l'axe Y (vertical)
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.Self);
    }
}
