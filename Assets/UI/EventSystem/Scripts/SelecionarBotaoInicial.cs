using UnityEngine;
using UnityEngine.UI;

public class SelecionarBotaoInicial : MonoBehaviour
{
    [Tooltip("Botão inicial do menu de Pause do jogo")]
    [SerializeField] Button BotaoPrincipalPause;
    [Tooltip("Botão inicial do menu de Game Over do jogo")]
    [SerializeField] Button BotaoPrincipalGameOver;

    public void AtivarBotaoPause()
    {
        BotaoPrincipalPause.Select();
    }

    public void AtivarBotaoGameOver()
    {
        BotaoPrincipalGameOver.Select();
    }
}
