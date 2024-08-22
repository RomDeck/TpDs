using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour changer de scène

public class QuitButton : MonoBehaviour
{
    // Méthode pour quitter vers le menu principal
    public void QuitToMenu()
    {
        // Assurez-vous que la scène du menu est ajoutée dans la Build Settings avec le nom "Menu" ou ajustez le nom ci-dessous
        SceneManager.LoadScene("Menu");
    }
}
