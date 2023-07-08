using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRun_GameManager : MonoBehaviour
{
    public static InfiniteRun_GameManager Instance;
    public enum GameStates { titulo, juego, pausa, reiniciado, game_over }
    public GameStates state;
    [Space(20)]
    [Header("Global Values")]
    [Space(10)]
    public int plusScore = 5;
    public GameObject coin;
    int currentscore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
            switch (state)
        {
            case GameStates.titulo:
                break;
            case GameStates.juego:
                GainScore();
                break;
            case GameStates.pausa:
                break;
            case GameStates.reiniciado:
                ResetAllValues();
                break;
            case GameStates.game_over:
                break;
        }

    }

    public void GainScore()
    {
        currentscore = currentscore + plusScore;
    }

    public void ResetAllValues()
    {
        currentscore = 0;
        MenuManager.instance.RefrescarPuntajeActual(currentscore);
    }


}
