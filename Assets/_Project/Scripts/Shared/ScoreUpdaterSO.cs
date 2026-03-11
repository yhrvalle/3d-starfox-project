using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ScoreUpdaterSO", menuName = "Core/ScoreChannel")]
public class ScoreUpdaterSO : ScriptableObject
{
    public Action<int> OnScoreUpdated;
    public void RaiseScore(int newScore)
    {
        OnScoreUpdated?.Invoke(newScore);
    }
}
