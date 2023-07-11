using UnityEngine;
using TMPro;

public class Pontuacao : MonoBehaviour
{
    int pontos;
    TextMeshProUGUI textoPontuacao;

    void Start()
    {
        textoPontuacao = GetComponent<TextMeshProUGUI>();
        textoPontuacao.text = pontos.ToString();
    }

    public void Aumentar(int quantidade)
    {
        pontos += quantidade;

        textoPontuacao.text = pontos.ToString();
    }

    public int Pontos()
    {
        return pontos;
    }
}
