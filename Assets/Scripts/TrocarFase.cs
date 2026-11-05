
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarFase : MonoBehaviour
{
    [Tooltip("Nome exato da próxima cena")]
    public string nomeProximaFase;

    private bool carregando = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (carregando || !other.CompareTag("Player"))
            return;

        if (string.IsNullOrWhiteSpace(nomeProximaFase))
        {
            Debug.LogError("Defina o nome da próxima fase!", this);
            return;
        }

        carregando = true;

        SceneManager.LoadScene(nomeProximaFase);
    }
}
