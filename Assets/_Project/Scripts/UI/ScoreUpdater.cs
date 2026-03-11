using TMPro;
using UnityEngine;

namespace Core.UI
{
    public class ScoreUpdater
    {
        [SerializeField] private TMP_Text m_scoreText;
        [SerializeField] private ScoreUpdaterSO m_scoreChannel;

        private void OnEnable()
        {
            m_scoreChannel.OnScoreUpdated += UpdateScoreText;
        }

        private void OnDisable()
        {
            m_scoreChannel.OnScoreUpdated -= UpdateScoreText;
        }

        private void UpdateScoreText(int newScore)
        {
            m_scoreText.text = $"{newScore}";
        }

    }
}
