using UnityEngine;

public class FogoFX : MonoBehaviour
{
    [SerializeField] GameObject fogoPadraoDireitoVFX;
    [SerializeField] GameObject fogoPadraoEsquerdoVFX;
    [SerializeField] GameObject fogoImpulsoDireitoVFX;
    [SerializeField] GameObject fogoImpulsoEsquerdoVFX;

    ControladorImpulso controladorImpulso;

    void Start()
    {
        controladorImpulso = GetComponent<ControladorImpulso>();
    }

    void Update()
    {
        if (Input.GetButton("Jump") && controladorImpulso.Quantidade() > 0)
        {
            ConfigurarFogo(false, fogoPadraoDireitoVFX, fogoPadraoEsquerdoVFX);
            ConfigurarFogo(true, fogoImpulsoDireitoVFX, fogoImpulsoEsquerdoVFX);
        }
        else
        {
            ConfigurarFogo(true, fogoPadraoDireitoVFX, fogoPadraoEsquerdoVFX);
            ConfigurarFogo(false, fogoImpulsoDireitoVFX, fogoImpulsoEsquerdoVFX);
        }
    }

    void ConfigurarFogo(bool habilitar, GameObject fogoDireito, GameObject fogoEsquerdo)
    {
        fogoDireito.SetActive(habilitar);
        fogoEsquerdo.SetActive(habilitar);
    }
}
