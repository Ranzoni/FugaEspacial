using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Canvas), typeof(AudioSource))]
public class GameOver : MonoBehaviour
{
    [Tooltip("Tempo de delay para apresentar o menu de Game Over")]
    [SerializeField] float atrasoParaGameOver = 1f;
    [Tooltip("Prefab com o script de Controle de Sessão")]
    [SerializeField] ControladorSessao sessao;
    [Tooltip("Prefab com o script de Seleção do Botão Inicial")]
    [SerializeField] SelecionarBotaoInicial selecionarBotaoInicial;
    [Tooltip("Prefab com o script de Geração de Objetos")]
    [SerializeField] GeradorObjeto geradorObjeto;

    public bool EhGameOver { get { return gameOverCanvas.enabled; } }

    Canvas gameOverCanvas;
    AudioSource somGameOver;

    void Start()
    {
        gameOverCanvas = GetComponent<Canvas>();
        gameOverCanvas.enabled = false;
        somGameOver = GetComponent<AudioSource>();
    }

    public void Apresentar()
    {
        StartCoroutine(Executar());
    }

    IEnumerator Executar()
    {
        geradorObjeto.Parar();

        var meteoros = FindObjectsOfType<MovimentoObjeto>();
        foreach (var meteoro in meteoros)
            meteoro.Parar();

        yield return new WaitForSeconds(atrasoParaGameOver);

        selecionarBotaoInicial.AtivarBotaoGameOver();
        gameOverCanvas.enabled = true;
        sessao.PararJogo();
        somGameOver.Play();
    }
}
