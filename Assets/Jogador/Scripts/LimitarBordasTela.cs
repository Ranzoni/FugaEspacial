using UnityEngine;

public class LimitarBordasTela : MonoBehaviour
{
    Vector3 posicaoBordasTela;
    float larguraJogador;
    float alturaJogador;

    void Start()
    {
        posicaoBordasTela = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        larguraJogador = GetComponentInChildren<MeshRenderer>().bounds.size.x / 2;
        alturaJogador = GetComponentInChildren<MeshRenderer>().bounds.size.y / 2;
    }

    void Update()
    {
        var posicaoAtual = transform.position;
        var valorLimiteX = posicaoBordasTela.x + larguraJogador;
        var valorLimiteY = posicaoBordasTela.y + alturaJogador;
        posicaoAtual.x = Mathf.Clamp(posicaoAtual.x, valorLimiteX, -valorLimiteX);
        posicaoAtual.y = Mathf.Clamp(posicaoAtual.y, valorLimiteY, -valorLimiteY);

        transform.position = posicaoAtual;
    }
}
