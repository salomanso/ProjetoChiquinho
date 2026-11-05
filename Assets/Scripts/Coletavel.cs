
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    public int quantidade = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GerenciadorColeta gerenciador =
                FindFirstObjectByType<GerenciadorColeta>();

            if (gerenciador != null)
            {
                gerenciador.AdicionarItem(quantidade);
            }

            Destroy(gameObject);
        }
    }
}
