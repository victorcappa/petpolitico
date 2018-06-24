using UnityEngine;

/* 
SISTEMA PARTIDO

    - É possível selecionar qualquer personagem de dentro do partido para a scene
    - Apenas um personagem pode ir para a scene, por vez
*/

public class Partido : MonoBehaviour {
    
     GameObject[] PersonagensScene = new GameObject[20];
    public GameObject LulaScene, CiroScene, BolsoScene, DilmaScene, SuplicyScene, EneasScene;
    public int LulaDentroScene, CiroDentroScene, BolsoDentroScene, DilmaDentroScene, SuplicyDentroScene, EneasDentroScene;

    void Awake()
    {
        LulaDentroScene = PlayerPrefs.GetInt("LulaDentroScene");
        CiroDentroScene = PlayerPrefs.GetInt("CiroDentroScene");
        BolsoDentroScene = PlayerPrefs.GetInt("BolsoDentroScene");
        DilmaDentroScene = PlayerPrefs.GetInt("DilmaDentroScene");
        SuplicyDentroScene = PlayerPrefs.GetInt("SuplicyDentroScene");

        if (LulaDentroScene == 1)
        {
            AtivaLula();
        }

        if (CiroDentroScene == 1)
        {
            AtivaCiro();
        }

        if (BolsoDentroScene == 1)
        {
            AtivaBolso();
        }

        if (DilmaDentroScene == 1)
        {
            AtivaDilma();
        }

        if (SuplicyDentroScene == 1)
        {
            AtivaSuplicy();
        }

        if (EneasDentroScene == 1)
        {
            AtivaEneas();
        }

        PersonagensScene[0] = LulaScene;
        PersonagensScene[1] = CiroScene;
        PersonagensScene[2] = BolsoScene;
        PersonagensScene[3] = DilmaScene;
        PersonagensScene[4] = SuplicyScene;
        PersonagensScene[5] = EneasScene;


    }

    // LULA

    public void AtivaLula()
    {
        int i = 0;
        PersonagensScene[i] = LulaScene;
        PersonagensScene[i].SetActive(true);
        LulaDentroScene = 1;
        PlayerPrefs.SetInt("LulaDentroScene", LulaDentroScene);

    }

    public void DesativaLula()
    {
        PersonagensScene[0].SetActive(false);
        LulaDentroScene = 0;
        PlayerPrefs.SetInt("LulaDentroScene", LulaDentroScene);

    }

    // ------------------------------------------------------------------ //

    // CIRO


    public void AtivaCiro()
    {
        int i = 1;
        PersonagensScene[i] = CiroScene;
        PersonagensScene[i].SetActive(true);
        CiroDentroScene = 1;
        PlayerPrefs.SetInt("CiroDentroScene", CiroDentroScene);

    }

    public void DesativaCiro()
    {

        PersonagensScene[1].SetActive(false);
        CiroDentroScene = 0;
        PlayerPrefs.SetInt("CiroDentroScene", CiroDentroScene);

    }

    // ------------------------------------------------------------------ //


    // BOLSONARO

    public void AtivaBolso()
    {
        int i = 2;
        PersonagensScene[i] = BolsoScene;
        PersonagensScene[i].SetActive(true);
        BolsoDentroScene = 1;
        PlayerPrefs.SetInt("BolsoDentroScene", BolsoDentroScene);

    }

    public void DesativaBolso()
    {
        PersonagensScene[2].SetActive(false);
        BolsoDentroScene = 0;
        PlayerPrefs.SetInt("BolsoDentroScene", BolsoDentroScene);

    }

    // DILMA

    public void AtivaDilma()
    {
        int i = 3;
        PersonagensScene[i] = DilmaScene;
        PersonagensScene[i].SetActive(true);
        DilmaDentroScene = 1;
        PlayerPrefs.SetInt("DilmaDentroScene", DilmaDentroScene);

    }

    public void DesativaDilma()
    {
        PersonagensScene[3].SetActive(false);
        DilmaDentroScene = 0;
        PlayerPrefs.SetInt("DilmaDentroScene", DilmaDentroScene);

    }

    // SUPLICY

    public void AtivaSuplicy()
    {
        int i = 4;
        PersonagensScene[i] = SuplicyScene;
        PersonagensScene[i].SetActive(true);
        SuplicyDentroScene = 1;
        PlayerPrefs.SetInt("SuplicyDentroScene", SuplicyDentroScene);

    }

    public void DesativaSuplicy()
    {
        PersonagensScene[4].SetActive(false);
        SuplicyDentroScene = 0;
        PlayerPrefs.SetInt("SuplicyDentroScene", SuplicyDentroScene);

    }

    // ENEAS

    public void AtivaEneas()
    {
        int i = 5;
        PersonagensScene[i] = EneasScene;
        PersonagensScene[i].SetActive(true);
        EneasDentroScene = 1;
        PlayerPrefs.SetInt("EneasDentroScene", EneasDentroScene);

    }

    public void DesativaEneas()
    {
        PersonagensScene[5].SetActive(false);
        EneasDentroScene = 0;
        PlayerPrefs.SetInt("EneasDentroScene", EneasDentroScene);


    }



}



