using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PartidoInimigo : MonoBehaviour
{

    public enum TipoDePartidoInimigo
    {
        ELEICAOVEREADOR,
        ELEICAODEPUTADO,
        ELEICAOPREFEITO,
        ELEICAOGOVERNADOR,
        ELEICAOPRESIDENTE,
        IMPEACHMENT,
        MILITANTES,
        LAVAJATO,
        SABATINA,

        DILMA,
        CIRAO,
        SUPLICY,
        ENEAS,
        CUNHA
    }

    // Imagem que aparece no partido do inimigo
    public GameObject LulaPartido, CiroPartido, BolsoPartido, DilmaPartido, SuplicyPartido, EneasPartido, DodorioPartido, HaddardPartido, CunhaPartido;

    // numero 0 ou 1, que define se o personagem está no partido
    public int LulaDentroPartido, CiroDentroPartido, BolsoDentroPartido, DilmaDentroPartido, SuplicyDentroPartido, EneasDentroPartido, DodorioDentroPartido, HaddardDentroPartido, CunhaDentroPartido;

    // Lista que define quem vai estar na scene, em cada situação
    public List<GameObject> NessaScene = new List<GameObject>();

    // Inimigos na Scene
    public GameObject LulaInimigo, CiroInimigo, BolsoInimigo, DilmaInimigo, SuplicyInimigo, EneasInimigo, DodorioInimigo, HaddardInimigo, CunhaInimigo;

    public float popInimigoLula, popInimigoCiro, popInimigoBolso, popInimigoDilma, popInimigoSuplicy, popInimigoEneas, popInimigoDodorio, popInimigoHaddard, popInimigoCunha;

    // public float popularidadeInimigoScene;
    // enum que define qual será o tipo de partido
    public TipoDePartidoInimigo partidoInimigoAtual;

    // enum que define qual o tipo da batalha 
    public SistemaBatalhas tipoDaBatalha;

    public int primeiraVez;
    public bool podeTrocarInimigo;
    GameObject apoioMidiaInimigo, confiancaInimigo;

    public GameObject inimigoDerrotado;

    /*  
        0 LULA
        1 CIRO
        2 BOLSO
        3 DILMA
        4 SUPLICY
        5 ENEAS
        6 DODORIO
        7 HADDARD
        8 CUNHA

    */
    public void Awake()
    {
        QualPartido();
        QualBatalha();

        primeiraVez = 1;

        PlayerPrefs.SetInt("PrimeiraVez", 1);



    }
    public void Start()
    {
        QualBatalha();

        QualPartido();



    } // FIM START

    private void Update()
    {
        QualBatalha();

        QualPartido();

    }


    public void QualBatalha()
    {
        tipoDaBatalha = GetComponent<SistemaBatalhas>();


        switch (tipoDaBatalha.tipoDessaBatalha)
        {
            case SistemaBatalhas.TipoBatalha.ELEICAOVEREADOR:

                partidoInimigoAtual = TipoDePartidoInimigo.ELEICAOVEREADOR;

                break;

            case SistemaBatalhas.TipoBatalha.ELEICAODEPUTADO:

                partidoInimigoAtual = TipoDePartidoInimigo.ELEICAODEPUTADO;

                break;

            case SistemaBatalhas.TipoBatalha.ELEICAOPREFEITO:

                partidoInimigoAtual = TipoDePartidoInimigo.ELEICAOPREFEITO;

                break;

            case SistemaBatalhas.TipoBatalha.ELEICAOGOVERNADOR:

                partidoInimigoAtual = TipoDePartidoInimigo.ELEICAOGOVERNADOR;

                break;

            case SistemaBatalhas.TipoBatalha.ELEICAOPRESIDENTE:

                partidoInimigoAtual = TipoDePartidoInimigo.ELEICAOPRESIDENTE;

                break;

            case SistemaBatalhas.TipoBatalha.IMPEACHMENT:
                partidoInimigoAtual = TipoDePartidoInimigo.IMPEACHMENT;


                break;

            case SistemaBatalhas.TipoBatalha.LAVAJATO:
                partidoInimigoAtual = TipoDePartidoInimigo.LAVAJATO;


                break;

            case SistemaBatalhas.TipoBatalha.MILITANTES:
                partidoInimigoAtual = TipoDePartidoInimigo.MILITANTES;


                break;

            case SistemaBatalhas.TipoBatalha.DILMA:
                partidoInimigoAtual = TipoDePartidoInimigo.DILMA;


                break;

            case SistemaBatalhas.TipoBatalha.CIRAO:
                partidoInimigoAtual = TipoDePartidoInimigo.CIRAO;

                break;

            case SistemaBatalhas.TipoBatalha.SUPLICY:
                partidoInimigoAtual = TipoDePartidoInimigo.SUPLICY;

                break;

            case SistemaBatalhas.TipoBatalha.ENEAS:
                partidoInimigoAtual = TipoDePartidoInimigo.ENEAS;

                break;

            case SistemaBatalhas.TipoBatalha.CUNHA:
                partidoInimigoAtual = TipoDePartidoInimigo.CUNHA;

                break;

            case SistemaBatalhas.TipoBatalha.SABATINA:
                partidoInimigoAtual = TipoDePartidoInimigo.SABATINA;

                break;

        }
    }

    public void QualPartido()
    {

        switch (partidoInimigoAtual)
        {
            case TipoDePartidoInimigo.ELEICAOVEREADOR:


                PartidoEleicaoVereador();

                break;

            case TipoDePartidoInimigo.ELEICAODEPUTADO:

                PartidoEleicaoDeputado();

                break;

            case TipoDePartidoInimigo.ELEICAOPREFEITO:

                PartidoEleicaoPrefeito();

                break;

            case TipoDePartidoInimigo.ELEICAOGOVERNADOR:

                PartidoEleicaoGovernador();

                break;

            case TipoDePartidoInimigo.ELEICAOPRESIDENTE:

                PartidoEleicaoPresidente();

                break;

            case TipoDePartidoInimigo.IMPEACHMENT:
                PartidoImpeachment();

                break;

            case TipoDePartidoInimigo.LAVAJATO:
                PartidoLavaJato();
                break;

            case TipoDePartidoInimigo.MILITANTES:
                PartidoMilitantes();
                break;

            case TipoDePartidoInimigo.DILMA:
                PartidoDilma();
                break;

            case TipoDePartidoInimigo.CIRAO:
                PartidoCirao();
                break;

            case TipoDePartidoInimigo.SUPLICY:
                PartidoSuplicy();
                break;

            case TipoDePartidoInimigo.ENEAS:
                PartidoEneas();
                break;

            case TipoDePartidoInimigo.CUNHA:
                PartidoCunha();
                break;

            case TipoDePartidoInimigo.SABATINA:
                PartidoSabatina();
                break;


        }


    }


    // ------- ELEIÇÕES -------

    public void PartidoEleicaoVereador()
    {
        PlayerPrefs.SetInt("CiroInimigoScene", 0);
        PlayerPrefs.SetInt("DilmaInimigoScene", 0);
        PlayerPrefs.SetInt("SuplicyInimigoScene", 0);
        PlayerPrefs.SetInt("EneasInimigoScene", 0);
        PlayerPrefs.SetInt("BolsoInimigoScene", 0);
        PlayerPrefs.SetInt("CunhaInimigoScene", 0);
        PlayerPrefs.SetInt("DodorioInimigoScene", 0);
        PlayerPrefs.SetInt("HaddardInimigoScene", 0);



        // ----------- //

        NaSceneOff(CiroInimigo);
        NaSceneOff(BolsoInimigo);
        NaSceneOff(SuplicyInimigo);
        NaSceneOff(EneasInimigo);
        NaSceneOff(DodorioInimigo);
        NaSceneOff(HaddardInimigo);
        NaSceneOff(CunhaInimigo);



        // ----------- //

        popInimigoLula = 100;

        PlayerPrefs.SetFloat("AutoridadeLulaInimigo", 230);
        PlayerPrefs.SetFloat("ApoioMidiaLulaInimigo", 16);
        PlayerPrefs.SetFloat("RetoricaLulaInimigo", 21);
        PlayerPrefs.SetInt("ConfiancaLulaInimigo", 21);
        PlayerPrefs.SetInt("LevelLulaInimigo", 3);

       

        if (primeiraVez == 1)
        {
            //DENTRO
            LulaPartidoOn();




            //FORA
            CiroPartidoOff();
            BolsoPartidoOff();
            EneasPartidoOff();
            SuplicyPartidoOff();
            DodorioPartidoOff();
            HaddardPartidoOff();
            CunhaPartidoOff();
            DilmaPartidoOff();



            // -------- //


            PlayerPrefs.SetFloat("PopInimigos", 0);

            PlayerPrefs.SetInt("QuantosInimigos", 1);

            if (PlayerPrefs.GetInt("QuantosInimigos") == 1 && PlayerPrefs.GetFloat("PopInimigos") <= 0)
            {
               

                PlayerPrefs.SetInt("LulaInimigoScene", 1);

                StartCoroutine(ColocaScene(LulaInimigo, 1f));
                PlayerPrefs.SetFloat("PopInimigos", popInimigoLula);

                print("essa é a primeira vez. PopInimigos = ");
                print(PlayerPrefs.GetFloat("PopInimigos"));
            }


            primeiraVez = 0;

            PlayerPrefs.SetInt("PrimeiraVez", primeiraVez);

            podeTrocarInimigo = true;

        }




        if (PlayerPrefs.GetInt("QuantosInimigos") == 0)
        {
            PlayerPrefs.SetInt("LulaInimigoScene", 0);
            StartCoroutine(TiraScene(LulaInimigo));
            PlayerPrefs.SetFloat("PopInimigos", 0);
        }





    } // FIM PARTIDO VEREADOR

    public void PartidoEleicaoDeputado()
    {
        // ----------- //

        NaSceneOff(CiroInimigo);
        NaSceneOff(LulaInimigo);
        NaSceneOff(SuplicyInimigo);
        NaSceneOff(EneasInimigo);
        NaSceneOff(DilmaInimigo);
        NaSceneOff(HaddardInimigo);
        NaSceneOff(CunhaInimigo);


        // ----------- //

        popInimigoBolso = 100;
        popInimigoDodorio = 100;

        PlayerPrefs.SetFloat("AutoridadeBolsoInimigo", 240); // 20 + lvl 4
        PlayerPrefs.SetFloat("ApoioMidiaBolsoInimigo", 18); // 10 + 4
        PlayerPrefs.SetFloat("RetoricaBolsoInimigo", 18);
        PlayerPrefs.SetInt("ConfiancaBolsoInimigo", 28);
        PlayerPrefs.SetInt("LevelBolsoInimigo", 4);


        PlayerPrefs.SetFloat("AutoridadeDodorioInimigo", 210);
        PlayerPrefs.SetFloat("ApoioMidiaDodorioInimigo", 32);
        PlayerPrefs.SetFloat("RetoricaDodorioInimigo", 22);
        PlayerPrefs.SetInt("ConfiancaDodorioInimigo", 32);
        PlayerPrefs.SetInt("LevelDodorioInimigo", 6);

        if (primeiraVez == 1)
        {
            //DENTRO
            BolsoPartidoOn();
            DodorioPartidoOn();


            //FORA
            CiroPartidoOff();
            EneasPartidoOff();
            SuplicyPartidoOff();
            LulaPartidoOff();
            DilmaPartidoOff();
            HaddardPartidoOff();
            CunhaPartidoOff();


            // -------- //


            PlayerPrefs.SetFloat("PopInimigos", 0);

            PlayerPrefs.SetInt("QuantosInimigos", 2);

            if (PlayerPrefs.GetInt("QuantosInimigos") == 2 && PlayerPrefs.GetFloat("PopInimigos") <= 0)
            {
                PlayerPrefs.SetInt("BolsoInimigoScene", 1);
                PlayerPrefs.SetInt("DodorioInimigoScene", 0);
                StartCoroutine(ColocaScene(BolsoInimigo, 1f));
                PlayerPrefs.SetFloat("PopInimigos", popInimigoBolso);

                print(PlayerPrefs.GetFloat("PopInimigos"));
            }


            primeiraVez = 0;

            PlayerPrefs.SetInt("PrimeiraVez", primeiraVez);

            podeTrocarInimigo = true;

        }



        if (PlayerPrefs.GetInt("QuantosInimigos") == 1 && PlayerPrefs.GetFloat("PopInimigos") <= 0 && podeTrocarInimigo == true)
        {
           // PlayerPrefs.SetInt("BolsoInimigoScene", 0);
            PlayerPrefs.SetInt("DodorioInimigoScene", 1);

            PlayerPrefs.SetInt("BolsoInimigoScene", 0);
            BolsoPartidoOff();

            StartCoroutine(TiraScene(BolsoInimigo));
            StartCoroutine(ColocaScene(DodorioInimigo,3f));

            PlayerPrefs.SetFloat("PopInimigos", popInimigoDodorio);
            podeTrocarInimigo = false;
            GetComponent<SistemaBatalhas>().apoioMidiaInimigo = PlayerPrefs.GetFloat("ApoioMidiaDodorioInimigo");
            GetComponent<SistemaBatalhas>().autoridadeInimigo = PlayerPrefs.GetFloat("AutoridadeDodorioInimigo");
            GetComponent<SistemaBatalhas>().retoricaInimigo = PlayerPrefs.GetFloat("RetoricaDodorioInimigo");
            GetComponent<SistemaBatalhas>().confiancaInimigo = PlayerPrefs.GetInt("ConfiancaDodorioInimigo");
            GetComponent<SistemaBatalhas>().levelInimigo = PlayerPrefs.GetInt("LevelDodorioInimigo");



        }




        if (PlayerPrefs.GetInt("QuantosInimigos") == 0)
        {
            PlayerPrefs.SetInt("BolsoInimigoScene", 0);
            PlayerPrefs.SetInt("DodorioInimigoScene", 0);
            StartCoroutine(TiraScene(DodorioInimigo));
            NaSceneOff(BolsoInimigo);
            DodorioPartidoOff();
            PlayerPrefs.SetFloat("PopInimigos", 0);
        }





    } // FIM PARTIDO DEPUTADO

    public void PartidoEleicaoPrefeito()
    {
        // ----------- //

        NaSceneOff(CiroInimigo);
        NaSceneOff(LulaInimigo);
        NaSceneOff(SuplicyInimigo);
        NaSceneOff(EneasInimigo);
        NaSceneOff(DilmaInimigo);
        NaSceneOff(BolsoInimigo);
        NaSceneOff(CunhaInimigo);

        // ----------- //


        popInimigoDodorio = 100;
        popInimigoHaddard = 100;

        PlayerPrefs.SetFloat("AutoridadeHaddardInimigo", 230); // 20 + lvl 4
        PlayerPrefs.SetFloat("ApoioMidiaHaddardInimigo", 36); // 10 + 4
        PlayerPrefs.SetFloat("RetoricaHaddardInimigo", 36);
        PlayerPrefs.SetInt("ConfiancaHaddardInimigo", 31);
        PlayerPrefs.SetInt("LevelHaddardInimigo", 8);



        PlayerPrefs.SetFloat("AutoridadeDodorioInimigo", 250);
        PlayerPrefs.SetFloat("ApoioMidiaDodorioInimigo", 40);
        PlayerPrefs.SetFloat("RetoricaDodorioInimigo", 30);
        PlayerPrefs.SetInt("ConfiancaDodorioInimigo", 35);
        PlayerPrefs.SetInt("LevelDodorioInimigo", 10);


        if (primeiraVez == 1)
        {
            //DENTRO
            HaddardPartidoOn();
            DodorioPartidoOn();


            //FORA
            CiroPartidoOff();
            EneasPartidoOff();
            SuplicyPartidoOff();
            LulaPartidoOff();
            DilmaPartidoOff();
            BolsoPartidoOff();
            CunhaPartidoOff();


            // -------- //


            PlayerPrefs.SetFloat("PopInimigos", 0);

            PlayerPrefs.SetInt("QuantosInimigos", 2);

            if (PlayerPrefs.GetInt("QuantosInimigos") == 2 && PlayerPrefs.GetFloat("PopInimigos") <= 0)
            {
                PlayerPrefs.SetInt("HaddardInimigoScene", 1);
                PlayerPrefs.SetInt("DodorioInimigoScene", 0);
                StartCoroutine(ColocaScene(HaddardInimigo, 1f));

                PlayerPrefs.SetFloat("PopInimigos", popInimigoHaddard);

                print(PlayerPrefs.GetFloat("PopInimigos"));
            }


            primeiraVez = 0;

            PlayerPrefs.SetInt("PrimeiraVez", primeiraVez);

            podeTrocarInimigo = true;

        }



        if (PlayerPrefs.GetInt("QuantosInimigos") == 1 && PlayerPrefs.GetFloat("PopInimigos") <= 0 && podeTrocarInimigo == true)
        {
            PlayerPrefs.SetInt("HaddardInimigoScene", 0);
            PlayerPrefs.SetInt("DodorioInimigoScene", 1);
            HaddardPartidoOff();
            StartCoroutine(TiraScene(HaddardInimigo));
            StartCoroutine(ColocaScene(DodorioInimigo, 3f));
            PlayerPrefs.SetFloat("PopInimigos", popInimigoDodorio);
            podeTrocarInimigo = false;
            GetComponent<SistemaBatalhas>().apoioMidiaInimigo = PlayerPrefs.GetFloat("ApoioMidiaDodorioInimigo");
            GetComponent<SistemaBatalhas>().autoridadeInimigo = PlayerPrefs.GetFloat("AutoridadeDodorioInimigo");
            GetComponent<SistemaBatalhas>().retoricaInimigo = PlayerPrefs.GetFloat("RetoricaDodorioInimigo");
            GetComponent<SistemaBatalhas>().confiancaInimigo = PlayerPrefs.GetInt("ConfiancaDodorioInimigo");
            GetComponent<SistemaBatalhas>().levelInimigo = PlayerPrefs.GetInt("LevelDodorioInimigo");



        }




        if (PlayerPrefs.GetInt("QuantosInimigos") == 0)
        {
            PlayerPrefs.SetInt("HaddardInimigoScene", 0);
            PlayerPrefs.SetInt("DodorioInimigoScene", 0);
            StartCoroutine(TiraScene(DodorioInimigo));
            NaSceneOff(HaddardInimigo);
            DodorioPartidoOff();
            PlayerPrefs.SetFloat("PopInimigos", 0);
        }





    } // FIM PARTIDO PREFEITO

    public void PartidoEleicaoGovernador()
    {
        // ----------- //

        NaSceneOff(CiroInimigo);
        NaSceneOff(LulaInimigo);
        NaSceneOff(DodorioInimigo);
        NaSceneOff(EneasInimigo);
        NaSceneOff(BolsoInimigo);
        NaSceneOff(HaddardInimigo);
        NaSceneOff(CunhaInimigo);


        // ----------- //

        popInimigoDilma = 100;
        popInimigoSuplicy = 100;

        PlayerPrefs.SetFloat("AutoridadeDilmaInimigo", 350); // 20 + lvl 4
        PlayerPrefs.SetFloat("ApoioMidiaDilmaInimigo", 40); // 10 + 4
        PlayerPrefs.SetFloat("RetoricaDilmaInimigo", 40);
        PlayerPrefs.SetInt("ConfiancaDilmaInimigo", 50);
        PlayerPrefs.SetInt("LevelDilmaInimigo", 15);


        PlayerPrefs.SetFloat("AutoridadeSuplicyInimigo", 350);
        PlayerPrefs.SetFloat("ApoioMidiaSuplicyInimigo", 50);
        PlayerPrefs.SetFloat("RetoricaSuplicyInimigo", 60);
        PlayerPrefs.SetInt("ConfiancaSuplicyInimigo", 55);
        PlayerPrefs.SetInt("LevelSuplicyInimigo", 20);

        if (primeiraVez == 1)
        {
            //DENTRO
            DilmaPartidoOn();
            SuplicyPartidoOn();


            //FORA
            CiroPartidoOff();
            EneasPartidoOff();
            BolsoPartidoOff();
            LulaPartidoOff();
            DodorioPartidoOff();
            HaddardPartidoOff();
            CunhaPartidoOff();
            // -------- //


            PlayerPrefs.SetFloat("PopInimigos", 0);

            PlayerPrefs.SetInt("QuantosInimigos", 2);

            if (PlayerPrefs.GetInt("QuantosInimigos") == 2 && PlayerPrefs.GetFloat("PopInimigos") <= 0)
            {
                PlayerPrefs.SetInt("DilmaInimigoScene", 1);
                PlayerPrefs.SetInt("SuplicyInimigoScene", 0);

                StartCoroutine(ColocaScene(DilmaInimigo, 1f));

                PlayerPrefs.SetFloat("PopInimigos", popInimigoDilma);

                print(PlayerPrefs.GetFloat("PopInimigos"));
            }


            primeiraVez = 0;

            PlayerPrefs.SetInt("PrimeiraVez", primeiraVez);

            podeTrocarInimigo = true;

        }



        if (PlayerPrefs.GetInt("QuantosInimigos") == 1 && PlayerPrefs.GetFloat("PopInimigos") <= 0 && podeTrocarInimigo == true)
        {
            PlayerPrefs.SetInt("DilmaInimigoScene", 0);
            PlayerPrefs.SetInt("SuplicyInimigoScene", 1);

            DilmaPartidoOff();
            StartCoroutine(TiraScene(DilmaInimigo));
            StartCoroutine(ColocaScene(SuplicyInimigo, 3f));

            PlayerPrefs.SetFloat("PopInimigos", popInimigoSuplicy);
            podeTrocarInimigo = false;
            GetComponent<SistemaBatalhas>().apoioMidiaInimigo = PlayerPrefs.GetFloat("ApoioMidiaSuplicyInimigo");
            GetComponent<SistemaBatalhas>().autoridadeInimigo = PlayerPrefs.GetFloat("AutoridadeSuplicyInimigo");
            GetComponent<SistemaBatalhas>().retoricaInimigo = PlayerPrefs.GetFloat("RetoricaSuplicyInimigo");
            GetComponent<SistemaBatalhas>().confiancaInimigo = PlayerPrefs.GetInt("ConfiancaSuplicyInimigo");
            GetComponent<SistemaBatalhas>().levelInimigo = PlayerPrefs.GetInt("LevelSuplicyInimigo");



        }




        if (PlayerPrefs.GetInt("QuantosInimigos") == 0)
        {
            PlayerPrefs.SetInt("DilmaInimigoScene", 0);
            PlayerPrefs.SetInt("SuplicyInimigoScene", 0);
            NaSceneOff(SuplicyInimigo);
            NaSceneOff(DilmaInimigo);
            SuplicyPartidoOff();
            PlayerPrefs.SetFloat("PopInimigos", 0);
        }





    } // FIM PARTIDO GOVERNADOR

    public void PartidoEleicaoPresidente()
    {
        // ----------- //

        NaSceneOff(CiroInimigo);
        NaSceneOff(SuplicyInimigo);
        NaSceneOff(HaddardInimigo);
        NaSceneOff(CunhaInimigo);
        NaSceneOff(EneasInimigo);
        NaSceneOff(DodorioInimigo);


        // ----------- //

        popInimigoBolso = 100;
        popInimigoDilma = 100;
        popInimigoLula = 100;


        PlayerPrefs.SetFloat("AutoridadeBolsoInimigo", 400); // 20 + lvl 4
        PlayerPrefs.SetFloat("ApoioMidiaBolsoInimigo", 50); // 10 + 4
        PlayerPrefs.SetFloat("RetoricaBolsoInimigo", 50);
        PlayerPrefs.SetInt("ConfiancaBolsoInimigo", 60);
        PlayerPrefs.SetInt("LevelBolsoInimigo", 20);


        PlayerPrefs.SetFloat("AutoridadeDilmaInimigo", 450);
        PlayerPrefs.SetFloat("ApoioMidiaDilmaInimigo", 60);
        PlayerPrefs.SetFloat("RetoricaDilmaInimigo", 65);
        PlayerPrefs.SetInt("ConfiancaDilmaInimigo", 65);
        PlayerPrefs.SetInt("LevelDilmaInimigo", 25);

        PlayerPrefs.SetFloat("AutoridadeLulaInimigo", 500);
        PlayerPrefs.SetFloat("ApoioMidiaLulaInimigo", 70);
        PlayerPrefs.SetFloat("RetoricaLulaInimigo", 85);
        PlayerPrefs.SetInt("ConfiancaLulaInimigo", 85);
        PlayerPrefs.SetInt("LevelLulaInimigo", 30);

       


        if (primeiraVez == 1)
        {
            //DENTRO
            BolsoPartidoOn();
            DilmaPartidoOn();
            LulaPartidoOn();


            //FORA
            CiroPartidoOff();
            EneasPartidoOff();
            SuplicyPartidoOff();
            HaddardPartidoOff();
            CunhaPartidoOff();
            DodorioPartidoOff();


            // -------- //


            PlayerPrefs.SetFloat("PopInimigos", 0);

            PlayerPrefs.SetInt("QuantosInimigos", 3);

            if (PlayerPrefs.GetInt("QuantosInimigos") == 3 && PlayerPrefs.GetFloat("PopInimigos") <= 0)
            {
                PlayerPrefs.SetInt("BolsoInimigoScene", 1);
                PlayerPrefs.SetInt("DilmaInimigoScene", 0);
                PlayerPrefs.SetInt("LulaInimigoScene", 0);

                StartCoroutine(ColocaScene(BolsoInimigo, 1f));

                PlayerPrefs.SetFloat("PopInimigos", popInimigoBolso);

            }


            primeiraVez = 0;

            PlayerPrefs.SetInt("PrimeiraVez", primeiraVez);

            podeTrocarInimigo = true;

        }



        if (PlayerPrefs.GetInt("QuantosInimigos") == 2 && PlayerPrefs.GetFloat("PopInimigos") <= 0 && podeTrocarInimigo == true)
        {
            PlayerPrefs.SetInt("BolsoInimigoScene", 0);
            PlayerPrefs.SetInt("LulaInimigoScene", 0);
            PlayerPrefs.SetInt("DilmaInimigoScene", 1);

            BolsoPartidoOff();

            StartCoroutine(TiraScene(BolsoInimigo));
            NaSceneOff(LulaInimigo);
            StartCoroutine(ColocaScene(DilmaInimigo, 3f));

            PlayerPrefs.SetFloat("PopInimigos", popInimigoDilma);

            podeTrocarInimigo = true;

            GetComponent<SistemaBatalhas>().apoioMidiaInimigo = PlayerPrefs.GetFloat("ApoioMidiaDilmaInimigo");
            GetComponent<SistemaBatalhas>().autoridadeInimigo = PlayerPrefs.GetFloat("AutoridadeDilmaInimigo");
            GetComponent<SistemaBatalhas>().retoricaInimigo = PlayerPrefs.GetFloat("RetoricaDilmaInimigo");
            GetComponent<SistemaBatalhas>().confiancaInimigo = PlayerPrefs.GetInt("ConfiancaDilmaInimigo");
            GetComponent<SistemaBatalhas>().levelInimigo = PlayerPrefs.GetInt("LevelDilmaInimigo");



        }


        if (PlayerPrefs.GetInt("QuantosInimigos") == 1 && PlayerPrefs.GetFloat("PopInimigos") <= 0 && podeTrocarInimigo == true)
        {
            PlayerPrefs.SetInt("BolsoInimigoScene", 0);
            PlayerPrefs.SetInt("LulaInimigoScene", 1);
            PlayerPrefs.SetInt("DilmaInimigoScene", 0);

            BolsoPartidoOff();
            DilmaPartidoOff();

            NaSceneOff(BolsoInimigo);
            StartCoroutine(TiraScene(DilmaInimigo));
            StartCoroutine(ColocaScene(LulaInimigo, 3f));

            PlayerPrefs.SetFloat("PopInimigos", popInimigoLula);

            podeTrocarInimigo = false;

            GetComponent<SistemaBatalhas>().apoioMidiaInimigo = PlayerPrefs.GetFloat("ApoioMidiaLulaInimigo");
            GetComponent<SistemaBatalhas>().autoridadeInimigo = PlayerPrefs.GetFloat("AutoridadeLulaInimigo");
            GetComponent<SistemaBatalhas>().retoricaInimigo = PlayerPrefs.GetFloat("RetoricaLulaInimigo");
            GetComponent<SistemaBatalhas>().confiancaInimigo = PlayerPrefs.GetInt("ConfiancaLulaInimigo");
            GetComponent<SistemaBatalhas>().levelInimigo = PlayerPrefs.GetInt("LevelLulaInimigo");



        }

        if (PlayerPrefs.GetInt("QuantosInimigos") == 0)
        {
            PlayerPrefs.SetInt("BolsoInimigoScene", 0);
            PlayerPrefs.SetInt("LulaInimigoScene", 0);
            PlayerPrefs.SetInt("DilmaInimigoScene", 0);

            NaSceneOff(DilmaInimigo);
            StartCoroutine(TiraScene(LulaInimigo));
            NaSceneOff(BolsoInimigo);
            LulaPartidoOff();

            PlayerPrefs.SetFloat("PopInimigos", 0);
        }





    } // FIM PARTIDO PRESIDENTE

    // -------         ---------


    // ------- DESBLOQUEIO DE PERSONAGENS -------

    public void PartidoDilma()
    {

        popInimigoDilma = 100;
        //primeiraVez = 1;
        PlayerPrefs.SetInt("DilmaInimigoScene", 1);

        PlayerPrefs.SetFloat("AutoridadeDilmaInimigo", 23);
        PlayerPrefs.SetFloat("ApoioMidiaDilmaInimigo", 13);
        PlayerPrefs.SetFloat("RetoricaDilmaInimigo", 18);
        PlayerPrefs.SetInt("LevelDilmaInimigo", 3);
        PlayerPrefs.SetInt("ConfiancaDilmaInimigo", 18);

        if (primeiraVez == 1)
        {
            //DENTRO
            DilmaPartidoOn();


            //FORA

            LulaPartidoOff();
            CiroPartidoOff();
            BolsoPartidoOff();
            EneasPartidoOff();
            SuplicyPartidoOff();
            DodorioPartidoOff();
            HaddardPartidoOff();
            CunhaPartidoOff();


            NaSceneOff(LulaInimigo);
            NaSceneOff(CiroInimigo);
            NaSceneOff(BolsoInimigo);
            NaSceneOff(EneasInimigo);
            NaSceneOff(SuplicyInimigo);
            NaSceneOff(DodorioInimigo);
            NaSceneOff(HaddardInimigo);
            NaSceneOff(CunhaInimigo);


            // -------- //

            primeiraVez = 0;

            PlayerPrefs.SetInt("PrimeiraVez", primeiraVez);

            podeTrocarInimigo = true;

            PlayerPrefs.SetFloat("PopInimigos", 0);

            PlayerPrefs.SetInt("QuantosInimigos", 1);

            if (PlayerPrefs.GetInt("QuantosInimigos") == 1 && PlayerPrefs.GetFloat("PopInimigos") <= 0)
            {


                PlayerPrefs.SetInt("DilmaInimigoScene", 1);

                StartCoroutine(ColocaScene(DilmaInimigo, 1f));
                PlayerPrefs.SetFloat("PopInimigos", popInimigoDilma);

                print("essa é a primeira vez. PopInimigos = ");
                print(PlayerPrefs.GetFloat("PopInimigos"));
            }




        }

        if (PlayerPrefs.GetInt("QuantosInimigos") == 0)
        {
            PlayerPrefs.SetInt("DilmaInimigoScene", 0);
            StartCoroutine(TiraScene(DilmaInimigo));
            DilmaPartidoOff();
            PlayerPrefs.SetFloat("PopInimigos", 0);
           // primeiraVez = 1;
        }











    }

    public void PartidoCirao()
    {

        popInimigoCiro = 100;

        // primeiraVez = 1;

        PlayerPrefs.SetFloat("AutoridadeCiroInimigo", 23);
        PlayerPrefs.SetInt("LevelCiroInimigo", 6);
        PlayerPrefs.SetFloat("ApoioMidiaCiroInimigo", 13);
        PlayerPrefs.SetFloat("RetoricaCiroInimigo", 18);
        PlayerPrefs.SetInt("ConfiancaCiroInimigo", 18);

        if (primeiraVez == 1)
        {
            //DENTRO

            CiroPartidoOn();


            //FORA
            LulaPartidoOff();
            BolsoPartidoOff();
            EneasPartidoOff();
            SuplicyPartidoOff();
            DodorioPartidoOff();
            HaddardPartidoOff();
            DilmaPartidoOff();
            CunhaPartidoOff();


            NaSceneOff(LulaInimigo);
            NaSceneOff(BolsoInimigo);
            NaSceneOff(EneasInimigo);
            NaSceneOff(SuplicyInimigo);
            NaSceneOff(DodorioInimigo);
            NaSceneOff(DilmaInimigo);
            NaSceneOff(HaddardInimigo);
            NaSceneOff(CunhaInimigo);





            // -------- //
            primeiraVez = 0;

            PlayerPrefs.SetInt("PrimeiraVez", primeiraVez);

            podeTrocarInimigo = true;


            PlayerPrefs.SetFloat("PopInimigos", 0);

            PlayerPrefs.SetInt("QuantosInimigos", 1);

            if (PlayerPrefs.GetInt("QuantosInimigos") == 1 && PlayerPrefs.GetFloat("PopInimigos") <= 0)
            {


                PlayerPrefs.SetInt("CiroInimigoScene", 1);

                StartCoroutine(ColocaScene(CiroInimigo, 1f));
                PlayerPrefs.SetFloat("PopInimigos", popInimigoCiro);


            }

        }


        if (PlayerPrefs.GetInt("QuantosInimigos") == 0)
        {
            PlayerPrefs.SetInt("CiroInimigoScene", 0);
            StartCoroutine(TiraScene(CiroInimigo));
            CiroPartidoOff();
            PlayerPrefs.SetFloat("PopInimigos", 0);
            //primeiraVez = 1;

        }





    } // FIM PARTIDO CIRO

    public void PartidoSuplicy()
    {

        popInimigoSuplicy = 100;


        PlayerPrefs.SetFloat("AutoridadeSuplicyInimigo", 23);
        PlayerPrefs.SetInt("LevelSuplicyInimigo", 8);
        PlayerPrefs.SetFloat("ApoioMidiaSuplicyInimigo", 13);
        PlayerPrefs.SetFloat("RetoricaSuplicyInimigo", 18);
        PlayerPrefs.SetInt("ConfiancaSuplicyInimigo", 18);

        if (primeiraVez == 1)
        {
            //DENTRO

            SuplicyPartidoOn();


            //FORA
            LulaPartidoOff();
            CiroPartidoOff();
            BolsoPartidoOff();
            EneasPartidoOff();
            DodorioPartidoOff();
            HaddardPartidoOff();
            DilmaPartidoOff();
            CunhaPartidoOff();



            NaSceneOff(LulaInimigo);
            NaSceneOff(CiroInimigo);
            NaSceneOff(BolsoInimigo);
            NaSceneOff(EneasInimigo);
            NaSceneOff(DodorioInimigo);
            NaSceneOff(DilmaInimigo);
            NaSceneOff(HaddardInimigo);
            NaSceneOff(CunhaInimigo);





            // -------- //


            PlayerPrefs.SetFloat("PopInimigos", 0);

            PlayerPrefs.SetInt("QuantosInimigos", 1);

            if (PlayerPrefs.GetInt("QuantosInimigos") == 1 && PlayerPrefs.GetFloat("PopInimigos") <= 0)
            {


                PlayerPrefs.SetInt("SuplicyInimigoScene", 1);

                StartCoroutine(ColocaScene(SuplicyInimigo, 1f));
                PlayerPrefs.SetFloat("PopInimigos", popInimigoSuplicy);


            }


            primeiraVez = 0;

            PlayerPrefs.SetInt("PrimeiraVez", primeiraVez);

            podeTrocarInimigo = true;

        }






        if (PlayerPrefs.GetInt("QuantosInimigos") == 0)
        {
            PlayerPrefs.SetInt("SuplicyInimigoScene", 0);
            StartCoroutine(TiraScene(SuplicyInimigo));
            SuplicyPartidoOff();
            PlayerPrefs.SetFloat("PopInimigos", 0);
        }





    }

    public void PartidoEneas()
    {

        popInimigoEneas = 100;


        PlayerPrefs.SetFloat("AutoridadeEneasInimigo", 23);
        PlayerPrefs.SetInt("LevelEneasInimigo", 15);
        PlayerPrefs.SetFloat("ApoioMidiaEneasInimigo", 13);
        PlayerPrefs.SetFloat("RetoricaEneasInimigo", 18);
        PlayerPrefs.SetInt("ConfiancaEneasInimigo", 18);

        if (primeiraVez == 1)
        {
            //DENTRO

            EneasPartidoOn();


            //FORA
            LulaPartidoOff();
            CiroPartidoOff();
            BolsoPartidoOff();
            SuplicyPartidoOff();
            DodorioPartidoOff();
            HaddardPartidoOff();
            DilmaPartidoOff();
            CunhaPartidoOff();


            NaSceneOff(LulaInimigo);
            NaSceneOff(CiroInimigo);
            NaSceneOff(BolsoInimigo);
            NaSceneOff(SuplicyInimigo);
            NaSceneOff(DodorioInimigo);
            NaSceneOff(DilmaInimigo);
            NaSceneOff(HaddardInimigo);
            NaSceneOff(CunhaInimigo);





            // -------- //


            PlayerPrefs.SetFloat("PopInimigos", 0);

            PlayerPrefs.SetInt("QuantosInimigos", 1);

            if (PlayerPrefs.GetInt("QuantosInimigos") == 1 && PlayerPrefs.GetFloat("PopInimigos") <= 0)
            {


                PlayerPrefs.SetInt("EneasInimigoScene", 1);

                StartCoroutine(ColocaScene(EneasInimigo, 1f));
                PlayerPrefs.SetFloat("PopInimigos", popInimigoEneas);


            }


            primeiraVez = 0;

            PlayerPrefs.SetInt("PrimeiraVez", primeiraVez);

            podeTrocarInimigo = true;

        }






        if (PlayerPrefs.GetInt("QuantosInimigos") == 0)
        {
            PlayerPrefs.SetInt("EneasInimigoScene", 0);
            StartCoroutine(TiraScene(EneasInimigo));
            EneasPartidoOff();
            PlayerPrefs.SetFloat("PopInimigos", 0);
        }





    }

    public void PartidoCunha()
    {

        popInimigoCunha = 100;


        PlayerPrefs.SetFloat("AutoridadeCunhaInimigo", 23);
        PlayerPrefs.SetInt("LevelCunhaInimigo", 15);
        PlayerPrefs.SetFloat("ApoioMidiaCunhaInimigo", 13);
        PlayerPrefs.SetFloat("RetoricaCunhaInimigo", 18);
        PlayerPrefs.SetInt("ConfiancaCunhaInimigo", 18);

        if (primeiraVez == 1)
        {
            //DENTRO

            CunhaPartidoOn();


            //FORA
            LulaPartidoOff();
            CiroPartidoOff();
            BolsoPartidoOff();
            SuplicyPartidoOff();
            DodorioPartidoOff();
            HaddardPartidoOff();
            DilmaPartidoOff();
            EneasPartidoOff();


            NaSceneOff(LulaInimigo);
            NaSceneOff(CiroInimigo);
            NaSceneOff(BolsoInimigo);
            NaSceneOff(SuplicyInimigo);
            NaSceneOff(DodorioInimigo);
            NaSceneOff(DilmaInimigo);
            NaSceneOff(HaddardInimigo);
            NaSceneOff(EneasInimigo);





            // -------- //


            PlayerPrefs.SetFloat("PopInimigos", 0);

            PlayerPrefs.SetInt("QuantosInimigos", 1);

            if (PlayerPrefs.GetInt("QuantosInimigos") == 1 && PlayerPrefs.GetFloat("PopInimigos") <= 0)
            {


                PlayerPrefs.SetInt("CunhaInimigoScene", 1);

                StartCoroutine(ColocaScene(CunhaInimigo, 1f));
                PlayerPrefs.SetFloat("PopInimigos", popInimigoCunha);


            }


            primeiraVez = 0;

            PlayerPrefs.SetInt("PrimeiraVez", primeiraVez);

            podeTrocarInimigo = true;

        }






        if (PlayerPrefs.GetInt("QuantosInimigos") == 0)
        {
            PlayerPrefs.SetInt("CunhaInimigoScene", 0);
            NaSceneOff(CunhaInimigo);
            StartCoroutine(TiraScene(CunhaInimigo));
            PlayerPrefs.SetFloat("PopInimigos", 0);
        }





    }
    // -------  VARIADOS       ---------

    public void PartidoImpeachment()
    {
        NaSceneOff(DodorioInimigo);
        NaSceneOff(LulaInimigo);
        NaSceneOff(SuplicyInimigo);
        NaSceneOff(HaddardInimigo);
        NaSceneOff(DilmaInimigo);
        NaSceneOff(BolsoInimigo);
        NaSceneOff(CunhaInimigo);

        // ----------- //


        popInimigoCiro = 100;
        popInimigoEneas = 100;

        PlayerPrefs.SetFloat("AutoridadeCiroInimigo", 200 * ((10 * PlayerPrefs.GetInt("LevelIndice") - 2))); 
        PlayerPrefs.SetFloat("ApoioMidiaCiroInimigo", 10 * ( ( 2 * PlayerPrefs.GetInt("LevelIndice") - 2 ))); 
        PlayerPrefs.SetFloat("RetoricaCiroInimigo", 15 * ((2 * PlayerPrefs.GetInt("LevelIndice") - 2)));
        PlayerPrefs.SetInt("ConfiancaCiroInimigo", 15 * ((2 * PlayerPrefs.GetInt("LevelIndice") - 2)));
        PlayerPrefs.SetInt("LevelCiroInimigo", (PlayerPrefs.GetInt("LevelIndice") - 2));



        PlayerPrefs.SetFloat("AutoridadeEneasInimigo", 200 * ((10 * PlayerPrefs.GetInt("LevelIndice"))));
        PlayerPrefs.SetFloat("ApoioMidiaEneasInimigo", 10 * ((2 * PlayerPrefs.GetInt("LevelIndice"))));
        PlayerPrefs.SetFloat("RetoricaEneasInimigo", 10 * ((2 * PlayerPrefs.GetInt("LevelIndice"))));
        PlayerPrefs.SetInt("ConfiancaEneasInimigo", 20 * ((2 * PlayerPrefs.GetInt("LevelIndice"))));
        PlayerPrefs.SetInt("LevelEneasInimigo", 10 * ((2 * PlayerPrefs.GetInt("LevelIndice"))));


        if (primeiraVez == 1)
        {
            //DENTRO
            CiroPartidoOn();
            EneasPartidoOn();


            //FORA
            BolsoPartidoOff();
            DodorioPartidoOff();
            SuplicyPartidoOff();
            LulaPartidoOff();
            DilmaPartidoOff();
            HaddardPartidoOff();
            CunhaPartidoOff();


            // -------- //


            PlayerPrefs.SetFloat("PopInimigos", 0);

            PlayerPrefs.SetInt("QuantosInimigos", 2);

            if (PlayerPrefs.GetInt("QuantosInimigos") == 2 && PlayerPrefs.GetFloat("PopInimigos") <= 0)
            {
                PlayerPrefs.SetInt("CiroInimigoScene", 1);
                PlayerPrefs.SetInt("EneasInimigoScene", 0);
                StartCoroutine(ColocaScene(CiroInimigo, 1f));
                PlayerPrefs.SetFloat("PopInimigos", popInimigoCiro);

                print(PlayerPrefs.GetFloat("PopInimigos"));
            }


            primeiraVez = 0;

            PlayerPrefs.SetInt("PrimeiraVez", primeiraVez);

            podeTrocarInimigo = true;

        }



        if (PlayerPrefs.GetInt("QuantosInimigos") == 1 && PlayerPrefs.GetFloat("PopInimigos") <= 0 && podeTrocarInimigo == true)
        {
            PlayerPrefs.SetInt("CiroInimigoScene", 0);
            PlayerPrefs.SetInt("EneasInimigoScene", 1);
            CiroPartidoOff();
            StartCoroutine(TiraScene(CiroInimigo));
            StartCoroutine(ColocaScene(EneasInimigo, 3f));
            PlayerPrefs.SetFloat("PopInimigos", popInimigoEneas);
            podeTrocarInimigo = false;

            GetComponent<SistemaBatalhas>().apoioMidiaInimigo = PlayerPrefs.GetFloat("ApoioMidiaEneasInimigo");
            GetComponent<SistemaBatalhas>().autoridadeInimigo = PlayerPrefs.GetFloat("AutoridadeEneasInimigo");
            GetComponent<SistemaBatalhas>().retoricaInimigo = PlayerPrefs.GetFloat("RetoricaEneasInimigo");
            GetComponent<SistemaBatalhas>().confiancaInimigo = PlayerPrefs.GetInt("ConfiancaEneasInimigo");
            GetComponent<SistemaBatalhas>().levelInimigo = PlayerPrefs.GetInt("LevelEneasInimigo");



        }




        if (PlayerPrefs.GetInt("QuantosInimigos") == 0)
        {
            PlayerPrefs.SetInt("CiroInimigoScene", 0);
            PlayerPrefs.SetInt("EneasInimigoScene", 0);
            StartCoroutine(TiraScene(EneasInimigo));
            NaSceneOff(CiroInimigo);
            EneasPartidoOff();
            PlayerPrefs.SetFloat("PopInimigos", 0);
        }




    } // FIM PARTIDO IMPEACHMENT

    public void PartidoMilitantes()
    {
        //DENTRO
        SuplicyPartidoOn();
        LulaPartidoOn();

        //FORA

        CiroPartidoOff();
        BolsoPartidoOff();
        EneasPartidoOff();
        DilmaPartidoOff();
        CunhaPartidoOff();


    }

    public void PartidoLavaJato()
    {
        //DENTRO
        BolsoPartidoOn();

        //FORA
        CiroPartidoOff();
        LulaPartidoOff();
        EneasPartidoOff();
        DilmaPartidoOff();
        SuplicyPartidoOff();
        CunhaPartidoOff();

    }

    public void PartidoSabatina()
    {
        //DENTRO
        BolsoPartidoOn();

        //FORA
        CiroPartidoOff();
        LulaPartidoOff();
        EneasPartidoOff();
        DilmaPartidoOff();
        SuplicyPartidoOff();
        CunhaPartidoOff();

    }


    // LULA DENTRO DO PARTIDO

    public void LulaPartidoOn()
    {
        LulaPartido.SetActive(true);
        LulaDentroPartido = 1;
        NessaScene.Add(LulaInimigo);
    }

    public void LulaPartidoOff()
    {
        LulaPartido.SetActive(false);
        LulaDentroPartido = 0;
        NessaScene.Remove(LulaInimigo);
    }

    // CIRO DENTRO DO PARTIDO

    public void CiroPartidoOn()
    {
        CiroPartido.SetActive(true);
        CiroDentroPartido = 1;
        NessaScene.Add(CiroInimigo);
    }

    public void CiroPartidoOff()
    {
        CiroPartido.SetActive(false);
        CiroDentroPartido = 0;
        NessaScene.Remove(CiroInimigo);
    }

    // BOLSONARO DENTRO DO PARTIDO

    public void BolsoPartidoOn()
    {
        BolsoPartido.SetActive(true);
        BolsoDentroPartido = 1;
        NessaScene.Add(BolsoInimigo);
    }

    public void BolsoPartidoOff()
    {
        BolsoPartido.SetActive(false);
        BolsoDentroPartido = 0;
        NessaScene.Remove(BolsoInimigo);
    }

    // DILMA DENTRO DO PARTIDO

    public void DilmaPartidoOn()
    {
        DilmaPartido.SetActive(true);
        DilmaDentroPartido = 1;
        NessaScene.Add(DilmaInimigo);
    }

    public void DilmaPartidoOff()
    {
        DilmaPartido.SetActive(false);
        DilmaDentroPartido = 0;
        NessaScene.Remove(DilmaInimigo);
    }

    // SUPLICY DENTRO DO PARTIDO

    public void SuplicyPartidoOn()
    {
        SuplicyPartido.SetActive(true);
        SuplicyDentroPartido = 1;
        NessaScene.Add(SuplicyInimigo);
    }

    public void SuplicyPartidoOff()
    {
        SuplicyPartido.SetActive(false);
        SuplicyDentroPartido = 0;
        NessaScene.Remove(SuplicyInimigo);
    }

    // ENEAS DENTRO DO PARTIDO

    public void EneasPartidoOn()
    {
        EneasPartido.SetActive(true);
        EneasDentroPartido = 1;
        NessaScene.Add(EneasInimigo);
    }

    public void EneasPartidoOff()
    {
        EneasPartido.SetActive(false);
        EneasDentroPartido = 0;
        NessaScene.Remove(EneasInimigo);
    }


    // DODORIO DENTRO DO PARTIDO

    public void DodorioPartidoOn()
    {
        DodorioPartido.SetActive(true);
        DodorioDentroPartido = 1;
        NessaScene.Add(DodorioInimigo);
    }

    public void DodorioPartidoOff()
    {
        DodorioPartido.SetActive(false);
        DodorioDentroPartido = 0;
        NessaScene.Remove(DodorioInimigo);
    }

    // HADDARD DENTRO DO PARTIDO

    public void HaddardPartidoOn()
    {
        HaddardPartido.SetActive(true);
        HaddardDentroPartido = 1;
        NessaScene.Add(HaddardInimigo);
    }

    public void HaddardPartidoOff()
    {
        HaddardPartido.SetActive(false);
        HaddardDentroPartido = 0;
        NessaScene.Remove(HaddardInimigo);
    }

    // CUNHA DENTRO DO PARTIDO

    public void CunhaPartidoOn()
    {
        CunhaPartido.SetActive(true);
        CunhaDentroPartido = 1;
        NessaScene.Add(CunhaInimigo);
    }

    public void CunhaPartidoOff()
    {
        CunhaPartido.SetActive(false);
        CunhaDentroPartido = 0;
        NessaScene.Remove(CunhaInimigo);
    }



    public void NaSceneOn(GameObject inimigoScene)
    {
        inimigoScene.SetActive(true);
    }

    public void NaSceneOff(GameObject inimigoScene)
    {
        inimigoScene.SetActive(false);
    }

    IEnumerator TiraScene(GameObject inimigoScene)
    {
        yield return new WaitForSeconds(1f);
        inimigoScene.GetComponent<Animation>().Play("SaiScene" + inimigoScene.GetComponent<Politico>().nomePoli);
        inimigoDerrotado.SetActive(true);
       
        yield return new WaitForSeconds(2f);
        inimigoDerrotado.SetActive(false);

        yield return new WaitForSeconds(4f);
        inimigoDerrotado.SetActive(false);
        inimigoScene.SetActive(false);


    }

    IEnumerator ColocaScene(GameObject inimigoScene, float tempo)
    {
        yield return new WaitForSeconds(tempo);
        inimigoScene.GetComponent<Animation>().Play("EntraScene" + inimigoScene.GetComponent<Politico>().nomePoli);

        inimigoScene.SetActive(true);


    }
   
    public void PrimeiraVez()
    {
        primeiraVez = 1;
    }



} // FIM DA CLASSE
