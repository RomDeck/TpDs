using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision détectée avec : " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Munition ramassée !");
            Destroy(gameObject); // Détruire la munition après l'avoir ramassée
        }
    }

}
