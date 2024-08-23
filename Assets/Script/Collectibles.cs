using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    private CountdownTimer countdownTimer;

    void Start()
    {
        // Trouver le CountdownTimer dans la sc�ne
        countdownTimer = FindObjectOfType<CountdownTimer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Appelle la m�thode CollectItem du CountdownTimer
            if (countdownTimer != null)
            {
                countdownTimer.CollectItem();
                Debug.Log("Munition ramass�e !");
            }

            // D�truire l'objet apr�s l'avoir ramass�
            Destroy(gameObject);
        }
    }
}
