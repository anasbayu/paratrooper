using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    int score;
    public TMP_Text scoreText;
    public TMP_Text highScoreText; // at the game over screen
    public TMP_Text currentScoreText;   // at the game over screen

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        score = 0;
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
            currentScoreText.text = score.ToString();
        }
        else
        {
            Debug.LogWarning("ScoreText not found in the scene.");
        }
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    public void CalculateEndGameScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
            highScoreText.text = score.ToString();
        }
    }
}
