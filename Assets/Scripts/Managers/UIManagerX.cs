using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagerX : MonoBehaviour
{
    static public UIManagerX instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    [Header("GameObjects")]
    public GameObject m_InGameScore;
    public GameObject m_GameOverPanel;

    [Header("Scores")]
    public TextMeshProUGUI m_InGameScoreText;
    public TextMeshProUGUI m_GameOverScoreText;

    //private
    private int score = 0;

    void Start()
    {
        m_GameOverPanel.SetActive(false);

        m_InGameScoreText.text = $"Score: {score}";
    }

    /// <summary>
    /// Add and update the score on the UI.
    /// </summary>
    /// <param name="_amount">The amount of score added (default = 1)</param>
    public void AddScore(int _amount = 1)
    {
        score += _amount;

        m_InGameScoreText.text = $"Score: {score}";
    }

    /// <summary>
    /// Set everything in the UI to the correct state for a gameover.
    /// </summary>
    public void SetGameOver()
    {
        m_InGameScore.SetActive(false);
        m_GameOverPanel.SetActive(true);

        m_GameOverScoreText.text = $"Score: {score}";
    }

    /// <summary>
    /// Return the current score.
    /// </summary>
    /// <returns></returns>
    public int GetScore()
    {
        return score;
    }
}
