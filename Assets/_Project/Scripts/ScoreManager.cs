using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    private int m_score;
    [SerializeField] private ScoreUpdaterSO m_scoreChannel;


    public void AddScore(int points)
    {
        m_score += points;
        m_scoreChannel.RaiseScore(m_score);
    }
}


