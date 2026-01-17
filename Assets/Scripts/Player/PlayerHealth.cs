using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float fallHeight = -5f;

    public static event Action<int> OnLivesChanged;
    public static event Action OnRespawnNeeded;

    private int lives;

    private void Start()
    {
        lives = DataManager.Instance.Lives.GetValue();
        OnLivesChanged?.Invoke(lives);
    }

    private void Update()
    {
        if (transform.position.y <= fallHeight)
            LoseLife();
    }

    public void LoseLife()
    {
        lives--;

        DataManager.Instance.Lives.SetValue(lives);
        DataManager.Instance.Lives.Save();

        OnLivesChanged?.Invoke(lives);

        if (lives <= 0)
        {
            DataManager.Instance.ResetAll();

            GameManager.Instance.LoadScene("MenuScene");
            CursorManager.Instance.ShowCursor();

            return;
        }

        AudioManager.Instance.Play(SoundType.Death);
        OnRespawnNeeded?.Invoke();
    }

    public void GainLife()
    {
        if (lives <= 0) return;

        lives++;

        DataManager.Instance.Lives.SetValue(lives);
        DataManager.Instance.Lives.Save();

        OnLivesChanged?.Invoke(lives);
        AudioManager.Instance.Play(SoundType.Life);
    }
}