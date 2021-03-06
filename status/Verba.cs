
using UnityEngine;
using UnityEngine.UI;

/* 
 VERBA

- não pertence ao personagem individualmente, mas ao jogador
- não há mudança de verba na mudança de personagem
- o jogo é iniciado com 200 de verba (para comprar o primeiro personagem)
- Ao passar de de level, ganha 100 de verba

*/

public class Verba : MonoBehaviour {

    public int verba;
    public Text verba_txtUI;
    public bool primeiraVez;
    public GameObject[] itens;

    public void Awake()
    {
        verba = PlayerPrefs.GetInt("Verba");
        minVerba();
        verbaInicial();

        // Colocar os itens comprados, na scene
        for (int i = 0; i < itens.Length; i++ )
        {
            itens[i].gameObject.GetComponent<CompraItens>().FoiComprado();

        }

    }

    public void Update()
    {        


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
                verba = 230;
                PlayerPrefs.SetInt("Verba", verba);
            }
            if (primeiraVez == true && PlayerPrefs.GetInt("DentroDoPartido") > 0 && verba > 0 )
            {
                primeiraVez = false;
                verba = 0;

            }

        }
    }

    public void deletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();

    }


} // fim da classe
