using System.Collections;
using UnityEngine;

public class GeradorMeteoro : MonoBehaviour
{
    [SerializeField] GameObject meteoroPrefab;
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
            var meteoroPosicao = new Vector3(transform.position.x, yValor, transform.position.z);
            var meteoroNovo = Instantiate(meteoroPrefab, meteoroPosicao, Quaternion.identity);

            meteoroNovo.transform.parent = transform;
            
            yield return new WaitForSeconds(tempoEspera);
        }
    }
}
