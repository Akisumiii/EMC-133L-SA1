using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI References")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject gameOverPanel;
    public GameObject congratsPanel;

    [Header("Game Settings")]
    public int lives = 3;
    public int score = 0;
    public int scoreToWin = 10;

    void Awake()
    {
        Instance = this;

        if (gameOverPanel != null)
        { 
            gameOverPanel.SetActive(false);
        }
        if (congratsPanel != null) 
        { 
            congratsPanel.SetActive(false); 
        }
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;

        if (score >= scoreToWin)
        {
            Congratulations();
        }
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    void Congratulations()
    {
        if (congratsPanel != null)
            congratsPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadNextLevel(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
