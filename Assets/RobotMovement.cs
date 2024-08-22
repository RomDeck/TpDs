using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;
    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        // Récupère le composant Animator et Rigidbody
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
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

        // Utiliser Rigidbody pour déplacer le robot
        rb.MovePosition(rb.position + movement);

        // Rotation
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Définir le paramètre IsWalking de l'Animator en fonction du mouvement
        bool isWalking = moveDirection.magnitude > 0;
        animator.SetBool("IsWalking", isWalking);
    }
}
