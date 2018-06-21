
using UnityEngine;
using UnityEngine.UI;

public class Verba : MonoBehaviour {

    public int verba;
    public Text verba_txtUI;
    public bool primeiraVez;

    public void Awake()
    {
        verba = PlayerPrefs.GetInt("Verba");
        minVerba();
        verbaInicial();
       
    }

    public void Update()
    {        
        //PlayerPrefs.DeleteAll();


        verba = PlayerPrefs.GetInt("Verba");
        verba_txtUI.text = verba.ToString();
        minVerba();

       
    }

    public void GanhaVerba()
    {
        int cresceVerba = 10;
        PlayerPrefs.SetInt("Verba", PlayerPrefs.GetInt("Verba") + cresceVerba);

    }

    public void minVerba()
    {
        if (PlayerPrefs.GetInt("Verba") <= 0)
        {
            PlayerPrefs.SetInt("Verba", 0);
        }
    }

    public void verbaInicial()
    {
        if (verba <= 0 && PlayerPrefs.GetInt("LevelIndice") <= 0 && PlayerPrefs.GetInt("DentroDoPartido") == 0)
        {
            primeiraVez = true;

            if (primeiraVez == true && PlayerPrefs.GetInt("DentroDoPartido") == 0 )
            {
                verba = 200;
                PlayerPrefs.SetInt("Verba", verba);
            }
            if (primeiraVez == true && PlayerPrefs.GetInt("DentroDoPartido") > 0 && verba > 0 )
            {
                primeiraVez = false;
                verba = 0;

            }

        }
    }



}
