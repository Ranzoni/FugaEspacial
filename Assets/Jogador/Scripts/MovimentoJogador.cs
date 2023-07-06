using UnityEngine;

public class MovimentoJogador : MonoBehaviour
{
    [SerializeField] float velocidadeMovimento = 2f;
    [SerializeField] float velocidadeRotacao = 80f;
    [SerializeField] float valorMaximoInclinacao = 0.5f;

    void Update()
    {
        Movimentar();
        Rotacionar();
    }

    float FatorMovimentacao()
    {
        return velocidadeMovimento * Time.deltaTime;
    }

    void Movimentar()
    {
        var xValor = Input.GetAxis("Horizontal") * FatorMovimentacao();
        var yValor = Input.GetAxis("Vertical") * FatorMovimentacao();
        transform.Translate(xValor, yValor, transform.position.z, Space.World);
    }

    float FatorRotacao()
    {
        return velocidadeRotacao * Time.deltaTime;
    }

    void Rotacionar()
    {
        var fatorRotacao = FatorRotacao();

        if (Input.GetButton("Vertical"))
        {
            if (Input.GetAxis("Vertical") > 0 && transform.rotation.z < valorMaximoInclinacao)
                transform.Rotate(Vector3.forward * fatorRotacao);
            else if (Input.GetAxis("Vertical") < 0  && transform.rotation.z > -valorMaximoInclinacao)
                transform.Rotate(Vector3.back * fatorRotacao);
        }
        else
        {
            if (transform.rotation.z > 0)
                transform.Rotate(Vector3.back * fatorRotacao);
            else if (transform.rotation.z < 0)
                transform.Rotate(Vector3.forward * fatorRotacao);
        }
    }
}
