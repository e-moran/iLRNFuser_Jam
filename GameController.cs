using System;
using System.Collections;
using UnityEngine;

public class GameController: MonoBehaviour
{
    public event Action<PlanetSpecification> OnNewRound; // An event to be used to restart the round
    public event Action<int> ScoreChanged;
    public event Action<int> TimeRemainingChanged;
    public SelectorGroup[] selectors;
    public int time = 60; // Time for one round in seconds

    public bool GameActive => _timeRemaining > 0;
    public int RemainingTime => _timeRemaining;

    private int _score = 0; // TODO implement scoring
    private PlanetSpecification _currPlanetSpecification;
    private int _timeRemaining;

    private void Awake()
    {
        _timeRemaining = time; // Calling this in awake so it's set before the UI draws the initial time
    }

    void Start()
    {
        StartCoroutine(GameTimer()); // Calling this when the scene loads
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
    }
}
