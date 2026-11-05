
using UnityEngine;
using UnityEngine.InputSystem;

public class AtaqueDoPlayer : MonoBehaviour
{
    [Header("Configuração do projétil")]
    public GameObject projetilPrefab;
    public Transform firePoint;

    [Header("Configuração do ataque")]
    public float intervaloAtaque = 0.3f;

    private int direcao = 1;
    private float proximoAtaque = 0f;

    void Update()
    {
        Keyboard teclado = Keyboard.current;

        if (teclado == null)
            return;

        // Define para qual lado o jogador está olhando.
        if (teclado.aKey.isPressed ||
            teclado.leftArrowKey.isPressed)
        {
            direcao = -1;
        }
        else if (teclado.dKey.isPressed ||
                 teclado.rightArrowKey.isPressed)
        {
            direcao = 1;
        }

        // Posiciona o ponto de lançamento no lado correto.
        if (firePoint != null)
        {
            Vector3 posicao = firePoint.localPosition;
            posicao.x = Mathf.Abs(posicao.x) * direcao;
            firePoint.localPosition = posicao;
        }

        Mouse mouse = Mouse.current;

        if (mouse != null &&
            mouse.leftButton.wasPressedThisFrame &&
            Time.time >= proximoAtaque)
        {
            Atacar();
            proximoAtaque = Time.time + intervaloAtaque;
        }
    }

    void Atacar()
    {
        if (projetilPrefab == null)
        {
            Debug.LogError(
                "Arraste o prefab Prego para o campo Projetil Prefab!",
                this
            );
            return;
        }

        if (firePoint == null)
        {
            Debug.LogError(
                "Arraste o FirePoint para o campo Fire Point!",
                this
            );
            return;
        }

        GameObject novoProjetil = Instantiate(
            projetilPrefab,
            firePoint.position,
            Quaternion.identity
        );

        AtirarPrego movimento =
            novoProjetil.GetComponent<AtirarPrego>();

        if (movimento != null)
        {
            movimento.Lancar(direcao);
        }
        else
        {
            Debug.LogError(
                "O prefab Prego não possui o script AtirarPrego!",
                novoProjetil
            );

            Destroy(novoProjetil);
        }
    }
}
