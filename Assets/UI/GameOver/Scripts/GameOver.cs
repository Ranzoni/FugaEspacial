using UnityEngine;

public class GameOver : MonoBehaviour
{
    Canvas gameOverCanvas;
    ControladorSessao sessao;
    bool ehGameOver;

    void Start()
    {
        sessao = FindObjectOfType<ControladorSessao>();
        gameOverCanvas = GetComponent<Canvas>();
        gameOverCanvas.enabled = false;

    }

    public void Apresentar()
    {
        gameOverCanvas.enabled = true;
        ehGameOver = true;
        sessao.PararJogo();
    }

    public bool EhGameOver()
    {
        return ehGameOver;
    }
}
