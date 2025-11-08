using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;

    private void Start()
    {
        UpdateLives();
        UpdateScore();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        PlayerHealth.OnLivesChanged += UpdateLives;
        PlayerScore.OnScoreChanged += UpdateScore;
    }

    private void OnDisable()
    {
        PlayerHealth.OnLivesChanged -= UpdateLives;
        PlayerScore.OnScoreChanged -= UpdateScore;
    }

    private void UpdateLives()
    {
        livesText.text = PlayerHealth.Lives.ToString();
    }

    private void UpdateScore()
    {
        scoreText.text = PlayerScore.Score.ToString();
    }
}
