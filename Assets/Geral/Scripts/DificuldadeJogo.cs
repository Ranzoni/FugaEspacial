using System.Collections;
using UnityEngine;

public class DificuldadeJogo : MonoBehaviour
{
    [Tooltip("Dificuldade inicial do jogo (Ela também define o tempo com que irá se modificar)")]
    [SerializeField] float fatorDificuldade = 1f;
    [Tooltip("Valor que será acrescentado na dificuldade do jogo")]
    [SerializeField] float acrescimoDificuldade = .3f;

    public float FatorDificuldade { get { return fatorDificuldade; } }

    void Start()
    {
        StartCoroutine(RotinaBalanceamento());
    }

    IEnumerator RotinaBalanceamento()
    {
        while (true)
        {
            yield return new WaitForSeconds(fatorDificuldade);

            fatorDificuldade += acrescimoDificuldade;
        }
    }
}
