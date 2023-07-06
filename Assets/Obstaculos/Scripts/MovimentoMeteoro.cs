using UnityEngine;

public class MovimentoMeteoro : MonoBehaviour
{
    [SerializeField] float velocidade = 3f;

    void Update()
    {
        var xValor = -velocidade * Time.deltaTime;
        transform.Translate(xValor, 0, 0);
    }
}
