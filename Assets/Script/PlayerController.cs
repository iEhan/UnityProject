using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;
    Rigidbody rb;
    public float moveSpeed = 5.0f;
    public float jumpForce = 7.0f;

    public int maxHealth = 1;
    [SerializeField] int currentHealth;

    private Camera mainCamera;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }
    public void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        Vector3 moveDirection = cameraForward.normalized * verticalInput + cameraRight.normalized * horizontalInput;

        if (moveDirection != Vector3.zero)
        {
            //change rotation
            transform.forward = moveDirection;

            //move the character
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }

    public void Jump()
    {
       if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Damage"))
        {
            Vector3 damageDirection = other.transform.position - transform.position;

            damageDirection.Normalize();

            rb.AddForce(-damageDirection * 2f, ForceMode.Impulse);

            currentHealth -= 1;

            if (currentHealth <= 0)
            {
                gameManager.Restart();
            }

            gameManager.UpdatehealthText(currentHealth, maxHealth);
        }
    }
}
