using UnityEngine;
using UnityEngine.SceneManagement; // N�cessaire pour changer de sc�ne

public class QuitButton : MonoBehaviour
{
    // M�thode pour quitter vers le menu principal
    public void QuitToMenu()
    {
        // Assurez-vous que la sc�ne du menu est ajout�e dans la Build Settings avec le nom "Menu" ou ajustez le nom ci-dessous
        SceneManager.LoadScene("Menu");
    }
}
