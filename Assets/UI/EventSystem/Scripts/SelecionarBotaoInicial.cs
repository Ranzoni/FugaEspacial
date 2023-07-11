using UnityEngine;
using UnityEngine.UI;

public class SelecionarBotaoInicial : MonoBehaviour
{
    [SerializeField] Button BotaoPrincipalPause;
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
