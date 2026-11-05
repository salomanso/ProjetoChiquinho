
using UnityEngine;

public class AtirarPrego : MonoBehaviour
{
    public float velocidade = 12f;
    public float tempoDeVida = 3f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destroy(gameObject, tempoDeVida);
    }

    public void Lancar(int direcao)
    {
        if (rb == null)
        {
            Debug.LogError(
                "O prefab Prego precisa de um Rigidbody2D!",
                gameObject
            );
            return;
        }

        rb.linearVelocity = new Vector2(
            direcao * velocidade,
            0f
        );
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        Destroy(gameObject);
    }
}
