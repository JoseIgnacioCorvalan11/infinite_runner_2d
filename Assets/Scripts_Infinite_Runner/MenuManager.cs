using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    [Header("Feedback")]
    [SerializeField] TextMeshProUGUI puntajeActual;

    [Space(10)]
    public GameObject titulo;
    public GameObject interfazJuego;
    public GameObject menuPausa;
    public GameObject finJuego;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //metodo de refrescar puntaje 
    public void RefrescarPuntajeActual(int puntaje)
    {
        puntajeActual.text = "Puntacion: " + puntaje.ToString();
    }

    private void Start()
    {
        InfiniteRun_GameManager.Instance.state = InfiniteRun_GameManager.GameStates.titulo;

        titulo.SetActive(true);
        interfazJuego.SetActive(false);
        menuPausa.SetActive(false);
        finJuego.SetActive(false);
    }

    public void RunnerEmpieza()
    {
        if (InfiniteRun_GameManager.Instance.state != InfiniteRun_GameManager.GameStates.titulo) return;
        InfiniteRun_GameManager.Instance.state = InfiniteRun_GameManager.GameStates.juego;
        InfiniteRun_GameManager.Instance.ResetAllValues();
        titulo.SetActive(false);
        interfazJuego.SetActive(true);
        menuPausa.SetActive(false);
        finJuego.SetActive(false);
    }

    public void RunnerPausado()
    {
        if (InfiniteRun_GameManager.Instance.state != InfiniteRun_GameManager.GameStates.juego) return;
        InfiniteRun_GameManager.Instance.state = InfiniteRun_GameManager.GameStates.pausa;
        titulo.SetActive(false);
        interfazJuego.SetActive(true);
        menuPausa.SetActive(true);
        finJuego.SetActive(false);
    }

    public void RunnerReiniciado()
    {
        if (InfiniteRun_GameManager.Instance.state != InfiniteRun_GameManager.GameStates.pausa) return;
        InfiniteRun_GameManager.Instance.state = InfiniteRun_GameManager.GameStates.juego;
        InfiniteRun_GameManager.Instance.ResetAllValues();
        titulo.SetActive(false);
        interfazJuego.SetActive(true);
        menuPausa.SetActive(false);
        finJuego.SetActive(false);

    }

    public void RunnerReanudo() 
    {
        if (InfiniteRun_GameManager.Instance.state != InfiniteRun_GameManager.GameStates.pausa) return;
        InfiniteRun_GameManager.Instance.state = InfiniteRun_GameManager.GameStates.juego;
        titulo.SetActive(false);
        interfazJuego.SetActive(true);
        menuPausa.SetActive(false);
        finJuego.SetActive(false);
    }

    public void RunnerTerminado()
    {
        if (InfiniteRun_GameManager.Instance.state != InfiniteRun_GameManager.GameStates.juego && CharacterScript.instance.state == CharacterScript.CharacterStates.Death) return;
        InfiniteRun_GameManager.Instance.state = InfiniteRun_GameManager.GameStates.game_over;
        titulo.SetActive(false);
        interfazJuego.SetActive(false);
        menuPausa.SetActive(false);
        finJuego.SetActive(true);
    }

    public void RunnerOtroIntento()
    {
        InfiniteRun_GameManager.Instance.state = InfiniteRun_GameManager.GameStates.juego;
        titulo.SetActive(false);
        interfazJuego.SetActive(true);
        menuPausa.SetActive(false);
        finJuego.SetActive(false);

    }

    public void OnApplicationQuit()
    {
        Debug.Log("Application has been Quit");
    }

}
