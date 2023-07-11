using UnityEngine;

public class Pause : MonoBehaviour
{
    Canvas pauseCanvas;
    ControladorSessao sessao;
    GameOver gameOver;
    SelecionarBotaoInicial selecionarBotaoInicial;

    void Start()
    {
        selecionarBotaoInicial = FindObjectOfType<SelecionarBotaoInicial>();
        sessao = FindObjectOfType<ControladorSessao>();
        gameOver = FindObjectOfType<GameOver>();
        pauseCanvas = GetComponent<Canvas>();
        pauseCanvas.enabled = false;
    }

    void Update()
    {
        if (!Input.GetButtonDown("Cancel") || gameOver.EhGameOver())
            return;

        if (sessao.JogoEstaParado())
            Continuar();
        else
            Pausar();
    }

    void Pausar()
    {
        selecionarBotaoInicial.AtivarBotaoPause();
        pauseCanvas.enabled = true;

        sessao.PararJogo();
    }

    public void Continuar()
    {
        pauseCanvas.enabled = false;

        sessao.ContinuarJogo();
    }

    public bool EstaPausado()
    {
        return pauseCanvas.enabled;
    }
}
