using System.Collections;
using UnityEngine;

public class Collector : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PF" || target.tag == "Verba_MiniGame")
        {
            target.gameObject.SetActive(false);
            // Destroy.(target.tag) tb funciona, mas prejudica a performance
        }
    }
}
