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


public class FichaLimpa : MonoBehaviour
{

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
    public float fichaLula, fichaCiro, fichaBolso, fichaDilma, fichaEneas, fichaSuplicy, fichaDodorio, fichaHaddard, fichaCunha;

    public GameObject PartidoManager;

    void Start()
    {
      
        FichaInicial();
    }

    void Update()
    {

        FichaAtualiza();

        CPI();

        AlmaHonesta();

    }



    void MaxMinFicha()
    {
        //MIN E MAX

        if (fichaLimpa <= 0)
        {
            fichaLimpa = 0;
        }

        if (fichaLimpa >= 100)
        {
            fichaLimpa = 100;
        }
    }




    public void FichaAtualiza()

    {
        MaxMinFicha();

        if (PartidoManager.GetComponent<Partido>().LulaDentroScene == 1)

        {
            fichaLula = Mathf.Round(fichaLimpa);
            ficha_txtUI.text = Mathf.Round(fichaLimpa).ToString(); // + "%");

            fichaLimpa -= Time.deltaTime * veloPerdaFicha;


            // BARRA Ficha

            barraFicha.maxValue = max_ficha;
            barraFicha.value = fichaLimpa;

            //

            PlayerPrefs.SetFloat("FichaLula", fichaLimpa);

        }


        if (PartidoManager.GetComponent<Partido>().CiroDentroScene == 1)
        {
            fichaCiro = Mathf.Round(fichaLimpa);
            ficha_txtUI.text = Mathf.Round(fichaLimpa).ToString(); // + "%");

            fichaLimpa -= Time.deltaTime * veloPerdaFicha;


            // BARRA Ficha

            barraFicha.maxValue = max_ficha;
            barraFicha.value = fichaLimpa;

            //

            PlayerPrefs.SetFloat("FichaCiro", fichaLimpa);

        }


        if (PartidoManager.GetComponent<Partido>().BolsoDentroScene == 1)
        {
            fichaBolso = Mathf.Round(fichaLimpa);
            ficha_txtUI.text = Mathf.Round(fichaLimpa).ToString(); // + "%");

            fichaLimpa -= Time.deltaTime * veloPerdaFicha;


            // BARRA Ficha

            barraFicha.maxValue = max_ficha;
            barraFicha.value = fichaLimpa;

            //

            PlayerPrefs.SetFloat("FichaBolso", fichaLimpa);
        }

        if (PartidoManager.GetComponent<Partido>().DilmaDentroScene == 1)
        {
            fichaDilma = Mathf.Round(fichaLimpa);
            ficha_txtUI.text = Mathf.Round(fichaLimpa).ToString(); // + "%");

            fichaLimpa -= Time.deltaTime * veloPerdaFicha;


            // BARRA Ficha

            barraFicha.maxValue = max_ficha;
            barraFicha.value = fichaLimpa;

            //

            PlayerPrefs.SetFloat("FichaDilma", fichaLimpa);
        }

        if (PartidoManager.GetComponent<Partido>().SuplicyDentroScene == 1)
        {
            fichaSuplicy = Mathf.Round(fichaLimpa);
            ficha_txtUI.text = Mathf.Round(fichaLimpa).ToString(); // + "%");

            fichaLimpa -= Time.deltaTime * veloPerdaFicha;


            // BARRA Ficha

            barraFicha.maxValue = max_ficha;
            barraFicha.value = fichaLimpa;

            //

            PlayerPrefs.SetFloat("FichaSuplicy", fichaLimpa);
        }


        if (PartidoManager.GetComponent<Partido>().EneasDentroScene == 1)
        {
            fichaEneas = Mathf.Round(fichaLimpa);
            ficha_txtUI.text = Mathf.Round(fichaLimpa).ToString(); // + "%");

            fichaLimpa -= Time.deltaTime * veloPerdaFicha;


            // BARRA Ficha

            barraFicha.maxValue = max_ficha;
            barraFicha.value = fichaLimpa;

            //

            PlayerPrefs.SetFloat("FichaEneas", fichaLimpa);
        }

        if (PartidoManager.GetComponent<Partido>().HaddardDentroScene == 1)
        {
            fichaHaddard = Mathf.Round(fichaLimpa);
            ficha_txtUI.text = Mathf.Round(fichaLimpa).ToString(); // + "%");

            fichaLimpa -= Time.deltaTime * veloPerdaFicha;


            // BARRA Ficha

            barraFicha.maxValue = max_ficha;
            barraFicha.value = fichaLimpa;

            //

            PlayerPrefs.SetFloat("FichaHaddard", fichaLimpa);
        }

        if (PartidoManager.GetComponent<Partido>().DodorioDentroScene == 1)
        {
            fichaDodorio = Mathf.Round(fichaLimpa);
            ficha_txtUI.text = Mathf.Round(fichaLimpa).ToString(); // + "%");

            fichaLimpa -= Time.deltaTime * veloPerdaFicha;


            // BARRA Ficha

            barraFicha.maxValue = max_ficha;
            barraFicha.value = fichaLimpa;

            //

            PlayerPrefs.SetFloat("FichaDodorio", fichaLimpa);
        }

        if (PartidoManager.GetComponent<Partido>().CunhaDentroScene == 1)
        {
            fichaCunha = Mathf.Round(fichaLimpa);
            ficha_txtUI.text = Mathf.Round(fichaLimpa).ToString(); // + "%");

            fichaLimpa -= Time.deltaTime * veloPerdaFicha;


            // BARRA Ficha

            barraFicha.maxValue = max_ficha;
            barraFicha.value = fichaLimpa;

            //

            PlayerPrefs.SetFloat("FichaCunha", fichaLimpa);
        }
    }

    public void FichaInicial()
    {
        if (PartidoManager.GetComponent<Partido>().LulaDentroScene == 1)
        {
            //VERIFICA SE É PRIMEIRA VEZ
            if (gameObject.GetComponent<Influencia>().level <= 1 && fichaLula <= 100 && gameObject.GetComponent<Popularidade>().popLula <= 50)
            {
                fichaLula = 100;
            }

            fichaLula = PlayerPrefs.GetFloat("FichaLula");
            fichaLimpa = fichaLula;

        }


        if (PartidoManager.GetComponent<Partido>().CiroDentroScene == 1)
        {
            //VERIFICA SE É PRIMEIRA VEZ
            if (gameObject.GetComponent<Influencia>().level <= 1 && fichaCiro <= 100 && gameObject.GetComponent<Popularidade>().popCiro <= 50)
            {
                fichaCiro = 100;
            }

            fichaCiro = PlayerPrefs.GetFloat("FichaCiro");
            fichaLimpa = fichaCiro;
        }

        if (PartidoManager.GetComponent<Partido>().BolsoDentroScene == 1)
        {
            //VERIFICA SE É PRIMEIRA VEZ
            if (gameObject.GetComponent<Influencia>().level <= 1 && fichaBolso <= 100 && gameObject.GetComponent<Popularidade>().popBolso <= 50)
            {
                fichaBolso = 100;
            }

            fichaBolso = PlayerPrefs.GetFloat("FichaBolso");
            fichaLimpa = fichaBolso;
        }

        if (PartidoManager.GetComponent<Partido>().DilmaDentroScene == 1)
        {
            //VERIFICA SE É PRIMEIRA VEZ
            if (gameObject.GetComponent<Influencia>().level <= 1 && fichaDilma <= 100 && gameObject.GetComponent<Popularidade>().popDilma <= 50)
            {
                fichaDilma = 100;
            }

            fichaDilma = PlayerPrefs.GetFloat("FichaDilma");
            fichaLimpa = fichaDilma;
        }

        if (PartidoManager.GetComponent<Partido>().SuplicyDentroScene == 1)
        {
            //VERIFICA SE É PRIMEIRA VEZ
            if (gameObject.GetComponent<Influencia>().level <= 1 && fichaSuplicy <= 100 && gameObject.GetComponent<Popularidade>().popSuplicy <= 50)
            {
                fichaSuplicy = 100;
            }

            fichaSuplicy = PlayerPrefs.GetFloat("FichaSuplicy");
            fichaLimpa = fichaSuplicy;
        }
       
        if (PartidoManager.GetComponent<Partido>().EneasDentroScene == 1)
        {
            //VERIFICA SE É PRIMEIRA VEZ
            if (gameObject.GetComponent<Influencia>().level <= 1 && fichaEneas <= 100 && gameObject.GetComponent<Popularidade>().popEneas <= 50)
            {
                fichaEneas = 100;
            }

            fichaEneas = PlayerPrefs.GetFloat("FichaEneas");
            fichaLimpa = fichaEneas;
        }

        if (PartidoManager.GetComponent<Partido>().HaddardDentroScene == 1)
        {
            //VERIFICA SE É PRIMEIRA VEZ
            if (gameObject.GetComponent<Influencia>().level <= 1 && fichaHaddard <= 100 && gameObject.GetComponent<Popularidade>().popHaddard <= 50)
            {
                fichaHaddard = 100;
            }

            fichaHaddard = PlayerPrefs.GetFloat("FichaHaddard");
            fichaLimpa = fichaHaddard;
        }

        if (PartidoManager.GetComponent<Partido>().DodorioDentroScene == 1)
        {
            //VERIFICA SE É PRIMEIRA VEZ
            if (gameObject.GetComponent<Influencia>().level <= 1 && fichaDodorio <= 100 && gameObject.GetComponent<Popularidade>().popDodorio <= 50)
            {
                fichaDodorio = 100;
            }

            fichaDodorio = PlayerPrefs.GetFloat("FichaDodorio");
            fichaLimpa = fichaDodorio;
        }

        if (PartidoManager.GetComponent<Partido>().CunhaDentroScene == 1)
        {
            //VERIFICA SE É PRIMEIRA VEZ
            if (gameObject.GetComponent<Influencia>().level <= 1 && fichaCunha <= 100 && gameObject.GetComponent<Popularidade>().popCunha <= 50)
            {
                fichaCunha = 100;
            }

            fichaCunha = PlayerPrefs.GetFloat("FichaCunha");
            fichaLimpa = fichaCunha;
        }
    }

    // METODO DE PERDA DE POPULARIDADE COM FICHA LIMPA BAIXA
    public void CPI()

    {
        if (fichaLimpa <= 20)
        {
            //PlayerPrefs.SetFloat("VeloPerdaPop", 0.5f);
            gameObject.GetComponent<Popularidade>().veloPerdaPop = 0.5f;

            cpi = 1;
            //PlayerPrefs.SetInt("CPI", cpi);

        }

        if (fichaLimpa > 20)
        {
            gameObject.GetComponent<Popularidade>().veloPerdaPop = 0.1f;

           // PlayerPrefs.SetFloat("VeloPerdaPop", 0.1f);

            cpi = 0;

            //PlayerPrefs.SetInt("CPI", cpi);


        }

      //  PlayerPrefs.SetFloat("VeloPerdaPop", PlayerPrefs.GetFloat("VeloPerdaPop"));



    }

    // METODO DE GANHO DE POPULARIDADE COM FICHA LIMPA ALTA
    public void AlmaHonesta()
    {
        if (fichaLimpa >= 90)
        {
            if (gameObject.GetComponent<Popularidade>().popScene < 51)
            {
              
                gameObject.GetComponent<Popularidade>().veloGanhaPop = 0.5f;

            }
            if (gameObject.GetComponent<Popularidade>().popScene >= 51)
            {
                gameObject.GetComponent<Popularidade>().veloGanhaPop = 0f;

            }

            almaHonesta = 1;

        }

        if (fichaLimpa < 90 && fichaLimpa > 20)
        {
            gameObject.GetComponent<Popularidade>().veloGanhaPop = 0f;

            almaHonesta = 0;

        }

    }

    public void deletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();

    }
}
