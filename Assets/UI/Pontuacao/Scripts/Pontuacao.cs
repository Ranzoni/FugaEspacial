using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Pontuacao : MonoBehaviour
{
    public int Pontos { get { return pontos; } }

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
}
