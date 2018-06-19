using UnityEngine;

public class Partido : MonoBehaviour {
    
     GameObject[] PersonagensScene = new GameObject[20];     public GameObject LulaScene, CiroScene, BolsonaroScene;
    public int LulaDentroScene, CiroDentroScene, BolsoDentroScene;     //public GameObject[] ArrayPoliticos;      void Awake()     {         LulaDentroScene = PlayerPrefs.GetInt("LulaDentroScene");
        CiroDentroScene = PlayerPrefs.GetInt("CiroDentroScene");
        BolsoDentroScene = PlayerPrefs.GetInt("BolsoDentroScene");

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
            AtivaBolsonaro();
        }
         PersonagensScene[0] = LulaScene;         PersonagensScene[1] = CiroScene;         PersonagensScene[2] = BolsonaroScene;       } 
    // LULA      public void AtivaLula()     {         int i = 0;         PersonagensScene[i] = LulaScene;         PersonagensScene[i].SetActive(true);
        LulaDentroScene = 1;
        PlayerPrefs.SetInt("LulaDentroScene", LulaDentroScene);      }      public void DesativaLula()     {         PersonagensScene[0].SetActive(false);
        LulaDentroScene = 0;
        PlayerPrefs.SetInt("LulaDentroScene", LulaDentroScene);
     }

    // ------------------------------------------------------------------ //
     // CIRO

     public void AtivaCiro()     {         int i = 1;         PersonagensScene[i] = CiroScene;         PersonagensScene[i].SetActive(true);         CiroDentroScene = 1;
        PlayerPrefs.SetInt("CiroDentroScene", CiroDentroScene);      }      public void DesativaCiro()     {          PersonagensScene[1].SetActive(false);         CiroDentroScene = 0;
        PlayerPrefs.SetInt("CiroDentroScene", CiroDentroScene);      }
     // ------------------------------------------------------------------ //


    // BOLSONARO
     public void AtivaBolsonaro()     {         int i = 2;         PersonagensScene[i] = BolsonaroScene;         PersonagensScene[i].SetActive(true);         BolsoDentroScene = 1;
        PlayerPrefs.SetInt("BolsoDentroScene", BolsoDentroScene);      }      public void DesativaBolsonaro()     {         PersonagensScene[2].SetActive(false);         BolsoDentroScene = 0;
        PlayerPrefs.SetInt("BolsoDentroScene", BolsoDentroScene);      }




} 


