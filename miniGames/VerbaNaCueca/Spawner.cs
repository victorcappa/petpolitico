using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] itensCaindo = new GameObject[2];
    private BoxCollider2D col; // col é o box colider do Spawner
    float x1, x2; // extremo esquerdo e direito do spawner

    float min, max;

    public void Update()
    {

        if (PlayerPrefs.GetInt("Chances") <= 0)
        {
           
            StopAllCoroutines();
        }

    }


    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();

        x1 = transform.position.x - col.bounds.size.x / 2f; // pegando a posição x1
        x2 = transform.position.x + col.bounds.size.x / 2f; // pegando a posição x2
    }

    public void Start()
    {
        StartCoroutine(CairPF(1f)); // tempo de spawn para a primeira vez
        StartCoroutine(CairVerba(3f)); // tempo de spawn para a primeira vez
        StartCoroutine(CairMoro(5f)); // tempo de spawn para a primeira vez
        StartCoroutine(CairHabeasCorpus(7f)); // tempo de spawn para a primeira vez
        StartCoroutine(CairReceita(10f)); // tempo de spawn para a primeira vez

        PlayerPrefs.SetInt("Chances", 3);

    }

    IEnumerator CairPF(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        min = Random.Range(1,5);
        max = Random.Range(5, 10);

        Vector3 temp = transform.position;
        temp.x = Random.Range(x1, x2); // randomizar onde será o x1 e x2 para cair objetos


        // instanciar de forma random quais itens vão cair da matriz itensCaindo (quartenio.identity é para deixar a rotação em 0)
       // if (powerUps == 0){
            GameObject itens = Instantiate(itensCaindo[0], temp, Quaternion.identity) as GameObject;
            itens.transform.SetParent(GameObject.FindGameObjectWithTag("Spawner").transform);
        // itensCaindo[0].GetComponent<Transform>().Translate(-1, 0, 0);
        //}
        //GameObject 

        StartCoroutine(CairPF(Random.Range(min, max))); // chamando a coroutine dentro dela mesma (para ser loop infinito (e o tempo entre objetos)
     
    }

    IEnumerator CairReceita(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        min = Random.Range(1, 8);
        max = Random.Range(8, 12);

        Vector3 temp = transform.position;
        temp.x = Random.Range(x1, x2); // randomizar onde será o x1 e x2 para cair objetos

        if (PlayerPrefs.GetInt("ScoreCueca") >= 10)
        {
            min = Random.Range(1, 6);
            max = Random.Range(6, 10);
        }

        if (PlayerPrefs.GetInt("ScoreCueca") >= 20)
        {
            min = Random.Range(1, 3);
            max = Random.Range(3, 6);
        }

        if (PlayerPrefs.GetInt("ScoreCueca") >= 30)
        {
            min = Random.Range(1, 3);
            max = Random.Range(3, 4);
        }


        // instanciar de forma random quais itens vão cair da matriz itensCaindo (quartenio.identity é para deixar a rotação em 0)
        // if (powerUps == 0){
        GameObject itens = Instantiate(itensCaindo[4], temp, Quaternion.identity) as GameObject;
        itens.transform.SetParent(GameObject.FindGameObjectWithTag("Spawner").transform);
        // itensCaindo[0].GetComponent<Transform>().Translate(-1, 0, 0);
        //}
        //GameObject 

        StartCoroutine(CairReceita(Random.Range(min, max))); // chamando a coroutine dentro dela mesma (para ser loop infinito (e o tempo entre objetos)

    }

    IEnumerator CairMoro(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        min = Random.Range(1, 5);
        max = Random.Range(5, 10);

        Vector3 temp = transform.position;
        temp.x = Random.Range(x1, x2); // randomizar onde será o x1 e x2 para cair objetos


        if (PlayerPrefs.GetInt("ScoreCueca") >= 10)
        {
            min = Random.Range(1, 6);
            max = Random.Range(6, 10);
        }

        if (PlayerPrefs.GetInt("ScoreCueca") >= 20)
        {
            min = Random.Range(1, 3);
            max = Random.Range(3, 6);
        }

        if (PlayerPrefs.GetInt("ScoreCueca") >= 30)
        {
            min = Random.Range(1, 20);
            max = Random.Range(20, 28);
        }

        // instanciar de forma random quais itens vão cair da matriz itensCaindo (quartenio.identity é para deixar a rotação em 0)
        // if (powerUps == 0){
        GameObject itens = Instantiate(itensCaindo[2], temp, Quaternion.identity) as GameObject;
        itens.transform.SetParent(GameObject.FindGameObjectWithTag("Spawner").transform);
        // itensCaindo[0].GetComponent<Transform>().Translate(-1, 0, 0);
        //}
        //GameObject 

        StartCoroutine(CairMoro(Random.Range(min, max))); // chamando a coroutine dentro dela mesma (para ser loop infinito (e o tempo entre objetos)

    }

    IEnumerator CairVerba(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        min = Random.Range(1, 12);
        max = Random.Range(12, 18);

        Vector3 temp = transform.position;
        temp.x = Random.Range(x1, x2); // randomizar onde será o x1 e x2 para cair objetos

        if (PlayerPrefs.GetInt("ScoreCueca") >= 10)
        {
            min = Random.Range(1, 18);
            max = Random.Range(18, 25);
        }

        if (PlayerPrefs.GetInt("ScoreCueca") >= 20)
        {
            min = Random.Range(1, 25);
            max = Random.Range(25, 32);
        }

        if (PlayerPrefs.GetInt("ScoreCueca") >= 30)
        {
            min = Random.Range(1, 30);
            max = Random.Range(30, 35);
        }
      
        GameObject itens = Instantiate(itensCaindo[1], temp, Quaternion.identity) as GameObject;
        itens.transform.SetParent(GameObject.FindGameObjectWithTag("Spawner").transform);
       

        StartCoroutine(CairVerba(Random.Range(min, max))); // chamando a coroutine dentro dela mesma (para ser loop infinito (e o tempo entre objetos)


    }

    IEnumerator CairHabeasCorpus(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        min = 1;
        max = 40;

        Vector3 temp = transform.position;
        temp.x = Random.Range(x1, x2); // randomizar onde será o x1 e x2 para cair objetos


        if (PlayerPrefs.GetInt("ScoreCueca") >= 10)
        {
            min = 1;
            max = 50;
        }

        if (PlayerPrefs.GetInt("ScoreCueca") >= 20)
        {
            min = 1;
            max = 60;
        }

        if (PlayerPrefs.GetInt("ScoreCueca") >= 30)
        {
            min = 1;
            max = 70;
        }

        GameObject itens = Instantiate(itensCaindo[3], temp, Quaternion.identity) as GameObject;
        itens.transform.SetParent(GameObject.FindGameObjectWithTag("Spawner").transform);


        StartCoroutine(CairHabeasCorpus(Random.Range(min, max))); // chamando a coroutine dentro dela mesma (para ser loop infinito (e o tempo entre objetos)


    }

  
  

    /* 
        COLOCAR UMA CONDICIONAL (se (pontuação >= x) { cai mais policial e com tempo menor) }

    */

}// FIM CLASSE

