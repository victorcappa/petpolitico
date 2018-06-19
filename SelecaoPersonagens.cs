using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography.X509Certificates;

public class SelecaoPersonagens : MonoBehaviour {
    //public GameObject[] MeuPartido = new GameObject[5];
    // public GameObject politico;

    public List<GameObject> MeuPartido = new List<GameObject>();
    public GameObject Lula, Ciro, Bolsonaro;
    public GameObject LulaPartido, CiroPartido, BolsoPartido;
    public int LulaDentroPartido, CiroDentroPartido, BolsoDentroPartido;

    private void Awake()

    {
        //PlayerPrefs.DeleteAll();

        LulaDentroPartido = PlayerPrefs.GetInt("LulaDentroPartido");
        CiroDentroPartido = PlayerPrefs.GetInt("CiroDentroPartido");
        BolsoDentroPartido = PlayerPrefs.GetInt("BolsoDentroPartido");


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
    
    }

    // LULA 

    public void LulaPartidoOn()
    {
        MeuPartido.Add(Lula);
        LulaPartido.SetActive(true);
        LulaDentroPartido = 1;
        PlayerPrefs.SetInt("LulaDentroPartido", LulaDentroPartido);
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

        MeuPartido.Add(Ciro);
        CiroPartido.SetActive(true);
        CiroDentroPartido = 1;
        PlayerPrefs.SetInt("CiroDentroPartido", CiroDentroPartido);

    }

    public void CiroPartidoOff()
    {
        MeuPartido.Remove(Ciro);
        CiroPartido.SetActive(false);
        CiroDentroPartido = 0;
        PlayerPrefs.SetInt("CiroDentroPartido", CiroDentroPartido);
    }

    // ------------------------------------------------------------------ //

    //BOLSORNARO

    public void BolsonaroPartidoOn()
    {

        MeuPartido.Add(Bolsonaro);
        BolsoPartido.SetActive(true);
        BolsoDentroPartido = 1;
        PlayerPrefs.SetInt("BolsoDentroPartido", BolsoDentroPartido);

    }

    public void BolsonaroPartidoOff()
    {
        MeuPartido.Remove(Bolsonaro);
        BolsoPartido.SetActive(false);
        BolsoDentroPartido = 0;
        PlayerPrefs.SetInt("BolsoDentroPartido", BolsoDentroPartido);
    }

    public void mostraMembros()
    {
        print(MeuPartido[0]);
        print(MeuPartido[1]);
        print(MeuPartido[2]);
    }

   
}
