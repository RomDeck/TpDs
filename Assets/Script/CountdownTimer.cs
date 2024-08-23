using UnityEngine;
using TMPro; // N�cessaire pour utiliser TextMeshProUGUI

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 10f; // Temps du chronom�tre en secondes
    private float currentTime;
    private bool timerStarted = false;
    private int totalCollectibles; // Nombre total d'objets � collecter
    private int collectedItems = 0; // Nombre d'objets ramass�s

    public TextMeshProUGUI timerText; // R�f�rence au texte UI TextMeshProUGUI
    public TextMeshProUGUI gameOverText; // R�f�rence au texte de fin de jeu
    public TextMeshProUGUI victoryText; // R�f�rence au texte de victoire
    public GameObject restartButton; // R�f�rence au bouton de recommencement
    public GameObject quitButton; // R�f�rence au bouton de quitter
    public GameObject player; // R�f�rence au GameObject du personnage
    public GameObject backgroundOverlay; // R�f�rence au fond noir transparent
    public GameObject collectiblesParent; // R�f�rence au parent des objets � collecter

    public AudioSource victoryAudioSource; // R�f�rence � l'AudioSource pour la victoire
    public AudioSource defeatAudioSource; // R�f�rence � l'AudioSource pour la d�faite
    private RobotMovement robotMovement; // R�f�rence au script RobotMovement

    void Start()
    {
        // Initialise le chronom�tre
        currentTime = countdownTime;
        UpdateTimerText();

        // Compter le nombre total d'objets � collecter
        totalCollectibles = collectiblesParent.transform.childCount;

        // Log le nombre total d'objets � r�cup�rer
        Debug.Log("Nombre total d'objets � r�cup�rer : " + totalCollectibles);

        // Assurez-vous que le texte de fin de jeu, les boutons, et le fond noir sont cach�s au d�but
        gameOverText.gameObject.SetActive(false);
        victoryText.gameObject.SetActive(false);
        restartButton.SetActive(false);
        quitButton.SetActive(false);
        backgroundOverlay.SetActive(false); // Masque le fond noir transparent

        // Obtenir le script RobotMovement
        if (player != null)
        {
            robotMovement = player.GetComponent<RobotMovement>();
        }
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

        // Jouer le son de d�faite
        if (defeatAudioSource != null)
        {
            defeatAudioSource.Play();
        }

        // Arr�ter le son de marche
        if (robotMovement != null && robotMovement.footstepSource != null && robotMovement.footstepSource.isPlaying)
        {
            robotMovement.footstepSource.Stop();
        }

        Debug.Log("Le chronom�tre est termin�!");
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = $"Temps restant : {currentTime:F2}s";
        }
    }

    // Appel� chaque fois qu'un objet est ramass�
    public void CollectItem()
    {
        collectedItems++;

        // Log le nombre d'objets ramass�s et restant
        Debug.Log("Objets ramass�s : " + collectedItems + " / " + totalCollectibles);

        if (collectedItems >= totalCollectibles)
        {
            Victory();
        }
    }

    void Victory()
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

        // Afficher le texte de victoire et les boutons
        victoryText.gameObject.SetActive(true);
        restartButton.SetActive(true);
        quitButton.SetActive(true);

        // Jouer le son de victoire
        if (victoryAudioSource != null)
        {
            victoryAudioSource.Play();
        }

        // Arr�ter le son de marche
        if (robotMovement != null && robotMovement.footstepSource != null && robotMovement.footstepSource.isPlaying)
        {
            robotMovement.footstepSource.Stop();
        }

        Debug.Log("Victoire! Tous les objets ont �t� ramass�s.");
    }
}
