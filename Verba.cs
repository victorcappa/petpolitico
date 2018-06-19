using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Verba : MonoBehaviour {

    public int verba;
    public Text verba_txtUI;

    public void Awake()
    {
        verba = PlayerPrefs.GetInt("Verba");
    }

    public void Update()
    {

        verba = PlayerPrefs.GetInt("Verba");
        verba_txtUI.text = verba.ToString();
    }

    public void GanhaVerba()
    {
        int cresceVerba = 10;
        PlayerPrefs.SetInt("Verba", PlayerPrefs.GetInt("Verba") + cresceVerba);

    }



}
