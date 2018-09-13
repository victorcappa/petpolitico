﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class SistemaBatalhas : MonoBehaviour
{
    public BattleStates currentState;
    public TipoBatalha tipoDessaBatalha;

    //float ataque = 20;

    // STATUS
    // -------------------------------

    public float popularidadePlayer, danoPlayer, autoridadePlayer, apoioMidiaPlayer, retoricaPlayer;
    public int levelPlayer;
    public int confiancaPlayer;
    public int verba;
    public float autoridadeAtaque;

    public int levelInimigo;
    public Text levelInimigo_txt;
    public float popularidadeInimigo, danoInimigo, autoridadeInimigo, apoioMidiaInimigo, retoricaInimigo;
    public int confiancaInimigo;
    // -------------------------------

    bool playerAtacou, inimigoAtacou;
    public Text popInimigo_txtUI, pop_txtUI, verbatxt, levelPlayer_txt;
    public Slider barraPopInimigo, barraPop;
    public bool trocouPersonagem, trocouInimigo;

    public int quantosInimigos;

    public Button botao1, botao2;

    public float somaPopPartido;

    public GameObject painelPartido, fecharPainel, canvasBatalha, canvasGame;

    public GameObject mainLula, mainCiro, mainBolso, mainDilma, mainSuplicy, mainEneas, mainDodorio, mainHaddard, mainCunha;
    public float popLula, popCiro, popBolso, popDilma, popSuplicy, popEneas, popDodorio, popHaddard, popCunha;
    public Button LulaPartido, CiroPartido, BolsoPartido, DilmaPartido, SuplicyPartido, EneasPartido, DodorioPartido, HaddardPartido, CunhaPartido;
    public GameObject LulaScene, CiroScene, BolsoScene, DilmaScene, SuplicyScene, EneasScene, DodorioScene, HaddardScene, CunhaScene;
    public GameObject MovimentosLula, MovimentosCiro, MovimentosBolso, MovimentosDilma, MovimentosSuplicy, MovimentosEneas, MovimentosDodorio, MovimentosHaddard, MovimentosCunha;
    public GameObject MovimentosPlayer;
    public Text dialogo, infoAtaque, qte_Ataque, aut_Ataque;

    public int qteAtaqueInimigoElogio = 1;


    // ------- ALUGUEL DE ATAQUES ------ //



    // --------------- ATAQUES ------------------ //


    // SONS ATAQUES

    public AudioSource SomAtaque1, SomAtaque2, SomAtaque3, SomDefesa, SomAumentaStatus, SomTiraStatus, SomEspecial, SomFalhouAtaque, SomSemPop, SomGanhouDebate, SomPerdeuDebate;
    int tocaSom;
    // ANIMAÇÕES ATAQUE

    public GameObject PersonagensScene, InimigosScene, GanhaMidiaPlayer, PerdeMidiaPlayer, GanhaMidiaInimigo, PerdeMidiaInimigo; // para piscar quando inimigo atacar
    public GameObject PerdePopPlayer, GanhaPopPlayer, PerdePopInimigo, GanhaPopInimigo;
    public Text mitouLacrou_Txt;
    // QUANTIDADES DE CADA ATAQUE (divididos pra linha não ficar grande demais)

    public int qteFraudarUrnas, qteHabeasCorpus, qteMilitancia, qteElogioJornal, qteDenunciaSupremo, qteForoPrivilegiado;
    public int qteVazarLigacoes, qteAdHominem, qteApoioCentrao, qteDelacaoPremiada, qteFakeNews, qtePerguntaPolemica;

    //  PARA CADA PERSONAGEM
    public int qteFraudarUrnasLula, qteFraudarUrnasCiro, qteFraudarUrnasBolso, qteFraudarUrnasDilma, qteFraudarUrnasSuplicy, qteFraudarUrnasEneas, qteFraudarUrnasDodorio, qteFraudarUrnasHaddard, qteFraudarUrnasCunha;
    public int qteHabeasLula, qteHabeasCiro, qteHabeasBolso, qteHabeasDilma, qteHabeasSuplicy, qteHabeasEneas, qteHabeasDodorio, qteHabeasHaddard, qteHabeasCunha;
    public int qteMilitanciaLula, qteMilitanciaCiro, qteMilitanciaBolso, qteMilitanciaDilma, qteMilitanciaSuplicy, qteMilitanciaEneas, qteMilitanciaDodorio, qteMilitanciaHaddard, qteMilitanciaCunha;
    public int qteElogioLula, qteElogioCiro, qteElogioBolso, qteElogioDilma, qteElogioSuplicy, qteElogioEneas, qteElogioDodorio, qteElogioHaddard, qteElogioCunha;
    public int qteDenunciaSupremoLula, qteDenunciaSupremoCiro, qteDenunciaSupremoBolso, qteDenunciaSupremoDilma, qteDenunciaSupremoSuplicy, qteDenunciaSupremoEneas, qteDenunciaSupremoDodorio, qteDenunciaSupremoHaddard, qteDenunciaSupremoCunha;
    public int qteForoLula, qteForoCiro, qteForoBolso, qteForoDilma, qteForoSuplicy, qteForoEneas, qteForoDodorio, qteForoHaddard, qteForoCunha;
    public int qteVazarLula, qteVazarCiro, qteVazarBolso, qteVazarDilma, qteVazarSuplicy, qteVazarEneas, qteVazarDodorio, qteVazarHaddard, qteVazarCunha;
    public int qteAdHominemLula, qteAdHominemCiro, qteAdHominemBolso, qteAdHominemDilma, qteAdHominemSuplicy, qteAdHominemEneas, qteAdHominemDodorio, qteAdHominemHaddard, qteAdHominemCunha;
    public int qteApoioCentraoLula, qteApoioCentraoCiro, qteApoioCentraoBolso, qteApoioCentraoDilma, qteApoioCentraoSuplicy, qteApoioCentraoEneas, qteApoioCentraoDodorio, qteApoioCentraoHaddard, qteApoioCentraoCunha;
    public int qteDelacaoLula, qteDelacaoCiro, qteDelacaoBolso, qteDelacaoDilma, qteDelacaoSuplicy, qteDelacaoEneas, qteDelacaoDodorio, qteDelacaoHaddard, qteDelacaoCunha;
    public int qteFakeNewsLula, qteFakeNewsCiro, qteFakeNewsBolso, qteFakeNewsDilma, qteFakeNewsSuplicy, qteFakeNewsEneas, qteFakeNewsDodorio, qteFakeNewsHaddard, qteFakeNewsCunha;
    public int qtePerguntaPolemicaLula, qtePerguntaPolemicaCiro, qtePerguntaPolemicaBolso, qtePerguntaPolemicaDilma, qtePerguntaPolemicaSuplicy, qtePerguntaPolemicaEneas, qtePerguntaPolemicaDodorio, qtePerguntaPolemicaHaddard, qtePerguntaPolemicaCunha;

    // ATAQUES ESPECIAIS DE CADA PERSONAGEM

    public int qteChamarGilmar, qteMeuPostoIpiranga, qteSemCustoContribuinte, qteCiclovia;
    public Button ataqueChamarGilmar, ataqueMeuPostoIpiranga, ataqueSemCustoContribuinte, ataqueCiclovia;

    public int qteChamarGilmarLula, qteChamarGilmarCiro, qteChamarGilmarBolso, qteChamarGilmarDilma, qteChamarGilmarSuplicy, qteChamarGilmarEneas, qteChamarGilmarDodorio, qteChamarGilmarHaddard, qteChamarGilmarCunha; // aumentar autoridade
    public int qteMeuPostoIpirangaBolso, qteMeuPostoIpirangaLula, qteMeuPostoIpirangaCiro, qteMeuPostoIpirangaDilma, qteMeuPostoIpirangaEneas, qteMeuPostoIpirangaSuplicy, qteMeuPostoIpirangaDodorio, qteMeuPostoIpirangaHaddard, qteMeuPostoIpirangaCunha ; // aumentar autoridade
    public int qteSemCustoContribuinteDodorio, qteSemCustoContribuinteLula, qteSemCustoContribuinteCiro, qteSemCustoContribuinteDilma, qteSemCustoContribuinteBolso, qteSemCustoContribuinteSuplicy, qteSemCustoContribuinteEneas, qteSemCustoContribuinteHaddard, qteSemCustoContribuinteCunha; // aumenta apoio da midia
    public int qteCicloviaHaddard, qteCicloviaLula, qteCicloviaCiro, qteCicloviaBolso, qteCicloviaDilma, qteCicloviaSuplicy, qteCicloviaEneas, qteCicloviaDodorio, qteCicloviaCunha; // aumenta apoio da midia

    // PARA INIMIGOS

    //public int qteFraudarUrnasInimigo, qteHabeasCorpusInimigo; qteMilitanciaInimigo, qteElogioJornalInimigo, qteDenunciaSupremoInimigo, qteFor

    // Bool para verificar se foi dado algum ataque de defesa 100%
    public bool playerProtegido, inimigoProtegido;


    // Botoes de ataque (desabilitam quando não tem mais a quantidade)

    public Button ataqueFraudarUrnas, ataqueHabeasCorpus, ataqueMilitancia, ataqueElogioJornal, ataqueDenunciaSupremo, ataqueFakeNews;
    public Button ataqueForoPrivilegiado, ataqueVazarLigacoes, ataqueAdHominem, ataqueApoioCentrao, ataqueDelacaoPremiada, ataquePerguntaPolemica;


    bool ataquePlayer, defesaPlayer, mudaStatusPlayer;

    int minAut, maxAut;
    // --------------- FIM ATAQUES ------------------ //

    public int chanceMitarLacrar, calculoConfianca, confianca;
    public float mitouLacrou;
    public bool direita, esquerda, direitaInimigo, esquerdaInimigo;

    public GameObject avisaBatalha;
    public Text avisaBatalhaTxt;
    public int avisouBatalha;

    // RESETA O GanhaInflu

    public int ganhouInfluLula, ganhouInfluCiro, ganhouInfluBolso, ganhouInfluDilma, ganhouInfluSuplicy, ganhouInfluEneas, ganhouInfluDodorio, ganhouInfluHaddard, ganhouInfluCunha;
    public int ganhouVerba;
    public GameObject jornalEleicoes;
    public Canvas canvasDentroJogo, canvasDebatesEleicoes;

    // TELA DESBLOQUEOU O PERSONAGEM

    public GameObject Dilma, Suplicy, Eneas, Cunha, Ciro, painelDesbloqueou;
    public Text desbloqueouPolitico, foiEleitoTxt;

    // GANHOU PERDEU

    public GameObject painelGanhouPerdeu;
    public Text ganhouPerdeuTxt, ganhouInfluTxt, ganhouVerbaTxt;

    public bool moveCamera;

    // ---- CANDIDATO ---- //

    string candidatoAtual;

    public enum BattleStates
    {
        START,
        ESCOLHAJOGADOR,
        ESCOLHAINIMIGO,
        PERDEU,
        GANHOU,
        ACABOU
    }

    public enum TipoBatalha
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



    public void Awake()
    {


        tocaSom = 1;

        if (canvasBatalha.GetComponent<Canvas>().enabled == true)
        {
            SomaPartido();
        }

        HabilitaBotoes();
       // PopPersonagens();

        pop_txtUI.text = Mathf.Round(popularidadePlayer).ToString();
        barraPop.value = popularidadePlayer;
        barraPop.maxValue = 100;


        StatusDeBatalha();
        StatusDeBatalhaInimigos();
        QuantidadeAtaques();
        ResetaQuantidadeAtaques();
        DireitaEsquerda();
        ResetaGanhouInflu();
        ResetaGanhaVerba();

        // TELA DE DESBLOQUEOU OFF

        Dilma.gameObject.SetActive(false);
        Suplicy.gameObject.SetActive(false);
        Eneas.gameObject.SetActive(false);
        Ciro.gameObject.SetActive(false);
        Suplicy.gameObject.SetActive(false);
        painelDesbloqueou.gameObject.SetActive(false);


    }



    public void Start()
    {
        CandidatoDessaBatalha();

        PopPersonagensInicial();
        //GetComponent<AlugaAtaque>().alugado = false;
        currentState = BattleStates.START;

        HabilitaBotoes();
        QuantidadeAtaques();
        quantosInimigos = PlayerPrefs.GetInt("QuantosInimigos");
        PlayerPrefs.SetFloat("QuantosInimigos", quantosInimigos);

        popularidadeInimigo = PlayerPrefs.GetFloat("PopInimigos");
        PlayerPrefs.SetFloat("PopInimigos", popularidadeInimigo);
        popInimigo_txtUI.text = popularidadeInimigo.ToString();
        barraPopInimigo.value = popularidadeInimigo;
        barraPopInimigo.maxValue = 100;
        playerAtacou = false;


        //tipoDessaBatalha = TipoBatalha.ELEICAO;
        if (canvasBatalha.GetComponent<Canvas>().enabled == true)
        {
            FluxoBatalha();
        }




       // popularidadePlayer = PlayerPrefs.GetFloat("PopularidadeNaScene");
        pop_txtUI.text = Mathf.Round(popularidadePlayer).ToString();
        barraPop.value = popularidadePlayer;
        barraPop.maxValue = 100;

        ataquePlayer = false;
        defesaPlayer = false;
        mudaStatusPlayer = false;

        // currentState = BattleStates.START;

    } // FIM START

    /* IEnumerator tirapop(float dano)
     {
         for (var i = 0; i < dano; i++)
         {
             popularidadeInimigo = popularidadeInimigo - i;
             print (i);
             popInimigo_txtUI.text = popularidadeInimigo.ToString();
             barraPopInimigo.value = popularidadeInimigo;
             if (i <= dano)
             {
                 playerAtacou = true;

             }

             PlayerPrefs.SetFloat("PopInimigos", popularidadeInimigo);
             popularidadeInimigo = PlayerPrefs.GetFloat("PopInimigos"); //

             popInimigo_txtUI.text = popularidadeInimigo.ToString();
             barraPopInimigo.value = popularidadeInimigo;

             yield return new WaitForSeconds(0.2f);


         }
     }*/

    void Update()
    {

        print("QUEM É CANDIDATO: " + candidatoAtual);
        //PlayerPrefs.DeleteAll();
        DireitaEsquerda();

        print(currentState);

        print("pop inimigos" + popularidadeInimigo);
        //print("soma pop partido" + somaPopPartido);
        pop_txtUI.text = Mathf.Round(popularidadePlayer).ToString();
        barraPop.value = popularidadePlayer;


        VerificaQteAtaques();
        if (canvasBatalha.GetComponent<Canvas>().enabled == true)
        {
            FluxoBatalha();
        }

        verba = PlayerPrefs.GetInt("Verba");
        verbatxt.text = verba.ToString();

        VerificaBatalha();
        AvisaBatalha();

        // mexer a camera

        if (ataquePlayer == true && moveCamera == true)
        {
            StartCoroutine(ShakeCamera());
            StartCoroutine(PiscaInimigo());
            Handheld.Vibrate();
            moveCamera = false;
        }

        if (currentState == BattleStates.ESCOLHAINIMIGO && moveCamera == true)
        {
            StartCoroutine(ShakeCamera());
            Handheld.Vibrate();
            moveCamera = false;
        }


    } // FIM UPDATE



    public void GanhouPerdeu()
    {
        painelGanhouPerdeu.gameObject.SetActive(true);

        if (currentState == BattleStates.GANHOU)
        {
            if (tocaSom == 1)
            {
                SomGanhouDebate.Play();

                tocaSom = 0;
            }
            ganhouPerdeuTxt.text = "Você Ganhou!";
            ganhouInfluTxt.text = "+" + PlayerPrefs.GetFloat("QuantoGanhouInflu").ToString();
            ganhouVerbaTxt.text = "+" + PlayerPrefs.GetInt("QuantoGanhouVerba").ToString();

            PlayerPrefs.SetInt("GanhouDebate", 1);

            if (tipoDessaBatalha == TipoBatalha.DILMA)
            {
                Dilma.gameObject.SetActive(true);
                foiEleitoTxt.text = "";
                desbloqueouPolitico.text = "Você desbloqueou um novo politico!";
                painelDesbloqueou.gameObject.SetActive(true);
            }

            if (tipoDessaBatalha == TipoBatalha.ENEAS)
            {
                Eneas.gameObject.SetActive(true);
                foiEleitoTxt.text = "";
                desbloqueouPolitico.text = "Você desbloqueou um novo politico!";
                painelDesbloqueou.gameObject.SetActive(true);

            }

            if (tipoDessaBatalha == TipoBatalha.SUPLICY)
            {
                Suplicy.gameObject.SetActive(true);
                foiEleitoTxt.text = "";
                desbloqueouPolitico.text = "Você desbloqueou um novo politico!";
                painelDesbloqueou.gameObject.SetActive(true);

            }

            if (tipoDessaBatalha == TipoBatalha.CUNHA)
            {
                Cunha.gameObject.SetActive(true);
                foiEleitoTxt.text = "";
                desbloqueouPolitico.text = "Você desbloqueou um novo politico!";
                painelDesbloqueou.gameObject.SetActive(true);

            }

            if (tipoDessaBatalha == TipoBatalha.CIRAO)
            {
                Ciro.gameObject.SetActive(true);
                foiEleitoTxt.text = "";
                desbloqueouPolitico.text = "Você desbloqueou um novo politico!";
                painelDesbloqueou.gameObject.SetActive(true);

            }

            if (tipoDessaBatalha == TipoBatalha.ELEICAOVEREADOR)
            {
                foiEleitoTxt.text = "Você foi eleito <color=#5AD02CFF>VEREADOR </color>";
                desbloqueouPolitico.text = "";
                painelDesbloqueou.gameObject.SetActive(true);
            }

            if (tipoDessaBatalha == TipoBatalha.ELEICAODEPUTADO)
            {
                foiEleitoTxt.text = "Você foi eleito <color=#5AD02CFF>DEPUTADO </color>";
                desbloqueouPolitico.text = "";
                painelDesbloqueou.gameObject.SetActive(true);
            }

            if (tipoDessaBatalha == TipoBatalha.ELEICAOPREFEITO)
            {
                foiEleitoTxt.text = "Você foi eleito <color=#5AD02CFF>PREFEITO </color>";
                desbloqueouPolitico.text = "";
                painelDesbloqueou.gameObject.SetActive(true);
            }

            if (tipoDessaBatalha == TipoBatalha.ELEICAOGOVERNADOR)
            {
                foiEleitoTxt.text = "Você foi eleito <color=#5AD02CFF>GOVERNADOR </color>";
                desbloqueouPolitico.text = "";
                painelDesbloqueou.gameObject.SetActive(true);
            }

            if (tipoDessaBatalha == TipoBatalha.ELEICAOPRESIDENTE)
            {
                foiEleitoTxt.text = "Você foi eleito <color=#5AD02CFF>PRESIDENTE </color>";
                desbloqueouPolitico.text = "";
                painelDesbloqueou.gameObject.SetActive(true);
            }
        }

        if (currentState == BattleStates.PERDEU)
        {
            if (tocaSom == 1)
            {
                SomPerdeuDebate.Play();

                tocaSom = 0;
            }

            ganhouPerdeuTxt.text = "Você Perdeu!";
            ganhouInfluTxt.text = "0";
            ganhouVerbaTxt.text = "0";

            PlayerPrefs.SetInt("PerdeuDebate", 1);


        }
    }


    public void FluxoBatalha()
    {
        PlayerPrefs.SetInt("NaBatalha", 1);

        popularidadeInimigo = PlayerPrefs.GetFloat("PopInimigos");
        PlayerPrefs.SetFloat("PopInimigos", popularidadeInimigo);
        quantosInimigos = PlayerPrefs.GetInt("QuantosInimigos");

        PlayerPrefs.SetInt("QuantosInimigos", quantosInimigos);


        popInimigo_txtUI.text = popularidadeInimigo.ToString();
        barraPopInimigo.value = popularidadeInimigo;

        pop_txtUI.text = Mathf.Round(popularidadePlayer).ToString();
        barraPop.value = popularidadePlayer;


        Debug.Log(currentState);

        levelPlayer_txt.text = "LVL : " + levelPlayer.ToString();
        levelInimigo_txt.text = "LVL : " + levelInimigo.ToString();


        switch (currentState)
        {

            case BattleStates.START:
                HabilitaBotoes();
                DialogoEscolha();

                popularidadeInimigo = PlayerPrefs.GetFloat("PopInimigos");

                print("Pop Inimigos " + PlayerPrefs.GetFloat("PopInimigos"));
                //print(playerAtacou);
                PopPersonagens();

                CalculoRetorica();

                StatusDeBatalhaInimigos();

                break;

            case BattleStates.ESCOLHAJOGADOR:

                // dialogo.text = "O que você irá fazer?";
                MinMaxAut();
                print("VEZ PLAYER");

                if (popularidadeInimigo <= 0 && quantosInimigos <= 0)
                {
                    currentState = BattleStates.GANHOU;

                }

                if (popularidadePlayer <= 0 && somaPopPartido <= 0)
                {
                    currentState = BattleStates.PERDEU;

                }

                if (playerAtacou == false)
                {
                    HabilitaBotoes();

                }

                if (playerAtacou == true)
                {
                    if (confiancaPlayer != 0)
                    {

                        if (chanceMitarLacrar == 2)
                        {
                            if (esquerda == true)
                            {
                                mitouLacrou_Txt.text = "LACROU!";
                                StartCoroutine(MitouLacrouAviso());
                            }

                            if (direita == true)
                            {
                                mitouLacrou_Txt.text = "MITOU!";
                                StartCoroutine(MitouLacrouAviso());
                            }
                        }
                    }

                    if (confiancaPlayer == 0)
                    {
                        SomFalhouAtaque.Play();
                        mitouLacrou_Txt.text = "ERROU!";
                        StartCoroutine(MitouLacrouAviso());

                        moveCamera = false;


                    }
                   
                    VerificaHpPlayer();
                    DireitaEsquerda();
                    inimigoAtacou = false;
                    MovimentosPlayer.gameObject.SetActive(false);
                    DesabilitaBotoes();

                    if (popularidadePlayer > 0 && popularidadeInimigo > 0)
                    {

                        StartCoroutine(VezInimigo());

                    }


                }

                if (trocouPersonagem == true)
                {

                    VerificaHpPlayer();
                    trocouPersonagem = false;
                    CalculoRetorica();
                    StatusDeBatalha();
                    DesabilitaBotoes();
                }
                break;



            case BattleStates.ESCOLHAINIMIGO:
                if (trocouInimigo == true)
                {
                    VerificaHpInimigo();
                    trocouInimigo = false;
                    StatusDeBatalhaInimigos();
                    CalculoRetorica();

                }

                if (popularidadeInimigo <= 0 && quantosInimigos <= 0)
                {
                    currentState = BattleStates.GANHOU;

                }

                if (popularidadePlayer <= 0 && somaPopPartido <= 0)
                {
                    currentState = BattleStates.PERDEU;

                }

                if (inimigoAtacou == false)
                {
                    AtaquesInimigo();
                    DesabilitaBotoes();
                }

                if (inimigoAtacou == true)
                {
                    if (confiancaInimigo != 0)
                    {
                        if (chanceMitarLacrar == 2)
                        {
                            if (esquerda == true)
                            {
                                mitouLacrou_Txt.text = "LACROU!";
                                StartCoroutine(MitouLacrouAviso());
                            }

                            if (direita == true)
                            {
                                mitouLacrou_Txt.text = "MITOU!";
                                StartCoroutine(MitouLacrouAviso());
                            }
                        }
                    }
                if (confiancaInimigo == 0)
                    {
                        SomFalhouAtaque.Play();
                        mitouLacrou_Txt.text = "ERROU!";
                        StartCoroutine(MitouLacrouAviso());


                    }
                    playerAtacou = false;
                    VerificaHpInimigo();
                    DireitaEsquerda();
                    print("INIMIGO ATACOU");

                    if (popularidadePlayer > 0 && popularidadeInimigo > 0)
                    {
                        StartCoroutine(VezPlayer());

                    }


                }

                break;

            case BattleStates.PERDEU:
                print("você perdeu");
                PlayerPrefs.SetInt("NaBatalha", 0);
                DesabilitaBotoes();
                ResetaSomaPop();
                GanhouPerdeu();

                break;

            case BattleStates.GANHOU:
                print("você ganhou");
                PlayerPrefs.SetInt("NaBatalha", 0);
                Insignias();
                DesabilitaBotoes();
                GanhouPerdeu();


                currentState = BattleStates.ACABOU;

                break;

            case BattleStates.ACABOU:

                ResetaSomaPop();
                HabilitaBotoes();
                //canvasDentroJogo.enabled = true;
                //canvasDebatesEleicoes.enabled = false;
                //currentState = BattleStates.START;

                break;

        }
    }

    public void Inicia()
    {
        currentState = BattleStates.START;
    }




    public void VerificaHpPlayer()
    {


        if (popularidadePlayer < 0)
        {
            popularidadePlayer = 0;
        }

        PlayerPrefs.SetFloat("PopInimigos", popularidadeInimigo);

        levelPlayer_txt.text = "LVL : " + levelPlayer.ToString();



        if (popularidadePlayer <= 0)
        {
            // abre painel para trocar de personagem
            painelPartido.gameObject.SetActive(true);
            fecharPainel.gameObject.SetActive(true);
            SomSemPop.Play();
            if (Mathf.Round(somaPopPartido) <= 0)
            {
                currentState = BattleStates.PERDEU;


                // StartCoroutine(TiraTodosDaScene());

            }



        }


        if (popularidadeInimigo <= 0 && PlayerPrefs.GetInt("PrimeiraVez") == 0)
        {
            quantosInimigos = PlayerPrefs.GetInt("QuantosInimigos") - 1;
            if (quantosInimigos <= 0)
            {
                quantosInimigos = 0;
            }
            PlayerPrefs.SetInt("QuantosInimigos", quantosInimigos);
            print("trocou inimigo");

            trocouInimigo = true;
            print("quanto enemy " + PlayerPrefs.GetInt("QuantosInimigos"));
            HabilitaBotoes();

            if (quantosInimigos == 0)
            {

                currentState = BattleStates.GANHOU;

                //  StartCoroutine(TiraTodosDaScene());

            }

        }
    }

    public void VerificaHpInimigo()
    {


        AtualizaPopPersonagens();


        if (popularidadePlayer > 0 && popularidadeInimigo > 0)
        {

            StartCoroutine(VezPlayer());



        }
        if (popularidadePlayer <= 0)
        {
            // abre painel para trocar de personagem
            currentState = BattleStates.ESCOLHAJOGADOR;

            painelPartido.gameObject.SetActive(true);
            fecharPainel.gameObject.SetActive(true);
            popularidadePlayer = 0;

            if (Mathf.Round(somaPopPartido) <= 0)
            {
                currentState = BattleStates.PERDEU;

                // StartCoroutine(TiraTodosDaScene());



            }

        }

        if (popularidadeInimigo <= 0 && PlayerPrefs.GetInt("PrimeiraVez") == 0)
        {
            SomSemPop.Play();

            quantosInimigos = PlayerPrefs.GetInt("QuantosInimigos") - 1;
            if (quantosInimigos <= 0)
            {
                quantosInimigos = 0;
            }

            PlayerPrefs.SetInt("QuantosInimigos", quantosInimigos);
            print("trocou inimigo");
            barraPopInimigo.value = popularidadeInimigo;
            levelInimigo_txt.text = "LVL : " + levelInimigo.ToString();

            print("quanto enemy " + PlayerPrefs.GetInt("QuantosInimigos"));

            StatusDeBatalhaInimigos();
            trocouInimigo = true;
            HabilitaBotoes();

            if (quantosInimigos == 0)
            {
                currentState = BattleStates.GANHOU;

                // StartCoroutine(TiraTodosDaScene());
            }


        }


    }



    public void TrocouDePersonagem()
    {
        StatusDeBatalha();
        SomaPartido();
        trocouPersonagem = true;
        StatusDeBatalha();
        PopPersonagens();

        pop_txtUI.text = Mathf.Round(popularidadePlayer).ToString();
        barraPop.value = Mathf.Round(popularidadePlayer);
        levelPlayer_txt.text = "LVL : " + levelPlayer.ToString();
        barraPop.maxValue = 100;
        painelPartido.gameObject.SetActive(false);
        fecharPainel.gameObject.SetActive(false);

        QuantidadeAtaques();

        DesabilitaBotoes();


    }

    IEnumerator VezInimigo()
    {

        yield return new WaitForSeconds(5f);

        currentState = BattleStates.ESCOLHAINIMIGO;


    }

    IEnumerator VezPlayer()
    {

        yield return new WaitForSeconds(5f);

        currentState = BattleStates.ESCOLHAJOGADOR;


    }


    public void TiraDaScene()
    {
        if (PlayerPrefs.GetInt("LulaDentroScene") == 1)
        {
        }

        if (PlayerPrefs.GetInt("CiroDentroScene") == 1)
        {
        }
        if (PlayerPrefs.GetInt("BolsoDentroScene") == 1)
        {

        }
        if (PlayerPrefs.GetInt("DilmaDentroScene") == 1)
        {
        }
        if (PlayerPrefs.GetInt("SuplicyDentroScene") == 1)
        {
        }
        if (PlayerPrefs.GetInt("EneasDentroScene") == 1)
        {
        }

        if (PlayerPrefs.GetInt("DodorioDentroScene") == 1)
        {

        }

        if (PlayerPrefs.GetInt("HaddardDentroScene") == 1)
        {
            //  PersonagemScene.gameObject.SetActive(false);

        }
    
        if (PlayerPrefs.GetInt("CunhaDentroScene") == 1)
        {
            //  PersonagemScene.gameObject.SetActive(false);

        }
    
    }
    public void DesabilitaBotoes()
    {
        botao1.interactable = false;
        botao2.interactable = false;
    }
    public void HabilitaBotoes()
    {
        botao1.interactable = true;
        botao2.interactable = true;
    }


    //PARA VERIFICAR SE ACABOU A POPULARIDADE DE TODOS DENTRO DO PARTIDO
    public void SomaPartido()
    {
        // quantosPartido = meuPartido.Count;

        somaPopPartido = 0;

        if (PlayerPrefs.GetInt("LulaDentroPartido") == 1)
        {
            somaPopPartido = Mathf.Round(Mathf.Round(somaPopPartido + Mathf.Round(PlayerPrefs.GetFloat("PopularidadeLula"))));
            print("Lula no partido");
        }

        if (PlayerPrefs.GetInt("CiroDentroPartido") == 1)
        {
            somaPopPartido = Mathf.Round(Mathf.Round(somaPopPartido + Mathf.Round(PlayerPrefs.GetFloat("PopularidadeCiro"))));

        }
        if (PlayerPrefs.GetInt("BolsoDentroPartido") == 1)
        {
            print("Bolso no partido");

            somaPopPartido = Mathf.Round(Mathf.Round(somaPopPartido + Mathf.Round(PlayerPrefs.GetFloat("PopularidadeBolso"))));
        }
        if (PlayerPrefs.GetInt("DilmaDentroPartido") == 1)
        {
            somaPopPartido = Mathf.Round(Mathf.Round(somaPopPartido + Mathf.Round(PlayerPrefs.GetFloat("PopularidadeDilma"))));

        }
        if (PlayerPrefs.GetInt("SuplicyDentroPartido") == 1)
        {
            somaPopPartido = Mathf.Round(Mathf.Round(somaPopPartido + Mathf.Round(PlayerPrefs.GetFloat("PopularidadeSuplicy"))));

        }
        if (PlayerPrefs.GetInt("EneasDentroPartido") == 1)
        {
            somaPopPartido = Mathf.Round(Mathf.Round(somaPopPartido + Mathf.Round(PlayerPrefs.GetFloat("PopularidadeEneas"))));

        }
        if (PlayerPrefs.GetInt("DodorioDentroPartido") == 1)
        {
            somaPopPartido = Mathf.Round(Mathf.Round(somaPopPartido + Mathf.Round(PlayerPrefs.GetFloat("PopularidadeDodorio"))));

        }

        if (PlayerPrefs.GetInt("HaddardDentroPartido") == 1)
        {
            somaPopPartido = Mathf.Round(Mathf.Round(somaPopPartido + Mathf.Round(PlayerPrefs.GetFloat("PopularidadeHaddard"))));

        }

        if (PlayerPrefs.GetInt("CunhaDentroPartido") == 1)
        {
            somaPopPartido = Mathf.Round(Mathf.Round(somaPopPartido + Mathf.Round(PlayerPrefs.GetFloat("PopularidadeCunha"))));

        }

        print("soma pop partido: " + somaPopPartido);
    }

    public void PopPersonagens()
    {
        if (PlayerPrefs.GetInt("LulaDentroScene") == 1)
        {
            popularidadePlayer = Mathf.Round(PlayerPrefs.GetFloat("PopularidadeLula"));

        }

        if (PlayerPrefs.GetInt("CiroDentroScene") == 1)
        {
            popularidadePlayer = Mathf.Round(PlayerPrefs.GetFloat("PopularidadeCiro"));
        }
        if (PlayerPrefs.GetInt("BolsoDentroScene") == 1)
        {
            popularidadePlayer = Mathf.Round(PlayerPrefs.GetFloat("PopularidadeBolso"));

        }
        if (PlayerPrefs.GetInt("DilmaDentroScene") == 1)
        {
            popularidadePlayer = Mathf.Round(PlayerPrefs.GetFloat("PopularidadeDilma"));
        }
        if (PlayerPrefs.GetInt("SuplicyDentroScene") == 1)
        {
            popularidadePlayer = Mathf.Round(PlayerPrefs.GetFloat("PopularidadeSuplicy"));
        }
        if (PlayerPrefs.GetInt("EneasDentroScene") == 1)
        {
            popularidadePlayer = Mathf.Round(PlayerPrefs.GetFloat("PopularidadeEneas"));
        }
        if (PlayerPrefs.GetInt("DodorioDentroScene") == 1)
        {
            popularidadePlayer = Mathf.Round(PlayerPrefs.GetFloat("PopularidadeDodorio"));
        }

        if (PlayerPrefs.GetInt("HaddardDentroScene") == 1)
        {
            popularidadePlayer = Mathf.Round(PlayerPrefs.GetFloat("PopularidadeHaddard"));
        }
    
        if (PlayerPrefs.GetInt("CunhaDentroScene") == 1)
        {
            popularidadePlayer = Mathf.Round(PlayerPrefs.GetFloat("PopularidadeCunha"));
        }

    }

    public void PopPersonagensInicial()
    {
        if (PlayerPrefs.GetInt("LulaDentroPartido") == 1)
        {
            PlayerPrefs.SetFloat("PopularidadeLula", 100);
            popularidadePlayer = 100;
        }

        if (PlayerPrefs.GetInt("CiroDentroPartido") == 1)
        {
            PlayerPrefs.SetFloat("PopularidadeCiro", 100);
            popularidadePlayer = 100;

        }
        if (PlayerPrefs.GetInt("BolsoDentroPartido") == 1)
        {
            PlayerPrefs.SetFloat("PopularidadeBolso", 100);
            popularidadePlayer = 100;

        }
        if (PlayerPrefs.GetInt("DilmaDentroPartido") == 1)
        {
            PlayerPrefs.SetFloat("PopularidadeDilma", 100);
            popularidadePlayer = 100;

        }
        if (PlayerPrefs.GetInt("SuplicyDentroPartido") == 1)
        {
            PlayerPrefs.SetFloat("PopularidadeSuplicy", 100);
            popularidadePlayer = 100;

        }
        if (PlayerPrefs.GetInt("EneasDentroPartido") == 1)
        {
            PlayerPrefs.SetFloat("PopularidadeEneas", 100);
            popularidadePlayer = 100;

        }

        if (PlayerPrefs.GetInt("DodorioDentroPartido") == 1)
        {
            PlayerPrefs.SetFloat("PopularidadeDodorio", 100);
            popularidadePlayer = 100;

        }

        if (PlayerPrefs.GetInt("HaddardDentroPartido") == 1)
        {
            PlayerPrefs.SetFloat("PopularidadeHaddard", 100);
            popularidadePlayer = 100;

        }
    
        if (PlayerPrefs.GetInt("CunhaDentroPartido") == 1)
        {
            PlayerPrefs.SetFloat("PopularidadeCunha", 100);
            popularidadePlayer = 100;

        }
    
    }


    public void ResetaSomaPop()
    {
        somaPopPartido = 0;

    }

    public void AtualizaPopPersonagens()
    {
        if (PlayerPrefs.GetInt("LulaDentroScene") == 1)
        {
            PlayerPrefs.SetFloat("PopularidadeLula", Mathf.Round(popularidadePlayer));
            if (PlayerPrefs.GetFloat("PopularidadeLula") <= 0)
            {
                LulaPartido.interactable = false;
            }
        }

        if (PlayerPrefs.GetInt("CiroDentroScene") == 1)
        {
            PlayerPrefs.SetFloat("PopularidadeCiro", Mathf.Round(popularidadePlayer));
            if (PlayerPrefs.GetFloat("PopularidadeCiro") <= 0)
            {
                CiroPartido.interactable = false;
            }
        }
        if (PlayerPrefs.GetInt("BolsoDentroScene") == 1)
        {
            PlayerPrefs.SetFloat("PopularidadeBolso", Mathf.Round(popularidadePlayer));
            if (PlayerPrefs.GetFloat("PopularidadeBolso") <= 0)
            {
                BolsoPartido.interactable = false;
            }
        }
        if (PlayerPrefs.GetInt("DilmaDentroScene") == 1)
        {
            PlayerPrefs.SetFloat("PopularidadeDilma", Mathf.Round(popularidadePlayer));
            if (PlayerPrefs.GetFloat("PopularidadeDilma") <= 0)
            {
                DilmaPartido.interactable = false;
            }
        }
        if (PlayerPrefs.GetInt("SuplicyDentroScene") == 1)
        {
            PlayerPrefs.SetFloat("PopularidadeSuplicy", Mathf.Round(popularidadePlayer));
            if (PlayerPrefs.GetFloat("PopularidadeSuplicy") <= 0)
            {
                SuplicyPartido.interactable = false;
            }
        }
        if (PlayerPrefs.GetInt("EneasDentroScene") == 1)
        {
            PlayerPrefs.SetFloat("PopularidadeEneas", Mathf.Round(popularidadePlayer));
            if (PlayerPrefs.GetFloat("PopularidadeEneas") <= 0)
            {
                EneasPartido.interactable = false;
            }
        }

        if (PlayerPrefs.GetInt("DodorioDentroScene") == 1)
        {
            PlayerPrefs.SetFloat("PopularidadeDodorio", Mathf.Round(popularidadePlayer));
            if (PlayerPrefs.GetFloat("PopularidadeDodorio") <= 0)
            {
                DodorioPartido.interactable = false;
            }
        }

        if (PlayerPrefs.GetInt("HaddardDentroScene") == 1)
        {
            PlayerPrefs.SetFloat("PopularidadeHaddard", Mathf.Round(popularidadePlayer));

            if (PlayerPrefs.GetFloat("PopularidadeHaddard") <= 0)
            {
                HaddardPartido.interactable = false;
            }
        }
    
        if (PlayerPrefs.GetInt("CunhaDentroScene") == 1)
        {
            PlayerPrefs.SetFloat("PopularidadeCunha", Mathf.Round(popularidadePlayer));

            if (PlayerPrefs.GetFloat("PopularidadeCunha") <= 0)
            {
                CunhaPartido.interactable = false;
            }
        }
    }


    public void PainelMovimentos()
    {
        if (PlayerPrefs.GetInt("LulaDentroScene") == 1)
        {
            MovimentosLula.gameObject.SetActive(true);

            MovimentosCiro.gameObject.SetActive(false);
            MovimentosBolso.gameObject.SetActive(false);
            MovimentosDilma.gameObject.SetActive(false);
            MovimentosSuplicy.gameObject.SetActive(false);
            MovimentosEneas.gameObject.SetActive(false);
            MovimentosDodorio.gameObject.SetActive(false);
            MovimentosHaddard.gameObject.SetActive(false);
            MovimentosCunha.gameObject.SetActive(false);

        }

        if (PlayerPrefs.GetInt("CiroDentroScene") == 1)
        {
            MovimentosCiro.gameObject.SetActive(true);

            MovimentosLula.gameObject.SetActive(false);
            MovimentosBolso.gameObject.SetActive(false);
            MovimentosDilma.gameObject.SetActive(false);
            MovimentosSuplicy.gameObject.SetActive(false);
            MovimentosEneas.gameObject.SetActive(false);
            MovimentosDodorio.gameObject.SetActive(false);
            MovimentosHaddard.gameObject.SetActive(false);
            MovimentosCunha.gameObject.SetActive(false);

        }

        if (PlayerPrefs.GetInt("BolsoDentroScene") == 1)
        {
            MovimentosBolso.gameObject.SetActive(true);

            MovimentosCiro.gameObject.SetActive(false);
            MovimentosLula.gameObject.SetActive(false);
            MovimentosDilma.gameObject.SetActive(false);
            MovimentosSuplicy.gameObject.SetActive(false);
            MovimentosEneas.gameObject.SetActive(false);
            MovimentosDodorio.gameObject.SetActive(false);
            MovimentosHaddard.gameObject.SetActive(false);
            MovimentosCunha.gameObject.SetActive(false);

        }

        if (PlayerPrefs.GetInt("DilmaDentroScene") == 1)
        {
            MovimentosDilma.gameObject.SetActive(true);

            MovimentosCiro.gameObject.SetActive(false);
            MovimentosBolso.gameObject.SetActive(false);
            MovimentosLula.gameObject.SetActive(false);
            MovimentosSuplicy.gameObject.SetActive(false);
            MovimentosEneas.gameObject.SetActive(false);
            MovimentosDodorio.gameObject.SetActive(false);
            MovimentosHaddard.gameObject.SetActive(false);
            MovimentosCunha.gameObject.SetActive(false);

        }

        if (PlayerPrefs.GetInt("SuplicyDentroScene") == 1)
        {
            MovimentosSuplicy.gameObject.SetActive(true);

            MovimentosCiro.gameObject.SetActive(false);
            MovimentosBolso.gameObject.SetActive(false);
            MovimentosDilma.gameObject.SetActive(false);
            MovimentosLula.gameObject.SetActive(false);
            MovimentosEneas.gameObject.SetActive(false);
            MovimentosDodorio.gameObject.SetActive(false);
            MovimentosHaddard.gameObject.SetActive(false);
            MovimentosCunha.gameObject.SetActive(false);

        }

        if (PlayerPrefs.GetInt("EneasDentroScene") == 1)
        {
            MovimentosEneas.gameObject.SetActive(true);

            MovimentosCiro.gameObject.SetActive(false);
            MovimentosBolso.gameObject.SetActive(false);
            MovimentosDilma.gameObject.SetActive(false);
            MovimentosSuplicy.gameObject.SetActive(false);
            MovimentosLula.gameObject.SetActive(false);
            MovimentosDodorio.gameObject.SetActive(false);
            MovimentosHaddard.gameObject.SetActive(false);
            MovimentosCunha.gameObject.SetActive(false);

        }

        if (PlayerPrefs.GetInt("DodorioDentroScene") == 1)
        {
            MovimentosDodorio.gameObject.SetActive(true);

            MovimentosCiro.gameObject.SetActive(false);
            MovimentosBolso.gameObject.SetActive(false);
            MovimentosDilma.gameObject.SetActive(false);
            MovimentosSuplicy.gameObject.SetActive(false);
            MovimentosLula.gameObject.SetActive(false);
            MovimentosEneas.gameObject.SetActive(false);
            MovimentosHaddard.gameObject.SetActive(false);
            MovimentosCunha.gameObject.SetActive(false);

        }

        if (PlayerPrefs.GetInt("HaddardDentroScene") == 1)
        {
            MovimentosHaddard.gameObject.SetActive(true);

            MovimentosCiro.gameObject.SetActive(false);
            MovimentosBolso.gameObject.SetActive(false);
            MovimentosDilma.gameObject.SetActive(false);
            MovimentosSuplicy.gameObject.SetActive(false);
            MovimentosLula.gameObject.SetActive(false);
            MovimentosEneas.gameObject.SetActive(false);
            MovimentosDodorio.gameObject.SetActive(false);
            MovimentosCunha.gameObject.SetActive(false);

        }

        if (PlayerPrefs.GetInt("CunhaDentroScene") == 1)
        {
            MovimentosCunha.gameObject.SetActive(true);

            MovimentosCiro.gameObject.SetActive(false);
            MovimentosBolso.gameObject.SetActive(false);
            MovimentosDilma.gameObject.SetActive(false);
            MovimentosSuplicy.gameObject.SetActive(false);
            MovimentosLula.gameObject.SetActive(false);
            MovimentosEneas.gameObject.SetActive(false);
            MovimentosDodorio.gameObject.SetActive(false);
            MovimentosHaddard.gameObject.SetActive(false);

        }
    
    
    } // FIM PAINEL MOVIMENTOS



    public void StatusDeBatalha()
    {
        if (PlayerPrefs.GetInt("LulaDentroScene") == 1)
        {
            autoridadePlayer = PlayerPrefs.GetFloat("AutoridadeLula");
            levelPlayer = PlayerPrefs.GetInt("LevelLula");
            apoioMidiaPlayer = PlayerPrefs.GetFloat("ApoioMidiaLula");
            confiancaPlayer = PlayerPrefs.GetInt("ConfiancaLula");
            retoricaPlayer = PlayerPrefs.GetFloat("RetoricaLula");

            LulaScene.gameObject.SetActive(true);

            CiroScene.gameObject.SetActive(false);
            BolsoScene.gameObject.SetActive(false);
            DilmaScene.gameObject.SetActive(false);
            SuplicyScene.gameObject.SetActive(false);
            EneasScene.gameObject.SetActive(false);
            DodorioScene.gameObject.SetActive(false);
            HaddardScene.gameObject.SetActive(false);
            CunhaScene.gameObject.SetActive(false);



        }
        if (PlayerPrefs.GetInt("CiroDentroScene") == 1)
        {
            autoridadePlayer = PlayerPrefs.GetFloat("AutoridadeCiro");
            levelPlayer = PlayerPrefs.GetInt("LevelCiro");
            apoioMidiaPlayer = PlayerPrefs.GetFloat("ApoioMidiaCiro");
            confiancaPlayer = PlayerPrefs.GetInt("ConfiancaCiro");
            retoricaPlayer = PlayerPrefs.GetFloat("RetoricaCiro");

            CiroScene.gameObject.SetActive(true);

            LulaScene.gameObject.SetActive(false);
            BolsoScene.gameObject.SetActive(false);
            DilmaScene.gameObject.SetActive(false);
            SuplicyScene.gameObject.SetActive(false);
            EneasScene.gameObject.SetActive(false);
            DodorioScene.gameObject.SetActive(false);
            HaddardScene.gameObject.SetActive(false);
            CunhaScene.gameObject.SetActive(false);

        }
        if (PlayerPrefs.GetInt("BolsoDentroScene") == 1)
        {
            autoridadePlayer = PlayerPrefs.GetFloat("AutoridadeBolso");
            levelPlayer = PlayerPrefs.GetInt("LevelBolso");
            apoioMidiaPlayer = PlayerPrefs.GetFloat("ApoioMidiaBolso");
            confiancaPlayer = PlayerPrefs.GetInt("ConfiancaBolso");
            retoricaPlayer = PlayerPrefs.GetFloat("RetoricaBolso");

            BolsoScene.gameObject.SetActive(true);

            CiroScene.gameObject.SetActive(false);
            LulaScene.gameObject.SetActive(false);
            DilmaScene.gameObject.SetActive(false);
            SuplicyScene.gameObject.SetActive(false);
            EneasScene.gameObject.SetActive(false);
            DodorioScene.gameObject.SetActive(false);
            HaddardScene.gameObject.SetActive(false);
            CunhaScene.gameObject.SetActive(false);

        }
        if (PlayerPrefs.GetInt("DilmaDentroScene") == 1)
        {
            autoridadePlayer = PlayerPrefs.GetFloat("AutoridadeDilma");
            levelPlayer = PlayerPrefs.GetInt("LevelDilma");
            apoioMidiaPlayer = PlayerPrefs.GetFloat("ApoioMidiaDilma");
            confiancaPlayer = PlayerPrefs.GetInt("ConfiancaDilma");
            retoricaPlayer = PlayerPrefs.GetFloat("RetoricaDilma");

            DilmaScene.gameObject.SetActive(true);

            CiroScene.gameObject.SetActive(false);
            BolsoScene.gameObject.SetActive(false);
            LulaScene.gameObject.SetActive(false);
            SuplicyScene.gameObject.SetActive(false);
            EneasScene.gameObject.SetActive(false);
            DodorioScene.gameObject.SetActive(false);
            HaddardScene.gameObject.SetActive(false);
            CunhaScene.gameObject.SetActive(false);

        }
        if (PlayerPrefs.GetInt("SuplicyDentroScene") == 1)
        {
            autoridadePlayer = PlayerPrefs.GetFloat("AutoridadeSuplicy");
            levelPlayer = PlayerPrefs.GetInt("LevelSuplicy");
            apoioMidiaPlayer = PlayerPrefs.GetFloat("ApoioMidiaSuplicy");
            confiancaPlayer = PlayerPrefs.GetInt("ConfiancaSuplicy");
            retoricaPlayer = PlayerPrefs.GetFloat("RetoricaSuplicy");

            SuplicyScene.gameObject.SetActive(true);

            CiroScene.gameObject.SetActive(false);
            BolsoScene.gameObject.SetActive(false);
            DilmaScene.gameObject.SetActive(false);
            LulaScene.gameObject.SetActive(false);
            EneasScene.gameObject.SetActive(false);
            DodorioScene.gameObject.SetActive(false);
            HaddardScene.gameObject.SetActive(false);
            CunhaScene.gameObject.SetActive(false);

        }
        if (PlayerPrefs.GetInt("EneasDentroScene") == 1)
        {
            autoridadePlayer = PlayerPrefs.GetFloat("AutoridadeEneas");
            levelPlayer = PlayerPrefs.GetInt("LevelEneas");
            apoioMidiaPlayer = PlayerPrefs.GetFloat("ApoioMidiaEneas");
            confiancaPlayer = PlayerPrefs.GetInt("ConfiancaEneas");
            retoricaPlayer = PlayerPrefs.GetFloat("RetoricaEneas");

            EneasScene.gameObject.SetActive(true);

            CiroScene.gameObject.SetActive(false);
            BolsoScene.gameObject.SetActive(false);
            DilmaScene.gameObject.SetActive(false);
            SuplicyScene.gameObject.SetActive(false);
            LulaScene.gameObject.SetActive(false);
            DodorioScene.gameObject.SetActive(false);
            HaddardScene.gameObject.SetActive(false);
            CunhaScene.gameObject.SetActive(false);

        }
        if (PlayerPrefs.GetInt("DodorioDentroScene") == 1)
        {
            autoridadePlayer = PlayerPrefs.GetFloat("AutoridadeDodorio");
            levelPlayer = PlayerPrefs.GetInt("LevelDodorio");
            apoioMidiaPlayer = PlayerPrefs.GetFloat("ApoioMidiaDodorio");
            confiancaPlayer = PlayerPrefs.GetInt("ConfiancaDodorio");
            retoricaPlayer = PlayerPrefs.GetFloat("RetoricaDodorio");

            DodorioScene.gameObject.SetActive(true);

            CiroScene.gameObject.SetActive(false);
            BolsoScene.gameObject.SetActive(false);
            DilmaScene.gameObject.SetActive(false);
            SuplicyScene.gameObject.SetActive(false);
            EneasScene.gameObject.SetActive(false);
            LulaScene.gameObject.SetActive(false);
            HaddardScene.gameObject.SetActive(false);
            CunhaScene.gameObject.SetActive(false);

        }

        if (PlayerPrefs.GetInt("HaddardDentroScene") == 1)
        {
            autoridadePlayer = PlayerPrefs.GetFloat("AutoridadeHaddard");
            levelPlayer = PlayerPrefs.GetInt("LevelHaddard");
            apoioMidiaPlayer = PlayerPrefs.GetFloat("ApoioMidiaHaddard");
            confiancaPlayer = PlayerPrefs.GetInt("ConfiancaHaddard");
            retoricaPlayer = PlayerPrefs.GetFloat("RetoricaHaddard");

            HaddardScene.gameObject.SetActive(true);

            CiroScene.gameObject.SetActive(false);
            BolsoScene.gameObject.SetActive(false);
            DilmaScene.gameObject.SetActive(false);
            SuplicyScene.gameObject.SetActive(false);
            EneasScene.gameObject.SetActive(false);
            LulaScene.gameObject.SetActive(false);
            DodorioScene.gameObject.SetActive(false);
            CunhaScene.gameObject.SetActive(false);

        }

        if (PlayerPrefs.GetInt("CunhaDentroScene") == 1)
        {
            autoridadePlayer = PlayerPrefs.GetFloat("AutoridadeCunha");
            levelPlayer = PlayerPrefs.GetInt("LevelCunha");
            apoioMidiaPlayer = PlayerPrefs.GetFloat("ApoioMidiaCunha");
            confiancaPlayer = PlayerPrefs.GetInt("ConfiancaCunha");
            retoricaPlayer = PlayerPrefs.GetFloat("RetoricaCunha");

            CunhaScene.gameObject.SetActive(true);

            CiroScene.gameObject.SetActive(false);
            BolsoScene.gameObject.SetActive(false);
            DilmaScene.gameObject.SetActive(false);
            SuplicyScene.gameObject.SetActive(false);
            EneasScene.gameObject.SetActive(false);
            LulaScene.gameObject.SetActive(false);
            DodorioScene.gameObject.SetActive(false);
            HaddardScene.gameObject.SetActive(false);

        }

    } // FIM STATUS DE BATALHA

    public void StatusDeBatalhaInimigos()
    {
        if (PlayerPrefs.GetInt("LulaInimigoScene") == 1)
        {
            autoridadeInimigo = PlayerPrefs.GetFloat("AutoridadeLulaInimigo");
            levelInimigo = PlayerPrefs.GetInt("LevelLulaInimigo");
            apoioMidiaInimigo = PlayerPrefs.GetFloat("ApoioMidiaLulaInimigo");
            retoricaInimigo = PlayerPrefs.GetFloat("RetoricaLulaInimigo");
            confiancaInimigo = PlayerPrefs.GetInt("ConfiancaLulaInimigo");


        }

        if (PlayerPrefs.GetInt("CiroInimigoScene") == 1)
        {
            autoridadeInimigo = PlayerPrefs.GetFloat("AutoridadeCiroInimigo");
            levelInimigo = PlayerPrefs.GetInt("LevelCiroInimigo");
            apoioMidiaInimigo = PlayerPrefs.GetFloat("ApoioMidiaCiroInimigo");
            retoricaInimigo = PlayerPrefs.GetFloat("RetoricaCiroInimigo");
            confiancaInimigo = PlayerPrefs.GetInt("ConfiancaCiroInimigo");
        }
        if (PlayerPrefs.GetInt("BolsoInimigoScene") == 1)
        {
            autoridadeInimigo = PlayerPrefs.GetFloat("AutoridadeBolsoInimigo");
            levelInimigo = PlayerPrefs.GetInt("LevelBolsoInimigo");
            apoioMidiaInimigo = PlayerPrefs.GetFloat("ApoioMidiaBolsoInimigo");
            retoricaInimigo = PlayerPrefs.GetFloat("RetoricaBolsoInimigo");
            confiancaInimigo = PlayerPrefs.GetInt("ConfiancaBolsoInimigo");

        }
        if (PlayerPrefs.GetInt("DilmaInimigoScene") == 1)
        {
            autoridadeInimigo = PlayerPrefs.GetFloat("AutoridadeDilmaInimigo");
            levelInimigo = PlayerPrefs.GetInt("LevelDilmaInimigo");
            apoioMidiaInimigo = PlayerPrefs.GetFloat("ApoioMidiaDilmaInimigo");
            retoricaInimigo = PlayerPrefs.GetFloat("RetoricaDilmaInimigo");
            confiancaInimigo = PlayerPrefs.GetInt("ConfiancaDilmaInimigo");
        }
        if (PlayerPrefs.GetInt("SuplicyInimigoScene") == 1)
        {
            autoridadeInimigo = PlayerPrefs.GetFloat("AutoridadeSuplicyInimigo");
            levelInimigo = PlayerPrefs.GetInt("LevelSuplicyInimigo");
            apoioMidiaInimigo = PlayerPrefs.GetFloat("ApoioMidiaSuplicyInimigo");
            retoricaInimigo = PlayerPrefs.GetFloat("RetoricaSuplicyInimigo");
            confiancaInimigo = PlayerPrefs.GetInt("ConfiancaSuplicyInimigo");
        }
        if (PlayerPrefs.GetInt("EneasInimigoScene") == 1)
        {
            autoridadeInimigo = PlayerPrefs.GetFloat("AutoridadeEneasInimigo");
            levelInimigo = PlayerPrefs.GetInt("LevelEneasInimigo");
            apoioMidiaInimigo = PlayerPrefs.GetFloat("ApoioMidiaEneasInimigo");
            retoricaInimigo = PlayerPrefs.GetFloat("RetoricaEneasInimigo");
            confiancaInimigo = PlayerPrefs.GetInt("ConfiancaEneasInimigo");
        }

        if (PlayerPrefs.GetInt("DodorioInimigoScene") == 1)
        {
            autoridadeInimigo = PlayerPrefs.GetFloat("AutoridadeDodorioInimigo");
            levelInimigo = PlayerPrefs.GetInt("LevelDodorioInimigo");
            apoioMidiaInimigo = PlayerPrefs.GetFloat("ApoioMidiaDodorioInimigo");
            retoricaInimigo = PlayerPrefs.GetFloat("RetoricaDodorioInimigo");
            confiancaInimigo = PlayerPrefs.GetInt("ConfiancaDodorioInimigo");
        }

        if (PlayerPrefs.GetInt("HaddardInimigoScene") == 1)
        {
            autoridadeInimigo = PlayerPrefs.GetFloat("AutoridadeHaddardoInimigo");
            levelInimigo = PlayerPrefs.GetInt("LevelHaddardInimigo");
            apoioMidiaInimigo = PlayerPrefs.GetFloat("ApoioMidiaHaddardInimigo");
            retoricaInimigo = PlayerPrefs.GetFloat("RetoricaHaddardInimigo");
            confiancaInimigo = PlayerPrefs.GetInt("ConfiancaHaddardInimigo");
        }
    
        if (PlayerPrefs.GetInt("CunhaInimigoScene") == 1)
        {
            autoridadeInimigo = PlayerPrefs.GetFloat("AutoridadeCunhaInimigo");
            levelInimigo = PlayerPrefs.GetInt("LevelCunhaInimigo");
            apoioMidiaInimigo = PlayerPrefs.GetFloat("ApoioMidiaCunhaInimigo");
            retoricaInimigo = PlayerPrefs.GetFloat("RetoricaCunhaInimigo");
            confiancaInimigo = PlayerPrefs.GetInt("ConfiancaCunhaInimigo");
        }
    
    } // FIM STATUS INIMIGO


    // ------------------------ ATAQUES ESPECIAIS DE CADA PERSONAGEM ----------------//

    // AUMENTA AUTORIDADE

    public void AtaqueChamarGilmar()
    {
        ataquePlayer = false;
        defesaPlayer = false;
        mudaStatusPlayer = true;
        autoridadeAtaque = Random.Range(30, 41);
        MitouLacrou();

        CalculoConfiancaPlayer();

        if (qteChamarGilmar <= 0)
        {
            ataqueChamarGilmar.interactable = false;
        }
        if (qteChamarGilmar > 0)
        {

            ataqueChamarGilmar.interactable = true;
            danoPlayer = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelPlayer / 5 + 2) * autoridadePlayer * autoridadeAtaque / autoridadePlayer) / 50) + 2) * mitouLacrou) * confianca;
            autoridadePlayer = autoridadePlayer + danoPlayer;

            if (confianca == 0)
            {
                dialogo.text = "Seu político errou o ataque porque não foi confiante";
                SomFalhouAtaque.Play();
            }
            if (confianca != 0)
            {
                SomAumentaStatus.Play();
                if (chanceMitarLacrar != 2)
                {
                    dialogo.text = "Você usou <color=#FFED00FF> CHAMAR GILMAR </color>. Agora, sua autoridade aumentou para " + autoridadePlayer;

                }

                if (direita == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Muito opressor! Você <color=#FFED00FF> MITOU com CHAMAR GILMAR </color> e aumentou sua Autoridade para " + autoridadePlayer);

                }
                if (esquerda == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Que tiro foi esse?! Você <color=#FFED00FF> LACROU com CHAMAR GILMAR </color> e aumentou sua Autoridade para " + autoridadePlayer);

                }

            }

            qteChamarGilmar = qteChamarGilmar  - 1;
            AtualizaQuantidadeAtaques();

        }


        DesabilitaBotoes();

        playerAtacou = true;
    }

    public void SelecionaChamarGilmar()
    {
        infoAtaque.text = "Aumenta sua Autoridade (ataque)";
        qte_Ataque.text = "Qte.: " + qteChamarGilmar + "/3";
        dialogo.text = "Utilizar o ataque Chamar Gilmar?";
        aut_Ataque.text = "Autoridade: 30 - 40";

    }

    public void AtaqueMeuPostoIpiranga()
    {
        ataquePlayer = false;
        defesaPlayer = false;
        mudaStatusPlayer = true;
        autoridadeAtaque = Random.Range(30, 41);
        MitouLacrou();

        CalculoConfiancaPlayer();

        if (qteMeuPostoIpiranga <= 0)
        {
            ataqueMeuPostoIpiranga.interactable = false;
        }
        if (qteMeuPostoIpiranga > 0)
        {

            ataqueMeuPostoIpiranga.interactable = true;
            danoPlayer = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelPlayer / 5 + 2) * autoridadePlayer * autoridadeAtaque / autoridadePlayer) / 50) + 2) * mitouLacrou) * confianca;
            autoridadePlayer = autoridadePlayer + danoPlayer;

            if (confianca == 0)
            {
                SomFalhouAtaque.Play();
                dialogo.text = "Seu político errou o ataque porque não foi confiante";

            }
            if (confianca != 0)
            {
                SomAumentaStatus.Play();
                if (chanceMitarLacrar != 2)
                {
                    dialogo.text = "Você usou <color=#FFED00FF> MEU POSTO IPIRANGA </color>. Agora, sua autoridade aumentou para " + autoridadePlayer;

                }

                if (direita == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Muito opressor! Você <color=#FFED00FF> MITOU com MEU POSTO IPIRANGA </color> e aumentou sua Autoridade para " + autoridadePlayer);

                }
                if (esquerda == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Que tiro foi esse?! Você <color=#FFED00FF> LACROU com MEU POSTO IPIRANGA </color> e aumentou sua Autoridade para " + autoridadePlayer);

                }

            }

            qteMeuPostoIpiranga = qteMeuPostoIpiranga  - 1;
            AtualizaQuantidadeAtaques();

        }


        DesabilitaBotoes();

        playerAtacou = true;
    }

    public void SelecionaMeuPostoIpiranga()
    {
        infoAtaque.text = "Aumenta sua Autoridade (ataque)";
        qte_Ataque.text = "Qte.: " + qteMeuPostoIpiranga  + "/3";
        dialogo.text = "Utilizar o ataque Meu Posto Ipiranga ?";
        aut_Ataque.text = "Autoridade: 30 - 40";

    }

    // AUMENTA APOIO MIDIA

    public void AtaqueSemCustoContribuinte()
    {

        ataquePlayer = false;
        defesaPlayer = true;
        mudaStatusPlayer = false;

        CalculoConfiancaPlayer();
        MitouLacrou();

        autoridadeAtaque = Random.Range(40, 51);

        if (qteSemCustoContribuinte <= 0)
        {
            ataqueSemCustoContribuinte.interactable = false;
        }
        if (qteSemCustoContribuinte > 0)
        {
            danoPlayer = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelPlayer / 5 + 2) * apoioMidiaPlayer * autoridadeAtaque / apoioMidiaPlayer) / 50) + 2) * mitouLacrou) * confianca;
            ataqueSemCustoContribuinte.interactable = true;
            apoioMidiaPlayer = apoioMidiaPlayer + danoPlayer;

            if (confianca == 0)
            {
                SomFalhouAtaque.Play();

                dialogo.text = "Seu político errou o ataque porque não foi confiante";

            }
            if (confianca != 0)
            {
                SomDefesa.Play();
                StartCoroutine(AumentouApoioMidiaPlayer());

                if (chanceMitarLacrar != 2)
                {
                    dialogo.text = "Você usou <color=#FFED00FF> SEM CUSTO AO CNTRIBUINTE </color>. Agora, seu Apoio da Mídia aumentou para " + apoioMidiaPlayer;

                }

                if (direita == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Muito opressor! Você <color=#FFED00FF> MITOU com SEM CUSTO AO CONTRIBUINTE </color> e aumentou o Apoio da Mídia para " + apoioMidiaPlayer);

                }
                if (esquerda == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Que tiro foi esse?! Você <color=#FFED00FF> LACROU com SEM CUSTO AO CONTRIBUINTE </color> e aumentou o Apoio da Mídia para " + apoioMidiaPlayer);

                }

            }

            qteSemCustoContribuinte = qteSemCustoContribuinte - 1;
            AtualizaQuantidadeAtaques();
        }





        DesabilitaBotoes();

        playerAtacou = true;

    }

    public void SelecionaSemCustoContribuinte()
    {
        infoAtaque.text = "Aumenta seu Apoio da Mídia (defesa)";
        qte_Ataque.text = "Qte.: " + qteSemCustoContribuinte + "/3";
        dialogo.text = "Utilizar o ataque Sem Custo Ao Contribuinte?";
        aut_Ataque.text = "Autoridade: 40 - 50";

    }

    public void AtaqueCiclovia()
    {

        ataquePlayer = false;
        defesaPlayer = true;
        mudaStatusPlayer = false;

        CalculoConfiancaPlayer();
        MitouLacrou();

        autoridadeAtaque = Random.Range(40, 51);

        if (qteCiclovia <= 0)
        {
            ataqueCiclovia.interactable = false;
        }
        if (qteCiclovia > 0)
        {
            danoPlayer = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelPlayer / 5 + 2) * apoioMidiaPlayer * autoridadeAtaque / apoioMidiaPlayer) / 50) + 2) * mitouLacrou) * confianca;
            ataqueCiclovia.interactable = true;
            apoioMidiaPlayer = apoioMidiaPlayer + danoPlayer;

            if (confianca == 0)
            {
                SomFalhouAtaque.Play();
                dialogo.text = "Seu político errou o ataque porque não foi confiante";

            }
            if (confianca != 0)
            {
                StartCoroutine(AumentouApoioMidiaPlayer());

                SomDefesa.Play();
                if (chanceMitarLacrar != 2)
                {
                    dialogo.text = "Você usou <color=#FFED00FF> CICLOVIA </color>. Agora, seu Apoio da Mídia aumentou para " + apoioMidiaPlayer;

                }

                if (direita == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Muito opressor! Você <color=#FFED00FF> MITOU com CICLOVIA </color> e aumentou o Apoio da Mídia para " + apoioMidiaPlayer);

                }
                if (esquerda == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Que tiro foi esse?! Você <color=#FFED00FF> LACROU com CICLOVIA </color> e aumentou o Apoio da Mídia para " + apoioMidiaPlayer);

                }

            }

            qteCiclovia = qteCiclovia - 1;
            AtualizaQuantidadeAtaques();
        }





        DesabilitaBotoes();

        playerAtacou = true;

    }

    public void SelecionaCiclovia()
    {
        infoAtaque.text = "Aumenta seu Apoio da Mídia (defesa)";
        qte_Ataque.text = "Qte.: " + qteCiclovia + "/3";
        dialogo.text = "Utilizar o ataque Ciclovia?";
        aut_Ataque.text = "Autoridade: 40 - 50";

    }

    // --------------- ATAQUES PLAYER ------------------ //


    // TIRA POPULARIDADE

    // Fraudar Urnas(autoridade 30-40)

    public void AtaqueFraudarUrnas()
    {
        ataquePlayer = true;
        defesaPlayer = false;
        mudaStatusPlayer = false;
        MitouLacrou();
        Protegido();
        CalculoConfiancaPlayer();
        autoridadeAtaque = Random.Range(30, 41);
        danoPlayer = Mathf.Round(Mathf.Round(Mathf.Round(((2 * (levelPlayer/ levelInimigo) / 5 + 2) * autoridadePlayer * autoridadeAtaque / apoioMidiaInimigo) / 50) + 2) * mitouLacrou) * confianca;

        if (qteFraudarUrnas <= 0)
        {
            ataqueFraudarUrnas.interactable = false;
        }
        if (qteFraudarUrnas > 0)
        {
            ataqueFraudarUrnas.interactable = true;

        }


        if (qteFraudarUrnas > 0)
        {
            print("ATAQUE COM DANO" + danoPlayer);

            //  StartCoroutine(tirapop(danoPlayer));



            popularidadeInimigo = Mathf.Round(popularidadeInimigo - danoPlayer);

            if (popularidadeInimigo <= 0)
            {
                popularidadeInimigo = 0;
            }

            qteFraudarUrnas = qteFraudarUrnas - 1;
            AtualizaQuantidadeAtaques();

            if (confianca == 0)
            {
                SomFalhouAtaque.Play();

                dialogo.text = "Seu político errou o ataque porque não foi confiante";



            }
            if (confianca != 0)
            {
                moveCamera = true;

                StartCoroutine(PerdeuPopInimigo());
                SonsAtaque();
                if (chanceMitarLacrar != 2)
                {
                    dialogo.text = "Você usou <color=#FFED00FF> FRAUDAR URNAS </color> e tirou " + danoPlayer + " de popularidade do oponente";

                }

                if (direita == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Muito opressor! Você <color=#FFED00FF> MITOU com FRAUDAR URNAS </color> e tirou " + danoPlayer + "  de popularidade do seu oponente");
                  
                }
                if (esquerda == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Que tiro foi esse?! Você LACROU e tirou " + danoPlayer + "  de popularidade do seu oponente");

                }

            }



        }




        pop_txtUI.text = Mathf.Round(popularidadePlayer).ToString();
        barraPop.value = popularidadePlayer;


        DesabilitaBotoes();

        PlayerPrefs.SetFloat("PopInimigos", popularidadeInimigo);
        popularidadeInimigo = PlayerPrefs.GetFloat("PopInimigos"); //

        popInimigo_txtUI.text = popularidadeInimigo.ToString();
        barraPopInimigo.value = popularidadeInimigo;

        playerAtacou = true;
    }

    public void SelecionaFraudarUrnas()
    {
        QuantidadeAtaques();

        infoAtaque.text = "Diminui popularidade do oponente";
        qte_Ataque.text = "Qte.: " + qteFraudarUrnas + "/5";
        dialogo.text = "Utilizar o ataque Fraudar Urnas?";
        aut_Ataque.text = "Autoridade: 30 - 40";

    }

    // Fake News (autoridade 50-60)

    public void AtaqueFakeNews()
    {

        ataquePlayer = true;
        defesaPlayer = false;
        mudaStatusPlayer = false;

        autoridadeAtaque = Random.Range(50, 61);

        MitouLacrou();
        Protegido();
        CalculoConfiancaPlayer();

        danoPlayer = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelPlayer / 5 + 2) * autoridadePlayer * autoridadeAtaque / apoioMidiaInimigo) / 50) + 2) * mitouLacrou) * confianca;

        if (qteFakeNews <= 0)
        {
            ataqueFakeNews.interactable = false;
        }
        if (qteFakeNews > 0)
        {
            ataqueFakeNews.interactable = true;

        }


        if (qteFakeNews > 0)
        {

            popularidadeInimigo = popularidadeInimigo - danoPlayer;
            if (popularidadeInimigo <= 0)
            {
                popularidadeInimigo = 0;
            }
            qteFakeNews = qteFakeNews - 1;
            AtualizaQuantidadeAtaques();

            if (confianca == 0)
            {
                SomFalhouAtaque.Play();

                dialogo.text = "Seu político errou o ataque porque não foi confiante";



            }
            if (confianca != 0)
            {
                moveCamera = true;

                StartCoroutine(PerdeuPopInimigo());

                SonsAtaque();
                if (chanceMitarLacrar != 2)
                {
                    dialogo.text = "Você usou Você <color=#FFED00FF> FAKE NEWS </color> e tirou " + danoPlayer + " de popularidade do oponente";

                }

                if (direita == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Muito opressor! Você <color=#FFED00FF> MITOU com FAKE NEWS </color>e tirou " + danoPlayer + "  de popularidade do seu oponente");

                }
                if (esquerda == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Que tiro foi esse?! Você <color=#FFED00FF> LACROU com FAKE NEWS </color> e tirou " + danoPlayer + "  de popularidade do seu oponente");

                }

            }



        }


        PlayerPrefs.SetFloat("PopInimigos", popularidadeInimigo);
        popularidadeInimigo = PlayerPrefs.GetFloat("PopInimigos");

        popInimigo_txtUI.text = popularidadeInimigo.ToString();
        barraPopInimigo.value = popularidadeInimigo;

        pop_txtUI.text = Mathf.Round(popularidadePlayer).ToString();
        barraPop.value = popularidadePlayer;


        DesabilitaBotoes();


        playerAtacou = true;

    } // FIM ATAQUE FAKE NEWS

    public void SelecionaFakeNews()
    {
        QuantidadeAtaques();

        infoAtaque.text = "Diminui popularidade do oponente";
        qte_Ataque.text = "Qte.: " + qteFakeNews + "/3";
        dialogo.text = "Utilizar o ataque Fake News?";
        aut_Ataque.text = "Autoridade: 50 - 60";

    }

    // Pergunta Polemica (autoridade 40-50)
    public void AtaquePerguntaPolemica()
    {

        ataquePlayer = true;
        defesaPlayer = false;
        mudaStatusPlayer = false;

        autoridadeAtaque = Random.Range(40, 51);

        MitouLacrou();
        Protegido();
        CalculoConfiancaPlayer();

        danoPlayer = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelPlayer / 5 + 2) * autoridadePlayer * autoridadeAtaque / apoioMidiaInimigo) / 50) + 2) * mitouLacrou) * confianca;

        if (qtePerguntaPolemica <= 0)
        {
            ataquePerguntaPolemica.interactable = false;
        }
        if (qtePerguntaPolemica > 0)
        {
            ataquePerguntaPolemica.interactable = true;

        }


        if (qtePerguntaPolemica > 0)
        {

            popularidadeInimigo = popularidadeInimigo - danoPlayer;
            qtePerguntaPolemica = qtePerguntaPolemica - 1;
            AtualizaQuantidadeAtaques();

            if (popularidadeInimigo <= 0)
            {
                popularidadeInimigo = 0;
            }

            if (confianca == 0)
            {
                SomFalhouAtaque.Play();

                dialogo.text = "Seu político errou o ataque porque não foi confiante";



            }
            if (confianca != 0)
            {
                StartCoroutine(PerdeuPopInimigo());

                moveCamera = true;

                SonsAtaque();

                if (chanceMitarLacrar != 2)
                {
                    dialogo.text = "Você usou <color=#FFED00FF> PERGUNTA POLÊMICA </color> e tirou " + danoPlayer + " de popularidade do oponente";

                }

                if (direita == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Muito opressor! Você <color=#FFED00FF> MITOU com PERGUNTA POLÊMICA </color> e tirou " + danoPlayer + "  de popularidade do seu oponente");

                }
                if (esquerda == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Que tiro foi esse?! Você <color=#FFED00FF> LACROU com PERGUNTA POLÊMICA </color> e tirou " + danoPlayer + "  de popularidade do seu oponente");

                }

            }



        }



        PlayerPrefs.SetFloat("PopInimigos", popularidadeInimigo);
        popularidadeInimigo = PlayerPrefs.GetFloat("PopInimigos");

        popInimigo_txtUI.text = popularidadeInimigo.ToString();
        barraPopInimigo.value = popularidadeInimigo;

        pop_txtUI.text = Mathf.Round(popularidadePlayer).ToString();
        barraPop.value = popularidadePlayer;


        DesabilitaBotoes();


        playerAtacou = true;

    } // FIM ATAQUE PERGUNTA POLEMICA

    public void SelecionaPerguntaPolemica()
    {
        QuantidadeAtaques();

        infoAtaque.text = "Diminui popularidade do oponente";
        qte_Ataque.text = "Qte.: " + qtePerguntaPolemica + "/3";
        dialogo.text = "Utilizar o ataque Pergunta Polemica?";
        aut_Ataque.text = "Autoridade: 40 - 50";

    }

    // ---------------------------------------------------

    // AUMENTA APOIO DA MIDIA

    // HABEAS CORPUS - aumenta apoio da mídia
    public void AtaqueHabeasCorpus()
    {

        ataquePlayer = false;
        defesaPlayer = true;
        mudaStatusPlayer = false;

        CalculoConfiancaPlayer();
        MitouLacrou();

        autoridadeAtaque = Random.Range(40, 51);

        if (qteHabeasCorpus <= 0)
        {
            ataqueHabeasCorpus.interactable = false;
        }
        if (qteHabeasCorpus > 0)
        {
            danoPlayer = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelPlayer / 5 + 2) * apoioMidiaPlayer * autoridadeAtaque / apoioMidiaPlayer) / 50) + 2) * mitouLacrou) * confianca;
            ataqueHabeasCorpus.interactable = true;
            apoioMidiaPlayer = apoioMidiaPlayer + danoPlayer;

            if (confianca == 0)
            {
                SomFalhouAtaque.Play();

                dialogo.text = "Seu político errou o ataque porque não foi confiante";

            }
            if (confianca != 0)
            {
                StartCoroutine(AumentouApoioMidiaPlayer());
                SomDefesa.Play();

                if (chanceMitarLacrar != 2)
                {
                    dialogo.text = "Você <color=#FFED00FF> usou HABEAS CORPUS </color>. Agora, seu Apoio da Mídia aumentou para " + apoioMidiaPlayer;

                }

                if (direita == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Muito opressor! Você <color=#FFED00FF> MITOU com HABEAS CORPUS </color> e aumentou o Apoio da Mídia para " + apoioMidiaPlayer);

                }
                if (esquerda == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Que tiro foi esse?! Você <color=#FFED00FF> LACROU com HABEAS CORPUS </color> e aumentou o Apoio da Mídia para " + apoioMidiaPlayer);

                }

            }

            qteHabeasCorpus = qteHabeasCorpus - 1;
            AtualizaQuantidadeAtaques();
        }





        DesabilitaBotoes();

        playerAtacou = true;
        print("Ataque Habeas finalizado");

    }

    public void SelecionaHabeasCorpus()
    {
        infoAtaque.text = "Aumenta seu Apoio da Mídia (defesa)";
        qte_Ataque.text = "Qte.: " + qteHabeasCorpus + "/3";
        dialogo.text = "Utilizar o ataque Habeas Corpus?";
        aut_Ataque.text = "Autoridade: 40 - 50";

    }

    // MUDA STATUS

    // MILITANCIA - aumenta autoridade
    public void AtaqueMilitancia()
    {
        ataquePlayer = false;
        defesaPlayer = false;
        mudaStatusPlayer = true;
        autoridadeAtaque = Random.Range(30, 41);
        MitouLacrou();

        CalculoConfiancaPlayer();

        if (qteMilitancia <= 0)
        {
            ataqueMilitancia.interactable = false;
        }
        if (qteMilitancia > 0)
        {

            ataqueMilitancia.interactable = true;
            danoPlayer = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelPlayer / 5 + 2) * autoridadePlayer * autoridadeAtaque / autoridadePlayer) / 50) + 2) * mitouLacrou) * confianca;
            autoridadePlayer = autoridadePlayer + danoPlayer;
            if (confianca == 0)
            {
                SomFalhouAtaque.Play();

                dialogo.text = "Seu político errou o ataque porque não foi confiante";

            }
            if (confianca != 0)
            {
                SomAumentaStatus.Play();

                if (chanceMitarLacrar != 2)
                {
                    dialogo.text = "Você usou <color=#FFED00FF> MILITÂNCIA </color>. Agora, sua autoridade aumentou para " + autoridadePlayer;

                }

                if (direita == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Muito opressor! Você <color=#FFED00FF> MITOU com MILITÂNCIA </color> com Militância e aumentou sua Autoridade para " + autoridadePlayer);

                }
                if (esquerda == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Que tiro foi esse?! Você <color=#FFED00FF> LACROU com MILITÂNCIA </color> com Militância e aumentou sua Autoridade para " + autoridadePlayer);

                }

            }

            qteMilitancia = qteMilitancia - 1;
            AtualizaQuantidadeAtaques();

        }


        DesabilitaBotoes();

        playerAtacou = true;
    }

    public void SelecionaMilitancia()
    {
        infoAtaque.text = "Aumenta sua Autoridade (ataque)";
        qte_Ataque.text = "Qte.: " + qteMilitancia + "/3";
        dialogo.text = "Utilizar o ataque Militancia?";
        aut_Ataque.text = "Autoridade: 30 - 40";

    }

    // DENUNCIA SUPREMO - tira autoridade
    public void AtaqueDenuciaSupremo()
    {
        ataquePlayer = true;
        defesaPlayer = false;
        mudaStatusPlayer = false;

        Protegido();

        MitouLacrou();
        CalculoConfiancaPlayer();
        autoridadeAtaque = Random.Range(30, 41);

        if (autoridadeInimigo <= 5)
        {
            ataqueDenunciaSupremo.interactable = false;
            dialogo.text = "O oponente já está com o mínimo de Autoridade";

        }

        if (qteDenunciaSupremo <= 0)
        {
            ataqueDenunciaSupremo.interactable = false;
        }
        if (qteDenunciaSupremo > 0)
        {

            ataqueDenunciaSupremo.interactable = true;


            danoPlayer = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelPlayer / 5 + 2) * autoridadePlayer * autoridadeAtaque / autoridadeInimigo) / 50) + 2) * mitouLacrou) * confianca;

            autoridadeInimigo = autoridadeInimigo - danoPlayer;


            if (confianca == 0)
            {
                SomFalhouAtaque.Play();

                dialogo.text = "Seu político errou o ataque porque não foi confiante";

            }
            if (confianca != 0)
            {
                SomTiraStatus.Play();

                if (chanceMitarLacrar != 2)
                {
                    dialogo.text = "Você usou <color=#FFED00FF> DENÚNCIA AO SUPREMO </color>, diminuindo a autoridade para " + autoridadeInimigo;

                }

                if (direita == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Muito opressor! Você <color=#FFED00FF> MITOU com DENÚNCIA AO SUPREMO </color> e tirou " + autoridadeInimigo + "  de autoridade do seu oponente");

                }
                if (esquerda == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Que tiro foi esse?! Você <color=#FFED00FF> LACROU com DENÚNCIA AO SUPREMO </color> e tirou " + autoridadeInimigo + "  de autoridadedo seu oponente");

                }
            }

            qteDenunciaSupremo = qteDenunciaSupremo - 1;
            AtualizaQuantidadeAtaques();

        }


        DesabilitaBotoes();

        playerAtacou = true;
    }

    public void SelecionaDenunciaSupremo()
    {
        infoAtaque.text = "Diminuí Autoridade (ataque) de seu oponente.";
        qte_Ataque.text = "Qte.: " + qteDenunciaSupremo + "/3";
        dialogo.text = "Utilizar o ataque Denuncia ao Supremo?";
        aut_Ataque.text = "Autoridade: 30 - 40";

    }


    //  ELOGIO JORNAL - aumenta popularidade
    public void AtaqueElogioJornal()
    {
        ataquePlayer = false;
        defesaPlayer = false;
        mudaStatusPlayer = true;
        CalculoConfiancaPlayer();

        autoridadeAtaque = Random.Range(40, 51);

        if (qteElogioJornal <= 0)
        {
            ataqueElogioJornal.interactable = false;
        }
        if (qteElogioJornal > 0)
        {
            danoPlayer = (autoridadeAtaque / 2) * confianca;
            popularidadePlayer = popularidadePlayer + danoPlayer;
            qteElogioJornal = qteElogioJornal - 1;
            AtualizaQuantidadeAtaques();

            ataqueElogioJornal.interactable = true;

            if (confianca == 0)
            {
                SomFalhouAtaque.Play();

                dialogo.text = "Seu político errou o ataque porque não foi confiante";

            }
            if (confianca != 0)
            {
                StartCoroutine(AumentouPopPlayer());

                SomEspecial.Play();

                dialogo.text = "Você foi <color=#FFED00FF> ELOGIADO NO JORNAL </color>. Agora, sua popularidade aumentou para " + popularidadePlayer;

            }

        }



        DesabilitaBotoes();

        playerAtacou = true;
    }

    public void SelecionaElogioJornal()
    {
        infoAtaque.text = "Aumenta sua Popularidade";
        qte_Ataque.text = "Qte.: " + qteElogioJornal + "/1";
        dialogo.text = "Utilizar o ataque Elogio do Jornal?";
        aut_Ataque.text = "Autoridade: 40 - 50";

    }

    // FORO PRIVILEGIADO - defesa 100% de um ataque
    public void AtaqueForoPrivilegiado()
    {
        ataquePlayer = false;
        defesaPlayer = true;
        mudaStatusPlayer = false;

        if (qteForoPrivilegiado <= 0)
        {
            ataqueForoPrivilegiado.interactable = false;
        }
        if (qteForoPrivilegiado > 0)
        {
            SomEspecial.Play();

            ataqueForoPrivilegiado.interactable = true;


            playerProtegido = true;
            dialogo.text = "Você utilizou seu <color=#FFED00FF> FORO PRIVILEGIADO </color> e está 100% protegido de um ataque ";
            qteForoPrivilegiado = qteForoPrivilegiado - 1;
            AtualizaQuantidadeAtaques();



        }



        DesabilitaBotoes();

        playerAtacou = true;
    }

    public void SelecionaForoPrivilegiado()
    {
        infoAtaque.text = "Protege 100% de um ataque";
        qte_Ataque.text = "Qte.: " + qteForoPrivilegiado + "/2";
        dialogo.text = "Utilizar o ataque Foro Privilegiado?";
        aut_Ataque.text = "Autoridade: 100";

    }

    // VAZAR LIGACOES - tira apoio da mídia do oponente

    public void AtaqueVazarLigacoes()
    {
        ataquePlayer = true;
        defesaPlayer = false;
        mudaStatusPlayer = false;

        MitouLacrou();
        Protegido();
        CalculoConfiancaPlayer();
        autoridadeAtaque = Random.Range(30, 41);

        if (qteVazarLigacoes <= 0)
        {
            ataqueVazarLigacoes.interactable = false;
        }
        if (qteVazarLigacoes > 0)
        {

            ataqueVazarLigacoes.interactable = true;

            danoPlayer = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelPlayer / 5 + 2) * apoioMidiaPlayer * autoridadeAtaque / apoioMidiaInimigo) / 50) + 2) * mitouLacrou) * confianca;
            if (apoioMidiaInimigo > danoPlayer)
            {
                apoioMidiaInimigo = apoioMidiaInimigo - danoPlayer;

                if (confianca == 0)
                {
                    SomFalhouAtaque.Play();

                    dialogo.text = "Seu político errou o ataque porque não foi confiante";

                }
                if (confianca != 0)
                {
                    StartCoroutine(PerdeuApoioMidiaInimigo());
                    SomTiraStatus.Play();

                    if (chanceMitarLacrar != 2)
                    {
                        dialogo.text = "Você <color=#FFED00FF> VAZOU LIGAÇÕES </color> comprometedoras de seu oponente e tirou " + danoPlayer + " de Apoio da Mídia";

                    }

                    if (direita == true && chanceMitarLacrar == 2)
                    {
                        dialogo.text = ("Muito opressor! Você <color=#FFED00FF> MITOU com VAZAR LIGAÇÕES </color> e tirou " + danoPlayer + " de Apoio da Mídia");

                    }
                    if (esquerda == true && chanceMitarLacrar == 2)
                    {
                        dialogo.text = ("Que tiro foi esse?! Você <color=#FFED00FF> LACROU com VAZAR LIGAÇÕES </color> e tirou " + danoPlayer + " de Apoio da Mídia");

                    }
                }

                qteVazarLigacoes = qteVazarLigacoes - 1;
                AtualizaQuantidadeAtaques();

            }
            if (apoioMidiaInimigo < danoPlayer)
            {
                apoioMidiaInimigo = 1;
                if (confianca == 0)
                {
                    dialogo.text = "Seu político errou o ataque porque não foi confiante";

                }
                if (confianca != 0)
                {
                    SomTiraStatus.Play();

                    StartCoroutine(PerdeuApoioMidiaInimigo());

                    dialogo.text = "Você <color=#FFED00FF> VAZOU  LIGAÇÕES </color> comprometedoras de seu oponente e tirou " + danoPlayer + " de Apoio da Mídia";

                }

                qteVazarLigacoes = qteVazarLigacoes - 1;
                AtualizaQuantidadeAtaques();

            }
            if (apoioMidiaInimigo <= 1 && qteVazarLigacoes > 0)
            {
                ataqueVazarLigacoes.interactable = false;
                dialogo.text = "O oponente já está com o mínimo de Apoio da Mídia";

            }





        }



        DesabilitaBotoes();

        playerAtacou = true;
    }

    public void SelecionaVazarLigacoes()
    {
        infoAtaque.text = "Diminuí Apoio da Mídia (defesa) do oponente.";
        qte_Ataque.text = "Qte.: " + qteVazarLigacoes + "/3";
        dialogo.text = "Utilizar o ataque Vazar Ligações?";
        aut_Ataque.text = "Autoridade: 30 - 40";

    }

    // AD HOMINEM - tira confiança (precisão) do oponente
    public void AtaqueAdHominem()
    {

        ataquePlayer = true;
        defesaPlayer = false;
        mudaStatusPlayer = false;

        MitouLacrou();
        Protegido();
        CalculoConfiancaPlayer();
        autoridadeAtaque = Random.Range(10, 16);

        if (qteAdHominem <= 0)
        {
            ataqueAdHominem.interactable = false;
        }
        if (qteAdHominem > 0)
        {

            ataqueAdHominem.interactable = true;

            danoPlayer = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelPlayer / 5 + 2) * confiancaPlayer * autoridadeAtaque / confiancaInimigo) / 100) + 2) * mitouLacrou) * confianca;
            if (confiancaInimigo > danoPlayer)
            {
                confiancaInimigo = (int)(confiancaInimigo - danoPlayer);

                if (confianca == 0)
                {
                    SomFalhouAtaque.Play();

                    dialogo.text = "Seu político errou o ataque porque não foi confiante";

                }
                if (confianca != 0)
                    
                    SomTiraStatus.Play();
                
                {
                    if (chanceMitarLacrar != 2)
                    {
                        dialogo.text = "Você utilizou argumentos <color=#FFED00FF> AD HOMINEM </color> e tirou " + danoPlayer + " de Confiança do seu oponente";

                    }

                    if (direita == true && chanceMitarLacrar == 2)
                    {
                        dialogo.text = ("Muito opressor! Você <color=#FFED00FF> MITOU com AD HOMINEM </color>e tirou " + danoPlayer + " de Confiança do seu oponente");

                    }
                    if (esquerda == true && chanceMitarLacrar == 2)
                    {
                        dialogo.text = ("Que tiro foi esse?! Você <color=#FFED00FF> LACROU com AD HOMINEM </color> e tirou " + danoPlayer + "de Confiança do seu oponente");

                    }

                }

                qteAdHominem = qteAdHominem - 1;
                AtualizaQuantidadeAtaques();

            }
            if (confiancaInimigo < danoPlayer)
            {
                confiancaInimigo = 1;
                if (confianca == 0)
                {
                    dialogo.text = "Seu político errou o ataque porque não foi confiante";

                }
                if (confianca != 0)
                {
                    SomTiraStatus.Play();

                    dialogo.text = "Você utilizou argumentos <color=#FFED00FF> AD HOMINEM </color> e tirou " + danoPlayer + " de Confiança do seu oponente";

                }
                qteAdHominem = qteAdHominem - 1;
                AtualizaQuantidadeAtaques();

            }
            if (confiancaInimigo <= 1 && qteAdHominem > 0)
            {
                ataqueAdHominem.interactable = false;
                dialogo.text = "O oponente já está com o mínimo de Confiança";

            }





        }



        DesabilitaBotoes();

        playerAtacou = true;
    }

    public void SelecionaAdHominem()
    {
        infoAtaque.text = "Diminuí a confiança (precisão) do oponente.";
        qte_Ataque.text = "Qte.: " + qteAdHominem + "/3";
        dialogo.text = "Utilizar o ataque Ad Hominem?";
        aut_Ataque.text = "Autoridade: 10 - 15";

    }

    // APOIO CENTRAO - aumenta confiança do player
    public void AtaqueApoioCentrao()
    {
        ataquePlayer = false;
        defesaPlayer = false;
        mudaStatusPlayer = true;

        MitouLacrou();
        Protegido();
        CalculoConfiancaPlayer();
        autoridadeAtaque = Random.Range(30, 41);

        if (qteApoioCentrao <= 0)
        {
            ataqueApoioCentrao.interactable = false;
        }
        if (qteApoioCentrao > 0)
        {

            ataqueApoioCentrao.interactable = true;

            danoPlayer = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelPlayer / 5 + 2) * confiancaPlayer * autoridadeAtaque / confiancaPlayer) / 50) + 2) * mitouLacrou) * confianca;


            confiancaPlayer = (int)(confiancaPlayer + danoPlayer);

            if (confianca == 0)
            {
                SomFalhouAtaque.Play();

                dialogo.text = "Seu político errou o ataque porque não foi confiante";

            }
            if (confianca != 0)
            {
                SomAumentaStatus.Play();

                if (chanceMitarLacrar != 2)
                {
                    dialogo.text = "Você conquistou <color=#FFED00FF> APOIO DO CENTRÃO </color> e aumentou " + danoPlayer + " de sua Confiança.";

                }

                if (direita == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Muito opressor! Você <color=#FFED00FF> MITOU com APOIO DO CENTRÃO </color> e aumentou " + danoPlayer + " de sua Retórica.");

                }
                if (esquerda == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Que tiro foi esse?! Você <color=#FFED00FF> LACROU com APOIO DO CENTRÃO </color> e aumentou " + danoPlayer + " de sua Retórica.");

                }
            }
            qteApoioCentrao = qteApoioCentrao - 1;
            AtualizaQuantidadeAtaques();


        }



        DesabilitaBotoes();

        playerAtacou = true;
    }

    public void SelecionaApoioCentrao()
    {
        infoAtaque.text = "Aumenta sua confiaça (precisão).";
        qte_Ataque.text = "Qte.: " + qteApoioCentrao + "/3";
        dialogo.text = "Utilizar o ataque Apoio Centrão?";
        aut_Ataque.text = "Autoridade: 30 - 40";

    }

    // --------------- ATAQUES ESPECIAIS ------------------ //


    // DELAÇÃO PREMIADA - aumenta autoridade e tira popularidade do oponente

    public void AtaqueDelacaoPremiada()
    {
        MitouLacrou();
        Protegido();
        CalculoConfiancaPlayer();

        autoridadeAtaque = Random.Range(40, 51);
        danoPlayer = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelPlayer / 5 + 2) * autoridadePlayer * autoridadeAtaque / apoioMidiaInimigo) / 50) + 2) * mitouLacrou) * confianca;



        if (qteDelacaoPremiada <= 0)
        {
            ataqueDelacaoPremiada.interactable = false;
        }
        if (qteDelacaoPremiada > 0)
        {
            ataqueDelacaoPremiada.interactable = true;

        }


        if (popularidadeInimigo >= danoPlayer && qteDelacaoPremiada > 0)
        {

            popularidadeInimigo = popularidadeInimigo - danoPlayer;
            autoridadePlayer = autoridadePlayer + (danoPlayer / 2);
            qteDelacaoPremiada = qteDelacaoPremiada - 1;

            AtualizaQuantidadeAtaques();

            if (confianca == 0)
            {
                SomFalhouAtaque.Play();

                dialogo.text = "Seu político errou o ataque porque não foi confiante";

            }
            if (confianca != 0)
            {
                SomEspecial.Play();

                dialogo.text = "Você usou <color=#FFED00FF> DELAÇÃO PREMIADA </color>, tirou " + danoPlayer + " de popularidade do oponente e aumentou sua autoridade (ataque) para " + danoPlayer;


            }


        }

        if (popularidadeInimigo < danoPlayer && playerAtacou == false && qteFraudarUrnas > 0)
        {

            qteFraudarUrnas = qteFraudarUrnas - 1;
            AtualizaQuantidadeAtaques();

            autoridadePlayer = autoridadePlayer + (danoPlayer / 2);

            danoPlayer = popularidadeInimigo * confianca;
            popularidadeInimigo = (popularidadeInimigo - danoPlayer) * confianca;

            if (confianca == 0)
            {
                SomFalhouAtaque.Play();

                dialogo.text = "Seu político errou o ataque porque não foi confiante";
            }
            if (confianca != 0)
            {
                SomEspecial.Play();

                dialogo.text = "Você usou <color=#FFED00FF> DELAÇÃO PREMIADA </color>, tirou " + danoPlayer + " de popularidade do oponente e aumentou sua autoridade (ataque) para " + danoPlayer;

            }


        }


        PlayerPrefs.SetFloat("PopInimigos", popularidadeInimigo);
        popularidadeInimigo = PlayerPrefs.GetFloat("PopInimigos"); //

        popInimigo_txtUI.text = popularidadeInimigo.ToString();
        barraPopInimigo.value = popularidadeInimigo;

        pop_txtUI.text = Mathf.Round(popularidadePlayer).ToString();
        barraPop.value = popularidadePlayer;


        DesabilitaBotoes();


        playerAtacou = true;

    } // FIM ATAQUE DELAÇÃO PREMIADA

    public void SelecionaDelacaoPremiada()
    {
        QuantidadeAtaques();

        infoAtaque.text = "Diminui popularidade do oponente e aumenta sua autoridade (ataque)";
        qte_Ataque.text = "Qte.: " + qteDelacaoPremiada + "/3";
        dialogo.text = "Utilizar o ataque Delação Premiada?";
        aut_Ataque.text = "Autoridade: 40 - 50";

    }

    // -------------------- QTE ATAQUES ------------------------- //

    public void QuantidadeAtaques()
    {
        if (PlayerPrefs.GetInt("LulaDentroScene") == 1)
        {
            qteFraudarUrnas = qteFraudarUrnasLula;
            qteHabeasCorpus = qteHabeasLula;
            qteMilitancia = qteMilitanciaLula;
            qteElogioJornal = qteElogioLula;
            qteDenunciaSupremo = qteDenunciaSupremoLula;
            qteForoPrivilegiado = qteForoLula;
            qteVazarLigacoes = qteVazarLula;
            qteAdHominem = qteAdHominemLula;
            qteApoioCentrao = qteApoioCentraoLula;
            qteDelacaoPremiada = qteDelacaoLula;
            qteFakeNews = qteFakeNewsLula;
            qtePerguntaPolemica = qtePerguntaPolemicaLula;
            qteCiclovia = qteCicloviaLula;
            qteChamarGilmar = qteChamarGilmarLula;
            qteSemCustoContribuinte = qteSemCustoContribuinteLula;
            qteMeuPostoIpiranga = qteMeuPostoIpirangaLula;
        }

        if (PlayerPrefs.GetInt("CiroDentroScene") == 1)
        {
            qteFraudarUrnas = qteFraudarUrnasCiro;
            qteHabeasCorpus = qteHabeasCiro;
            qteMilitancia = qteMilitanciaCiro;
            qteElogioJornal = qteElogioCiro;
            qteDenunciaSupremo = qteDenunciaSupremoCiro;
            qteForoPrivilegiado = qteForoCiro;
            qteVazarLigacoes = qteVazarCiro;
            qteAdHominem = qteAdHominemCiro;
            qteApoioCentrao = qteApoioCentraoCiro;
            qteDelacaoPremiada = qteDelacaoCiro;
            qteFakeNews = qteFakeNewsCiro;
            qtePerguntaPolemica = qtePerguntaPolemicaCiro;
            qteCiclovia = qteCicloviaCiro;
            qteChamarGilmar = qteChamarGilmarCiro;
            qteSemCustoContribuinte = qteSemCustoContribuinteCiro;
            qteMeuPostoIpiranga = qteMeuPostoIpirangaCiro;
        }

        if (PlayerPrefs.GetInt("BolsoDentroScene") == 1)
        {
            qteFraudarUrnas = qteFraudarUrnasBolso;
            qteHabeasCorpus = qteHabeasBolso;
            qteMilitancia = qteMilitanciaBolso;
            qteElogioJornal = qteElogioBolso;
            qteDenunciaSupremo = qteDenunciaSupremoBolso;
            qteForoPrivilegiado = qteForoBolso;
            qteVazarLigacoes = qteVazarBolso;
            qteAdHominem = qteAdHominemBolso;
            qteApoioCentrao = qteApoioCentraoBolso;
            qteDelacaoPremiada = qteDelacaoBolso;
            qteFakeNews = qteFakeNewsBolso;
            qtePerguntaPolemica = qtePerguntaPolemicaBolso;
            qteCiclovia = qteCicloviaBolso;
            qteChamarGilmar = qteChamarGilmarBolso;
            qteSemCustoContribuinte = qteSemCustoContribuinteBolso;
            qteMeuPostoIpiranga = qteMeuPostoIpirangaBolso;
        }

        if (PlayerPrefs.GetInt("DilmaDentroScene") == 1)
        {
            qteFraudarUrnas = qteFraudarUrnasDilma;
            qteHabeasCorpus = qteHabeasDilma;
            qteMilitancia = qteMilitanciaDilma;
            qteElogioJornal = qteElogioDilma;
            qteDenunciaSupremo = qteDenunciaSupremoDilma;
            qteForoPrivilegiado = qteForoDilma;
            qteVazarLigacoes = qteVazarDilma;
            qteAdHominem = qteAdHominemDilma;
            qteApoioCentrao = qteApoioCentraoDilma;
            qteDelacaoPremiada = qteDelacaoDilma;
            qteFakeNews = qteFakeNewsDilma;
            qtePerguntaPolemica = qtePerguntaPolemicaDilma;
            qteCiclovia = qteCicloviaDilma;
            qteChamarGilmar = qteChamarGilmarDilma;
            qteSemCustoContribuinte = qteSemCustoContribuinteDilma;
            qteMeuPostoIpiranga = qteMeuPostoIpirangaDilma;
        }

        if (PlayerPrefs.GetInt("SuplicyDentroScene") == 1)
        {
            qteFraudarUrnas = qteFraudarUrnasSuplicy;
            qteHabeasCorpus = qteHabeasSuplicy;
            qteMilitancia = qteMilitanciaSuplicy;
            qteElogioJornal = qteElogioSuplicy;
            qteDenunciaSupremo = qteDenunciaSupremoSuplicy;
            qteForoPrivilegiado = qteForoSuplicy;
            qteVazarLigacoes = qteVazarSuplicy;
            qteAdHominem = qteAdHominemSuplicy;
            qteApoioCentrao = qteApoioCentraoSuplicy;
            qteDelacaoPremiada = qteDelacaoSuplicy;
            qteFakeNews = qteFakeNewsSuplicy;
            qtePerguntaPolemica = qtePerguntaPolemicaSuplicy;
            qteCiclovia = qteCicloviaSuplicy;
            qteChamarGilmar = qteChamarGilmarSuplicy;
            qteSemCustoContribuinte = qteSemCustoContribuinteSuplicy;
            qteMeuPostoIpiranga = qteMeuPostoIpirangaSuplicy;
        }


        if (PlayerPrefs.GetInt("EneasDentroScene") == 1)
        {
            qteFraudarUrnas = qteFraudarUrnasEneas;
            qteHabeasCorpus = qteHabeasEneas;
            qteMilitancia = qteMilitanciaEneas;
            qteElogioJornal = qteElogioEneas;
            qteDenunciaSupremo = qteDenunciaSupremoEneas;
            qteForoPrivilegiado = qteForoEneas;
            qteVazarLigacoes = qteVazarEneas;
            qteAdHominem = qteAdHominemEneas;
            qteApoioCentrao = qteApoioCentraoEneas;
            qteDelacaoPremiada = qteDelacaoEneas;
            qteFakeNews = qteFakeNewsEneas;
            qtePerguntaPolemica = qtePerguntaPolemicaEneas;
            qteCiclovia = qteCicloviaEneas;
            qteChamarGilmar = qteChamarGilmarEneas;
            qteSemCustoContribuinte = qteSemCustoContribuinteEneas;
            qteMeuPostoIpiranga = qteMeuPostoIpirangaEneas;
        }

        if (PlayerPrefs.GetInt("DodorioDentroScene") == 1)
        {
            qteFraudarUrnas = qteFraudarUrnasDodorio;
            qteHabeasCorpus = qteHabeasDodorio;
            qteMilitancia = qteMilitanciaDodorio;
            qteElogioJornal = qteElogioDodorio;
            qteDenunciaSupremo = qteDenunciaSupremoDodorio;
            qteForoPrivilegiado = qteForoDodorio;
            qteVazarLigacoes = qteVazarDodorio;
            qteAdHominem = qteAdHominemDodorio;
            qteApoioCentrao = qteApoioCentraoDodorio;
            qteDelacaoPremiada = qteDelacaoDodorio;
            qteFakeNews = qteFakeNewsDodorio;
            qtePerguntaPolemica = qtePerguntaPolemicaDodorio;
            qteCiclovia = qteCicloviaDodorio;
            qteChamarGilmar = qteChamarGilmarDodorio;
            qteSemCustoContribuinte = qteSemCustoContribuinteDodorio;
            qteMeuPostoIpiranga = qteMeuPostoIpirangaDodorio;
        }

        if (PlayerPrefs.GetInt("HaddardDentroScene") == 1)
        {
            qteFraudarUrnas = qteFraudarUrnasHaddard;
            qteHabeasCorpus = qteHabeasHaddard;
            qteMilitancia = qteMilitanciaHaddard;
            qteElogioJornal = qteElogioHaddard;
            qteDenunciaSupremo = qteDenunciaSupremoHaddard;
            qteForoPrivilegiado = qteForoHaddard;
            qteVazarLigacoes = qteVazarHaddard;
            qteAdHominem = qteAdHominemHaddard;
            qteApoioCentrao = qteApoioCentraoHaddard;
            qteDelacaoPremiada = qteDelacaoHaddard;
            qteFakeNews = qteFakeNewsHaddard;
            qtePerguntaPolemica = qtePerguntaPolemicaHaddard;
            qteCiclovia = qteCicloviaHaddard;
            qteChamarGilmar = qteChamarGilmarHaddard;
            qteSemCustoContribuinte = qteSemCustoContribuinteHaddard;
            qteMeuPostoIpiranga = qteMeuPostoIpirangaHaddard;
        }

        if (PlayerPrefs.GetInt("CunhaDentroScene") == 1)
        {
            qteFraudarUrnas = qteFraudarUrnasCunha;
            qteHabeasCorpus = qteHabeasCunha;
            qteMilitancia = qteMilitanciaCunha;
            qteElogioJornal = qteElogioCunha;
            qteDenunciaSupremo = qteDenunciaSupremoCunha;
            qteForoPrivilegiado = qteForoCunha;
            qteVazarLigacoes = qteVazarCunha;
            qteAdHominem = qteAdHominemCunha;
            qteApoioCentrao = qteApoioCentraoCunha;
            qteDelacaoPremiada = qteDelacaoCunha;
            qteFakeNews = qteFakeNewsCunha;
            qtePerguntaPolemica = qtePerguntaPolemicaCunha;
            qteCiclovia = qteCicloviaCunha;
            qteChamarGilmar = qteChamarGilmarCunha;
            qteSemCustoContribuinte = qteSemCustoContribuinteCunha;
            qteMeuPostoIpiranga = qteMeuPostoIpirangaCunha;
        }

        VerificaQteAtaques();

    } // FIM QUANTIDADE ATAQUES

    public void AtualizaQuantidadeAtaques()
    {
        if (PlayerPrefs.GetInt("LulaDentroScene") == 1)
        {
            qteFraudarUrnasLula = qteFraudarUrnas;
            qteHabeasLula = qteHabeasCorpus;
            qteMilitanciaLula = qteMilitancia;
            qteElogioLula = qteElogioJornal;
            qteDenunciaSupremoLula = qteDenunciaSupremo;
            qteForoLula = qteForoPrivilegiado;
            qteVazarLula = qteVazarLigacoes;
            qteAdHominemLula = qteAdHominem;
            qteApoioCentraoLula = qteApoioCentrao;
            qteDelacaoLula = qteDelacaoPremiada;
            qteFakeNewsLula = qteFakeNews;
            qtePerguntaPolemicaLula = qtePerguntaPolemica;
            qteChamarGilmarLula = qteChamarGilmar;
            qteMeuPostoIpirangaLula = qteMeuPostoIpiranga;
            qteSemCustoContribuinteLula = qteSemCustoContribuinte;
            qteCicloviaLula = qteCiclovia;
        }

        if (PlayerPrefs.GetInt("CiroDentroScene") == 1)
        {
            qteFraudarUrnasCiro = qteFraudarUrnas;
            qteHabeasCiro = qteHabeasCorpus;
            qteMilitanciaCiro = qteMilitancia;
            qteElogioCiro = qteElogioJornal;
            qteDenunciaSupremoCiro = qteDenunciaSupremo;
            qteForoCiro = qteForoPrivilegiado;
            qteVazarCiro = qteVazarLigacoes;
            qteAdHominemCiro = qteAdHominem;
            qteApoioCentraoCiro = qteApoioCentrao;
            qteDelacaoCiro = qteDelacaoPremiada;
            qteFakeNewsCiro = qteFakeNews;
            qtePerguntaPolemicaCiro = qtePerguntaPolemica;
            qteChamarGilmarCiro= qteChamarGilmar;
            qteMeuPostoIpirangaCiro = qteMeuPostoIpiranga;
            qteSemCustoContribuinteCiro = qteSemCustoContribuinte;
            qteCicloviaCiro = qteCiclovia;

        }

        if (PlayerPrefs.GetInt("BolsoDentroScene") == 1)
        {
            qteFraudarUrnasBolso = qteFraudarUrnas;
            qteHabeasBolso = qteHabeasCorpus;
            qteMilitanciaBolso = qteMilitancia;
            qteElogioBolso = qteElogioJornal;
            qteDenunciaSupremoBolso = qteDenunciaSupremo;
            qteForoBolso = qteForoPrivilegiado;
            qteVazarBolso = qteVazarLigacoes;
            qteAdHominemBolso = qteAdHominem;
            qteApoioCentraoBolso = qteApoioCentrao;
            qteDelacaoBolso = qteDelacaoPremiada;
            qteFakeNewsBolso = qteFakeNews;
            qtePerguntaPolemicaBolso = qtePerguntaPolemica;
            qteChamarGilmarBolso = qteChamarGilmar;
            qteMeuPostoIpirangaBolso = qteMeuPostoIpiranga;
            qteSemCustoContribuinteBolso = qteSemCustoContribuinte;
            qteCicloviaBolso = qteCiclovia;
        }

        if (PlayerPrefs.GetInt("DilmaDentroScene") == 1)
        {
            qteFraudarUrnasDilma = qteFraudarUrnas;
            qteHabeasDilma = qteHabeasCorpus;
            qteMilitanciaDilma = qteMilitancia;
            qteElogioDilma = qteElogioJornal;
            qteDenunciaSupremoDilma = qteDenunciaSupremo;
            qteForoDilma = qteForoPrivilegiado;
            qteVazarDilma = qteVazarLigacoes;
            qteAdHominemDilma = qteAdHominem;
            qteApoioCentraoDilma = qteApoioCentrao;
            qteDelacaoDilma = qteDelacaoPremiada;
            qteFakeNewsDilma = qteFakeNews;
            qtePerguntaPolemicaDilma = qtePerguntaPolemica;
            qteChamarGilmarDilma = qteChamarGilmar;
            qteMeuPostoIpirangaDilma = qteMeuPostoIpiranga;
            qteSemCustoContribuinteDilma = qteSemCustoContribuinte;
            qteCicloviaDilma = qteCiclovia;
        }

        if (PlayerPrefs.GetInt("SuplicyDentroScene") == 1)
        {
            qteFraudarUrnasSuplicy = qteFraudarUrnas;
            qteHabeasSuplicy = qteHabeasCorpus;
            qteMilitanciaSuplicy = qteMilitancia;
            qteElogioSuplicy = qteElogioJornal;
            qteDenunciaSupremoSuplicy = qteDenunciaSupremo;
            qteForoSuplicy = qteForoPrivilegiado;
            qteVazarSuplicy = qteVazarLigacoes;
            qteAdHominemSuplicy = qteAdHominem;
            qteApoioCentraoSuplicy = qteApoioCentrao;
            qteDelacaoSuplicy = qteDelacaoPremiada;
            qteFakeNewsSuplicy = qteFakeNews;
            qtePerguntaPolemicaSuplicy = qtePerguntaPolemica;
            qteChamarGilmarSuplicy = qteChamarGilmar;
            qteMeuPostoIpirangaSuplicy = qteMeuPostoIpiranga;
            qteSemCustoContribuinteSuplicy = qteSemCustoContribuinte;
            qteCicloviaSuplicy = qteCiclovia;
        }

        if (PlayerPrefs.GetInt("EneasDentroScene") == 1)
        {
            qteFraudarUrnasEneas = qteFraudarUrnas;
            qteHabeasEneas = qteHabeasCorpus;
            qteMilitanciaEneas = qteMilitancia;
            qteElogioEneas = qteElogioJornal;
            qteDenunciaSupremoEneas = qteDenunciaSupremo;
            qteForoEneas = qteForoPrivilegiado;
            qteVazarEneas = qteVazarLigacoes;
            qteAdHominemEneas = qteAdHominem;
            qteApoioCentraoEneas = qteApoioCentrao;
            qteDelacaoEneas = qteDelacaoPremiada;
            qteFakeNewsEneas = qteFakeNews;
            qtePerguntaPolemicaEneas = qtePerguntaPolemica;
            qteChamarGilmarEneas = qteChamarGilmar;
            qteMeuPostoIpirangaEneas = qteMeuPostoIpiranga;
            qteSemCustoContribuinteEneas = qteSemCustoContribuinte;
            qteCicloviaEneas= qteCiclovia;
        }

        if (PlayerPrefs.GetInt("DodorioDentroScene") == 1)
        {
            qteFraudarUrnasDodorio = qteFraudarUrnas;
            qteHabeasDodorio = qteHabeasCorpus;
            qteMilitanciaDodorio = qteMilitancia;
            qteElogioDodorio = qteElogioJornal;
            qteDenunciaSupremoDodorio = qteDenunciaSupremo;
            qteForoDodorio = qteForoPrivilegiado;
            qteVazarDodorio = qteVazarLigacoes;
            qteAdHominemDodorio = qteAdHominem;
            qteApoioCentraoDodorio = qteApoioCentrao;
            qteDelacaoDodorio = qteDelacaoPremiada;
            qteFakeNewsDodorio = qteFakeNews;
            qtePerguntaPolemicaDodorio = qtePerguntaPolemica;
            qteChamarGilmarDodorio = qteChamarGilmar;
            qteMeuPostoIpirangaDodorio = qteMeuPostoIpiranga;
            qteSemCustoContribuinteDodorio = qteSemCustoContribuinte;
            qteCicloviaDodorio = qteCiclovia;
        }

        if (PlayerPrefs.GetInt("HaddardDentroScene") == 1)
        {
            qteFraudarUrnasHaddard = qteFraudarUrnas;
            qteHabeasHaddard = qteHabeasCorpus;
            qteMilitanciaHaddard = qteMilitancia;
            qteElogioHaddard = qteElogioJornal;
            qteDenunciaSupremoHaddard = qteDenunciaSupremo;
            qteForoHaddard = qteForoPrivilegiado;
            qteVazarHaddard = qteVazarLigacoes;
            qteAdHominemHaddard = qteAdHominem;
            qteApoioCentraoHaddard = qteApoioCentrao;
            qteDelacaoHaddard = qteDelacaoPremiada;
            qteFakeNewsHaddard = qteFakeNews;
            qtePerguntaPolemicaHaddard = qtePerguntaPolemica;
            qteChamarGilmarHaddard = qteChamarGilmar;
            qteMeuPostoIpirangaHaddard = qteMeuPostoIpiranga;
            qteSemCustoContribuinteHaddard = qteSemCustoContribuinte;
            qteCicloviaHaddard = qteCiclovia;
        }
   
        if (PlayerPrefs.GetInt("CunhaDentroScene") == 1)
        {
            qteFraudarUrnasCunha = qteFraudarUrnas;
            qteHabeasCunha = qteHabeasCorpus;
            qteMilitanciaCunha = qteMilitancia;
            qteElogioCunha = qteElogioJornal;
            qteDenunciaSupremoCunha = qteDenunciaSupremo;
            qteForoCunha = qteForoPrivilegiado;
            qteVazarCunha = qteVazarLigacoes;
            qteAdHominemCunha = qteAdHominem;
            qteApoioCentraoCunha = qteApoioCentrao;
            qteDelacaoCunha = qteDelacaoPremiada;
            qteFakeNewsCunha = qteFakeNews;
            qtePerguntaPolemicaCunha = qtePerguntaPolemica;
            qteChamarGilmarCunha = qteChamarGilmar;
            qteMeuPostoIpirangaCunha = qteMeuPostoIpiranga;
            qteSemCustoContribuinteCunha = qteSemCustoContribuinte;
            qteCicloviaCunha = qteCiclovia;
        }
    }

    // RESETA ATAQUES QUANDO ALUGAR

    public void ResetaFraudarUrnas()
    {
        qteFraudarUrnasLula = 5;
        qteFraudarUrnasCiro = 5;
        qteFraudarUrnasBolso = 5;
        qteFraudarUrnasDilma = 5;
        qteFraudarUrnasSuplicy = 5;
        qteFraudarUrnasEneas = 5;
        qteFraudarUrnasDodorio = 5;
        qteFraudarUrnasHaddard = 5;
        qteFraudarUrnasCunha = 5;
    }

    public void ResetaHabeasCorpus()
    {
        qteHabeasLula = 3;
        qteHabeasCiro = 3;
        qteHabeasBolso = 3;
        qteHabeasDilma = 3;
        qteHabeasSuplicy = 3;
        qteHabeasEneas = 3;
        qteHabeasDodorio = 3;
        qteHabeasHaddard = 3;
        qteHabeasCunha = 3;
    }

    public void ResetaMilitancia()
    {
        qteMilitanciaLula = 3;
        qteMilitanciaCiro = 3;
        qteMilitanciaBolso = 3;
        qteMilitanciaDilma = 3;
        qteMilitanciaSuplicy = 3;
        qteMilitanciaEneas = 3;
        qteMilitanciaDodorio = 3;
        qteMilitanciaHaddard = 3;
        qteMilitanciaCunha = 3;
    }
   
    public void ResetaElogio()
    {
        qteElogioLula = 1;
        qteElogioCiro = 1;
        qteElogioBolso = 1;
        qteElogioDilma = 1;
        qteElogioSuplicy = 1;
        qteElogioEneas = 1;
        qteElogioDodorio = 1;
        qteElogioHaddard = 1;
        qteElogioCunha = 1;
    }
   
    public void ResetaDenunciaSupremo()
    {
        qteDenunciaSupremoLula = 3;
        qteDenunciaSupremoCiro = 3;
        qteDenunciaSupremoBolso = 3;
        qteDenunciaSupremoDilma = 3;
        qteDenunciaSupremoSuplicy = 3;
        qteDenunciaSupremoEneas = 3;
        qteDenunciaSupremoDodorio = 3;
        qteDenunciaSupremoHaddard = 3;
        qteDenunciaSupremoCunha = 3;
    }

    public void ResetaForo()
    {
        qteForoLula = 2;
        qteForoCiro = 2;
        qteForoBolso = 2;
        qteForoDilma = 2;
        qteForoSuplicy = 2;
        qteForoEneas = 2;
        qteForoDodorio = 2;
        qteForoHaddard = 2;
        qteForoCunha = 2;
    }

    public void ResetaVazarLigacoes()
    {
        qteVazarLula = 3;
        qteVazarCiro = 3;
        qteVazarBolso = 3;
        qteVazarDilma = 3;
        qteVazarSuplicy = 3;
        qteVazarEneas = 3;
        qteVazarDodorio = 3;
        qteVazarHaddard = 3;
        qteVazarCunha = 3;
    }

    public void ResetaAdHominem()
    {
        qteAdHominemLula = 3;
        qteAdHominemCiro = 3;
        qteAdHominemBolso = 3;
        qteAdHominemDilma = 3;
        qteAdHominemSuplicy = 3;
        qteAdHominemEneas = 3;
        qteAdHominemDodorio = 3;
        qteAdHominemHaddard = 3;
        qteAdHominemCunha = 3;
    }

    public void ResetapoioCentrao()
    {
        qteApoioCentraoLula = 3;
        qteApoioCentraoCiro = 3;
        qteApoioCentraoBolso = 3;
        qteApoioCentraoDilma = 3;
        qteApoioCentraoSuplicy = 3;
        qteApoioCentraoEneas = 3;
        qteApoioCentraoDodorio = 3;
        qteApoioCentraoHaddard = 3;
        qteApoioCentraoCunha = 3;
    }

    public void ResetaDelacao()
    {
         
        qteDelacaoLula = 3;
        qteDelacaoCiro = 3;
        qteDelacaoBolso = 3;
        qteDelacaoDilma = 3;
        qteDelacaoSuplicy = 3;
        qteDelacaoEneas = 3;
        qteDelacaoDodorio = 3;
        qteDelacaoHaddard = 3;
        qteDelacaoCunha = 3;
    }

    public void ResetaFakeNews()
    {
        qteFakeNewsLula = 3;
        qteFakeNewsCiro = 3;
        qteFakeNewsBolso = 3;
        qteFakeNewsDilma = 3;
        qteFakeNewsSuplicy = 3;
        qteFakeNewsEneas = 3;
        qteFakeNewsDodorio = 3;
        qteFakeNewsHaddard = 3;
        qteFakeNewsCunha = 3;
    }

    public void ResetaPerguntaPolemica()
    {
        qtePerguntaPolemicaLula = 3;
        qtePerguntaPolemicaCiro = 3;
        qtePerguntaPolemicaBolso = 3;
        qtePerguntaPolemicaDilma = 3;
        qtePerguntaPolemicaSuplicy = 3;
        qtePerguntaPolemicaEneas = 3;
        qtePerguntaPolemicaDodorio = 3;
        qtePerguntaPolemicaHaddard = 3;
        qtePerguntaPolemicaCunha = 3;
    }

    public void ResetaChamarGilmar()
    {
        qteChamarGilmarLula = 3;
        qteChamarGilmarCiro = 3;
        qteChamarGilmarBolso = 3;
        qteChamarGilmarDilma = 3;
        qteChamarGilmarSuplicy = 3;
        qteChamarGilmarEneas = 3;
        qteChamarGilmarDodorio = 3;
        qteChamarGilmarHaddard = 3;
        qteChamarGilmarCunha = 3;
    }

    public void ResetaPostoIpiranga()
    {
        qteMeuPostoIpirangaLula = 3;
        qteMeuPostoIpirangaCiro = 3;
        qteMeuPostoIpirangaBolso = 3;
        qteMeuPostoIpirangaDilma = 3;
        qteMeuPostoIpirangaSuplicy = 3;
        qteMeuPostoIpirangaEneas = 3;
        qteMeuPostoIpirangaDodorio = 3;
        qteMeuPostoIpirangaHaddard = 3;
        qteMeuPostoIpirangaCunha = 3;
    }

    public void ResetaSemCustoContribuinte()
    {
        qteSemCustoContribuinteLula = 3;
        qteSemCustoContribuinteCiro = 3;
        qteSemCustoContribuinteBolso = 3;
        qteSemCustoContribuinteDilma = 3;
        qteSemCustoContribuinteSuplicy = 3;
        qteSemCustoContribuinteEneas = 3;
        qteSemCustoContribuinteDodorio = 3;
        qteSemCustoContribuinteHaddard = 3;
        qteSemCustoContribuinteCunha = 3;
    }

    public void ResetaCiclovia()
    {
        qteCicloviaLula = 3;
        qteCicloviaCiro = 3;
        qteCicloviaBolso = 3;
        qteCicloviaDilma = 3;
        qteCicloviaSuplicy = 3;
        qteCicloviaEneas = 3;
        qteCicloviaDodorio = 3;
        qteCicloviaHaddard = 3;
        qteCicloviaCunha = 3;

    }
   
    // --------------- // 


    public void ResetaQuantidadeAtaques()
    {
        qteFraudarUrnasLula = 5;
        qteFraudarUrnasCiro = 5;
        qteFraudarUrnasBolso = 5;
        qteFraudarUrnasDilma = 5;
        qteFraudarUrnasSuplicy = 5;
        qteFraudarUrnasEneas = 5;
        qteFraudarUrnasDodorio = 5;
        qteFraudarUrnasHaddard = 5;
        qteFraudarUrnasCunha = 5;


        qteHabeasLula = 3;
        qteHabeasCiro = 3;
        qteHabeasBolso = 3;
        qteHabeasDilma = 3;
        qteHabeasSuplicy = 3;
        qteHabeasEneas = 3;
        qteHabeasDodorio = 3;
        qteHabeasHaddard = 3;
        qteHabeasCunha = 3;

        qteMilitanciaLula = 3;
        qteMilitanciaCiro = 3;
        qteMilitanciaBolso = 3;
        qteMilitanciaDilma = 3;
        qteMilitanciaSuplicy = 3;
        qteMilitanciaEneas = 3;
        qteMilitanciaDodorio = 3;
        qteMilitanciaHaddard = 3;
        qteMilitanciaCunha = 3;


        qteElogioLula = 1;
        qteElogioCiro = 1;
        qteElogioBolso = 1;
        qteElogioDilma = 1;
        qteElogioSuplicy = 1;
        qteElogioEneas = 1;
        qteElogioDodorio = 1;
        qteElogioHaddard = 1;
        qteElogioCunha = 1;


        qteDenunciaSupremoLula = 3;
        qteDenunciaSupremoCiro = 3;
        qteDenunciaSupremoBolso = 3;
        qteDenunciaSupremoDilma = 3;
        qteDenunciaSupremoSuplicy = 3;
        qteDenunciaSupremoEneas = 3;
        qteDenunciaSupremoDodorio = 3;
        qteDenunciaSupremoHaddard = 3;
        qteDenunciaSupremoCunha = 3;

        qteForoLula = 2;
        qteForoCiro = 2;
        qteForoBolso = 2;
        qteForoDilma = 2;
        qteForoSuplicy = 2;
        qteForoEneas = 2;
        qteForoDodorio = 2;
        qteForoHaddard = 2;
        qteForoCunha = 2;

        qteVazarLula = 3;
        qteVazarCiro = 3;
        qteVazarBolso = 3;
        qteVazarDilma = 3;
        qteVazarSuplicy = 3;
        qteVazarEneas = 3;
        qteVazarDodorio = 3;
        qteVazarHaddard = 3;
        qteVazarCunha = 3;

        qteAdHominemLula = 3;
        qteAdHominemCiro = 3;
        qteAdHominemBolso = 3;
        qteAdHominemDilma = 3;
        qteAdHominemSuplicy = 3;
        qteAdHominemEneas = 3;
        qteAdHominemDodorio = 3;
        qteAdHominemHaddard = 3;
        qteAdHominemCunha = 3;

        qteApoioCentraoLula = 3;
        qteApoioCentraoCiro = 3;
        qteApoioCentraoBolso = 3;
        qteApoioCentraoDilma = 3;
        qteApoioCentraoSuplicy = 3;
        qteApoioCentraoEneas = 3;
        qteApoioCentraoDodorio = 3;
        qteApoioCentraoHaddard = 3;
        qteApoioCentraoCunha = 3;

        qteDelacaoLula = 3;
        qteDelacaoCiro = 3;
        qteDelacaoBolso = 3;
        qteDelacaoDilma = 3;
        qteDelacaoSuplicy = 3;
        qteDelacaoEneas = 3;
        qteDelacaoDodorio = 3;
        qteDelacaoHaddard = 3;
        qteDelacaoCunha = 3;

        qteFakeNewsLula = 3;
        qteFakeNewsCiro = 3;
        qteFakeNewsBolso = 3;
        qteFakeNewsDilma = 3;
        qteFakeNewsSuplicy = 3;
        qteFakeNewsEneas = 3;
        qteFakeNewsDodorio = 3;
        qteFakeNewsHaddard = 3;
        qteFakeNewsCunha = 3;

        qtePerguntaPolemicaLula = 3;
        qtePerguntaPolemicaCiro = 3;
        qtePerguntaPolemicaBolso = 3;
        qtePerguntaPolemicaDilma = 3;
        qtePerguntaPolemicaSuplicy = 3;
        qtePerguntaPolemicaEneas = 3;
        qtePerguntaPolemicaDodorio = 3;
        qtePerguntaPolemicaHaddard = 3;
        qtePerguntaPolemicaCunha = 3;

        qteChamarGilmarLula = 3;
        qteChamarGilmarCiro = 3;
        qteChamarGilmarBolso = 3;
        qteChamarGilmarDilma = 3;
        qteChamarGilmarSuplicy = 3;
        qteChamarGilmarEneas = 3;
        qteChamarGilmarDodorio = 3;
        qteChamarGilmarHaddard = 3;
        qteChamarGilmarCunha = 3;

        qteMeuPostoIpirangaLula = 3;
        qteMeuPostoIpirangaCiro = 3;
        qteMeuPostoIpirangaBolso = 3;
        qteMeuPostoIpirangaDilma = 3;
        qteMeuPostoIpirangaSuplicy = 3;
        qteMeuPostoIpirangaEneas = 3;
        qteMeuPostoIpirangaDodorio = 3;
        qteMeuPostoIpirangaHaddard = 3;
        qteMeuPostoIpirangaCunha = 3;

        qteSemCustoContribuinteLula = 3;
        qteSemCustoContribuinteCiro = 3;
        qteSemCustoContribuinteBolso = 3;
        qteSemCustoContribuinteDilma = 3;
        qteSemCustoContribuinteSuplicy = 3;
        qteSemCustoContribuinteEneas = 3;
        qteSemCustoContribuinteDodorio = 3;
        qteSemCustoContribuinteHaddard = 3;
        qteSemCustoContribuinteCunha = 3;

        qteCicloviaLula = 3;
        qteCicloviaCiro = 3;
        qteCicloviaBolso = 3;
        qteCicloviaDilma = 3;
        qteCicloviaSuplicy = 3;
        qteCicloviaEneas = 3;
        qteCicloviaDodorio = 3;
        qteCicloviaHaddard = 3;
        qteCicloviaCunha = 3;

    }

    public void VerificaQteAtaques()
    {
        if (qteFraudarUrnas <= 0)
        {
            ataqueFraudarUrnas.interactable = false;
        }
        if (qteFraudarUrnas > 0)
        {
            ataqueFraudarUrnas.interactable = true;

        }

        if (qteHabeasCorpus <= 0)
        {
            ataqueHabeasCorpus.interactable = false;
        }
        if (qteHabeasCorpus > 0)
        {
            ataqueHabeasCorpus.interactable = true;

        }

        if (qteMilitancia <= 0)
        {
            ataqueMilitancia.interactable = false;
        }
        if (qteMilitancia > 0)
        {
            ataqueMilitancia.interactable = true;

        }

        if (qteElogioJornal <= 0)
        {
            ataqueElogioJornal.interactable = false;
        }
        if (qteElogioJornal > 0)
        {
            ataqueElogioJornal.interactable = true;

        }

        if (qteDenunciaSupremo <= 0)
        {
            ataqueDenunciaSupremo.interactable = false;
        }
        if (qteDenunciaSupremo > 0)
        {
            ataqueDenunciaSupremo.interactable = true;

        }

        if (qteForoPrivilegiado <= 0)
        {
            ataqueForoPrivilegiado.interactable = false;
        }
        if (qteForoPrivilegiado > 0)
        {
            ataqueForoPrivilegiado.interactable = true;

        }

        if (qteVazarLigacoes <= 0)
        {
            ataqueVazarLigacoes.interactable = false;
        }
        if (qteVazarLigacoes > 0)
        {
            ataqueVazarLigacoes.interactable = true;

        }

        if (qteAdHominem <= 0)
        {
            ataqueAdHominem.interactable = false;
        }
        if (qteAdHominem > 0)
        {
            ataqueAdHominem.interactable = true;

        }

        if (qteApoioCentrao <= 0)
        {
            ataqueApoioCentrao.interactable = false;
        }
        if (qteApoioCentrao > 0)
        {
            ataqueApoioCentrao.interactable = true;

        }

        if (qteDelacaoPremiada <= 0)
        {
            ataqueDelacaoPremiada.interactable = false;
        }
        if (qteDelacaoPremiada > 0)
        {
            ataqueDelacaoPremiada.interactable = true;

        }

        if (qteFakeNews <= 0)
        {
            ataqueFakeNews.interactable = false;
        }
        if (qteFakeNews > 0)
        {
            ataqueFakeNews.interactable = true;

        }

        if (qtePerguntaPolemica <= 0)
        {
            ataquePerguntaPolemica.interactable = false;
        }
        if (qtePerguntaPolemica > 0)
        {
            ataquePerguntaPolemica.interactable = true;
        }

        if (qteChamarGilmar <= 0)
        {
            ataqueChamarGilmar.interactable = false;
        }
        if (qteChamarGilmar > 0)
        {
            ataqueChamarGilmar.interactable = true;
        }

        if (qteMeuPostoIpiranga <= 0)
        {
            ataqueMeuPostoIpiranga.interactable = false;
        }
        if (qteMeuPostoIpiranga > 0)
        {
            ataqueMeuPostoIpiranga.interactable = true;
        }

        if (qteSemCustoContribuinte <= 0)
        {
            ataqueSemCustoContribuinte.interactable = false;
        }
        if (qteSemCustoContribuinte > 0)
        {
            ataqueSemCustoContribuinte.interactable = true;
        }

        if (qteCiclovia <= 0)
        {
            ataqueCiclovia.interactable = false;
        }
        if (qteCiclovia > 0)
        {
            ataqueCiclovia.interactable = true;
        }
    }




    // ---------------                 ------------------ //


    // --------------- ATAQUES INIMIGO ------------------ //


    // ---------------                 ------------------ //

    // TIRA POPULARIDADE PLAYER

    public void AtaqueInimigoFraudarUrnas(int autoridadeAtaque)
    {

        MitouLacrou();
        CalculoConfiancaInimigo();
        Protegido();

        print("autoridade ataque inimigo" + autoridadeAtaque);

        danoInimigo = Mathf.Round(Mathf.Round(Mathf.Round(((2 * (levelInimigo / levelPlayer) / 5 + 2) * autoridadeInimigo * autoridadeAtaque / apoioMidiaPlayer) / 50) + 2) * mitouLacrou) * confianca;



        if (Mathf.Round(popularidadePlayer) <= 0)
        {
            popularidadePlayer = 0;
        }




        somaPopPartido = Mathf.Round(somaPopPartido - danoInimigo);
        popularidadePlayer = Mathf.Round(popularidadePlayer) - danoInimigo;
        dialogo.text = " ";

        if (popularidadePlayer <= 0)
        {
            popularidadePlayer = 0;
        }

        if (confianca == 0)
        {
            SomFalhouAtaque.Play();

            dialogo.text = "O oponente errou o ataque, pois não foi confiante";

        }
        if (confianca != 0)
        {
            moveCamera = true;

            StartCoroutine(PiscaPlayer());
            StartCoroutine(PerdeuPopPlayer());

            SonsAtaque();

            if (chanceMitarLacrar != 2)
            {
                dialogo.text = "O oponente usou  <color=#FFED00FF> FRAUDAR URNAS </color> e tirou " + danoInimigo + " de sua popularidade";

            }

            if (direita == true && chanceMitarLacrar == 2)
            {
                dialogo.text = ("Oponente <color=#FFED00FF> MITOU com FRAUDAR URNAS </color>  e tirou " + danoInimigo + " da sua popularidade");
               
                StartCoroutine(MitouLacrouAviso());
            }
            if (esquerda == true && chanceMitarLacrar == 2)
            {
                dialogo.text = ("Oponente <color=#FFED00FF> LACROU com FRAUDAR URNAS </color> e tirou " + danoInimigo + " da sua popularidade");
                StartCoroutine(MitouLacrouAviso());
            }
        }







        StartCoroutine(DialogoEscolhaPersonagem());

        AtualizaPopPersonagens();

        popInimigo_txtUI.text = popularidadeInimigo.ToString();
        barraPopInimigo.value = popularidadeInimigo;

        pop_txtUI.text = Mathf.Round(popularidadePlayer).ToString();
        barraPop.value = popularidadePlayer;



        // HabilitaBotoes();

        inimigoAtacou = true;


    } // FIM ATAQUE Fraudar Urnas

    public void AtaqueInimigoFakeNews(int autoridadeAtaque)
    {

        MitouLacrou();
        CalculoConfiancaInimigo();
        danoInimigo = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelInimigo / 5 + 2) * autoridadeInimigo * autoridadeAtaque / apoioMidiaPlayer) / 50) + 2) * mitouLacrou) * confianca;

        Protegido();



        if (Mathf.Round(popularidadePlayer) <= 0)
        {
            popularidadePlayer = 0;
        }




        somaPopPartido = Mathf.Round(somaPopPartido - danoInimigo);
        popularidadePlayer = Mathf.Round(popularidadePlayer) - danoInimigo;
        dialogo.text = " ";

        if (popularidadePlayer <= 0)
        {
            popularidadePlayer = 0;
        }

        if (confianca == 0)
        {
            SomFalhouAtaque.Play();

            dialogo.text = "O oponente errou o ataque, pois não foi confiante";

        }
        if (confianca != 0)
        {
            moveCamera = true;

            StartCoroutine(PerdeuPopPlayer());

            StartCoroutine(PiscaPlayer());

            SonsAtaque();

            if (chanceMitarLacrar != 2)
            {
                dialogo.text = "O oponente usou <color=#FFED00FF> FAKE NEWS </color> e tirou " + danoInimigo + " de sua popularidade";

            }

            if (direita == true && chanceMitarLacrar == 2)
            {
             
                dialogo.text = ("Oponente <color=#FFED00FF> MITOU com FAKE NEWS </color>, tirando " + danoInimigo + " da sua popularidade");

            }

            if (esquerda == true && chanceMitarLacrar == 2)
            {
                
                dialogo.text = ("Oponente <color=#FFED00FF> LACROU com FAKE NEWS </color> tirando " + danoInimigo + " da sua popularidade");

            }
        }








        StartCoroutine(DialogoEscolhaPersonagem());

        AtualizaPopPersonagens();

        popInimigo_txtUI.text = popularidadeInimigo.ToString();
        barraPopInimigo.value = popularidadeInimigo;

        pop_txtUI.text = Mathf.Round(popularidadePlayer).ToString();
        barraPop.value = popularidadePlayer;



        //HabilitaBotoes();

        inimigoAtacou = true;

    } // FIM ATAQUE FAKE NEWS

    public void AtaqueInimigoPerguntaPolemica(int autoridadeAtaque)
    {
        moveCamera = true;

        MitouLacrou();
        CalculoConfiancaInimigo();
        danoInimigo = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelInimigo / 5 + 2) * autoridadeInimigo * autoridadeAtaque / apoioMidiaPlayer) / 50) + 2) * mitouLacrou) * confianca;
        Protegido();



        if (Mathf.Round(popularidadePlayer) <= 0)
        {
            popularidadePlayer = 0;
        }

        if (popularidadePlayer <= 0)
        {
            popularidadePlayer = 0;
        }


        somaPopPartido = Mathf.Round(somaPopPartido - danoInimigo);
        popularidadePlayer = Mathf.Round(popularidadePlayer) - danoInimigo;
        dialogo.text = " ";

        if (confianca == 0)
        {
            SomFalhouAtaque.Play();

            dialogo.text = "O oponente errou o ataque, pois não foi confiante";

        }
        if (confianca != 0)
        {
            moveCamera = true;

            StartCoroutine(PiscaPlayer());
            StartCoroutine(PerdeuPopPlayer());

            SonsAtaque();


            if (chanceMitarLacrar != 2)
            {
                dialogo.text = "O oponente usou <color=#FFED00FF> PERGUNTA POLÊMICA </color> e tirou " + danoInimigo + " de sua popularidade";

            }

            if (direita == true && chanceMitarLacrar == 2)
            {
                dialogo.text = ("Oponente <color=#FFED00FF> MITOU com PERGUNTA POLÊMICA </color> " + danoInimigo + " da sua popularidade");

            }
            if (esquerda == true && chanceMitarLacrar == 2)
            {
                dialogo.text = ("Oponente <color=#FFED00FF> LACROU com PERGUNTA POLÊMICA </color> " + danoInimigo + " da sua popularidade");

            }
        }






        StartCoroutine(DialogoEscolhaPersonagem());



        AtualizaPopPersonagens();

        popInimigo_txtUI.text = popularidadeInimigo.ToString();
        barraPopInimigo.value = popularidadeInimigo;

        pop_txtUI.text = Mathf.Round(popularidadePlayer).ToString();
        barraPop.value = popularidadePlayer;



        // HabilitaBotoes();

        inimigoAtacou = true;

    } // FIM ATAQUE DISCURSO INFLAMADO


    // ------ //


    // TIRA APOIO DA MIDIA PLAYER
    public void AtaqueInimigoVazarLigacoes(int autoridadeAtaque)
    {


        MitouLacrou();
        Protegido();
        CalculoConfiancaInimigo();
        //autoridadeAtaque = Random.Range(30, 40);


        danoInimigo = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelInimigo / 5 + 2) * apoioMidiaInimigo * autoridadeAtaque / apoioMidiaPlayer) / 50) + 2) * mitouLacrou) * confianca;

        if (apoioMidiaPlayer > danoInimigo)
        {
            apoioMidiaPlayer = apoioMidiaPlayer - danoInimigo;

            if (confianca == 0)
            {
                SomFalhouAtaque.Play();

                dialogo.text = "Oponente errou o ataque porque não foi confiante";

            }
            if (confianca != 0)
            {
                StartCoroutine(PerdeuApoioMidiaPlayer());
                SomTiraStatus.Play();
                if (chanceMitarLacrar != 2)
                {
                    dialogo.text = "Oponente utilizou <color=#FFED00FF> VAZAR LIGAÇÕES </color> comprometedoras e tirou " + danoInimigo + " de seu Apoio da Mídia";

                }

                if (direita == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Muito opressor! Oponente <color=#FFED00FF> MITOU com VAZAR LIGAÇÕES </color> e tirou " + danoInimigo + " de seu Apoio da Mídia");

                }
                if (esquerda == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Que tiro foi esse?! Oponente <color=#FFED00FF> LACROU com VAZAR LIGAÇÕES </color> e tirou " + danoInimigo + " de seu Apoio da Mídia");

                }
            }
        }

        if (apoioMidiaPlayer < danoInimigo)
        {
            apoioMidiaPlayer = 10;

            if (confianca == 0)
            {
                SomFalhouAtaque.Play();

                dialogo.text = "Oponente errou o ataque porque não foi confiante";

            }
            if (confianca != 0)
            {
                StartCoroutine(PerdeuApoioMidiaPlayer());

                SomTiraStatus.Play();
                dialogo.text = "Oponente utilizou <color=#FFED00FF> VAZAR LIGAÇÕES </color> comprometedoras e tirou " + danoInimigo + " de seu Apoio da Mídia";
            }


        }

        StartCoroutine(DialogoEscolhaPersonagem());


        popInimigo_txtUI.text = popularidadeInimigo.ToString();
        barraPopInimigo.value = popularidadeInimigo;

        pop_txtUI.text = Mathf.Round(popularidadePlayer).ToString();
        barraPop.value = popularidadePlayer;



        // HabilitaBotoes();

        inimigoAtacou = true;
    }

    // TIRA CONFIANÇA
    public void AtaqueInimigoAdHominem(int autoridadeAtaque)
    {

        MitouLacrou();
        Protegido();
        CalculoConfiancaInimigo();

        danoInimigo = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelInimigo / 5 + 2) * confiancaInimigo * autoridadeAtaque / confiancaPlayer) / 100) + 2) * mitouLacrou) * confianca;

        if (confiancaPlayer > danoInimigo && confiancaPlayer > 10)
        {
            confiancaPlayer = (int)(confiancaPlayer - danoInimigo);
            if (confianca == 0)
            {
                SomFalhouAtaque.Play();

                dialogo.text = "Oponente errou o ataque porque não foi confiante";

            }
            if (confianca != 0)
            {
                SomAumentaStatus.Play();

                if (chanceMitarLacrar != 2)
                {
                    dialogo.text = "Oponente utilizou argumentos <color=#FFED00FF> AD HOMINEM </color>  e tirou " + danoInimigo + " de sua Confiança";

                }

                if (direita == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Muito opressor! Oponente <color=#FFED00FF> MITOU com AD HOMINEM </color>  e tirou " + danoInimigo + " de sua Confiança");

                }
                if (esquerda == true && chanceMitarLacrar == 2)
                {
                    dialogo.text = ("Que tiro foi esse?! Oponente <color=#FFED00FF> LACROU com AD HOMINEM </color>  e tirou " + danoInimigo + " de sua Confiança");

                }

            }

            // DesabilitaBotoes();

            inimigoAtacou = true;

        }

        if (confiancaPlayer < danoInimigo && confiancaPlayer > 10)
        {
            confiancaPlayer = 1;
            if (confianca == 0)
            {
                SomFalhouAtaque.Play();

                dialogo.text = "Oponente errou o ataque porque não foi confiante";

            }
            if (confianca != 0)
            {
                SomAumentaStatus.Play();

                dialogo.text = "Oponente utilizou argumentos <color=#FFED00FF> AD HOMINEM </color>  e tirou " + danoInimigo + " de sua Confiança";

            }

            // DesabilitaBotoes();

            inimigoAtacou = true;
        }

        if (confiancaPlayer < 10)
        {
            inimigoAtacou = false;
        }

        StartCoroutine(DialogoEscolhaPersonagem());

    }

    // TIRA AUTORIDADE PLAYER

    public void AtaqueInimigoDenunciaSupremo(int autoridadeAtaque)
    {
        Protegido(); // verifica se o player está protegido

        MitouLacrou();
        CalculoConfiancaInimigo();



        danoInimigo = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelInimigo / 5 + 2) * autoridadeInimigo * autoridadeAtaque / autoridadePlayer) / 50) + 2) * mitouLacrou) * confianca;
        autoridadePlayer = autoridadePlayer - danoInimigo;

        if (autoridadePlayer <= 0)
        {
            autoridadePlayer = 5;
        }

        if (confianca == 0)
        {
            SomFalhouAtaque.Play();

            dialogo.text = "Oponente errou o ataque porque não foi confiante";

        }
        if (confianca != 0)
        {
            SomAumentaStatus.Play();

            if (chanceMitarLacrar != 2)
            {
                dialogo.text = "Oponente usou <color=#FFED00FF> DENÚNCIA AO SUPREMO </color> . Você perdeu " + danoInimigo + " de Autoridade";

            }

            if (direita == true && chanceMitarLacrar == 2)
            {
                dialogo.text = ("Muito opressor! Oponente <color=#FFED00FF> MITOU com DENÚNCIA AO SUPREMO </color> e tirou " + danoInimigo + " da sua Autoridade");

            }
            if (esquerda == true && chanceMitarLacrar == 2)
            {
                dialogo.text = ("Que tiro foi esse?! Oponente <color=#FFED00FF> LACROU com DENÚNCIA AO SUPREMO </color> e tirou " + danoInimigo + " da sua Autoridade");

            }




        }

        StartCoroutine(DialogoEscolhaPersonagem());


        popInimigo_txtUI.text = popularidadeInimigo.ToString();
        barraPopInimigo.value = popularidadeInimigo;

        pop_txtUI.text = Mathf.Round(popularidadePlayer).ToString();
        barraPop.value = popularidadePlayer;



        // HabilitaBotoes();

        inimigoAtacou = true;

    } // FIM ATAQUE INIMIGO DENUNCIA SUPREMO

    // AUMENTA AUTORIDADE INIMIGO

    public void AtaqueInimigoMilitancia(int autoridadeAtaque)
    {
        MitouLacrou();
        CalculoConfiancaInimigo();


        danoInimigo = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelInimigo / 5 + 2) * autoridadeInimigo * autoridadeAtaque / autoridadeInimigo) / 50) + 2) * mitouLacrou) * confianca;
        autoridadeInimigo = autoridadeInimigo + danoInimigo;

        if (confianca == 0)
        {
            SomFalhouAtaque.Play();

            dialogo.text = "Oponente errou o ataque porque não foi confiante";

        }
        if (confianca != 0)
        {
            SomAumentaStatus.Play();

            if (chanceMitarLacrar != 2)
            {
                dialogo.text = "Oponente usou <color=#FFED00FF> MILITÂNCIA </color>. Autoridade aumentou para " + autoridadeInimigo;

            }

            if (direita == true && chanceMitarLacrar == 2)
            {
                dialogo.text = ("Muito opressor! Oponente <color=#FFED00FF> MITOU com MILITÂNCIA </color> e aumentou Autoridade para " + autoridadeInimigo);

            }
            if (esquerda == true && chanceMitarLacrar == 2)
            {
                dialogo.text = ("Que tiro foi esse?! Oponente <color=#FFED00FF> LACROU com MILITÂNCIA </color> e aumentou Autoridade para " + autoridadeInimigo);

            }




        }

        StartCoroutine(DialogoEscolhaPersonagem());


        popInimigo_txtUI.text = popularidadeInimigo.ToString();
        barraPopInimigo.value = popularidadeInimigo;

        pop_txtUI.text = Mathf.Round(popularidadePlayer).ToString();
        barraPop.value = popularidadePlayer;



        //HabilitaBotoes();

        inimigoAtacou = true;

    }

    // AUMENTA APOIO DA MIDIA DO INIMIGO 
    public void AtaqueInimigoHabeasCorpus(int autoridadeAtaque)
    {
        CalculoConfiancaInimigo();
        MitouLacrou();


        danoInimigo = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelInimigo / 5 + 2) * apoioMidiaInimigo * autoridadeAtaque / apoioMidiaInimigo) / 50) + 2) * mitouLacrou) * confianca;
        apoioMidiaInimigo = apoioMidiaInimigo + danoInimigo;

        if (confianca == 0)
        {
            SomFalhouAtaque.Play();

            dialogo.text = "Oponente errou o ataque porque não foi confiante";

        }
        if (confianca != 0)
        {
            SomDefesa.Play();
            StartCoroutine(AumentouApoioMidiaInimigo());

            if (chanceMitarLacrar != 2)
            {
                dialogo.text = "Oponente usou <color=#FFED00FF> HABEAS CORPUS </color>. Agora, o Apoio da Mídia aumentou para " + apoioMidiaInimigo;
                
            }

            if (direita == true && chanceMitarLacrar == 2)
            {
                dialogo.text = ("Muito opressor! Oponente <color=#FFED00FF> MITOU com HABEAS CORPUS </color> e aumentou o Apoio da Mídia para " + apoioMidiaInimigo);

            }
            if (esquerda == true && chanceMitarLacrar == 2)
            {
                dialogo.text = ("Que tiro foi esse?! Oponente <color=#FFED00FF> LACROU com HABEAS CORPUS </color> e aumentou o Apoio da Mídia para " + apoioMidiaInimigo);

            }




        }

        StartCoroutine(DialogoEscolhaPersonagem());


        popInimigo_txtUI.text = popularidadeInimigo.ToString();
        barraPopInimigo.value = popularidadeInimigo;

        pop_txtUI.text = Mathf.Round(popularidadePlayer).ToString();
        barraPop.value = popularidadePlayer;



        //HabilitaBotoes();

        inimigoAtacou = true;
    } // FIM HABEAS CORPUS INIMIGO

    //  AUMENTA POPULARIDADE
    public void AtaqueInimigoElogioJornal(int autoridadeAtaque)
    {

        CalculoConfiancaInimigo();

        // autoridadeAtaque = Random.Range(40, 50);


        danoInimigo = (autoridadeAtaque / 2) * confianca;
        popularidadeInimigo = popularidadeInimigo + danoInimigo;



        if (confianca == 0)
        {
            SomFalhouAtaque.Play();

            dialogo.text = "Oponente errou o ataque porque não foi confiante";

        }
        if (confianca != 0)
        {
            StartCoroutine(AumentouPopInimigo());

            SomEspecial.Play();

            dialogo.text = "Oponente foi <color=#FFED00FF> ELOGIADO NO JORNAL </color>. Popularidade aumentou para " + popularidadeInimigo;

        }


        popInimigo_txtUI.text = popularidadeInimigo.ToString();
        barraPopInimigo.value = popularidadeInimigo;

        pop_txtUI.text = Mathf.Round(popularidadePlayer).ToString();
        barraPop.value = popularidadePlayer;

        StartCoroutine(DialogoEscolhaPersonagem());

        //HabilitaBotoes();

        inimigoAtacou = true;
    }

    // AUMENTA CONFIANÇA

    public void AtaqueInimigoApoioCentrao(int autoridadeAtaque)
    {

        MitouLacrou();
        Protegido();
        CalculoConfiancaInimigo();

        danoInimigo = Mathf.Round(Mathf.Round(Mathf.Round(((2 * levelInimigo / 5 + 2) * confiancaInimigo * autoridadeAtaque / confiancaInimigo) / 50) + 2) * mitouLacrou) * confianca;


        confiancaInimigo = (int)(confiancaInimigo + danoInimigo);
        if (confianca == 0)
        {
            SomFalhouAtaque.Play();

            dialogo.text = "Oponente errou o ataque porque não foi confiante";

        }
        if (confianca != 0)
        {
            SomAumentaStatus.Play();

            if (chanceMitarLacrar != 2)
            {
                dialogo.text = "Oponente conquistou <color=#FFED00FF> APOIO DO CENTRÃO </color> e aumentou " + danoInimigo + " de Confiança.";

            }

            if (direita == true && chanceMitarLacrar == 2)
            {
                dialogo.text = ("Muito opressor! Oponente <color=#FFED00FF> MITOU com APOIO DO CENTRÃO </color> e aumentou " + danoInimigo + " de Retórica.");

            }
            if (esquerda == true && chanceMitarLacrar == 2)
            {
                dialogo.text = ("Que tiro foi esse?! Oponente <color=#FFED00FF> LACROU com APOIO DO CENTRÃO </color> e aumentou " + danoInimigo + " Retórica.");

            }
        }




        StartCoroutine(DialogoEscolhaPersonagem());


        //DesabilitaBotoes();

        inimigoAtacou = true;
    }

    // -------- //

    public void AtaquesInimigo()
    {
        MinMaxAut();

        // PLAYER ATACOU

        if (ataquePlayer == true && defesaPlayer == false && mudaStatusPlayer == false && inimigoAtacou == false)// && inimigoJaAtacou == false)
        {
            print("minMax" + autoridadeAtaque);

            if (popularidadePlayer >= 80 && inimigoAtacou == false)
            {
                int i = Random.Range(1, 4);
                switch (i)
                {
                    case (1):

                        AtaqueInimigoFraudarUrnas(Random.Range(minAut, maxAut));
                        break;

                    case (2):
                        AtaqueInimigoFakeNews(Random.Range(minAut, maxAut));
                        break;

                    case (3):
                        AtaqueInimigoPerguntaPolemica(Random.Range(minAut, maxAut));
                        break;

                }

                print("minMax" + autoridadeAtaque);

            }

            if (popularidadePlayer >= 50 && popularidadePlayer < 80 && inimigoAtacou == false)
            {
                int i = Random.Range(1, 4);
                switch (i)
                {
                    case (1):

                        AtaqueInimigoHabeasCorpus(Random.Range(minAut, maxAut));
                        break;

                    case (2):
                        AtaqueInimigoAdHominem(Random.Range(minAut, maxAut));
                        break;

                    case (3):
                        AtaqueInimigoPerguntaPolemica(Random.Range(minAut, maxAut));
                        break;

                }

            }

            if (popularidadePlayer >= 20 && popularidadePlayer < 50 && inimigoAtacou == false)
            {
                int i = Random.Range(1, 4);
                switch (i)
                {
                    case (1):

                        AtaqueInimigoHabeasCorpus(Random.Range(minAut, maxAut));
                        break;

                    case (2):
                        if (autoridadePlayer > 10)
                        {
                            AtaqueInimigoDenunciaSupremo(Random.Range(minAut, maxAut));
                        }
                        if (autoridadePlayer < 10)
                        {
                            AtaqueInimigoHabeasCorpus(Random.Range(minAut, maxAut));
                        }
                        break;

                    case (3):
                        AtaqueInimigoFakeNews(Random.Range(minAut, maxAut));
                        break;

                }

            }

            if (popularidadePlayer < 20 && inimigoAtacou == false)
            {
                int i = Random.Range(1, 5);
                switch (i)
                {
                    case (1):

                        AtaqueInimigoHabeasCorpus(Random.Range(minAut, maxAut));
                        break;

                    case (2):
                        AtaqueInimigoAdHominem(Random.Range(minAut, maxAut));
                        break;

                    case (3):
                        AtaqueInimigoFraudarUrnas(Random.Range(minAut, maxAut));
                        break;

                    case (4):
                        AtaqueInimigoApoioCentrao(Random.Range(minAut, maxAut));
                        break;
                }
            }

            if (popularidadeInimigo <= 30 && qteAtaqueInimigoElogio == 1 && inimigoAtacou == false)
            {
                AtaqueInimigoElogioJornal(Random.Range(minAut, maxAut));
                qteAtaqueInimigoElogio = 0;

            }


        }

        // PLAYER DEFENDEU

        if (ataquePlayer == false && defesaPlayer == true && mudaStatusPlayer == false && inimigoAtacou == false)
        {
            if (popularidadePlayer >= 80 && inimigoAtacou == false)
            {
                int i = Random.Range(1, 4);
                switch (i)
                {
                    case (1):

                        AtaqueInimigoFraudarUrnas(Random.Range(minAut, maxAut));
                        break;

                    case (2):
                        AtaqueInimigoFakeNews(Random.Range(minAut, maxAut));
                        break;

                    case (3):
                        AtaqueInimigoPerguntaPolemica(Random.Range(minAut, maxAut));
                        break;

                }

            }

            if (popularidadePlayer >= 50 && popularidadePlayer < 80 && inimigoAtacou == false)
            {
                int i = Random.Range(1, 4);
                switch (i)
                {
                    case (1):
                        if (apoioMidiaPlayer > 10)
                        {
                            AtaqueInimigoVazarLigacoes(Random.Range(minAut, maxAut));
                        }
                        if (apoioMidiaPlayer <= 10)
                        {
                            AtaqueInimigoMilitancia(Random.Range(minAut, maxAut));

                        }

                        break;

                    case (2):
                        AtaqueInimigoFakeNews(Random.Range(minAut, maxAut));
                        break;

                    case (3):
                        AtaqueInimigoPerguntaPolemica(Random.Range(minAut, maxAut));
                        break;

                }

            }

            if (popularidadePlayer >= 20 && popularidadePlayer < 50 && inimigoAtacou == false)
            {
                int i = Random.Range(1, 4);
                switch (i)
                {
                    case (1):

                        AtaqueInimigoAdHominem(Random.Range(minAut, maxAut));
                        break;

                    case (2):
                        if (autoridadePlayer > 10)
                        {
                            AtaqueInimigoDenunciaSupremo(Random.Range(minAut, maxAut));
                        }
                        if (autoridadePlayer < 10)
                        {
                            AtaqueInimigoHabeasCorpus(Random.Range(minAut, maxAut));
                        }
                        break;

                    case (3):
                        AtaqueInimigoFakeNews(Random.Range(minAut, maxAut));
                        break;

                }

            }

            if (popularidadePlayer < 20 && inimigoAtacou == false)
            {
                int i = Random.Range(1, 5);
                switch (i)
                {
                    case (1):

                        AtaqueInimigoHabeasCorpus(Random.Range(minAut, maxAut));
                        break;

                    case (2):
                        AtaqueInimigoAdHominem(Random.Range(minAut, maxAut));
                        break;

                    case (3):
                        AtaqueInimigoFraudarUrnas(Random.Range(minAut, maxAut));
                        break;

                    case (4):
                        AtaqueInimigoApoioCentrao(Random.Range(minAut, maxAut));
                        break;
                }
            }

            if (popularidadeInimigo <= 30 && qteAtaqueInimigoElogio == 1 && inimigoAtacou == false)
            {
                AtaqueInimigoElogioJornal(Random.Range(minAut, maxAut));
                qteAtaqueInimigoElogio = 0;

            }

        }

        // PLAYER MUDOU STATUS

        if (ataquePlayer == false && defesaPlayer == false && mudaStatusPlayer == true && inimigoAtacou == false)
        {
            print("PLAYER MUDOU STATUS");

            if (popularidadePlayer >= 80)
            {
                print("ATAQUE MUDA STATUS1");

                int i = Random.Range(1, 4);
                switch (i)
                {
                    case (1):

                        AtaqueInimigoFraudarUrnas(Random.Range(minAut, maxAut));
                        inimigoAtacou = true;

                        break;

                    case (2):
                        AtaqueInimigoMilitancia(Random.Range(minAut, maxAut));
                        inimigoAtacou = true;

                        break;

                    case (3):
                        AtaqueInimigoPerguntaPolemica(Random.Range(minAut, maxAut));
                        inimigoAtacou = true;

                        break;

                }

            }

            if (popularidadePlayer >= 50 && popularidadePlayer < 80 && inimigoAtacou == false)
            {
                print("ATAQUE MUDA STATUS2");

                int i = Random.Range(1, 4);
                switch (i)
                {
                    case (1):

                        if (apoioMidiaPlayer > 10)
                        {
                            AtaqueInimigoVazarLigacoes(Random.Range(minAut, maxAut));
                        }
                        if (apoioMidiaPlayer <= 10)
                        {
                            AtaqueInimigoMilitancia(Random.Range(minAut, maxAut));
                        }
                        break;

                    case (2):
                        AtaqueInimigoApoioCentrao(Random.Range(minAut, maxAut));
                        break;

                    case (3):
                        AtaqueInimigoHabeasCorpus(Random.Range(minAut, maxAut));
                        break;

                }

            }

            if (popularidadePlayer >= 20 && popularidadePlayer < 50 && inimigoAtacou == false)
            {
                print("ATAQUE MUDA STATUS3");

                int i = Random.Range(1, 4);
                switch (i)
                {
                    case (1):

                        AtaqueInimigoAdHominem(Random.Range(minAut, maxAut));
                        break;

                    case (2):
                        if (autoridadePlayer > 10)
                        {
                            AtaqueInimigoDenunciaSupremo(Random.Range(minAut, maxAut));
                        }
                        if (autoridadePlayer < 10)
                        {
                            AtaqueInimigoHabeasCorpus(Random.Range(minAut, maxAut));
                        }
                        break;

                    case (3):
                        AtaqueInimigoFakeNews(Random.Range(minAut, maxAut));
                        break;

                }

            }

            if (popularidadePlayer < 20 && inimigoAtacou == false)
            {
                print("ATAQUE MUDA STATUS4");

                int i = Random.Range(1, 4);
                switch (i)
                {
                    case (1):

                        AtaqueInimigoHabeasCorpus(Random.Range(minAut, maxAut));
                        break;

                    case (2):
                        AtaqueInimigoAdHominem(Random.Range(minAut, maxAut));
                        break;

                    case (3):
                        AtaqueInimigoFraudarUrnas(Random.Range(minAut, maxAut));
                        break;

                    case (4):
                        AtaqueInimigoApoioCentrao(Random.Range(minAut, maxAut));
                        break;
                }
            }

            if (popularidadeInimigo <= 30 && qteAtaqueInimigoElogio == 1 && inimigoAtacou == false)
            {
                AtaqueInimigoElogioJornal(Random.Range(minAut, maxAut));
                qteAtaqueInimigoElogio = 0;

            }

        }

        // TROCOU DE PERSONAGEM

        if (trocouPersonagem == true && inimigoAtacou == false)
        {

            if (popularidadePlayer >= 80 && inimigoAtacou == false)
            {
                int i = Random.Range(1, 3);
                switch (i)
                {
                    case (1):

                        AtaqueInimigoFraudarUrnas(Random.Range(minAut, maxAut));
                        break;

                    case (2):
                        AtaqueInimigoMilitancia(Random.Range(minAut, maxAut));
                        break;

                    case (3):
                        AtaqueInimigoPerguntaPolemica(Random.Range(minAut, maxAut));
                        break;

                }

            }

            if (popularidadePlayer >= 50 && popularidadePlayer < 80 && inimigoAtacou == false)
            {
                int i = Random.Range(1, 3);
                switch (i)
                {
                    case (1):

                        if (apoioMidiaPlayer > 10)
                        {
                            AtaqueInimigoVazarLigacoes(Random.Range(minAut, maxAut));
                        }
                        if (apoioMidiaPlayer <= 10)
                        {
                            AtaqueInimigoMilitancia(Random.Range(minAut, maxAut));
                        }
                        break;

                    case (2):
                        AtaqueInimigoApoioCentrao(Random.Range(minAut, maxAut));
                        break;

                    case (3):
                        AtaqueInimigoHabeasCorpus(Random.Range(minAut, maxAut));
                        break;

                }

            }

            if (popularidadePlayer >= 20 && popularidadePlayer < 50 && inimigoAtacou == false)
            {
                int i = Random.Range(1, 3);
                switch (i)
                {
                    case (1):

                        AtaqueInimigoAdHominem(Random.Range(minAut, maxAut));
                        break;

                    case (2):
                        AtaqueInimigoDenunciaSupremo(Random.Range(minAut, maxAut));
                        break;

                    case (3):
                        AtaqueInimigoFakeNews(Random.Range(minAut, maxAut));
                        break;

                }

            }

            if (popularidadePlayer < 20 && inimigoAtacou == false)
            {
                int i = Random.Range(1, 4);
                switch (i)
                {
                    case (1):

                        AtaqueInimigoHabeasCorpus(Random.Range(minAut, maxAut));
                        break;

                    case (2):
                        AtaqueInimigoAdHominem(Random.Range(minAut, maxAut));
                        break;

                    case (3):
                        AtaqueInimigoFraudarUrnas(Random.Range(minAut, maxAut));
                        break;

                    case (4):
                        AtaqueInimigoApoioCentrao(Random.Range(minAut, maxAut));
                        break;
                }
            }

            if (popularidadeInimigo <= 30 && qteAtaqueInimigoElogio == 1 && inimigoAtacou == false)
            {
                AtaqueInimigoElogioJornal(Random.Range(minAut, maxAut));
                qteAtaqueInimigoElogio = 0;

            }
        }

        // RETORICA INIMIGO É MAIOR

        if (ataquePlayer == false && defesaPlayer == false && mudaStatusPlayer == false && inimigoAtacou == false)
        {
            int i = Random.Range(1, 3);
            switch (i)
            {
                case (1):

                    AtaqueInimigoFraudarUrnas(Random.Range(minAut, maxAut));
                    inimigoAtacou = true;

                    break;

                case (2):
                    AtaqueInimigoMilitancia(Random.Range(minAut, maxAut));
                    inimigoAtacou = true;

                    break;

                case (3):
                    AtaqueInimigoPerguntaPolemica(Random.Range(minAut, maxAut));
                    inimigoAtacou = true;

                    break;

            }
        }

    } // FIM ATAQUES INIMIGO


    public void MinMaxAut()
    {
        if (levelPlayer <= 3)
        {
            minAut = 15;
            maxAut = 41;
        }

        if (levelPlayer > 3 && levelPlayer <= 6)
        {
            minAut = 20;
            maxAut = 45;
        }

        if (levelPlayer > 6 && levelPlayer <= 10)
        {
            minAut = 25;
            maxAut = 46;
        }

        if (levelPlayer > 10 && levelPlayer <= 16)
        {
            minAut = 30;
            maxAut = 47;
        }

        if (levelPlayer > 16 && levelPlayer <= 30)
        {
            minAut = 35;
            maxAut = 48;
        }

        if (levelPlayer > 30)
        {
            minAut = 45;
            maxAut = 50;
        }

    }
    // --------------------- //

    public void MitouLacrou()
    {
        
        chanceMitarLacrar = Random.Range(0, 4);
        print(chanceMitarLacrar);

        if (chanceMitarLacrar == 2) // manter como numero 2, pra não precisar mudar em todo os ataques (independente da chancemitarlacrar)
        {
            mitouLacrou = 2f;
        }

        if (chanceMitarLacrar != 2)
        {
            mitouLacrou = 1;
        }

       



    }

    public void CalculoConfiancaPlayer()
    {
        calculoConfianca = Random.Range(0, confiancaPlayer + 1);

        if (calculoConfianca == 0)
        {
            confianca = 0;
            print("Seu político errou o ataque porque não foi confiante");

        }

        if (calculoConfianca != 0)
        {
            confianca = 1;
            print("O ataque foi confiante");
        }
    }

    public void CalculoConfiancaInimigo()
    {
        calculoConfianca = Random.Range(0, confiancaInimigo + 1);

        if (calculoConfianca == 0)
        {
            confianca = 0;
            print("oponente errou ataque");
            dialogo.text = "Oponente errou o ataque porque não foi confiante";

        }

        if (calculoConfianca != 0)
        {
            confianca = 1;
            print("oponente acertou ataque");
        }
    }

    public void DireitaEsquerda()
    {
        if (direita == true)
        {
            esquerda = false;
        }
        if (esquerda == true)
        {
            direita = false;
        }

        if (PlayerPrefs.GetInt("LulaDentroScene") == 1)
        {
            esquerda = true;
        }

        if (PlayerPrefs.GetInt("CiroDentroScene") == 1)
        {
            esquerda = true;
        }
        if (PlayerPrefs.GetInt("BolsoDentroScene") == 1)
        {
            direita = true;

        }
        if (PlayerPrefs.GetInt("DilmaDentroScene") == 1)
        {
            esquerda = true;
        }
        if (PlayerPrefs.GetInt("SuplicyDentroScene") == 1)
        {
            esquerda = true;
        }
        if (PlayerPrefs.GetInt("EneasDentroScene") == 1)
        {
            direita = true;
        }

        if (PlayerPrefs.GetInt("DodorioDentroScene") == 1)
        {
            direita = true;
        }

        if (PlayerPrefs.GetInt("HaddardDentroScene") == 1)
        {
            esquerda = true;
        }

        if (PlayerPrefs.GetInt("CunhaDentroScene") == 1)
        {
            esquerda = true;
        }


    }

    public void DireitaEsquerdaInimigos()
    {
        if (direitaInimigo == true)
        {
            esquerdaInimigo = false;
        }
        if (esquerdaInimigo == true)
        {
            direitaInimigo = false;
        }

        if (PlayerPrefs.GetInt("LulaInimigoScene") == 1)
        {
            esquerdaInimigo = true;
        }

        if (PlayerPrefs.GetInt("CiroInimigoScene") == 1)
        {
            esquerdaInimigo = true;
        }
        if (PlayerPrefs.GetInt("BolsoInimigoScene") == 1)
        {
            direitaInimigo = true;

        }
        if (PlayerPrefs.GetInt("DilmaInimigoScene") == 1)
        {
            esquerdaInimigo = true;
        }
        if (PlayerPrefs.GetInt("SuplicyInimigoScene") == 1)
        {
            esquerdaInimigo = true;
        }
        if (PlayerPrefs.GetInt("EneasInimigoScene") == 1)
        {
            direitaInimigo = true;
        }

        if (PlayerPrefs.GetInt("DodorioInimigoScene") == 1)
        {
            direitaInimigo = true;
        }

        if (PlayerPrefs.GetInt("HaddardInimigoScene") == 1)
        {
            esquerdaInimigo = true;
        }

        if (PlayerPrefs.GetInt("CunhaInimigoScene") == 1)
        {
            esquerdaInimigo = true;
        }


    }

    public void CalculoRetorica()
    {
        if (retoricaPlayer >= retoricaInimigo && playerAtacou == false)
        {
            currentState = BattleStates.ESCOLHAJOGADOR;
            HabilitaBotoes();
            print("retorica do player foi maior");
            //MovimentosPlayer.gameObject.SetActive(true);

        }

        if (retoricaPlayer < retoricaInimigo && inimigoAtacou == false)
        {
            StartCoroutine(VezInimigo());
            DesabilitaBotoes();

            print("retorica do inimigo foi maior");
            MovimentosPlayer.gameObject.SetActive(false);


        }
    }



    public void Protegido()
    {
        if (playerProtegido == true && currentState == BattleStates.ESCOLHAINIMIGO)
        {
            danoInimigo = 0;
            playerProtegido = false;
        }

        if (inimigoProtegido == true && currentState == BattleStates.ESCOLHAJOGADOR)
        {
            danoPlayer = 0;
            inimigoProtegido = false;
        }
    }

    public void DialogoEscolha()
    {
        dialogo.text = "O que você irá fazer?";
    }

    IEnumerator DialogoEscolhaPersonagem()
    {
        HabilitaBotoes();
        yield return new WaitForSeconds(5f);
        dialogo.text = " ";
        yield return new WaitForSeconds(0.2f);
        dialogo.text = "O que você irá fazer?";

    }


    // -------------- TIPOS DE BATALHAS ----------- //

    public void BatalhaEleições()
    {
        if (PlayerPrefs.GetInt("LevelIndice") == 3)
        {
            tipoDessaBatalha = TipoBatalha.ELEICAOVEREADOR;
        }

        if (PlayerPrefs.GetInt("LevelIndice") == 6)
        {
            tipoDessaBatalha = TipoBatalha.ELEICAODEPUTADO;
        }

        if (PlayerPrefs.GetInt("LevelIndice") == 10)
        {
            tipoDessaBatalha = TipoBatalha.ELEICAOPREFEITO;
        }

        if (PlayerPrefs.GetInt("LevelIndice") == 20)
        {
            tipoDessaBatalha = TipoBatalha.ELEICAOGOVERNADOR;
        }

        if (PlayerPrefs.GetInt("LevelIndice") == 30)
        {
            tipoDessaBatalha = TipoBatalha.ELEICAOPRESIDENTE;
        }


    }

    public void BatalhaImpeachment()
    {
        tipoDessaBatalha = TipoBatalha.IMPEACHMENT;


    }

   
    public void BatalhaDilma()
    {
        tipoDessaBatalha = TipoBatalha.DILMA;


    }

    public void BatalhaSuplicy()
    {
        tipoDessaBatalha = TipoBatalha.SUPLICY;


    }

    public void BatalhaEneas()
    {
        tipoDessaBatalha = TipoBatalha.ENEAS;


    }

    public void BatalhaCirao()
    {
        tipoDessaBatalha = TipoBatalha.CIRAO;


    }
   
    public void BatalhaCunha()
    {
        tipoDessaBatalha = TipoBatalha.CUNHA;


    }

  

    public void VerificaBatalha()
    {
        // ---------- BATALHAS DE DESBLOQUEIO DE PERSONAGEM ----------- //

        if (tipoDessaBatalha == TipoBatalha.DILMA)
        {
            switch (currentState)
            {
                case BattleStates.GANHOU:
                    PlayerPrefs.SetInt("DilmaDesblock", 1);
                    GanhaInflu(100);
                    GanhaVerba(30);
                    break;
            }


        }

        if (tipoDessaBatalha == TipoBatalha.SUPLICY)
        {
            switch (currentState)
            {
                case BattleStates.GANHOU:
                    PlayerPrefs.SetInt("SuplicyDesblock", 1);
                    GanhaInflu(100);
                    GanhaVerba(30);
                    break;
            }


        }

        if (tipoDessaBatalha == TipoBatalha.ENEAS)
        {
            switch (currentState)
            {
                case BattleStates.GANHOU:
                    PlayerPrefs.SetInt("EneasDesblock", 1);
                    GanhaInflu(100);
                    GanhaVerba(30);
                    break;
            }


        }

        if (tipoDessaBatalha == TipoBatalha.CIRAO)
        {
            switch (currentState)
            {
                case BattleStates.GANHOU:
                    PlayerPrefs.SetInt("CiraoDesblock", 1);
                    GanhaInflu(100);
                    GanhaVerba(30);
                    break;
            }


        }

        if (tipoDessaBatalha == TipoBatalha.CUNHA)
        {
            switch (currentState)
            {
                case BattleStates.GANHOU:
                    PlayerPrefs.SetInt("CunhaDesblock", 1);
                    GanhaInflu(100);
                    GanhaVerba(30);
                    break;
            }


        }

        // ------- BATALHAS VARIADAS -------- //

       
        if (tipoDessaBatalha == TipoBatalha.SABATINA)
        {
            switch (currentState)
            {
                case BattleStates.GANHOU:
                    GanhaInflu(100);
                    GanhaVerba(30);
                    break;
            }


        }

        if (tipoDessaBatalha == TipoBatalha.IMPEACHMENT)
        {
            switch (currentState)
            {
                case BattleStates.GANHOU:
                    GanhaInflu(100);
                    GanhaVerba(30);
                    break;

                case BattleStates.PERDEU:
                    

                    if (PlayerPrefs.GetString("Candidato") == "Lula")
                    {
                        PlayerPrefs.SetInt("LevelLula", PlayerPrefs.GetInt("LevelLula") - 1);                  
                    }

                    if (PlayerPrefs.GetString("Candidato") == "Ciro")
                    {
                        PlayerPrefs.SetInt("LevelCiro", PlayerPrefs.GetInt("LevelCiro") - 1);                  
                    }

                    if (PlayerPrefs.GetString("Candidato") == "Bolso")
                    {
                        PlayerPrefs.SetInt("LevelBolso", PlayerPrefs.GetInt("LevelBolso") - 1);                  
                    }

                    if (PlayerPrefs.GetString("Candidato") == "Dilma")
                    {
                        PlayerPrefs.SetInt("LevelDilma", PlayerPrefs.GetInt("LevelDilma") - 1);                  
                    }

                    if (PlayerPrefs.GetString("Candidato") == "Suplicy")
                    {
                        PlayerPrefs.SetInt("LevelSuplicy", PlayerPrefs.GetInt("LevelSuplicy") - 1);                  
                    }

                    if (PlayerPrefs.GetString("Candidato") == "Eneas")
                    {
                        PlayerPrefs.SetInt("LevelEneas", PlayerPrefs.GetInt("LevelEneas") - 1);                  
                    }

                    if (PlayerPrefs.GetString("Candidato") == "Dodorio")
                    {
                        PlayerPrefs.SetInt("LevelDodorio", PlayerPrefs.GetInt("LevelDodorio") - 1);                  
                    }

                    if (PlayerPrefs.GetString("Candidato") == "Haddard")
                    {
                        PlayerPrefs.SetInt("LevelHaddard", PlayerPrefs.GetInt("LevelHaddard") - 1);                  
                    }

                    if (PlayerPrefs.GetString("Candidato") == "Cunha")
                    {
                        PlayerPrefs.SetInt("LevelCunha", PlayerPrefs.GetInt("LevelCunha") - 1);
                    }
                    break;
            }


        }

        // ----------  ----------- //

    }

    public void AvisaBatalha()
    {
        if (PlayerPrefs.GetInt("LevelIndice") == 3 || PlayerPrefs.GetInt("LevelIndice") == 5 || PlayerPrefs.GetInt("LevelIndice") == 8 || PlayerPrefs.GetInt("LevelIndice") == 10)
        {
            avisaBatalha.gameObject.SetActive(true);
            avisaBatalhaTxt.text = "Um novo debate foi desbloqueado!";


        }

        if (PlayerPrefs.GetInt("LevelIndice") != 3 || PlayerPrefs.GetInt("LevelIndice") != 5 || PlayerPrefs.GetInt("LevelIndice") != 8 || PlayerPrefs.GetInt("LevelIndice") != 10)
        {
            avisaBatalha.gameObject.SetActive(false);
            avisaBatalhaTxt.text = " ";


        }
    }
   
   
    public void GanhaInflu(float influ)
    {
        PlayerPrefs.SetFloat("QuantoGanhouInflu", influ);

        if (PlayerPrefs.GetInt("LulaDentroPartido") == 1 && ganhouInfluLula == 0)
        {

            // PlayerPrefs.SetFloat("InfluLula", PlayerPrefs.GetFloat("InfluLula") + influ);
            mainLula.GetComponent<Influencia>().influLula += influ;
            ganhouInfluLula = 1;
        }

        if (PlayerPrefs.GetInt("CiroDentroPartido") == 1 && ganhouInfluCiro == 0)
        {
            mainCiro.GetComponent<Influencia>().influCiro += influ;
            ganhouInfluCiro = 1;
        }

        if (PlayerPrefs.GetInt("BolsoDentroPartido") == 1 && ganhouInfluBolso == 0)
        {
            mainBolso.GetComponent<Influencia>().influBolso += influ;
            ganhouInfluBolso = 1;
        }

        if (PlayerPrefs.GetInt("DilmaDentroPartido") == 1 && ganhouInfluDilma == 0)
        {
            mainDilma.GetComponent<Influencia>().influDilma += influ;
            ganhouInfluDilma = 1;
        }

        if (PlayerPrefs.GetInt("SuplicyDentroPartido") == 1 && ganhouInfluSuplicy == 0)
        {
            mainSuplicy.GetComponent<Influencia>().influSuplicy += influ;
            ganhouInfluSuplicy = 1;
        }

        if (PlayerPrefs.GetInt("EneasDentroPartido") == 1 && ganhouInfluEneas == 0)
        {
            mainEneas.GetComponent<Influencia>().influEneas += influ;
            ganhouInfluEneas = 1;
        }

        if (PlayerPrefs.GetInt("DodorioDentroPartido") == 1 && ganhouInfluDodorio == 0)
        {
            mainDodorio.GetComponent<Influencia>().influDodorio += influ;
            ganhouInfluDodorio = 1;
        }

        if (PlayerPrefs.GetInt("HaddardDentroPartido") == 1 && ganhouInfluHaddard == 0)
        {
            mainHaddard.GetComponent<Influencia>().influHaddard += influ;
            ganhouInfluHaddard = 1;
        }

        if (PlayerPrefs.GetInt("CunhaDentroPartido") == 1 && ganhouInfluCunha == 0)
        {
            mainCunha.GetComponent<Influencia>().influCunha += influ;
            ganhouInfluCunha = 1;
        }
    }

    public void GanhaVerba(int verba)
    {
        PlayerPrefs.SetInt("QuantoGanhouVerba", verba);

        if (ganhouVerba == 0)
        {
            PlayerPrefs.SetInt("Verba", PlayerPrefs.GetInt("Verba") + verba);
            ganhouVerba = 1;
        }
    }

   
    public void CandidatoDessaBatalha()
    {
        if (PlayerPrefs.GetString("Candidato") == "Lula")
        {
            candidatoAtual = "Lula";
        }

        if (PlayerPrefs.GetString("Candidato") == "Bolso")
        {
            candidatoAtual = "Bolso";
        }

        if (PlayerPrefs.GetString("Candidato") == "Ciro")
        {
            candidatoAtual = "Ciro";
        }

        if (PlayerPrefs.GetString("Candidato") == "Dilma")
        {
            candidatoAtual = "Dilma";
        }

        if (PlayerPrefs.GetString("Candidato") == "Suplicy")
        {
            candidatoAtual = "Suplicy";
        }

        if (PlayerPrefs.GetString("Candidato") == "Eneas")
        {
            candidatoAtual = "Eneas";
        }

        if (PlayerPrefs.GetString("Candidato") == "Dodorio")
        {
            candidatoAtual = "Dodorio";
        }

        if (PlayerPrefs.GetString("Candidato") == "Haddard")
        {
            candidatoAtual = "Haddard";
        }

        if (PlayerPrefs.GetString("Candidato") == "Cunha")
        {
            candidatoAtual = "Cunha";
        }
    }

    public void Insignias()
    {
        if (tipoDessaBatalha == TipoBatalha.ELEICAOVEREADOR)
        {
            switch (currentState)
            {
                case BattleStates.GANHOU:
                    // o candidato é definido na classe ConvocaEleicoes
                    GanhaVerba(30);
                    jornalEleicoes.gameObject.GetComponent<Canvas>().enabled = false;
                    GanhaInflu(150f);

                    if (candidatoAtual == "Lula")
                    {
                        PlayerPrefs.SetInt("LulaVereador", 1);
                    }

                    if (candidatoAtual == "Ciro")
                    {
                        PlayerPrefs.SetInt("CiroVereador", 1);
                    }

                    if (candidatoAtual == "Bolso")
                    {
                        PlayerPrefs.SetInt("BolsoVereador", 1);
                    }

                    if (candidatoAtual == "Dilma")
                    {
                        PlayerPrefs.SetInt("DilmaVereador", 1);
                    }

                    if (candidatoAtual == "Suplicy")
                    {
                        PlayerPrefs.SetInt("SuplicyVereador", 1);
                    }

                    if (candidatoAtual == "Eneas")
                    {
                        PlayerPrefs.SetInt("EneasVereador", 1);
                    }

                    if (candidatoAtual == "Dodorio")
                    {
                        PlayerPrefs.SetInt("DodorioVereador", 1);
                    }

                    if (candidatoAtual== "Haddard")
                    {
                        PlayerPrefs.SetInt("HaddardVereador", 1);
                    }

                    if (candidatoAtual == "Cunha")
                    {
                        PlayerPrefs.SetInt("CunhaVereador", 1);
                    }

                    break;
            }
        }


        if (tipoDessaBatalha == TipoBatalha.ELEICAODEPUTADO)
        {
            switch (currentState)
            {
                case BattleStates.GANHOU:

                    GanhaVerba(50);

                    jornalEleicoes.gameObject.GetComponent<Canvas>().enabled = false;
                    GanhaInflu(180f);


                    // o candidato é definido na classe ConvocaEleicoes

                    if (candidatoAtual == "Lula")
                    {
                        PlayerPrefs.SetInt("LulaDeputado", 1);
                    }

                    if (candidatoAtual == "Ciro")
                    {
                        PlayerPrefs.SetInt("CiroDeputado", 1);
                    }

                    if (candidatoAtual == "Bolso")
                    {
                        PlayerPrefs.SetInt("BolsoDeputado", 1);
                    }

                    if (candidatoAtual == "Dilma")
                    {
                        PlayerPrefs.SetInt("DilmaDeputado", 1);
                    }

                    if (candidatoAtual == "Suplicy")
                    {
                        PlayerPrefs.SetInt("SuplicyDeputado", 1);
                    }

                    if (candidatoAtual == "Eneas")
                    {
                        PlayerPrefs.SetInt("EneasDeputado", 1);
                    }

                    if (candidatoAtual == "Dodorio")
                    {
                        PlayerPrefs.SetInt("DodorioDeputado", 1);
                    }

                    if (candidatoAtual == "Haddard")
                    {
                        PlayerPrefs.SetInt("HaddardDeputado", 1);
                    }

                    if (candidatoAtual == "Cunha")
                    {
                        PlayerPrefs.SetInt("CunhaDeputado", 1);
                    }

                    break;
            }
        }

        if (tipoDessaBatalha == TipoBatalha.ELEICAOPREFEITO)
        {
            switch (currentState)
            {
                case BattleStates.GANHOU:

                    GanhaVerba(80);

                    jornalEleicoes.gameObject.GetComponent<Canvas>().enabled = false;
                    GanhaInflu(200f);

                    // o candidato é definido na classe ConvocaEleicoes

                    if (candidatoAtual == "Lula")
                    {
                        PlayerPrefs.SetInt("LulaPrefeito", 1);
                    }

                    if (candidatoAtual == "Ciro")
                    {
                        PlayerPrefs.SetInt("CiroPrefeito", 1);
                    }

                    if (candidatoAtual == "Bolso")
                    {
                        PlayerPrefs.SetInt("BolsoPrefeito", 1);
                    }

                    if (candidatoAtual == "Dilma")
                    {
                        PlayerPrefs.SetInt("DilmaPrefeito", 1);
                    }

                    if (candidatoAtual == "Suplicy")
                    {
                        PlayerPrefs.SetInt("SuplicyPrefeito", 1);
                    }

                    if (candidatoAtual == "Eneas")
                    {
                        PlayerPrefs.SetInt("EneasPrefeito", 1);
                    }

                    if (candidatoAtual == "Dodorio")
                    {
                        PlayerPrefs.SetInt("DodorioPrefeito", 1);
                    }

                    if (candidatoAtual == "Haddard")
                    {
                        PlayerPrefs.SetInt("HaddardPrefeito", 1);
                    }

                    if (candidatoAtual == "Cunha")
                    {
                        PlayerPrefs.SetInt("CunhaPrefeito", 1);
                    }

                    break;
            }
        }

        if (tipoDessaBatalha == TipoBatalha.ELEICAOGOVERNADOR)
        {
            switch (currentState)
            {
                case BattleStates.GANHOU:

                    GanhaVerba(100);

                    jornalEleicoes.gameObject.GetComponent<Canvas>().enabled = false;
                    GanhaInflu(220f);
                    // o candidato é definido na classe ConvocaEleicoes

                    if (candidatoAtual == "Lula")
                    {
                        PlayerPrefs.SetInt("LulaGovernador", 1);
                    }

                    if (candidatoAtual == "Ciro")
                    {
                        PlayerPrefs.SetInt("CiroGovernador", 1);
                    }

                    if (candidatoAtual == "Bolso")
                    {
                        PlayerPrefs.SetInt("BolsoGovernador", 1);
                    }

                    if (candidatoAtual == "Dilma")
                    {
                        PlayerPrefs.SetInt("DilmaGovernador", 1);
                    }

                    if (candidatoAtual == "Suplicy")
                    {
                        PlayerPrefs.SetInt("SuplicyGovernador", 1);
                    }

                    if (candidatoAtual == "Eneas")
                    {
                        PlayerPrefs.SetInt("EneasGovernador", 1);
                    }

                    if (candidatoAtual == "Dodorio")
                    {
                        PlayerPrefs.SetInt("DodorioGovernador", 1);
                    }

                    if (candidatoAtual == "Haddard")
                    {
                        PlayerPrefs.SetInt("HaddardGovernador", 1);
                    }

                    if (candidatoAtual == "Cunha")
                    {
                        PlayerPrefs.SetInt("CunhaGovernador", 1);
                    }

                    break;
            }
        }

        if (tipoDessaBatalha == TipoBatalha.ELEICAOPRESIDENTE)
        {
            switch (currentState)
            {
                case BattleStates.GANHOU:

                    GanhaVerba(120);

                    jornalEleicoes.gameObject.GetComponent<Canvas>().enabled = false;
                    GanhaInflu(300f);
                    // o candidato é definido na classe ConvocaEleicoes

                    if (candidatoAtual == "Lula")
                    {
                        PlayerPrefs.SetInt("LulaPresidente", 1);
                    }

                    if (candidatoAtual == "Ciro")
                    {
                        PlayerPrefs.SetInt("CiroPresidente", 1);
                    }

                    if (candidatoAtual == "Bolso")
                    {
                        PlayerPrefs.SetInt("BolsoPresidente", 1);
                    }

                    if (candidatoAtual == "Dilma")
                    {
                        PlayerPrefs.SetInt("DilmaPresidente", 1);
                    }

                    if (candidatoAtual == "Suplicy")
                    {
                        PlayerPrefs.SetInt("SuplicyPresidente", 1);
                    }

                    if (candidatoAtual == "Eneas")
                    {
                        PlayerPrefs.SetInt("EneasPresidente", 1);
                    }

                    if (candidatoAtual == "Dodorio")
                    {
                        PlayerPrefs.SetInt("DodorioPresidente", 1);
                    }

                    if (candidatoAtual == "Haddard")
                    {
                        PlayerPrefs.SetInt("HaddardPresidente", 1);
                    }

                    if (candidatoAtual == "Cunha")
                    {
                        PlayerPrefs.SetInt("CunhaPresidente", 1);
                    }

                    break;
            }
        }

    } // FIM INSIGNIAS

    public void ResetaGanhouInflu()
    {
        ganhouInfluCiro = 0;
        ganhouInfluLula = 0;
        ganhouInfluBolso = 0;
        ganhouInfluDilma = 0;
        ganhouInfluSuplicy = 0;
        ganhouInfluEneas = 0;
        ganhouInfluDodorio = 0;
        ganhouInfluHaddard = 0;
        ganhouInfluCunha = 0;


    }

    public void ResetaGanhaVerba()
    {
        ganhouVerba = 0;

    }



    // --------------            ------------ //
   
    // -------------- ANIMAÇÕES ------------ //
   
    // --------------            ------------ //


    IEnumerator PiscaPlayer()
    {
        PersonagensScene.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PersonagensScene.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PersonagensScene.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PersonagensScene.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PersonagensScene.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PersonagensScene.gameObject.SetActive(true);


    }

    IEnumerator PiscaInimigo()
    {
        InimigosScene.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        InimigosScene.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        InimigosScene.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        InimigosScene.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        InimigosScene.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        InimigosScene.gameObject.SetActive(true);


    }

    IEnumerator MitouLacrouAviso()
    {

        yield return new WaitForSeconds(1f);
        mitouLacrou_Txt.text = "";

    }

    IEnumerator AumentouApoioMidiaPlayer()
    {
        GanhaMidiaPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaMidiaPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaMidiaPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaMidiaPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaMidiaPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaMidiaPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaMidiaPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaMidiaPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaMidiaPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaMidiaPlayer.gameObject.SetActive(false);
    }

    IEnumerator PerdeuApoioMidiaPlayer()
    {
        PerdeMidiaPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdeMidiaPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdeMidiaPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdeMidiaPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdeMidiaPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdeMidiaPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdeMidiaPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdeMidiaPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdeMidiaPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdeMidiaPlayer.gameObject.SetActive(false);
    }

    IEnumerator PerdeuApoioMidiaInimigo()
    {
        PerdeMidiaInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdeMidiaInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdeMidiaInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdeMidiaInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdeMidiaInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdeMidiaInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdeMidiaInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdeMidiaInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdeMidiaInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdeMidiaInimigo.gameObject.SetActive(false);

    }

    IEnumerator AumentouApoioMidiaInimigo()
    {
        GanhaMidiaInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaMidiaInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaMidiaInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaMidiaInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaMidiaInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaMidiaInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaMidiaInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaMidiaInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaMidiaInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaMidiaInimigo.gameObject.SetActive(false);
    }

    IEnumerator AumentouPopPlayer()
    {
        GanhaPopPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaPopPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaPopPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaPopPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaPopPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaPopPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaPopPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaPopPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaPopPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaPopPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaPopPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaPopPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaPopPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaPopPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaPopPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaPopPlayer.gameObject.SetActive(false);
    }

    IEnumerator PerdeuPopPlayer()
    {
        PerdePopPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdePopPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdePopPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdePopPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdePopPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdePopPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdePopPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdePopPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdePopPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdePopPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdePopPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdePopPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdePopPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdePopPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdePopPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdePopPlayer.gameObject.SetActive(false);
    }

    IEnumerator AumentouPopInimigo()
    {
        GanhaPopInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaPopInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaPopInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaPopInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaPopInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaPopInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaPopInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaPopInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaPopInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaPopInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaPopInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaPopInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaPopInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaPopInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GanhaPopInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GanhaPopInimigo.gameObject.SetActive(false);
    }

    IEnumerator PerdeuPopInimigo()
    {
        PerdePopInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdePopInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdePopInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdePopInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdePopInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdePopInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdePopInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdePopInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdePopInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdePopInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdePopInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdePopInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdePopInimigo.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        PerdePopInimigo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PerdePopInimigo.gameObject.SetActive(false);
    }

    IEnumerator ShakeCamera()
    {
        Camera.main.GetComponent<ShakeCam>().shakeDuration = 1f;
        moveCamera = false;
        yield return new WaitForSeconds(3f);

    }

   
    // ------- SOM ----- //

    public void SonsAtaque()
    {
        int i = Random.Range(0, 3);

        switch (i)
        {
            case 0:
                SomAtaque1.Play();
                break;

            case 1:
                
                SomAtaque2.Play();

                break;

            case 2:

                SomAtaque3.Play();

                break;

            case 3:

                SomAtaque1.Play();

                break;

        }
    }


    // ----------- playerprefs ---------- //

} // FIM DA CLASSE

