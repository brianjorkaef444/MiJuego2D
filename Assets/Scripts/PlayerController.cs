using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    // 🔹 Variables para disparar
    public GameObject bulletPrefab;   // Prefab de la bala
    public Transform firePoint;       // Lugar desde donde disparará

    // 🔹 Variables para el audio
    public AudioClip jumpSound;       // Clip del salto
    private AudioSource audioSource;  // Fuente de audio

    private Rigidbody2D rb;
    private bool isGrounded = true;
    private bool facingRight = true; // Para dirección del personaje

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Aseguramos que haya un AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        // 🔹 Movimiento
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // 🔹 Actualizar dirección
        if (moveInput > 0)
            facingRight = true;
        else if (moveInput < 0)
            facingRight = false;

        // 🔹 Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;

            // 🔹 Reproducir sonido de salto
            if (jumpSound != null && audioSource != null)
                audioSource.PlayOneShot(jumpSound);
        }

        // 🔹 Disparo con la tecla Z
        if (Input.GetKeyDown(KeyCode.Z) && bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().SetDirection(facingRight ? Vector2.right : Vector2.left);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
}
