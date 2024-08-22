using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;
    private Animator animator;

    void Start()
    {
        // Récupère le composant Animator
        animator = GetComponent<Animator>();
    }

    void Update()
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

        Vector3 moveDirection = new Vector3(moveRight, 0, moveForward);
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Définir le paramètre IsWalking de l'Animator en fonction du mouvement
        bool isWalking = moveDirection.magnitude > 0;
        animator.SetBool("IsWalking", isWalking);
    }
}
