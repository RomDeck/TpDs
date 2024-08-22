using UnityEngine;
using TMPro; // Nécessaire pour utiliser TextMeshProUGUI

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 10f; // Temps du chronomètre en secondes
    private float currentTime;
    private bool timerStarted = false;

    public TextMeshProUGUI timerText; // Référence au texte UI TextMeshProUGUI
    public TextMeshProUGUI gameOverText; // Référence au texte de fin de jeu
    public GameObject restartButton; // Référence au bouton de recommencement
    public GameObject quitButton; // Référence au bouton de quitter
    public GameObject player; // Référence au GameObject du personnage
    public GameObject backgroundOverlay; // Référence au fond noir transparent

    void Start()
    {
        // Initialise le chronomètre
        currentTime = countdownTime;
        UpdateTimerText();

        // Assurez-vous que le texte de fin de jeu, les boutons, et le fond noir sont cachés au début
        gameOverText.gameObject.SetActive(false);
        restartButton.SetActive(false);
        quitButton.SetActive(false);
        backgroundOverlay.SetActive(false); // Masque le fond noir transparent
    }

    void Update()
    {
        // Vérifie si l'utilisateur appuie sur une touche de déplacement pour la première fois
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            if (!timerStarted)
            {
                StartTimer();
            }
        }

        // Décompte du temps
        if (timerStarted)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0f)
            {
                currentTime = 0f;
                TimerEnded();
            }
            UpdateTimerText();
        }
    }

    void StartTimer()
    {
        timerStarted = true;
    }

    void TimerEnded()
    {
        timerStarted = false;

        // Désactiver le script de mouvement du personnage
        if (player != null)
        {
            player.GetComponent<RobotMovement>().enabled = false;
        }

        // Afficher le fond noir transparent
        if (backgroundOverlay != null)
        {
            backgroundOverlay.SetActive(true);
        }

        // Afficher le texte de fin de jeu et les boutons
        gameOverText.gameObject.SetActive(true);
        restartButton.SetActive(true);
        quitButton.SetActive(true);

        // Ajoutez ici d'autres comportements si nécessaire
        Debug.Log("Le chronomètre est terminé!");
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = $"Temps restant : {currentTime:F2}s";
        }
    }
}
