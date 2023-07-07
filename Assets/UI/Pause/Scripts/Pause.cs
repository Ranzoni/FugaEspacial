using UnityEngine;

public class Pause : MonoBehaviour
{
    Canvas pauseCanvas;
    ControladorSessao sessao;
    GameOver gameOver;

    void Start()
    {
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
        pauseCanvas.enabled = true;

        sessao.PararJogo();
    }

    public void Continuar()
    {
        pauseCanvas.enabled = false;

        sessao.ContinuarJogo();
    }
}
