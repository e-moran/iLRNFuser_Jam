using System;
using UnityEngine;

public class GameController: MonoBehaviour
{
    public event Action<PlanetSpecification> OnNewRound; // An event to be used to restart the round
    public event Action<int> ScoreChanged;
    
    public SelectorGroup[] selectors;

    private int _score = 0; // TODO implement scoring
    private PlanetSpecification _currPlanetSpecification;

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
}
