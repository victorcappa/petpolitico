using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] itensCaindo = new GameObject[2];
    private BoxCollider2D col; // col é o box colider do Spawner

    float x1, x2; // extremo esquerdo e direito do spawner

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();

        x1 = transform.position.x - col.bounds.size.x / 2f; // pegando a posição x1
        x2 = transform.position.x + col.bounds.size.x / 2f; // pegando a posição x2
    }

    private void Start()
    {
        StartCoroutine(Spawn(4f)); // tempo de spawn para a primeira vez

    }

    IEnumerator Spawn(float time)
    {
        yield return new WaitForSecondsRealtime(time);

   

        Vector3 temp = transform.position;
        temp.x = Random.Range(x1, x2); // randomizar onde será o x1 e x2 para cair objetos

        // instanciar de forma random quais itens vão cair da matriz itensCaindo (quartenio.identity é para deixar a rotação em 0)

        GameObject itens = Instantiate(itensCaindo[Random.Range(0, itensCaindo.Length)], temp, Quaternion.identity) as GameObject;
        //GameObject 
        itens.transform.SetParent(GameObject.FindGameObjectWithTag("Spawner").transform);

        StartCoroutine(Spawn(Random.Range(1f, 4f))); // chamando a coroutine dentro dela mesma (para ser loop infinito (e o tempo entre objetos)
    }

    /* 
        COLOCAR UMA CONDICIONAL (se (pontuação >= x) { cai mais policial e com tempo menor) }

    */

}// FIM CLASSE

