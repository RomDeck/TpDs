using UnityEngine;
using TMPro; // N�cessaire pour utiliser TextMeshProUGUI
using UnityEngine.SceneManagement; // N�cessaire pour recharger la sc�ne ou changer de sc�ne

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 10f; // Temps du chronom�tre en secondes
    private float currentTime;
    private bool timerStarted = false;

    public TextMeshProUGUI timerText; // R�f�rence au texte UI TextMeshProUGUI
    public TextMeshProUGUI gameOverText; // R�f�rence au texte de fin de jeu
    public GameObject restartButton; // R�f�rence au bouton de recommencement
    public GameObject quitButton; // R�f�rence au bouton de quitter

    void Start()
    {
        // Initialise le chronom�tre
        currentTime = countdownTime;
        UpdateTimerText();
        // Assurez-vous que le texte de fin de jeu et les boutons sont cach�s au d�but
        gameOverText.gameObject.SetActive(false);
        restartButton.SetActive(false);
        quitButton.SetActive(false);
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
        gameOverText.gameObject.SetActive(true);
        restartButton.SetActive(true);
        quitButton.SetActive(true);
        // Vous pouvez �galement ajouter d'autres comportements ici
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
