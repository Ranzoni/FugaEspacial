using System.Collections;
using UnityEngine;

public class GeradorObjeto : MonoBehaviour
{
    [SerializeField] GameObject[] listaPrefab;
    [SerializeField] float tempoMinimoGeracao = .5f;
    [SerializeField] float tempoMaximoGeracao = 1.5f;
    [SerializeField] float menorTempoPossivel = .001f;
    [SerializeField] float alturaMinima = -5f;
    [SerializeField] float alturaMaxima = 5f;
    [SerializeField] int intervaloPontuacao = 400;

    bool fabricar = true;
    DificuldadeJogo dificuldadeJogo;
    Pontuacao pontuacao;
    bool podeGerarItem;

    void Start()
    {
        dificuldadeJogo = FindObjectOfType<DificuldadeJogo>();
        pontuacao = FindObjectOfType<Pontuacao>();

        StartCoroutine(Gerar());
    }

    void Update()
    {
        VerificarSePodeGerarItem();
    }

    IEnumerator Gerar()
    {
        while (true)
        {
            if (!fabricar)
                break;

            var tempoEspera = TempoEspera();
            var yValor = Random.Range(alturaMinima, alturaMaxima);
            var novaPosicao = new Vector3(transform.position.x, yValor, transform.position.z);

            var prefab = RetornarPrefabAleatorio();
            var novoObjeto = Instantiate(prefab, novaPosicao, Quaternion.identity);

            novoObjeto.transform.parent = transform;
            
            yield return new WaitForSeconds(tempoEspera);
        }
    }

    float TempoEspera()
    {
        var tempoMinimoBalanceado = tempoMinimoGeracao / dificuldadeJogo.FatorBalanceamento();
        if (tempoMinimoBalanceado <= 0)
            tempoMinimoBalanceado = menorTempoPossivel;

        var tempoMaximoBalanceado = tempoMaximoGeracao / dificuldadeJogo.FatorBalanceamento();
        if (tempoMaximoBalanceado <= tempoMinimoBalanceado)
            return tempoMinimoGeracao + menorTempoPossivel;

        var tempoEspera = Random.Range(tempoMinimoBalanceado, tempoMaximoGeracao);
        return tempoEspera;
    }

    GameObject RetornarPrefabAleatorio()
    {
        while (true)
        {
            var index = Random.Range(0, listaPrefab.Length);
            if (listaPrefab[index].tag == "Item")
            {
                if (!podeGerarItem)
                    continue;

                podeGerarItem = false;
            }

            return listaPrefab[index];
        };
    }

    void VerificarSePodeGerarItem()
    {
        var pontuacaoAtual = pontuacao.Pontos();
        if (pontuacaoAtual == 0 || podeGerarItem)
            return;

        podeGerarItem = pontuacaoAtual % intervaloPontuacao == 0;
    }

    public void Parar()
    {
        fabricar = false;
    }
}
