
using UnityEngine;

public class GerenciadorColeta : MonoBehaviour
{
    public int totalItens = 0;

    public void AdicionarItem(int quantidade)
    {
        totalItens += quantidade;

        Debug.Log("Itens coletados: " + totalItens);
    }
}
