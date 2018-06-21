using System.Collections.Generic;
using UnityEngine;


public class SelecaoPersonagens : MonoBehaviour
{
    //public GameObject[] MeuPartido = new GameObject[5];
    // public GameObject politico;

    public List<GameObject> MeuPartido = new List<GameObject>();
    public GameObject Lula, Ciro, Bolsonaro, Dilma;
    public GameObject LulaPartido, CiroPartido, BolsoPartido, DilmaPartido;
    public int LulaDentroPartido, CiroDentroPartido, BolsoDentroPartido, DilmaDentroPartido;
    public GameObject[] TiraPartidoBtn;

    private void Awake()


    {
        //PlayerPrefs.DeleteAll();

        LulaDentroPartido = PlayerPrefs.GetInt("LulaDentroPartido");
        CiroDentroPartido = PlayerPrefs.GetInt("CiroDentroPartido");
        BolsoDentroPartido = PlayerPrefs.GetInt("BolsoDentroPartido");
        DilmaDentroPartido = PlayerPrefs.GetInt("DilmaDentroPartido");


        if (LulaDentroPartido == 1)
        {
            LulaPartidoOn();
        }

        if (CiroDentroPartido == 1)
        {
            CiroPartidoOn();
        }
        if (BolsoDentroPartido == 1)
        {
            BolsonaroPartidoOn();
        }

        if (DilmaDentroPartido == 1)
        {
            DilmaPartidoOn();
        }

    }

    // LULA 

    public void LulaPartidoOn()
    {
        int precoLula = 200;

        if (PlayerPrefs.GetInt("Verba") >= precoLula)
        {
            PlayerPrefs.SetInt("Comprado", 1);
            PlayerPrefs.SetInt("Verba", (PlayerPrefs.GetInt("Verba") - precoLula));

        }

        if (PlayerPrefs.GetInt("Comprado") == 1)

        {
            MeuPartido.Add(Lula);
            LulaPartido.SetActive(true);
            LulaDentroPartido = 1;
            PlayerPrefs.SetInt("LulaDentroPartido", LulaDentroPartido);
            precoLula = 0;


        }
    }


    public void LulaPartidoOff()
    {
        MeuPartido.Remove(Lula);
        LulaPartido.SetActive(false);
        LulaDentroPartido = 0;
        PlayerPrefs.SetInt("LulaDentroPartido", LulaDentroPartido);
    }

    // ------------------------------------------------------------------ //

    //CIRO

    public void CiroPartidoOn()
    {
        int precoCiro = 200;


        if (PlayerPrefs.GetInt("Verba") >= precoCiro)
        {
            PlayerPrefs.SetInt("Comprado", 1);
            PlayerPrefs.SetInt("Verba", (PlayerPrefs.GetInt("Verba") - precoCiro));

        }
        if (PlayerPrefs.GetInt("Comprado") == 1)
        {
            precoCiro = 0;
            MeuPartido.Add(Ciro);
            CiroPartido.SetActive(true);
            CiroDentroPartido = 1;
            PlayerPrefs.SetInt("CiroDentroPartido", CiroDentroPartido);
        }
    }


    public void CiroPartidoOff()
    {
        MeuPartido.Remove(Ciro);
        CiroPartido.SetActive(false);
        CiroDentroPartido = 0;
        PlayerPrefs.SetInt("CiroDentroPartido", CiroDentroPartido);
    }

    // ------------------------------------------------------------------ //

    //BOLSONARO

    public void BolsonaroPartidoOn()
    {
        int precoBolso = 200;


        if (PlayerPrefs.GetInt("Verba") >= precoBolso)
        {
            PlayerPrefs.SetInt("Comprado", 1);
            PlayerPrefs.SetInt("Verba", (PlayerPrefs.GetInt("Verba") - precoBolso));

        }
        if (PlayerPrefs.GetInt("Comprado") == 1)

        {
            precoBolso = 0;
            MeuPartido.Add(Bolsonaro);
            BolsoPartido.SetActive(true);
            BolsoDentroPartido = 1;
            PlayerPrefs.SetInt("BolsoDentroPartido", BolsoDentroPartido);

           
        }
    }

    public void BolsonaroPartidoOff()
    {
        MeuPartido.Remove(Bolsonaro);
        BolsoPartido.SetActive(false);
        BolsoDentroPartido = 0;
        PlayerPrefs.SetInt("BolsoDentroPartido", BolsoDentroPartido);
    }

    // DILMA
    public void DilmaPartidoOn()
    {
        int precoDilma = 200;

        if (PlayerPrefs.GetInt("Verba") >= precoDilma)
        {
            PlayerPrefs.SetInt("Comprado", 1);
            PlayerPrefs.SetInt("Verba", (PlayerPrefs.GetInt("Verba") - precoDilma));

        }
        if (PlayerPrefs.GetInt("Comprado") == 1)

        {
            MeuPartido.Add(Dilma);
            precoDilma = 0;
            DilmaPartido.SetActive(true);
            DilmaDentroPartido = 1;
            PlayerPrefs.SetInt("DilmaDentroPartido", DilmaDentroPartido);
        }

    }

    public void DilmaPartidoOff()
    {
        MeuPartido.Remove(Bolsonaro);
        DilmaPartido.SetActive(false);
        DilmaDentroPartido = 0;
        PlayerPrefs.SetInt("DilmaDentroPartido", DilmaDentroPartido);

    }


    public void mostraMembros()
    {
        print(MeuPartido[0]);
        print(MeuPartido[1]);
        print(MeuPartido[2]);
        print(MeuPartido[3]);
    }

    public void minPartido()
    {
        PlayerPrefs.SetInt("DentroDoPartido", MeuPartido.Count);
        print(PlayerPrefs.GetInt("DentroDoPartido"));

        if (PlayerPrefs.GetInt("DentroDoPartido") == 1)
        {
            foreach (GameObject btn in TiraPartidoBtn)
            {

                btn.SetActive(false);
            }
           

        }
        else
        {
            foreach (GameObject btn in TiraPartidoBtn)
            {

                btn.SetActive(true);
            }
        }

    }

        public void Update()
        {
            minPartido();
        }
    }

