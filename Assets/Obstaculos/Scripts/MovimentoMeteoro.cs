using UnityEngine;

public class MovimentoMeteoro : MonoBehaviour
{
    [SerializeField] float velocidade = 3f;

    DificuldadeJogo dificuldadeJogo;

    void Start()
    {
        dificuldadeJogo = FindObjectOfType<DificuldadeJogo>();
    }

    void Update()
    {
        var xValor = FatorVelocidadeBalanceado();
        transform.Translate(xValor, 0, 0);
    }

    float FatorVelocidadeBalanceado()
    {
        return -velocidade * Time.deltaTime * dificuldadeJogo.FatorBalanceamento();
    }
}
