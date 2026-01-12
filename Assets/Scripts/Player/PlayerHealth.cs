using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float fallHeight = -5f;
    [SerializeField] private AudioSource lifeSound;
    [SerializeField] private AudioSource deathSound;

    public static event Action<int> OnLivesChanged;
    public static event Action<Vector3> OnRespawnNeeded;

    private int lives;
    private Vector3 spawnPoint;

    private void Start()
    {
        lives = DataManager.Instance.Lives.GetValue();
        OnLivesChanged?.Invoke(lives);

        spawnPoint = transform.position;
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

        deathSound?.PlayOneShot(deathSound?.clip);
        OnRespawnNeeded?.Invoke(spawnPoint);
    }

    public void GainLife()
    {
        if (lives <= 0) return;

        lives++;

        DataManager.Instance.Lives.SetValue(lives);
        DataManager.Instance.Lives.Save();

        OnLivesChanged?.Invoke(lives);
        lifeSound?.PlayOneShot(lifeSound?.clip);
    }
}