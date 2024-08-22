using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision d�tect�e avec : " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Munition ramass�e !");
            Destroy(gameObject); // D�truire la munition apr�s l'avoir ramass�e
        }
    }

}
