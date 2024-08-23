using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;
    public AudioSource footstepSource;  // L'AudioSource attach�e au robot
    public AudioClip footstepClip;  // Le son des pas
    public float footstepInterval = 0.5f;  // Intervalle entre chaque son de pas

    private Animator animator;
    private Rigidbody rb;
    private float nextFootstepTime;

    void Start()
    {
        // R�cup�re le composant Animator et Rigidbody
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        // Assure-toi que l'AudioSource est configur� correctement
        if (footstepSource != null)
        {
            footstepSource.clip = footstepClip;
            footstepSource.loop = false;  // Ne pas faire boucler le son des pas
        }
    }

    void FixedUpdate()
    {
        float moveForward = 0f;
        float moveRight = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveForward = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveForward = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveRight = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveRight = 1f;
        }

        Vector3 moveDirection = new Vector3(moveRight, 0, moveForward).normalized;
        Vector3 movement = moveDirection * speed * Time.deltaTime;

        // Utiliser Rigidbody pour d�placer le robot
        rb.MovePosition(rb.position + movement);

        // Rotation
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // D�finir le param�tre IsWalking de l'Animator en fonction du mouvement
        bool isWalking = moveDirection.magnitude > 0;
        animator.SetBool("IsWalking", isWalking);

        // G�rer le son des pas
        HandleFootsteps(isWalking);
    }

    void HandleFootsteps(bool isWalking)
    {
        if (isWalking)
        {
            // Jouer le son des pas � un intervalle d�fini
            if (Time.time >= nextFootstepTime)
            {
                PlayFootstep();
                nextFootstepTime = Time.time + footstepInterval;
            }
        }
        else
        {
            // Arr�ter le son des pas lorsqu'on arr�te de marcher
            if (footstepSource.isPlaying)
            {
                footstepSource.Stop();
            }
        }
    }

    void PlayFootstep()
    {
        if (footstepSource != null && footstepClip != null)
        {
            footstepSource.PlayOneShot(footstepClip);
        }
    }
}
