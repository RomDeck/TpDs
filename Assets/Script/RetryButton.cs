using UnityEngine;
using UnityEngine.SceneManagement; // N�cessaire pour recharger la sc�ne

public class RetryButton : MonoBehaviour
{
    // M�thode pour recommencer le jeu
    public void RestartGame()
    {
        // Recharge la sc�ne actuelle pour recommencer le jeu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
