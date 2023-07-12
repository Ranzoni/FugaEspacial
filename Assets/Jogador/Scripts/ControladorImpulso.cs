using System.Collections;
using UnityEngine;

public class ControladorImpulso : MonoBehaviour
{
    [Tooltip("Força do impulso")]
    [SerializeField] float impulso = 2f;
    [Tooltip("Capacidade de uso do impulso (também será o valor inicial)")]
    [SerializeField] float quantidade = 100f;
    [Tooltip("Quantidade de impulso que será gasto conforme o uso")]
    [SerializeField] float gastoComUso = 10f;
    [Tooltip("O tempo de delay para debitar a quantidade de impulso conforme o uso")]
    [SerializeField] float tempoDeGasto = .5f;
    [Tooltip("Quantidade de impulso que será recuperado")]
    [SerializeField] float recuperacao = 20f;

    public float Impulso
    {
        get
        {
            if (!Input.GetButton("Jump") || quantidade <= 0)
                return 0;

            return impulso;
        }
    }
    public float Quantidade { get { return quantidade; } }
    public float QuantidadeMaxima { get { return quantidadeMaxima; } }

    bool impulsoEmUso;
    float quantidadeMaxima;

    void Start()
    {
        quantidadeMaxima = quantidade;
    }

    void Update()
    {
        if (Input.GetButtonUp("Jump"))
            impulsoEmUso = false;

        if (!Input.GetButton("Jump") || impulsoEmUso)
            return;

        impulsoEmUso = true;
        StartCoroutine(ReduzirQuantidade());
    }

    public void RecuperarImpulso()
    {
        quantidade += recuperacao;

        if (quantidade > quantidadeMaxima)
            quantidade = quantidadeMaxima;
    }

    IEnumerator ReduzirQuantidade()
    {
        while (impulsoEmUso && quantidade > 0)
        {
            yield return new WaitForSeconds(tempoDeGasto);
        
            quantidade -= gastoComUso;
        }
    }
}
