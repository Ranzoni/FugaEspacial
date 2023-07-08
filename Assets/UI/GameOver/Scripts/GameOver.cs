using UnityEngine;

public class GameOver : MonoBehaviour
{
    Canvas gameOverCanvas;
    ControladorSessao sessao;
    bool ehGameOver;
    AudioSource somGameOver;

    void Start()
    {
        sessao = FindObjectOfType<ControladorSessao>();
        gameOverCanvas = GetComponent<Canvas>();
        gameOverCanvas.enabled = false;
        somGameOver = GetComponent<AudioSource>();
    }

    public void Apresentar()
    {
        gameOverCanvas.enabled = true;
        ehGameOver = true;
        sessao.PararJogo();
        somGameOver.Play();
    }

    public bool EhGameOver()
    {
        return ehGameOver;
    }
}
