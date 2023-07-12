using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ControladorDisplayImpuslo : MonoBehaviour
{
    [Tooltip("Prefab com o script de Controle de Impulso")]
    [SerializeField] ControladorImpulso controladorImpulso;

    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = controladorImpulso.Quantidade / controladorImpulso.QuantidadeMaxima;
    }
}
