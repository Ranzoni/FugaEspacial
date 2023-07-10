using System.Collections;
using UnityEngine;

public class ControladorImpulso : MonoBehaviour
{
    [SerializeField] float impulso = 2f;
    [SerializeField] float quantidade = 100f;
    [SerializeField] float gastoComUso = 10f;
    [SerializeField] float tempoDeGasto = .5f;

    bool estaUsando;
    float quantidadeMaxima;

    void Start()
    {
        quantidadeMaxima = quantidade;
    }

    void Update()
    {
        if (Input.GetButtonUp("Jump"))
            estaUsando = false;

        if (!Input.GetButton("Jump") || estaUsando)
            return;

        estaUsando = true;
        StartCoroutine(ReduzirQuantidade());
    }

    IEnumerator ReduzirQuantidade()
    {
        while (estaUsando && quantidade > 0)
        {
            yield return new WaitForSeconds(tempoDeGasto);
        
            quantidade -= gastoComUso;
        }
    }

    public float Impulso()
    {
        if (!Input.GetButton("Jump") || quantidade <= 0)
            return 0;

        return impulso;
    }

    public float Quantidade()
    {
        return quantidade;
    }

    public float QuantidadeMaxima()
    {
        return quantidadeMaxima;
    }
}
