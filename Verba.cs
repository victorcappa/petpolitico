
using UnityEngine;
using UnityEngine.UI;

public class Verba : MonoBehaviour {

    public int verba;
    public Text verba_txtUI;

    public void Awake()
    {
        verba = PlayerPrefs.GetInt("Verba");
        minVerba();
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



}
