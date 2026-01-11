using System;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private AudioSource coinSound;

    public static event Action<int> OnScoreChanged;
    private int score = 0;

    private void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        OnScoreChanged?.Invoke(score);
    }

    public void AddScore()
    {
        score += 1;
        OnScoreChanged?.Invoke(score);
        PlayerPrefs.SetInt("score", score);

        coinSound.PlayOneShot(coinSound.clip);
    }
}