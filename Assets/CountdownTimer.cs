using UnityEngine;
using TMPro; // Nécessaire pour utiliser TextMeshProUGUI

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 10f; // Temps du chronomètre en secondes
    private float currentTime;
    private bool timerStarted = false;
    private int totalCollectibles; // Nombre total d'objets à collecter
    private int collectedItems = 0; // Nombre d'objets ramassés

    public TextMeshProUGUI timerText; // Référence au texte UI TextMeshProUGUI
    public TextMeshProUGUI gameOverText; // Référence au texte de fin de jeu
    public TextMeshProUGUI victoryText; // Référence au texte de victoire
    public GameObject restartButton; // Référence au bouton de recommencement
    public GameObject quitButton; // Référence au bouton de quitter
    public GameObject player; // Référence au GameObject du personnage
    public GameObject backgroundOverlay; // Référence au fond noir transparent
    public GameObject collectiblesParent; // Référence au parent des objets à collecter

    void Start()
    {
        // Initialise le chronomètre
        currentTime = countdownTime;
        UpdateTimerText();

        // Compter le nombre total d'objets à collecter
        totalCollectibles = collectiblesParent.transform.childCount;

        // Log le nombre total d'objets à collecter
        Debug.Log("Nombre total d'objets à récupérer : " + totalCollectibles);

        // Assurez-vous que le texte de fin de jeu, les boutons, et le fond noir sont cachés au début
        gameOverText.gameObject.SetActive(false);
        victoryText.gameObject.SetActive(false);
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

        Debug.Log("Le chronomètre est terminé!");
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = $"Temps restant : {currentTime:F2}s";
        }
    }

    // Appelé chaque fois qu'un objet est ramassé
    public void CollectItem()
    {
        collectedItems++;

        // Log le nombre d'objets ramassés et restant
        Debug.Log("Objets ramassés : " + collectedItems + " / " + totalCollectibles);

        if (collectedItems >= totalCollectibles)
        {
            Victory();
        }
    }

    void Victory()
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

        // Afficher le texte de victoire et les boutons
        victoryText.gameObject.SetActive(true);
        restartButton.SetActive(true);
        quitButton.SetActive(true);

        Debug.Log("Victoire! Tous les objets ont été ramassés.");
    }
}
