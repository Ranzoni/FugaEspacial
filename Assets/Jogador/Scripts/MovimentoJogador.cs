using UnityEngine;

[RequireComponent(typeof(ControladorImpulso))]
public class MovimentoJogador : MonoBehaviour
{
    [Tooltip("Velocidade com que a nave irá se movimentar")]
    [SerializeField] float velocidade = 2f;
    [Tooltip("Velocidade com que a nave irá se inclinar ao se movimentar na vertical")]
    [SerializeField] float velocidadeInclinacao = 80f;
    [Tooltip("A inclinação máxima que a nave atingirá ao se movimentar na vertical")]
    [SerializeField] float inclinacaoMaxima = 0.5f;

    ControladorImpulso controladorImpulso;

    void Start()
    {
        controladorImpulso = GetComponent<ControladorImpulso>();
    }

    void Update()
    {
        Movimentar();
        Rotacionar();
    }
    
    float FatorMovimentacao()
    {
        var velocidadeTotal = controladorImpulso.Impulso + velocidade;

        return velocidadeTotal * Time.deltaTime;
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
        return velocidadeInclinacao * Time.deltaTime;
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

        return rotacaoAtual >= inclinacaoMaxima;
    }

    void VoltarInclinacao()
    {
        var fatorRotacao = FatorRotacao();
        var rotationZ = Mathf.Round(transform.rotation.z * 100f) / 100f;

        if (rotationZ > 0)
            transform.Rotate(Vector3.back * fatorRotacao);
        else if (rotationZ < 0)
            transform.Rotate(Vector3.forward * fatorRotacao);
    }
}
