using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Fonction pour lancer le jeu
    public void PlayGame()
    {
        // Charger la scène "Game"
        SceneManager.LoadScene("Game");
    }

    // Fonction pour afficher les crédits
    public void ShowCredits()
    {
        // Charger la scène "Credits"
        SceneManager.LoadScene("Credits");
    }

    // Fonction pour quitter le jeu
    public void QuitGame()
    {
        // Si on est en mode éditeur, arrêter le mode de jeu
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    // Si on est en build, quitter l'application
                    Application.Quit();
        #endif
    }

    // fonction pour revenir au menu principal
    public void ReturnToMenu()
    {
        // Charger la scène "Menu"
        SceneManager.LoadScene("Menu");
    }
}
