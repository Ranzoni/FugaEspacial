using System.Collections;
using UnityEngine;

public class DificuldadeJogo : MonoBehaviour
{
    [SerializeField] int intervaloParaDificuldade = 10;
    float balanceador = 1f;

    void Start()
    {
        StartCoroutine(RotinaBalanceamento());
    }

    IEnumerator RotinaBalanceamento()
    {
        while (true)
        {
            yield return new WaitForSeconds(balanceador);

            balanceador += .3f;
        }
    }

    public float FatorBalanceamento()
    {
        return balanceador;
    }
}
