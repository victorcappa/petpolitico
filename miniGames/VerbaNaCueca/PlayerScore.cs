
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class PlayerScore : MonoBehaviour {

    private Text scoreText;
    private int score = 0;


    private void Awake()
    {
        scoreText = GameObject.Find("Verba_txt").GetComponent<Text>();
        score = PlayerPrefs.GetInt("Verba");
        scoreText.text = score.ToString();

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PF")
        {
            transform.position = new Vector2(0,100); // mover o player pra longe (pra simular que ele sumiu / se sumir de verdade, o script nao roda)
            target.gameObject.SetActive(false);
            StartCoroutine(RestartGame());
        }

        if (target.tag ==  "Verba_MiniGame")
        {
            target.gameObject.SetActive(false);
            score = score + 10;
            scoreText.text = score.ToString();
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}// FIM DA CLASSE













