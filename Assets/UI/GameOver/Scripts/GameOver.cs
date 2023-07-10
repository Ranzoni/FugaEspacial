using UnityEngine;

public class GameOver : MonoBehaviour
{
    Canvas gameOverCanvas;
    ControladorSessao sessao;
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
        sessao.PararJogo();
        somGameOver.Play();
    }

    public bool EhGameOver()
    {
        return gameOverCanvas.enabled;
    }
}
