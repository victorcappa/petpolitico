using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;

public class FichaLimpa : MonoBehaviour {

    public Text ficha_txtUI;
    public float veloPerdaFicha;
    public float fichaLimpa = 50;
    public float max_ficha = 100;
    public float min_ficha = 0;
    public bool recuperarFicha = false;
    public int cpi;
    //public GameObject tempPersonagem;



    void Start()
    {
        //PlayerPrefs.DeleteAll();

        FichaPersonagens();
        CPI();

    }

    // Update is called once per frame
    void Update()
    {

        FichaPersonagens();
        CPI();

        GanhaFicha();
        MaxMinFicha();

       // PlayerPrefs.GetFloat("VeloPerdaPop", PlayerPrefs.GetFloat("VeloPerdaPop"));
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

            if (PlayerPrefs.GetFloat("FichaLula") <= 0)
            {
                PlayerPrefs.SetFloat("FichaLula", 100);
            }
            if (PlayerPrefs.GetInt("LevelLula") == 0 && PlayerPrefs.GetFloat("FichaLula") <= 0)
            {
                PlayerPrefs.SetFloat("FichaLula", 50);
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
                PlayerPrefs.SetFloat("FichaCiro", 100);
            }

            if (PlayerPrefs.GetInt("LevelCiro") == 0 && PlayerPrefs.GetFloat("FichaCiro") <= 0)
            {
                PlayerPrefs.SetFloat("FichaCiro", 50);
            }



        }


        if (PlayerPrefs.GetInt("BolsoDentroScene") == 1)
        {
            fichaLimpa = PlayerPrefs.GetFloat("FichaBolsonaro");
            float tempFicha = Mathf.Round(PlayerPrefs.GetFloat("FichaBolsonaro"));
            ficha_txtUI.text = (tempFicha.ToString() + "%");

            fichaLimpa = PlayerPrefs.GetFloat("FichaBolsonaro");
            fichaLimpa -= Time.deltaTime * veloPerdaFicha;
            PlayerPrefs.SetFloat("FichaBolsonaro", fichaLimpa);

            if (PlayerPrefs.GetFloat("FichaBolsonaro") <= 0)
            {
                PlayerPrefs.SetFloat("FichaBolsonaro", 0);

                if (PlayerPrefs.GetInt("LevelBolso") == 0 && PlayerPrefs.GetFloat("FichaBolsonaro") <= 0)
                {
                    PlayerPrefs.SetFloat("FichaBolsonaro", 50);
                }
            }


           

        }





    }


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
}
