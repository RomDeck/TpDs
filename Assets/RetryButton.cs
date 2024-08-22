using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour recharger la scène

public class RetryButton : MonoBehaviour
{
    // Méthode pour recommencer le jeu
    public void RestartGame()
    {
        // Recharge la scène actuelle pour recommencer le jeu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
