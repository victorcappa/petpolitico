using System.Collections.Generic;
using UnityEngine;

public class SelecaoPersonagens : MonoBehaviour
{

    public List<GameObject> MeuPartido = new List<GameObject>();
    public GameObject Lula, Ciro, Bolsonaro, Dilma, Suplicy, Eneas;
    public GameObject LulaPartido, CiroPartido, BolsoPartido, DilmaPartido, SuplicyPartido, EneasPartido;
    public int LulaDentroPartido, CiroDentroPartido, BolsoDentroPartido, DilmaDentroPartido, SuplicyDentroPartido, EneasDentroPartido;
    public GameObject[] TiraPartidoBtn;

    private void Awake()


    {
        //PlayerPrefs.DeleteAll();

        LulaDentroPartido = PlayerPrefs.GetInt("LulaDentroPartido");
        CiroDentroPartido = PlayerPrefs.GetInt("CiroDentroPartido");
        BolsoDentroPartido = PlayerPrefs.GetInt("BolsoDentroPartido");
        DilmaDentroPartido = PlayerPrefs.GetInt("DilmaDentroPartido");
        SuplicyDentroPartido = PlayerPrefs.GetInt("SuplicyDentroPartido");
        EneasDentroPartido = PlayerPrefs.GetInt("EneasDentroPartido");



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

        if (EneasDentroPartido == 1)
        {
            EneasPartidoOn();
        }

        if (SuplicyDentroPartido == 1)
        {
            SuplicyPartidoOn();
        }
    }

    // -------------- LULA -------------- //


    public void LulaPartidoOn()
    {
        int precoLula = 200;
        int lulaComprado = 0;

        // autorizando comprar

        if (PlayerPrefs.GetInt("Verba") >= precoLula)
        {
            PlayerPrefs.SetInt("PodeComprarLula", 1); // PodeComprarNomePersonagem, para não interferir nos outros

        }

        if (PlayerPrefs.GetInt("PodeComprarLula") == 1)

        {
            // se tem menos de 4 no partido e o personagem ainda não foi comprado

            if (MeuPartido.Count < 4 && PlayerPrefs.GetInt("LulaComprado") == 0) 
            {
                PlayerPrefs.SetInt("Verba", (PlayerPrefs.GetInt("Verba") - precoLula));
                lulaComprado = 1;
                PlayerPrefs.SetInt("LulaComprado", lulaComprado);
            }
            if (MeuPartido.Count >=4)
            {
                print("O partido pode contar apenas 4 políticos.");
            }


        }
        // se o personagem já foi comprado, o preço fica zero
        if (PlayerPrefs.GetInt("LulaComprado") == 1)
        {
            precoLula = 0;

            // se tem menos de 4 no partido, ele é adicionado 
            if (MeuPartido.Count < 4)
            {
                MeuPartido.Add(Lula);
                LulaPartido.SetActive(true);
                LulaDentroPartido = 1;
                PlayerPrefs.SetInt("LulaDentroPartido", LulaDentroPartido);
            }
           
        }


    }


    public void LulaPartidoOff()
    {
        MeuPartido.Remove(Lula);
        LulaPartido.SetActive(false);
        LulaDentroPartido = 0;
        PlayerPrefs.SetInt("LulaDentroPartido", LulaDentroPartido);
        PlayerPrefs.SetInt("LulaComprado", 1);


    }

    // ------------------------------------------------------------------ //

    // ---------------------------- CIRO ----------------------------------- //

    public void CiroPartidoOn()
    {
        int precoCiro = 200;
        int ciroComprado = 0;

        if (PlayerPrefs.GetInt("Verba") >= precoCiro)
        {
            PlayerPrefs.SetInt("PodeComprarCiro", 1);

        }

        if (PlayerPrefs.GetInt("PodeComprarCiro") == 1)

        {

            if (MeuPartido.Count < 4 && PlayerPrefs.GetInt("CiroComprado") == 0)
            {
                PlayerPrefs.SetInt("Verba", (PlayerPrefs.GetInt("Verba") - precoCiro));
                ciroComprado = 1;
                PlayerPrefs.SetInt("CiroComprado", ciroComprado);
            }
            if (MeuPartido.Count >= 4)
            {
                print("O partido pode contar apenas 4 políticos.");
            }


        }

        if (PlayerPrefs.GetInt("CiroComprado") == 1)
        {
            precoCiro = 0;

            if (MeuPartido.Count < 4)
            {
                MeuPartido.Add(Ciro);
                CiroPartido.SetActive(true);
                CiroDentroPartido = 1;
                PlayerPrefs.SetInt("CiroDentroPartido", CiroDentroPartido);
            }

        }


    }


    public void CiroPartidoOff()
    {
        MeuPartido.Remove(Ciro);
        CiroPartido.SetActive(false);
        CiroDentroPartido = 0;
        PlayerPrefs.SetInt("CiroDentroPartido", CiroDentroPartido);
        PlayerPrefs.SetInt("CiroComprado", 1);

    }

    // ------------------------------------------------------------------ //

    // -------------------- BOLSONARO ------------------------ //

    public void BolsonaroPartidoOn()
    {
        int precoBolso = 200;
        int bolsoComprado = 0;

        if (PlayerPrefs.GetInt("Verba") >= precoBolso)
        {
            PlayerPrefs.SetInt("PodeComprarBolso", 1);

        }

        if (PlayerPrefs.GetInt("PodeComprarBolso") == 1)

        {

            if (MeuPartido.Count < 4 && PlayerPrefs.GetInt("BolsoComprado") == 0)
            {
                PlayerPrefs.SetInt("Verba", (PlayerPrefs.GetInt("Verba") - precoBolso));
                bolsoComprado = 1;
                PlayerPrefs.SetInt("BolsoComprado", bolsoComprado);
            }
            if (MeuPartido.Count >= 4)
            {
                print("O partido pode contar apenas 4 políticos.");
            }

        }

        if (PlayerPrefs.GetInt("BolsoComprado") == 1)
        {
            precoBolso = 0;

            if (MeuPartido.Count < 4)
            {
                MeuPartido.Add(Bolsonaro);
                BolsoPartido.SetActive(true);
                BolsoDentroPartido = 1;
                PlayerPrefs.SetInt("BolsoDentroPartido", BolsoDentroPartido);
            }
        }
    }

    public void BolsonaroPartidoOff()
    {
        MeuPartido.Remove(Bolsonaro);
        BolsoPartido.SetActive(false);
        BolsoDentroPartido = 0;
        PlayerPrefs.SetInt("BolsoDentroPartido", BolsoDentroPartido);
        PlayerPrefs.SetInt("BolsoComprado", 1);

    }

    //  --------------------- DILMA -------------------- //

    public void DilmaPartidoOn()
    {
        int precoDilma = 200;
        int dilmaComprado = 0;

        if (PlayerPrefs.GetInt("Verba") >= precoDilma)
        {
            PlayerPrefs.SetInt("PodeComprarDilma", 1);

        }

        if (PlayerPrefs.GetInt("PodeComprarDilma") == 1)

        {

            if (MeuPartido.Count < 4 && PlayerPrefs.GetInt("DilmaComprado") == 0)
            {
                PlayerPrefs.SetInt("Verba", (PlayerPrefs.GetInt("Verba") - precoDilma));
                dilmaComprado = 1;
                PlayerPrefs.SetInt("DilmaComprado", dilmaComprado);
            }
            if (MeuPartido.Count >= 4)
            {
                print("O partido pode contar apenas 4 políticos.");
            }

        }

        if (PlayerPrefs.GetInt("DilmaComprado") == 1)
        {
            precoDilma = 0;

            if (MeuPartido.Count < 4)
            {
                MeuPartido.Add(Dilma);
                DilmaPartido.SetActive(true);
                DilmaDentroPartido = 1;
                PlayerPrefs.SetInt("DilmaDentroPartido", DilmaDentroPartido);
            }
        }
    }

    public void DilmaPartidoOff()
    {
        MeuPartido.Remove(Dilma);
        DilmaPartido.SetActive(false);
        DilmaDentroPartido = 0;
        PlayerPrefs.SetInt("DilmaDentroPartido", DilmaDentroPartido);
        PlayerPrefs.SetInt("DilmaComprado", 1);

    }

    // -------------------- SUPLICY --------------------- //

    public void SuplicyPartidoOn()
    {
        int precoSuplicy = 200;
        int suplicyComprado = 0;

        if (PlayerPrefs.GetInt("Verba") >= precoSuplicy)
        {
            PlayerPrefs.SetInt("PodeComprarSuplicy", 1);

        }

        if (PlayerPrefs.GetInt("PodeComprarSuplicy") == 1)

        {

            if (MeuPartido.Count < 4 && PlayerPrefs.GetInt("SuplicyComprado") == 0)
            {
                PlayerPrefs.SetInt("Verba", (PlayerPrefs.GetInt("Verba") - precoSuplicy));
                suplicyComprado = 1;
                PlayerPrefs.SetInt("SuplicyComprado", suplicyComprado);
            }
            if (MeuPartido.Count >= 4)
            {
                print("O partido pode contar apenas 4 políticos.");
            }

        }

        if (PlayerPrefs.GetInt("SuplicyComprado") == 1)
        {
            precoSuplicy = 0;

            if (MeuPartido.Count < 4)
            {
                MeuPartido.Add(Suplicy);
                SuplicyPartido.SetActive(true);
                SuplicyDentroPartido = 1;
                PlayerPrefs.SetInt("SuplicyDentroPartido", SuplicyDentroPartido);
            }
        }
    }

    public void SuplicyPartidoOff()
    {
        MeuPartido.Remove(Suplicy);
        SuplicyPartido.SetActive(false);
        SuplicyDentroPartido = 0;
        PlayerPrefs.SetInt("SuplicyDentroPartido", SuplicyDentroPartido);
        PlayerPrefs.SetInt("SuplicyComprado", 1);

    }



    // --------------------- ENEAS ----------------------- //

    public void EneasPartidoOn()
    {
        int precoEneas = 200;
        int eneasComprado = 0;

        if (PlayerPrefs.GetInt("Verba") >= precoEneas)
        {
            PlayerPrefs.SetInt("PodeComprarEneas", 1);

        }

        if (PlayerPrefs.GetInt("PodeComprarEneas") == 1)

        {

            if (MeuPartido.Count < 4 && PlayerPrefs.GetInt("EneasComprado") == 0)
            {
                PlayerPrefs.SetInt("Verba", (PlayerPrefs.GetInt("Verba") - precoEneas));
                eneasComprado = 1;
                PlayerPrefs.SetInt("EneasComprado", eneasComprado);
            }
            if (MeuPartido.Count >= 4)
            {
                print("O partido pode contar apenas 4 políticos.");
            }

        }

        if (PlayerPrefs.GetInt("EneasComprado") == 1)
        {
            precoEneas = 0;

            if (MeuPartido.Count < 4)
            {
                MeuPartido.Add(Eneas);
                EneasPartido.SetActive(true);
                EneasDentroPartido = 1;
                PlayerPrefs.SetInt("EneasDentroPartido", EneasDentroPartido);
            }
        }
    }

    public void EneasPartidoOff()
    {
        MeuPartido.Remove(Eneas);
        EneasPartido.SetActive(false);
        EneasDentroPartido = 0;
        PlayerPrefs.SetInt("EneasDentroPartido", EneasDentroPartido);
        PlayerPrefs.SetInt("EneasComprado", 1);

    }

    // --------------------------------------------------------------- //

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

