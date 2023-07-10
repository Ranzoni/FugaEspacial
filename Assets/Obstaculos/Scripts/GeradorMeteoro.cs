using System.Collections;
using UnityEngine;

public class GeradorMeteoro : MonoBehaviour
{
    [SerializeField] GameObject[] listaPrefab;
    [SerializeField] float tempoMinimoGeracao = .5f;
    [SerializeField] float tempoMaximoGeracao = 1.5f;
    [SerializeField] float menorTempoPossivel = .001f;
    [SerializeField] float alturaMinima = -5f;
    [SerializeField] float alturaMaxima = 5f;

    bool fabricarMeteoros = true;
    DificuldadeJogo dificuldadeJogo;

    void Start()
    {
        dificuldadeJogo = FindObjectOfType<DificuldadeJogo>();

        StartCoroutine(GerarMeteoro());
    }

    IEnumerator GerarMeteoro()
    {
        while (true)
        {
            if (!fabricarMeteoros)
                break;

            var tempoEspera = TempoEspera();
            var yValor = Random.Range(alturaMinima, alturaMaxima);
            var novaPosicao = new Vector3(transform.position.x, yValor, transform.position.z);

            var prefab = RetornarPrefabAleatorio();
            var novoObstaculo = Instantiate(prefab, novaPosicao, Quaternion.identity);

            novoObstaculo.transform.parent = transform;
            
            yield return new WaitForSeconds(tempoEspera);
        }
    }

    float TempoEspera()
    {
        var tempoMinimoBalanceado = tempoMinimoGeracao / dificuldadeJogo.FatorBalanceamento();
        if (tempoMinimoBalanceado <= 0)
            tempoMinimoBalanceado = menorTempoPossivel;

        var tempoMaximoBalanceado = tempoMaximoGeracao / dificuldadeJogo.FatorBalanceamento();
        if (tempoMaximoBalanceado <= tempoMinimoBalanceado)
            return tempoMinimoGeracao + menorTempoPossivel;

        var tempoEspera = Random.Range(tempoMinimoBalanceado, tempoMaximoGeracao);
        return tempoEspera;
    }

    GameObject RetornarPrefabAleatorio()
    {
        var index = Random.Range(0, listaPrefab.Length);
        return listaPrefab[index];
    }

    public void Parar()
    {
        fabricarMeteoros = false;
    }
}
