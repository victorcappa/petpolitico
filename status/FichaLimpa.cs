using UnityEngine;
using UnityEngine.UI;

/* 

SISTEMA FICHA LIMPA

- é um dos status do jogo
- é medido em % (de 0 - 100)
- cada personagem começa com 100% de ficha limpa
- vai reduzindo ao longo do tempo, com uma velocidade de 0.2f
- ao atingir 80, desencadeia o método AlmaHonesta (ganho de popularidade com velocidade 0.5)
- ao atingir 20, desencadeia o método CPI (perda de influencia e popularidade)
- Com perda de levels (perda de popularidade abaixo de 20) é perdido 10 de ficha limpa

*/


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
    public Slider barraFicha;



    void Start()
    {
        FichaPersonagens();
        CPI();
        AlmaHonesta();

    }

    void Update()
    {

        FichaPersonagens();
        CPI();

       // GanhaFicha();
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
        veloPerdaFicha = 0.05f;
        if (PlayerPrefs.GetInt("LulaDentroScene") == 1)

        {
            PlayerPrefs.SetFloat("FichaNaScene", PlayerPrefs.GetFloat("FichaLula"));
            fichaLimpa = PlayerPrefs.GetFloat("FichaLula");
            float tempFicha = Mathf.Round(PlayerPrefs.GetFloat("FichaLula"));
            ficha_txtUI.text = (tempFicha.ToString()); // + "%");

            fichaLimpa = PlayerPrefs.GetFloat("FichaLula");
            fichaLimpa -= Time.deltaTime * veloPerdaFicha;
            PlayerPrefs.SetFloat("FichaLula", fichaLimpa);

            // BARRA Ficha

            barraFicha.maxValue = max_ficha;
            barraFicha.value = fichaLimpa;

            //

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
            PlayerPrefs.SetFloat("FichaNaScene", PlayerPrefs.GetFloat("FichaCiro"));

            fichaLimpa = PlayerPrefs.GetFloat("FichaCiro");
            float tempFicha = Mathf.Round(PlayerPrefs.GetFloat("FichaCiro"));
            ficha_txtUI.text = (tempFicha.ToString()); // + "%");

            fichaLimpa = PlayerPrefs.GetFloat("FichaCiro");
            fichaLimpa -= Time.deltaTime * veloPerdaFicha;
            PlayerPrefs.SetFloat("FichaCiro", fichaLimpa);

            // BARRA Ficha

            barraFicha.maxValue = max_ficha;
            barraFicha.value = fichaLimpa;

            //

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

            PlayerPrefs.SetFloat("FichaNaScene", PlayerPrefs.GetFloat("FichaBolso"));

            fichaLimpa = PlayerPrefs.GetFloat("FichaBolso");
            float tempFicha = Mathf.Round(PlayerPrefs.GetFloat("FichaBolso"));
            ficha_txtUI.text = (tempFicha.ToString()); // + "%");

            fichaLimpa = PlayerPrefs.GetFloat("FichaBolso");
            fichaLimpa -= Time.deltaTime * veloPerdaFicha;
            PlayerPrefs.SetFloat("FichaBolso", fichaLimpa);

            // BARRA Ficha

            barraFicha.maxValue = max_ficha;
            barraFicha.value = fichaLimpa;

            //

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

            PlayerPrefs.SetFloat("FichaNaScene", PlayerPrefs.GetFloat("FichaDilma"));

            fichaLimpa = PlayerPrefs.GetFloat("FichaDilma");
            float tempFicha = Mathf.Round(PlayerPrefs.GetFloat("FichaDilma"));
            ficha_txtUI.text = (tempFicha.ToString()); // + "%");

            fichaLimpa = PlayerPrefs.GetFloat("FichaDilma");
            fichaLimpa -= Time.deltaTime * veloPerdaFicha;
            PlayerPrefs.SetFloat("FichaDilma", fichaLimpa);

            // BARRA Ficha

            barraFicha.maxValue = max_ficha;
            barraFicha.value = fichaLimpa;

            //

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
            
            PlayerPrefs.SetFloat("FichaNaScene", PlayerPrefs.GetFloat("FichaSuplicy"));

            fichaLimpa = PlayerPrefs.GetFloat("FichaSuplicy");
            float tempFicha = Mathf.Round(PlayerPrefs.GetFloat("FichaSuplicy"));
            ficha_txtUI.text = (tempFicha.ToString()); //) + "%");

            fichaLimpa = PlayerPrefs.GetFloat("FichaSuplicy");
            fichaLimpa -= Time.deltaTime * veloPerdaFicha;
            PlayerPrefs.SetFloat("FichaSuplicy", fichaLimpa);

            // BARRA Ficha

            barraFicha.maxValue = max_ficha;
            barraFicha.value = fichaLimpa;

            //

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
            PlayerPrefs.SetFloat("FichaNaScene", PlayerPrefs.GetFloat("FichaEneas"));

            fichaLimpa = PlayerPrefs.GetFloat("FichaEneas");
            float tempFicha = Mathf.Round(PlayerPrefs.GetFloat("FichaEneas"));
            ficha_txtUI.text = (tempFicha.ToString());// + "%");

            fichaLimpa = PlayerPrefs.GetFloat("FichaEneas");
            fichaLimpa -= Time.deltaTime * veloPerdaFicha;
            PlayerPrefs.SetFloat("FichaEneas", fichaLimpa);

            // BARRA Ficha

            barraFicha.maxValue = max_ficha;
            barraFicha.value = fichaLimpa;

            //

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
    
        if (PlayerPrefs.GetInt("DodorioDentroScene") == 1)

        {
            PlayerPrefs.SetFloat("FichaNaScene", PlayerPrefs.GetFloat("FichaDodorio"));

            fichaLimpa = PlayerPrefs.GetFloat("FichaDodorio");
            float tempFicha = Mathf.Round(PlayerPrefs.GetFloat("FichaDodorio"));
            ficha_txtUI.text = (tempFicha.ToString()); // + "%");

            fichaLimpa = PlayerPrefs.GetFloat("FichaDodorio");
            fichaLimpa -= Time.deltaTime * veloPerdaFicha;
            PlayerPrefs.SetFloat("FichaDodorio", fichaLimpa);

            // BARRA Ficha

            barraFicha.maxValue = max_ficha;
            barraFicha.value = fichaLimpa;

            //

            //MIN E MAX

            if (PlayerPrefs.GetFloat("FichaDodorio") <= 0)
            {
                PlayerPrefs.SetFloat("FichaDodorio", 0);
            }

            if (PlayerPrefs.GetFloat("FichaDodorio") >= 100)
            {
                PlayerPrefs.SetFloat("FichaDodorio", 100);
            }


            // INICIO DO JOGO
            if (PlayerPrefs.GetInt("LevelDodorio") <= 1 && PlayerPrefs.GetFloat("FichaDodorio") <= 100 && PlayerPrefs.GetFloat("PopularidadeDodorio") <= 50)
            {
                PlayerPrefs.SetFloat("FichaDodorio", 100);
            }




        }
    
        if (PlayerPrefs.GetInt("HaddardDentroScene") == 1)

        {
            PlayerPrefs.SetFloat("FichaNaScene", PlayerPrefs.GetFloat("FichaHaddard"));

            fichaLimpa = PlayerPrefs.GetFloat("FichaHaddard");
            float tempFicha = Mathf.Round(PlayerPrefs.GetFloat("FichaHaddard"));
            ficha_txtUI.text = (tempFicha.ToString()); // + "%");

            fichaLimpa = PlayerPrefs.GetFloat("FichaHaddard");
            fichaLimpa -= Time.deltaTime * veloPerdaFicha;
            PlayerPrefs.SetFloat("FichaHaddard", fichaLimpa);

            // BARRA Ficha

            barraFicha.maxValue = max_ficha;
            barraFicha.value = fichaLimpa;

            //

            //MIN E MAX

            if (PlayerPrefs.GetFloat("FichaHaddard") <= 0)
            {
                PlayerPrefs.SetFloat("FichaHaddard", 0);
            }

            if (PlayerPrefs.GetFloat("FichaHaddard") >= 100)
            {
                PlayerPrefs.SetFloat("FichaHaddard", 100);
            }


            // INICIO DO JOGO
            if (PlayerPrefs.GetInt("LevelHaddard") <= 1 && PlayerPrefs.GetFloat("FichaHaddard") <= 100 && PlayerPrefs.GetFloat("PopularidadeHaddard") <= 50)
            {
                PlayerPrefs.SetFloat("FichaHaddard", 100);
            }




        }
    
        if (PlayerPrefs.GetInt("CunhaDentroScene") == 1)

        {
            PlayerPrefs.SetFloat("FichaNaScene", PlayerPrefs.GetFloat("FichaCunha"));

            fichaLimpa = PlayerPrefs.GetFloat("FichaCunha");
            float tempFicha = Mathf.Round(PlayerPrefs.GetFloat("FichaCunha"));
            ficha_txtUI.text = (tempFicha.ToString()); // + "%");

            fichaLimpa = PlayerPrefs.GetFloat("FichaCunha");
            fichaLimpa -= Time.deltaTime * veloPerdaFicha;
            PlayerPrefs.SetFloat("FichaCunha", fichaLimpa);

            // BARRA Ficha

            barraFicha.maxValue = max_ficha;
            barraFicha.value = fichaLimpa;

            //

            //MIN E MAX

            if (PlayerPrefs.GetFloat("FichaCunha") <= 0)
            {
                PlayerPrefs.SetFloat("FichaCunha", 0);
            }

            if (PlayerPrefs.GetFloat("FichaCunha") >= 100)
            {
                PlayerPrefs.SetFloat("FichaCunha", 100);
            }


            // INICIO DO JOGO
            if (PlayerPrefs.GetInt("LevelCunha") <= 1 && PlayerPrefs.GetFloat("FichaCunha") <= 100 && PlayerPrefs.GetFloat("PopularidadeCunha") <= 50)
            {
                PlayerPrefs.SetFloat("FichaCunha", 100);
            }




        }
    }

    // METODO DE PERDA DE POPULARIDADE COM FICHA LIMPA BAIXA
    public void CPI()

    {
        if (fichaLimpa <= 30)
        {
            GetComponent<Popularidade>().veloPerdaPop = 0.1f;

            //PlayerPrefs.SetFloat("VeloPerdaPop", 0.1f);

            cpi = 1;
            PlayerPrefs.SetInt("CPI", cpi);

            PlayerPrefs.SetInt("AlertaFichaBaixo", 1);

        }

        if (fichaLimpa > 30)
        {
           GetComponent<Popularidade>().veloPerdaPop = 0.07f;

           // PlayerPrefs.SetFloat("VeloPerdaPop", 0.07f);

            cpi = 0;

            PlayerPrefs.SetInt("CPI", cpi);


        }

        PlayerPrefs.SetFloat("VeloPerdaPop", PlayerPrefs.GetFloat("VeloPerdaPop"));
        PlayerPrefs.SetInt("AlertaFichaBaixo", 0);



    }

    // METODO DE GANHO DE POPULARIDADE COM FICHA LIMPA ALTA
    public void AlmaHonesta()
    {
        if (fichaLimpa >= 90)
        {
            if (PlayerPrefs.GetFloat("PopularidadeNaScene") < 51)
            {
                PlayerPrefs.SetFloat("VeloGanhaPop", 0.2f);

            }
            if (PlayerPrefs.GetFloat("PopularidadeNaScene") >= 51)
            {
                PlayerPrefs.SetFloat("VeloGanhaPop", 0f);

            }

            almaHonesta = 1;
            PlayerPrefs.SetInt("AlmaHonesta", almaHonesta);
            PlayerPrefs.SetInt("AlertaFichaAlto", 1);


        }
        if (fichaLimpa < 90 && fichaLimpa > 30)
        {
            PlayerPrefs.SetFloat("VeloGanhaPop", 0);
            almaHonesta = 0;
            PlayerPrefs.SetInt("AlmaHonesta", almaHonesta);
            PlayerPrefs.SetInt("AlertaFichaAlto", 0);

        }

        PlayerPrefs.SetFloat("VeloGanhaPop", PlayerPrefs.GetFloat("VeloGanhaPop"));
    }

    public void deletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();

    }
}


