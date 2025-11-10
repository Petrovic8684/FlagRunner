using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnder : MonoBehaviour
{
    [SerializeField] private AudioSource endSound;

    private ThirdPersonController controller;
    private Animator darknessAnimator;

    private void Awake()
    {
        darknessAnimator = GameObject.Find("BlacknessCanvas/Blackness").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;

        controller = other.gameObject.GetComponentInChildren<ThirdPersonController>();
        if (controller != null)
            controller.enabled = false;

        PlayerPrefs.SetInt("lives", PlayerHealth.Lives);
        PlayerPrefs.SetInt("score", PlayerScore.Score);

        darknessAnimator.Rebind();
        darknessAnimator.Update(0f);

        darknessAnimator.Play("BlacknessFadeReverse", 0, 0f);

        endSound.PlayOneShot(endSound.clip);
        Invoke("LoadNextScene", 1.05f);
    }

    private void LoadNextScene()
    {
        darknessAnimator.speed = 1f;

        if (controller != null)
            controller.enabled = true;

        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }
}
