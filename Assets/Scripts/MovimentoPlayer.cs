
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimentação")]
    public float velocidade = 5f;
    public float forcaPulo = 10f;

    [Header("Verificação do Chão")]
    public LayerMask camadaChao;

    private Rigidbody2D rb;
    private BoxCollider2D colisor;
    private float movimento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colisor = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Keyboard teclado = Keyboard.current;

        if (teclado == null)
            return;

        movimento = 0f;

        if (teclado.aKey.isPressed ||
            teclado.leftArrowKey.isPressed)
        {
            movimento = -1f;
        }

        if (teclado.dKey.isPressed ||
            teclado.rightArrowKey.isPressed)
        {
            movimento = 1f;
        }

        if (teclado.spaceKey.wasPressedThisFrame && EstaNoChao())
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                forcaPulo
            );
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(
            movimento * velocidade,
            rb.linearVelocity.y
        );
    }

    bool EstaNoChao()
    {
        Bounds limites = colisor.bounds;

        Vector2 posicaoPes = new Vector2(
            limites.center.x,
            limites.min.y - 0.05f
        );

        return Physics2D.OverlapCircle(
            posicaoPes,
            0.12f,
            camadaChao
        ) != null;
    }
}
