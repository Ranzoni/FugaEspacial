using System.Collections;
using UnityEngine;

public class GeradorMeteoro : MonoBehaviour
{
    [SerializeField] GameObject[] listaPrefab;
    [SerializeField] float tempoMinimoGeracao = .5f;
    [SerializeField] float tempoMaximoGeracao = 1.5f;
    [SerializeField] float alturaMinima = -5f;
    [SerializeField] float alturaMaxima = 5f;

    void Start()
    {
        StartCoroutine(GerarMeteoro());
    }

    IEnumerator GerarMeteoro()
    {
        while (true)
        {
            var tempoEspera = Random.Range(tempoMinimoGeracao, tempoMaximoGeracao);
            var yValor = Random.Range(alturaMinima, alturaMaxima);
            var novaPosicao = new Vector3(transform.position.x, yValor, transform.position.z);

            var prefab = RetornarPrefabAleatorio();
            var novoObstaculo = Instantiate(prefab, novaPosicao, Quaternion.identity);

            novoObstaculo.transform.parent = transform;
            
            yield return new WaitForSeconds(tempoEspera);
        }
    }

    GameObject RetornarPrefabAleatorio()
    {
        var index = Random.Range(0, listaPrefab.Length);
        return listaPrefab[index];
    }
}
