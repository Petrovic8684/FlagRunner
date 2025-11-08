using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startLives = 3;
    [SerializeField] private Animator darknessAnimator;

    public static event Action OnLivesChanged;

    private static int lives;
    public static int Lives => lives;

    private Vector3 spawnPoint;
    private ThirdPersonController controller;

    private void Awake()
    {
        controller = GetComponent<ThirdPersonController>();
    }

    private void Start()
    {
        lives = PlayerPrefs.GetInt("lives", startLives);
        OnLivesChanged?.Invoke();

        spawnPoint = transform.position;
    }

    private void Update()
    {
        if (transform.position.y <= -5f)
            TakeDamage();
    }

    public void TakeDamage()
    {
        lives--;
        OnLivesChanged?.Invoke();

        darknessAnimator.Rebind();
        darknessAnimator.Update(0f);

        if (lives <= 0)
        {
            PlayerPrefs.SetInt("lives", startLives);
            PlayerPrefs.SetInt("score", 0);

            SceneManager.LoadScene("MenuScene");
            return;
        }

        controller.RespawnAt(spawnPoint);
    }

    public void GainLife()
    {
        if (lives <= 0) return;

        lives++;
        OnLivesChanged?.Invoke();
    }
}
