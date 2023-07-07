using UnityEngine;

public class LimparObjeto : MonoBehaviour
{
    float limiteTelaX;
    float larguraObjeto;
    float margem = 2f;
    
    void Start()
    {
        limiteTelaX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)).x;
        larguraObjeto = GetComponentInChildren<MeshRenderer>().bounds.size.x / 2;
    }

    void Update()
    {
        if (transform.position.x + larguraObjeto + margem < limiteTelaX)
            Destroy(gameObject);
    }
}
