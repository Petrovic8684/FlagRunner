using System;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static event Action OnScoreChanged;
    private static int score = 0;

    public static int Score => score;

    private void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        OnScoreChanged?.Invoke();
    }

    public void AddScore()
    {
        score += 1;
        OnScoreChanged?.Invoke();
    }
}
