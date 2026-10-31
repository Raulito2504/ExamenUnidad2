using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{
    private Vector2 movimiento;

    private Rigidbody2D rb;
    public float velocidad = 3f;
    public float salto = 4f;
    public float rebote = 10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void OnMove(InputValue value)
    {
        movimiento = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        rb.AddForce(movimiento * velocidad);
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("lava"))
        {
            Debug.Log("Te moriste");
        }
        else if (collision.gameObject.CompareTag("meta"))
        {
            Debug.Log("ganaste");
        }
        else if (collision.gameObject.CompareTag("rebote"))
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                rebote
            );
        }

    }
}