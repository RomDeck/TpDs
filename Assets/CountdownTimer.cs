using UnityEngine;
using TMPro; // N�cessaire pour utiliser TextMeshProUGUI

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 10f; // Temps du chronom�tre en secondes
    private float currentTime;
    private bool timerStarted = false;

    public TextMeshProUGUI timerText; // R�f�rence au texte UI TextMeshProUGUI
    public TextMeshProUGUI gameOverText; // R�f�rence au texte de fin de jeu
    public GameObject restartButton; // R�f�rence au bouton de recommencement
    public GameObject quitButton; // R�f�rence au bouton de quitter
    public GameObject player; // R�f�rence au GameObject du personnage
    public GameObject backgroundOverlay; // R�f�rence au fond noir transparent

    void Start()
    {
        // Initialise le chronom�tre
        currentTime = countdownTime;
        UpdateTimerText();

        // Assurez-vous que le texte de fin de jeu, les boutons, et le fond noir sont cach�s au d�but
        gameOverText.gameObject.SetActive(false);
        restartButton.SetActive(false);
        quitButton.SetActive(false);
        backgroundOverlay.SetActive(false); // Masque le fond noir transparent
    }

    void Update()
    {
        // V�rifie si l'utilisateur appuie sur une touche de d�placement pour la premi�re fois
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            if (!timerStarted)
            {
                StartTimer();
            }
        }

        // D�compte du temps
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

        // D�sactiver le script de mouvement du personnage
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

        // Ajoutez ici d'autres comportements si n�cessaire
        Debug.Log("Le chronom�tre est termin�!");
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = $"Temps restant : {currentTime:F2}s";
        }
    }
}
