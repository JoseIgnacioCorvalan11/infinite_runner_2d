using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador_Enemigo : MonoBehaviour
{
    public GameObject enemigos;
    [SerializeField] int numeroObjetos = 1;
    Queue<GameObject> pool = new Queue<GameObject>();
    [SerializeField] float tiempoSegundos = 2f;
    float contadorSegundos = 0f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numeroObjetos; i++)
        {
            GameObject tempo = Instantiate(enemigos);
            tempo.SetActive(false);
            pool.Enqueue(tempo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        contadorSegundos += Time.deltaTime;
        if (contadorSegundos > tiempoSegundos)
        {
            InstanciadorObjetos();
            contadorSegundos = 0f;
        }
    }

    void InstanciadorObjetos()
    {
        GameObject temp = pool.Dequeue();
        pool.Enqueue(temp);
        temp.SetActive(true);
        float x = Random.Range(-10, 0);
        float y = Random.Range(-10, 0);
        float z = 0f;
        temp.transform.position = new Vector3(x, y, z);
    }
}
