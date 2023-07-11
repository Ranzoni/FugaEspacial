using System.Collections;
using UnityEngine;

public class ControladorImpulso : MonoBehaviour
{
    [SerializeField] float impulso = 2f;
    [SerializeField] float quantidade = 100f;
    [SerializeField] float gastoComUso = 10f;
    [SerializeField] float tempoDeGasto = .5f;
    [SerializeField] float quantidadeParaRecuperar = 20f;

    bool emUso;
    float quantidadeMaxima;

    void Start()
    {
        quantidadeMaxima = quantidade;
    }

    void Update()
    {
        if (Input.GetButtonUp("Jump"))
            emUso = false;

        if (!Input.GetButton("Jump") || emUso)
            return;

        emUso = true;
        StartCoroutine(ReduzirQuantidade());
    }

    public void RecuperarImpulso()
    {
        quantidade += quantidadeParaRecuperar;

        if (quantidade > quantidadeMaxima)
            quantidade = quantidadeMaxima;
    }

    IEnumerator ReduzirQuantidade()
    {
        while (emUso && quantidade > 0)
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
