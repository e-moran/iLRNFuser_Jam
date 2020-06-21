using System;
using System.Collections;
using UnityEngine;

public class GameController: MonoBehaviour
{
    public event Action<PlanetSpecification> OnNewRound; // An event to be used to restart the round
    public event Action<int> ScoreChanged;
    public event Action<int> TimeRemainingChanged;
    public event Action OnNewGame;
    public SelectorGroup[] selectors;
    public int time = 60; // Time for one round in seconds
    public GameObject menu;
    public UiMenuScore uiPreviousScore;
    public UiMenuScore uiHighScore;

    public bool GameActive => _timeRemaining > 0;
    public int RemainingTime => _timeRemaining;
    public int PreviousRoundScore { get; private set; }
    public int HighScore { get; private set; }

    private int _score = 0;
    private PlanetSpecification _currPlanetSpecification;
    private int _timeRemaining;

    void Awake()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        Debug.Log(HighScore);
    }

    public void NewGame()
    {
        if (GameActive)
        {
            Debug.Log("Game already running.");
            return;
        }
        
        _timeRemaining = time;
        
        menu.SetActive(false);
        NewRound();
        StartCoroutine(GameTimer());
        OnNewGame?.Invoke();
    }

    private void EndGame()
    {
        if (_score > HighScore)
        {
            HighScore = _score;
            PlayerPrefs.SetInt("HighScore", HighScore);
            uiHighScore.UpdateScore(HighScore);
        }

        PreviousRoundScore = _score;
        uiPreviousScore.UpdateScore(PreviousRoundScore);
        menu.SetActive(true);
    }

    public void NewRound()
    {
        _currPlanetSpecification = new PlanetSpecification();
        OnNewRound?.Invoke(_currPlanetSpecification);
    }

    public void EndRound()
    {
        bool wonRound = _currPlanetSpecification.ValidateEntry(GetValuesFromSelectors());
        
        if (wonRound)
        {
            _score++;
            ScoreChanged?.Invoke(_score);
        }
        
        NewRound();
    }

    private int[] GetValuesFromSelectors()
    {
        int[] values = new int[selectors.Length];
        
        for (int i = 0; i < selectors.Length; i++)
        {
            values[i] = selectors[i].Selected;
        }

        return values;
    }

    IEnumerator GameTimer()
    {
        while (_timeRemaining > 0)
        {
            yield return new WaitForSeconds(1);
            _timeRemaining--;
            TimeRemainingChanged?.Invoke(_timeRemaining);
        }
        
        EndGame();
    }
}
