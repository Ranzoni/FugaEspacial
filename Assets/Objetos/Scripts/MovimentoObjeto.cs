using UnityEngine;

public class MovimentoObjeto : MonoBehaviour
{
    [Tooltip("Velocidade com que o objeto irá se movimentar (Ela será alterada conforme a dificuldade do jogo aumenta)")]
    [SerializeField] float velocidade = 3f;
    [Tooltip("Prefab com o script de Dificuldade do Jogo")]
    [SerializeField] DificuldadeJogo dificuldadeJogo;

    void Update()
    {
        var xValor = FatorVelocidadeBalanceado();
        transform.Translate(xValor, 0, 0);
    }

    float FatorVelocidadeBalanceado()
    {
        return -velocidade * Time.deltaTime * dificuldadeJogo.FatorDificuldade;
    }

    public void Parar()
    {
        velocidade = 0;
    }
}
