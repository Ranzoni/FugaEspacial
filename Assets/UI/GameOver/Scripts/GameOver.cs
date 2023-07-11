using System.Collections;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    Canvas gameOverCanvas;
    ControladorSessao sessao;
    AudioSource somGameOver;
    SelecionarBotaoInicial selecionarBotaoInicial;

    void Start()
    {
        sessao = FindObjectOfType<ControladorSessao>();
        gameOverCanvas = GetComponent<Canvas>();
        gameOverCanvas.enabled = false;
        somGameOver = GetComponent<AudioSource>();
        selecionarBotaoInicial = FindObjectOfType<SelecionarBotaoInicial>();
    }

    public void Apresentar()
    {
        StartCoroutine(Executar());
    }

    IEnumerator Executar()
    {
        var geradorMeteoro = FindObjectOfType<GeradorMeteoro>();
        geradorMeteoro.Parar();

        var meteoros = FindObjectsOfType<MovimentoMeteoro>();
        foreach (var meteoro in meteoros)
            meteoro.Parar();

        yield return new WaitForSeconds(1f);

        selecionarBotaoInicial.AtivarBotaoGameOver();
        gameOverCanvas.enabled = true;
        sessao.PararJogo();
        somGameOver.Play();
    }

    public bool EhGameOver()
    {
        return gameOverCanvas.enabled;
    }
}
