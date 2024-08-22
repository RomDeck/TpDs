using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    private CountdownTimer countdownTimer;

    void Start()
    {
        // Trouver le CountdownTimer dans la scène
        countdownTimer = FindObjectOfType<CountdownTimer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Appelle la méthode CollectItem du CountdownTimer
            if (countdownTimer != null)
            {
                countdownTimer.CollectItem();
                Debug.Log("Munition ramassée !");
            }

            // Détruire l'objet après l'avoir ramassé
            Destroy(gameObject);
        }
    }
}
