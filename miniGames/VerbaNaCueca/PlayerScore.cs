
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{

    private Text scoreText;
    private int score = 10;
    int chances;
    public Text chances_txtUI;
    public GameObject telaOver;
    public int quantoGanhou;
    public Text quantoGanhouTxt;
    public AudioSource SomVerba, SomPf, GameOver, SomPowerUp;
    public bool habeasCorpus;
    public GameObject HabeasCorpus;
    public int qteHabeasCorpus;
    public Text qteHabeasCorpusTxt;
    public void Awake()
    {
       // scoreText = GameObject.Find("Verba_txt").GetComponent<Text>();
       // scoreText.text = PlayerPrefs.GetInt("Verba").ToString();
        chances = 3;
        chances_txtUI.text = chances.ToString();


    }

    public void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PF" || target.tag == "Moro" || target.tag == "Receita")
        {
            target.gameObject.SetActive(false);

            if (habeasCorpus == true)
            {
                chances = chances + 1;
                qteHabeasCorpus = qteHabeasCorpus - 1;

                qteHabeasCorpusTxt.text = qteHabeasCorpus.ToString();

                if (qteHabeasCorpus == 0)
                {
                    habeasCorpus = false;
                    HabeasCorpus.gameObject.SetActive(false);

                }
            
               


            }

           
                chances = chances - 1;

                chances_txtUI.text = chances.ToString();
                SomPf.Play();


          

            if (chances <= 0 && habeasCorpus == false)
            {
                telaOver.gameObject.SetActive(true);

                this.gameObject.GetComponent<Image>().enabled = false;

                //transform.position = new Vector2(0, 100); // mover o player pra longe (pra simular que ele sumiu / se sumir de verdade, o script nao roda)

                PlayerPrefs.SetInt("Chances", chances);

                GameOver.Play();
                SomPf.Play();



            }

        }

        if (target.tag == "Verba_MiniGame")
        {
            score = 5;
            target.gameObject.SetActive(false);
            scoreText = GameObject.Find("Verba_txt").GetComponent<Text>();
            PlayerPrefs.SetInt("Verba", PlayerPrefs.GetInt("Verba") + score);
            scoreText.text = PlayerPrefs.GetInt("Verba").ToString();
            quantoGanhou = quantoGanhou + score;
            quantoGanhouTxt.text = quantoGanhou.ToString();
            SomVerba.Play();
            PlayerPrefs.SetInt("ScoreCueca", score);
        }

        if (target.tag == "HabeasCorpus")
        {
            target.gameObject.SetActive(false);
            habeasCorpus = true;
            HabeasCorpus.gameObject.SetActive(true);
            SomPowerUp.Play();
            qteHabeasCorpus = qteHabeasCorpus + 1;
            qteHabeasCorpusTxt.text = qteHabeasCorpus.ToString();

        }


    }

   

    public void RestartGame()
    {
        telaOver.gameObject.SetActive(false);

        PlayerPrefs.SetInt("ScoreCueca", 0);

        scoreText = GameObject.Find("Verba_txt").GetComponent<Text>();
        scoreText.text = PlayerPrefs.GetInt("Verba").ToString();

        chances = 3;
        chances_txtUI.text = chances.ToString();
        PlayerPrefs.SetInt("Chances", chances);
       
        GameOver.Stop();

        habeasCorpus = false;
       // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        this.gameObject.GetComponent<Image>().enabled = true;

        // transform.position = new Vector2(0, 0);

    }

   


  


}// FIM DA CLASSE













