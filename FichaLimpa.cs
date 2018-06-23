using UnityEngine;
using UnityEngine.UI;

public class FichaLimpa : MonoBehaviour {

    public Text ficha_txtUI;
    public float veloPerdaFicha;
    public float fichaLimpa = 100;
    public float max_ficha = 100;
    public float min_ficha = 0;
    public bool recuperarFicha = false;
    public int cpi;
    public int almaHonesta;
    //public GameObject tempPersonagem;



    void Start()
    {
        //PlayerPrefs.DeleteAll();
        FichaPersonagens();
        CPI();
        AlmaHonesta();

    }

    void Update()
    {

        FichaPersonagens();
        CPI();

        GanhaFicha();
        MaxMinFicha();

        AlmaHonesta();

    }



    void MaxMinFicha()
    {
        if (fichaLimpa <= min_ficha)
        {
            fichaLimpa = min_ficha;
        }

        if (fichaLimpa >= max_ficha)
        {
            fichaLimpa = max_ficha;
        }
    }



    void GanhaFicha()
    {
        if (fichaLimpa <= 100)
        {
            fichaLimpa += Time.deltaTime * veloPerdaFicha;
        }
    }



    public void FichaPersonagens()

    {

        if (PlayerPrefs.GetInt("LulaDentroScene") == 1)

        {
            fichaLimpa = PlayerPrefs.GetFloat("FichaLula");
            float tempFicha = Mathf.Round(PlayerPrefs.GetFloat("FichaLula"));
            ficha_txtUI.text = (tempFicha.ToString() + "%");

            fichaLimpa = PlayerPrefs.GetFloat("FichaLula");
            fichaLimpa -= Time.deltaTime * veloPerdaFicha;
            PlayerPrefs.SetFloat("FichaLula", fichaLimpa);

            //MIN E MAX

            if (PlayerPrefs.GetFloat("FichaLula") <= 0)
            {
                PlayerPrefs.SetFloat("FichaLula", 0);
            }

            if (PlayerPrefs.GetFloat("FichaLula") >= 100)
            {
                PlayerPrefs.SetFloat("FichaLula", 100);
            }


            // INICIO DO JOGO
            if (PlayerPrefs.GetInt("LevelLula") <=1 && PlayerPrefs.GetFloat("FichaLula") <= 100 && PlayerPrefs.GetFloat("PopularidadeLula") <= 50)
            {
                PlayerPrefs.SetFloat("FichaLula", 100);
            }
           



        }


        if (PlayerPrefs.GetInt("CiroDentroScene") == 1)
        {
            fichaLimpa = PlayerPrefs.GetFloat("FichaCiro");
            float tempFicha = Mathf.Round(PlayerPrefs.GetFloat("FichaCiro"));
            ficha_txtUI.text = (tempFicha.ToString() + "%");

            fichaLimpa = PlayerPrefs.GetFloat("FichaCiro");
            fichaLimpa -= Time.deltaTime * veloPerdaFicha;
            PlayerPrefs.SetFloat("FichaCiro", fichaLimpa);

            if (PlayerPrefs.GetFloat("FichaCiro") <= 0)
            {
                PlayerPrefs.SetFloat("FichaCiro", 0);
            }

            if (PlayerPrefs.GetFloat("FichaCiro") >= 100)
            {
                PlayerPrefs.SetFloat("FichaCiro", 100);
            }

            if (PlayerPrefs.GetInt("LevelCiro") == 0 && PlayerPrefs.GetFloat("FichaCiro") <= 100 && PlayerPrefs.GetFloat("PopularidadeCiro") <= 50)
            {
                PlayerPrefs.SetFloat("FichaCiro", 100);
            }



        }


        if (PlayerPrefs.GetInt("BolsoDentroScene") == 1)
        {
            fichaLimpa = PlayerPrefs.GetFloat("FichaBolso");
            float tempFicha = Mathf.Round(PlayerPrefs.GetFloat("FichaBolso"));
            ficha_txtUI.text = (tempFicha.ToString() + "%");

            fichaLimpa = PlayerPrefs.GetFloat("FichaBolso");
            fichaLimpa -= Time.deltaTime * veloPerdaFicha;
            PlayerPrefs.SetFloat("FichaBolso", fichaLimpa);

            if (PlayerPrefs.GetFloat("FichaBolso") <= 0)
            {
                PlayerPrefs.SetFloat("FichaBolso", 0);
            }

            if (PlayerPrefs.GetFloat("FichaBolso") >= 100)
            {
                PlayerPrefs.SetFloat("FichaBolso", 100);
            }

            if (PlayerPrefs.GetInt("LevelBolso") == 0 && PlayerPrefs.GetFloat("FichaBolso") <= 100 && PlayerPrefs.GetFloat("PopularidadeBolso") <= 50)
                {
                    PlayerPrefs.SetFloat("FichaBolso", 100);
                }

        }

        if (PlayerPrefs.GetInt("DilmaDentroScene") == 1)
        {
            fichaLimpa = PlayerPrefs.GetFloat("FichaDilma");
            float tempFicha = Mathf.Round(PlayerPrefs.GetFloat("FichaDilma"));
            ficha_txtUI.text = (tempFicha.ToString() + "%");

            fichaLimpa = PlayerPrefs.GetFloat("FichaDilma");
            fichaLimpa -= Time.deltaTime * veloPerdaFicha;
            PlayerPrefs.SetFloat("FichaDilma", fichaLimpa);

            if (PlayerPrefs.GetFloat("FichaDilma") <= 0)
            {
                PlayerPrefs.SetFloat("FichaDilma", 0);
            }

            if (PlayerPrefs.GetFloat("FichaDilma") >= 100)
            {
                PlayerPrefs.SetFloat("FichaDilma", 100);
            }

            if (PlayerPrefs.GetInt("LevelDilma") == 0 && PlayerPrefs.GetFloat("FichaDilma") <= 100 && PlayerPrefs.GetFloat("PopularidadeDilma") <= 50)
            {
                PlayerPrefs.SetFloat("FichaDilma", 100);
            }

        }

        if (PlayerPrefs.GetInt("SuplicyDentroScene") == 1)
        {
            fichaLimpa = PlayerPrefs.GetFloat("FichaSuplicy");
            float tempFicha = Mathf.Round(PlayerPrefs.GetFloat("FichaSuplicy"));
            ficha_txtUI.text = (tempFicha.ToString() + "%");

            fichaLimpa = PlayerPrefs.GetFloat("FichaSuplicy");
            fichaLimpa -= Time.deltaTime * veloPerdaFicha;
            PlayerPrefs.SetFloat("FichaSuplicy", fichaLimpa);

            if (PlayerPrefs.GetFloat("FichaSuplicy") <= 0)
            {
                PlayerPrefs.SetFloat("FichaSuplicy", 0);
            }

            if (PlayerPrefs.GetFloat("FichaSuplicy") >= 100)
            {
                PlayerPrefs.SetFloat("FichaSuplicy", 100);
            }

            if (PlayerPrefs.GetInt("LevelSuplicy") == 0 && PlayerPrefs.GetFloat("FichaSuplicy") <= 100 && PlayerPrefs.GetFloat("PopularidadeSuplicy") <= 50)
            {
                PlayerPrefs.SetFloat("FichaSuplicy", 100);
            }

        }
  

        if (PlayerPrefs.GetInt("EneasDentroScene") == 1)
        {
            fichaLimpa = PlayerPrefs.GetFloat("FichaEneas");
            float tempFicha = Mathf.Round(PlayerPrefs.GetFloat("FichaEneas"));
            ficha_txtUI.text = (tempFicha.ToString() + "%");

            fichaLimpa = PlayerPrefs.GetFloat("FichaEneas");
            fichaLimpa -= Time.deltaTime * veloPerdaFicha;
            PlayerPrefs.SetFloat("FichaEneas", fichaLimpa);

            if (PlayerPrefs.GetFloat("FichaEneas") <= 0)
            {
                PlayerPrefs.SetFloat("FichaEneas", 0);
            }

            if (PlayerPrefs.GetFloat("FichaEneas") >= 100)
            {
                PlayerPrefs.SetFloat("FichaEneas", 100);
            }

            if (PlayerPrefs.GetInt("LevelEneas") == 0 && PlayerPrefs.GetFloat("FichaEneas") <= 100 && PlayerPrefs.GetFloat("PopularidadeEneas") <= 50)
            {
                PlayerPrefs.SetFloat("FichaEneas", 100);
            }

        }
    
    }


    // METODO DE PERDA DE POPULARIDADE COM FICHA LIMPA BAIXA
    public void CPI()

    {
        if (fichaLimpa <= 20)
        {
            PlayerPrefs.SetFloat("VeloPerdaPop", 0.5f);

            cpi = 1;
            PlayerPrefs.SetInt("CPI", cpi);
          
        }

        if (fichaLimpa > 20)
        {
            PlayerPrefs.SetFloat("VeloPerdaPop", 0.1f);

            cpi = 0;

            PlayerPrefs.SetInt("CPI", cpi);


        }

        PlayerPrefs.SetFloat("VeloPerdaPop", PlayerPrefs.GetFloat("VeloPerdaPop"));



    }

    // METODO DE GANHO DE POPULARIDADE COM FICHA LIMPA ALTA
    public void AlmaHonesta()
    {
        if (fichaLimpa >= 80)
        {
            PlayerPrefs.SetFloat("VeloGanhaPop", 0.5f);
            almaHonesta = 1;
            PlayerPrefs.SetInt("AlmaHonesta", almaHonesta);

        }
        if (fichaLimpa < 80 && fichaLimpa > 20 )
        {
            PlayerPrefs.SetFloat("VeloGanhaPop", 0);
            almaHonesta = 0;
            PlayerPrefs.SetInt("AlmaHonesta", almaHonesta);

        }
        PlayerPrefs.SetFloat("VeloGanhaPop", PlayerPrefs.GetFloat("VeloGanhaPop"));
    }
}
