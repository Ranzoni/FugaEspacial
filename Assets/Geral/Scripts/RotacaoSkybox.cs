using UnityEngine;

public class RotacaoSkybox : MonoBehaviour
{
    [Tooltip("Velocidade de rotação do Skybox")]
    [SerializeField] float velocidadeRotacao = 10f;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", FatorRotacao());
    }

    float FatorRotacao()
    {
        return Time.time * velocidadeRotacao;
    }
}
