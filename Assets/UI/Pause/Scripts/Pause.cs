using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class Pause : MonoBehaviour
{
    [Tooltip("Prefab com o script de Controle de Sessão")]
    [SerializeField] ControladorSessao sessao;
    [Tooltip("Prefab com o script de Game Over do jogo")]
    [SerializeField] GameOver gameOver;
    [Tooltip("Prefab com o script de Seleção do Botão Inicial")]
    [SerializeField] SelecionarBotaoInicial selecionarBotaoInicial;

    public bool EstaPausado { get { return pauseCanvas.enabled; } }

    Canvas pauseCanvas;

    void Start()
    {
        pauseCanvas = GetComponent<Canvas>();
        pauseCanvas.enabled = false;
    }

    void Update()
    {
        if (!Input.GetButtonDown("Cancel") || gameOver.EhGameOver)
            return;

        if (EstaPausado)
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
}
