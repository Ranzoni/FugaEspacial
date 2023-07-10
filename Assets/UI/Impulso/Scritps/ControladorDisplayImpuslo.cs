using UnityEngine;
using UnityEngine.UI;

public class ControladorDisplayImpuslo : MonoBehaviour
{
    [SerializeField] ControladorImpulso controladorImpulso;

    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = controladorImpulso.Quantidade() / controladorImpulso.QuantidadeMaxima();
    }
}
