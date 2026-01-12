using System;
using UnityEngine;

public class PlayerScore : MonoBehaviour, IRewardable
{
    [SerializeField] private AudioSource coinSound;

    public static event Action<int> OnScoreChanged;
    private int score = 0;

    private void Start()
    {
        score = DataManager.Instance.Score.GetValue();
        OnScoreChanged?.Invoke(score);
    }

    public void AddScore()
    {
        score++;

        DataManager.Instance.Score.SetValue(score);
        DataManager.Instance.Score.Save();

        OnScoreChanged?.Invoke(score);
        coinSound?.PlayOneShot(coinSound?.clip);
    }
}