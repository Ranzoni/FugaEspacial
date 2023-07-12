using System.Collections;
using UnityEngine;

public class GeradorObjeto : MonoBehaviour
{
    [Header("Objetos")]
    [Tooltip("Prefabs dos objetos que serão gerados")]
    [SerializeField] GameObject[] listaPrefab;
    [Header("Tempo")]
    [Tooltip("Tempo mínimo inicial para gerar os objetos (Ele será reduzido conforme a dificuldade do jogo aumenta)")]
    [SerializeField] float tempoMinimoGeracao = .5f;
    [Tooltip("Tempo máximo inicial para gerar os objetos (Ele será reduzido conforme a dificuldade do jogo aumenta)")]
    [SerializeField] float tempoMaximoGeracao = 1.5f;
    [Tooltip("Tempo mínimo limite para gerar os objetos (O limite mínimo do Tempo Máximo de Geração será definido na soma deste campo com o campo de Tempo Mínimo de Geração)")]
    [SerializeField] float menorTempoPossivel = .001f;
    [Header("Altura")]
    [Tooltip("Altura mínima para gerar os objetos")]
    [SerializeField] float alturaMinima = -5f;
    [Tooltip("Altura máxima para gerar os objetos")]
    [SerializeField] float alturaMaxima = 5f;
    [Header("Item")]
    [Tooltip("Os itens serão gerados neste intervalo de pontos, então caso ele tenha o valor 400 os itens só irão aparecer a cada 400 pontos conquistados. Exemplo: a partir dos 400, depois a partir dos 800, 1200, 1600, ...")]
    [SerializeField] int intervaloPontos = 400;
    [Header("UI")]
    [Tooltip("Prefab com o script de Dificuldade do Jogo")]
    [SerializeField] DificuldadeJogo dificuldadeJogo;
    [Tooltip("Prefab com o script de Pontuação")]
    [SerializeField] Pontuacao pontuacao;

    bool fabricar = true;
    bool podeGerarItem;

    void Start()
    {
        StartCoroutine(Gerar());
    }

    IEnumerator Gerar()
    {
        while (true)
        {
            if (!fabricar)
                break;

            var tempoParaGeracao = TempoBalanceadoParaGeracao();
            var yValor = Random.Range(alturaMinima, alturaMaxima);
            var novaPosicao = new Vector3(transform.position.x, yValor, transform.position.z);

            var prefab = RetornarPrefabAleatorio();
            var novoObjeto = Instantiate(prefab, novaPosicao, Quaternion.identity);

            novoObjeto.transform.parent = transform;
            
            yield return new WaitForSeconds(tempoParaGeracao);
        }
    }

    float TempoBalanceadoParaGeracao()
    {
        var tempoMinimoBalanceado = tempoMinimoGeracao / dificuldadeJogo.FatorDificuldade;
        if (tempoMinimoBalanceado <= 0)
            tempoMinimoBalanceado = menorTempoPossivel;

        var tempoMaximoBalanceado = tempoMaximoGeracao / dificuldadeJogo.FatorDificuldade;
        if (tempoMaximoBalanceado <= tempoMinimoBalanceado)
            return tempoMinimoGeracao + menorTempoPossivel;

        var tempoGeracao = Random.Range(tempoMinimoBalanceado, tempoMaximoGeracao);
        return tempoGeracao;
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

    void Update()
    {
        VerificarSePodeGerarItem();
    }

    void VerificarSePodeGerarItem()
    {
        var pontuacaoAtual = pontuacao.Pontos;
        if (pontuacaoAtual == 0 || podeGerarItem)
            return;

        if (EstaNoIntervaloParaGerarItem(pontuacaoAtual))
            podeGerarItem = true;
    }

    bool EstaNoIntervaloParaGerarItem(int pontuacao)
    {
        return pontuacao % intervaloPontos == 0;
    }

    public void Parar()
    {
        fabricar = false;
    }
}
