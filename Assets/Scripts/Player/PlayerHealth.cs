using System;
using UnityEngine;
using StarterAssets;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startLives = 3;
    [SerializeField] private float fallHeight = -5f;
    [SerializeField] private AudioSource lifeSound;
    [SerializeField] private AudioSource deathSound;

    public static event Action<int> OnLivesChanged;
    public static event Action<Vector3> OnRespawnNeeded;

    private int lives;
    private Vector3 spawnPoint;

    private void Start()
    {
        lives = PlayerPrefs.GetInt("lives", startLives);
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
        OnLivesChanged?.Invoke(lives);
        PlayerPrefs.SetInt("lives", lives);

        if (lives <= 0)
        {
            PlayerPrefs.SetInt("lives", startLives);
            PlayerPrefs.SetInt("score", 0);

            GameManager.Instance.LoadScene("MenuScene");
            CursorManager.Instance.ShowCursor();

            return;
        }

        deathSound.PlayOneShot(deathSound.clip);
        OnRespawnNeeded?.Invoke(spawnPoint);
    }

    public void GainLife()
    {
        if (lives <= 0) return;

        lives++;
        OnLivesChanged?.Invoke(lives);
        PlayerPrefs.SetInt("lives", lives);

        lifeSound.PlayOneShot(lifeSound.clip);
    }
}