using TMPro;
using UnityEngine;

namespace Core.UI
{
    public class DialogueLines : MonoBehaviour
    {
        [SerializeField] private string[] m_lines;
        [SerializeField] private TMP_Text m_textBox;

        private int m_currentLineIndex = 0;

        public void ShowNextLine()
        {
            m_currentLineIndex++;
            m_textBox.text = m_lines[m_currentLineIndex];
        }
    }
}
