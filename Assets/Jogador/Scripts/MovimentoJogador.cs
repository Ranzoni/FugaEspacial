using UnityEngine;

public class MovimentoJogador : MonoBehaviour
{
    [SerializeField] float velocidadeMovimento = 2f;
    [SerializeField] float velocidadeRotacao = 80f;
    [SerializeField] float valorMaximoInclinacao = 0.5f;
    [SerializeField] float velocidadeImpulso = 2f;

    void Update()
    {
        Movimentar();
        Rotacionar();
    }

    float VelocidadePadrao()
    {
        return velocidadeMovimento * Time.deltaTime;
    }

    float VelocidadeComImpulso()
    {
        return (velocidadeImpulso + velocidadeMovimento) * Time.deltaTime;
    }
    
    float FatorMovimentacao()
    {
        if (Input.GetButton("Jump"))
            return VelocidadeComImpulso();

        return VelocidadePadrao();
    }

    void Movimentar()
    {
        var xValor = Input.GetAxis("Horizontal") * FatorMovimentacao();
        var yValor = Input.GetAxis("Vertical") * FatorMovimentacao();
        
        var novaPosicao = new Vector3(xValor, yValor, transform.position.z);
        
        transform.Translate(novaPosicao, Space.World);
    }

    float FatorRotacao()
    {
        return velocidadeRotacao * Time.deltaTime;
    }

    void Rotacionar()
    {
        if (Input.GetAxis("Vertical") != 0)
            Inclinar();
        else
            VoltarInclinacao();
    }

    void Inclinar()
    {
        if (EstaNaInclinacaoMaxima())
            return;

        var fatorRotacao = FatorRotacao();

        if (Input.GetAxis("Vertical") > 0)
            transform.Rotate(Vector3.forward * fatorRotacao);
        else if (Input.GetAxis("Vertical") < 0)
            transform.Rotate(Vector3.back * fatorRotacao);
    }

    bool EstaNaInclinacaoMaxima()
    {
        var rotacaoAtual = transform.rotation.z;
        rotacaoAtual = rotacaoAtual >= 0 ? rotacaoAtual : -rotacaoAtual;

        return rotacaoAtual >= valorMaximoInclinacao;
    }

    void VoltarInclinacao()
    {
        var fatorRotacao = FatorRotacao();

        if (transform.rotation.z > 0)
            transform.Rotate(Vector3.back * fatorRotacao);
        else if (transform.rotation.z < 0)
            transform.Rotate(Vector3.forward * fatorRotacao);
    }
}
