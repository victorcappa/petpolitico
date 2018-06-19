using UnityEngine;
using UnityEngine.UI;

public class Politico : MonoBehaviour {

    public string nomePoli = "";
    public Text nomePoli_txtUI;



	// Use this for initialization
	void Start () 

    {
        nomePoli_txtUI.text = nomePoli;
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
}
