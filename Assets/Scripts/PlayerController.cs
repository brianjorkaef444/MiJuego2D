using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    // 🔹 Variables para disparar
    public GameObject bulletPrefab;   // Prefab de la bala
    public Transform firePoint;       // Lugar desde donde disparará

    private Rigidbody2D rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 🔹 Movimiento
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // 🔹 Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        // 🔹 Disparo con la tecla Z
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Instanciamos la bala en la posición del FirePoint
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            
            // Hacemos que la bala se mueva hacia la derecha
            bullet.GetComponent<Bullet>().SetDirection(Vector2.right);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
