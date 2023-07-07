using System.Collections;
using UnityEngine;

public class SistemaPontuacao : MonoBehaviour
{
    [SerializeField] int pontuacaoPorSegundo = 10;

    Pontuacao pontuacao;

    void Start()
    {
        pontuacao = FindObjectOfType<Pontuacao>();
        StartCoroutine(ProcessoParaPontuacao());
    }

    IEnumerator ProcessoParaPontuacao()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            FazerPontuacao();
        }
    }

    void FazerPontuacao()
    {
        pontuacao.Aumentar(pontuacaoPorSegundo);
    }
}
