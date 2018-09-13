using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Debates : MonoBehaviour {

    public int lvlDesblock;
    public Image imgDebate;

    // ----------------- //


    public void Update()
    {
        DesbloqueiaDebate();
    }

    public void DesbloqueiaDebate()
    {
        if (PlayerPrefs.GetInt("LevelIndice") >= lvlDesblock)
        {
            imgDebate.enabled = true;        
        }

        if (PlayerPrefs.GetInt("LevelIndice") < lvlDesblock)
        {
            imgDebate.enabled = false;        

        }
    }
}
