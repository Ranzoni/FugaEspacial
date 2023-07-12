using System.Collections;
using UnityEngine;

public class SistemaPontuacao : MonoBehaviour
{
    [Tooltip("Tempo para pontuar (em segundos)")]
    [SerializeField] float tempoPontuacao = 1f;
    [Tooltip("Quantidade de pontos que serão conquistados")]
    [SerializeField] int quantidadePontos = 10;
    [Tooltip("Prefab com o script de Pontuação")]
    [SerializeField] Pontuacao pontuacao;

    void Start()
    {
        StartCoroutine(ProcessoParaPontuacao());
    }

    IEnumerator ProcessoParaPontuacao()
    {
        while (true)
        {
            yield return new WaitForSeconds(tempoPontuacao);

            FazerPontuacao();
        }
    }

    void FazerPontuacao()
    {
        pontuacao.Aumentar(quantidadePontos);
    }
}
