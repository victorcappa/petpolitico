using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartidoBatalha : MonoBehaviour {

    GameObject[] PersonagensScene = new GameObject[20];
    public GameObject LulaScene, CiroScene, BolsoScene, DilmaScene, SuplicyScene, EneasScene, DodorioScene, HaddardScene, CunhaScene;
    public int LulaDentroScene, CiroDentroScene, BolsoDentroScene, DilmaDentroScene, SuplicyDentroScene, EneasDentroScene, DodorioDentroScene, HaddardDentroScene, CunhaDentroScene;

    public void Awake()
    {


        LulaDentroScene = PlayerPrefs.GetInt("LulaDentroScene");
        CiroDentroScene = PlayerPrefs.GetInt("CiroDentroScene");
        BolsoDentroScene = PlayerPrefs.GetInt("BolsoDentroScene");
        DilmaDentroScene = PlayerPrefs.GetInt("DilmaDentroScene");
        SuplicyDentroScene = PlayerPrefs.GetInt("SuplicyDentroScene");
        EneasDentroScene = PlayerPrefs.GetInt("EneasDentroScene");
        DodorioDentroScene = PlayerPrefs.GetInt("DodorioDentroScene");
        HaddardDentroScene = PlayerPrefs.GetInt("HaddardDentroScene");
        CunhaDentroScene = PlayerPrefs.GetInt("CunhaDentroScene");
    }
    public void Start()
    {
       

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

        if (DodorioDentroScene == 1)
        {
            AtivaDodorio();
        }

        if (HaddardDentroScene == 1)
        {
            AtivaHaddard();
        }

        if (CunhaDentroScene == 1)
        {
            AtivaCunha();
        }


        PersonagensScene[0] = LulaScene;
        PersonagensScene[1] = CiroScene;
        PersonagensScene[2] = BolsoScene;
        PersonagensScene[3] = DilmaScene;
        PersonagensScene[4] = SuplicyScene;
        PersonagensScene[5] = EneasScene;
        PersonagensScene[6] = DodorioScene;
        PersonagensScene[7] = HaddardScene;
        PersonagensScene[8] = CunhaScene;
    }

    // LULA

    public void AtivaLula()
    {
        int i = 0;
        PersonagensScene[i] = LulaScene;
        PersonagensScene[i].SetActive(true);
        LulaDentroScene = 1;
        PlayerPrefs.SetInt("LulaDentroScene", LulaDentroScene);
        PlayerPrefs.SetInt("DentroDaScene", i);

        if (CiroDentroScene == 1)
        {
            DesativaCiro();

        }
        if (BolsoDentroScene == 1)
        {
            DesativaBolso();

        }
        if (DilmaDentroScene == 1)
        {
            DesativaDilma();

        }
        if (SuplicyDentroScene == 1)
        {
            DesativaSuplicy();

        }
        if (EneasDentroScene == 1)
        {
            DesativaEneas();

        }
        if (DodorioDentroScene == 1)
        {
            DesativaDodorio();

        }
        if (HaddardDentroScene == 1)
        {
            DesativaHaddard();

        }
        if (CunhaDentroScene == 1)
        {
            DesativaCunha();

        }


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
        PlayerPrefs.SetInt("DentroDaScene", i);
       
        if (LulaDentroScene == 1)
        {
            DesativaLula();

        }
        if (BolsoDentroScene == 1)
        {
            DesativaBolso();

        }
        if (DilmaDentroScene == 1)
        {
            DesativaDilma();

        }
        if (SuplicyDentroScene == 1)
        {
            DesativaSuplicy();

        }
        if (EneasDentroScene == 1)
        {
            DesativaEneas();

        }
        if (DodorioDentroScene == 1)
        {
            DesativaDodorio();

        }
        if (HaddardDentroScene == 1)
        {
            DesativaHaddard();

        }
        if (CunhaDentroScene == 1)
        {
            DesativaCunha();

        }


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
        PlayerPrefs.SetInt("DentroDaScene", i);

        if (CiroDentroScene == 1)
        {
            DesativaCiro();

        }
        if (LulaDentroScene == 1)
        {
            DesativaLula();

        }
        if (DilmaDentroScene == 1)
        {
            DesativaDilma();

        }
        if (SuplicyDentroScene == 1)
        {
            DesativaSuplicy();

        }
        if (EneasDentroScene == 1)
        {
            DesativaEneas();

        }
        if (DodorioDentroScene == 1)
        {
            DesativaDodorio();

        }
        if (HaddardDentroScene == 1)
        {
            DesativaHaddard();

        }
        if (CunhaDentroScene == 1)
        {
            DesativaCunha();

        }

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
        PlayerPrefs.SetInt("DentroDaScene", i);

        if (CiroDentroScene == 1)
        {
            DesativaCiro();

        }
        if (BolsoDentroScene == 1)
        {
            DesativaBolso();

        }
        if (LulaDentroScene == 1)
        {
            DesativaLula();

        }
        if (SuplicyDentroScene == 1)
        {
            DesativaSuplicy();

        }
        if (EneasDentroScene == 1)
        {
            DesativaEneas();

        }
        if (DodorioDentroScene == 1)
        {
            DesativaDodorio();

        }
        if (HaddardDentroScene == 1)
        {
            DesativaHaddard();

        }
        if (CunhaDentroScene == 1)
        {
            DesativaCunha();

        }



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
        PlayerPrefs.SetInt("DentroDaScene", i);
     
        if (CiroDentroScene == 1)
        {
            DesativaCiro();

        }
        if (BolsoDentroScene == 1)
        {
            DesativaBolso();

        }
        if (DilmaDentroScene == 1)
        {
            DesativaDilma();

        }
        if (LulaDentroScene == 1)
        {
            DesativaLula();

        }
        if (EneasDentroScene == 1)
        {
            DesativaEneas();

        }
        if (DodorioDentroScene == 1)
        {
            DesativaDodorio();

        }
        if (HaddardDentroScene == 1)
        {
            DesativaHaddard();

        }
        if (CunhaDentroScene == 1)
        {
            DesativaCunha();

        }

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
        PlayerPrefs.SetInt("DentroDaScene", i);

        if (CiroDentroScene == 1)
        {
            DesativaCiro();

        }
        if (BolsoDentroScene == 1)
        {
            DesativaBolso();

        }
        if (DilmaDentroScene == 1)
        {
            DesativaDilma();

        }
        if (SuplicyDentroScene == 1)
        {
            DesativaSuplicy();

        }
        if (LulaDentroScene == 1)
        {
            DesativaLula();

        }
        if (DodorioDentroScene == 1)
        {
            DesativaDodorio();

        }
        if (HaddardDentroScene == 1)
        {
            DesativaHaddard();

        }
        if (CunhaDentroScene == 1)
        {
            DesativaCunha();

        }
    }

    public void DesativaEneas()
    {
        PersonagensScene[5].SetActive(false);
        EneasDentroScene = 0;
        PlayerPrefs.SetInt("EneasDentroScene", EneasDentroScene);


    }



    // DODORIO

    public void AtivaDodorio()
    {
        int i = 6;
        PersonagensScene[i] = DodorioScene;
        PersonagensScene[i].SetActive(true);
        DodorioDentroScene = 1;
        PlayerPrefs.SetInt("DodorioDentroScene", DodorioDentroScene);
        PlayerPrefs.SetInt("DentroDaScene", i);

        if (CiroDentroScene == 1)
        {
            DesativaCiro();

        }
        if (BolsoDentroScene == 1)
        {
            DesativaBolso();

        }
        if (DilmaDentroScene == 1)
        {
            DesativaDilma();

        }
        if (SuplicyDentroScene == 1)
        {
            DesativaSuplicy();

        }
        if (EneasDentroScene == 1)
        {
            DesativaEneas();

        }
        if (LulaDentroScene == 1)
        {
            DesativaLula();

        }
        if (HaddardDentroScene == 1)
        {
            DesativaHaddard();

        }
        if (CunhaDentroScene == 1)
        {
            DesativaCunha();

        }
    

    }

    public void DesativaDodorio()
    {
        PersonagensScene[6].SetActive(false);
        DodorioDentroScene = 0;
        PlayerPrefs.SetInt("DodorioDentroScene", DodorioDentroScene);


    }


    // HADDARD

    public void AtivaHaddard()
    {
        int i = 7;
        PersonagensScene[i] = HaddardScene;
        PersonagensScene[i].SetActive(true);
        HaddardDentroScene = 1;
        PlayerPrefs.SetInt("HaddardDentroScene", HaddardDentroScene);
        PlayerPrefs.SetInt("DentroDaScene", i);

        if (CiroDentroScene == 1)
        {
            DesativaCiro();

        }
        if (BolsoDentroScene == 1)
        {
            DesativaBolso();

        }
        if (DilmaDentroScene == 1)
        {
            DesativaDilma();

        }
        if (SuplicyDentroScene == 1)
        {
            DesativaSuplicy();

        }
        if (EneasDentroScene == 1)
        {
            DesativaEneas();

        }
        if (DodorioDentroScene == 1)
        {
            DesativaDodorio();

        }
        if (LulaDentroScene == 1)
        {
            DesativaLula();

        }
        if (CunhaDentroScene == 1)
        {
            DesativaCunha();

        }
    }

    public void DesativaHaddard()
    {
        PersonagensScene[7].SetActive(false);
        HaddardDentroScene = 0;
        PlayerPrefs.SetInt("HaddardDentroScene", HaddardDentroScene);


    }

    // CUNHA

    public void AtivaCunha()
    {
        int i = 8;
        PersonagensScene[i] = CunhaScene;
        PersonagensScene[i].SetActive(true);
        CunhaDentroScene = 1;
        PlayerPrefs.SetInt("CunhaDentroScene", CunhaDentroScene);
        PlayerPrefs.SetInt("DentroDaScene", i);


    }

    public void DesativaCunha()
    {
        PersonagensScene[8].SetActive(false);
        HaddardDentroScene = 0;
        PlayerPrefs.SetInt("CunhaDentroScene", CunhaDentroScene);
        if (CiroDentroScene == 1)
        {
            DesativaCiro();

        }
        if (BolsoDentroScene == 1)
        {
            DesativaBolso();

        }
        if (DilmaDentroScene == 1)
        {
            DesativaDilma();

        }
        if (SuplicyDentroScene == 1)
        {
            DesativaSuplicy();

        }
        if (EneasDentroScene == 1)
        {
            DesativaEneas();

        }
        if (DodorioDentroScene == 1)
        {
            DesativaDodorio();

        }
        if (HaddardDentroScene == 1)
        {
            DesativaHaddard();

        }
        if (LulaDentroScene == 1)
        {
            DesativaLula();

        }

    }


    public void deletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();

    }

}
