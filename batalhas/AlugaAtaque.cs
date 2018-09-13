using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AlugaAtaque : MonoBehaviour
{
    public int preco;
    private int verba;
    public Text txt_preco;
    public Image bg_msg;
    public Text info;
    public bool alugado;
    public GameObject painelConfirmaAtaque, painelConfirmaAlugaAtaque;
    public AudioSource Comprou, SemVerba;

    IEnumerator ApagaMsg() // criado para que a mensagem desapareça após 3 segundos (3f)
    {

        yield return new WaitForSeconds(2f);

        info.text = ""; // apó 3 segundos, info.text ficará vazio
        bg_msg.gameObject.SetActive(false);

    }


    

    public void Awake()
    {
        alugado = false;


    }
    private void Start()
    {
        txt_preco.text = preco.ToString();
        alugado = false;

    }

    public void FoiAlugado()
    {
      
   
        if (alugado == true)
        {
            painelConfirmaAtaque.SetActive(true);
            painelConfirmaAlugaAtaque.SetActive(false);
            preco = 0;
            txt_preco.text = preco.ToString();

        }
        if (alugado == false)
        {
            painelConfirmaAtaque.SetActive(false);
            painelConfirmaAlugaAtaque.SetActive(true);

        }
    }

    public void Alugar()
    {
        verba = PlayerPrefs.GetInt("Verba");

       

        if (verba >= preco)

        {
            PlayerPrefs.SetInt("Verba", PlayerPrefs.GetInt("Verba") - preco);
            alugado = true;
            Comprou.Play();

        }

        else if (verba < preco)
        {
            bg_msg.gameObject.SetActive(true);

            info.text = "Você não tem verba o suficiente";
            StartCoroutine(ApagaMsg());
            alugado = false;
            SemVerba.Play();

        }


    }


   

} // FIM CLASSE
