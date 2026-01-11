using StarterAssets;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public static event Action OnLevelChangeStarted;
    public static event Action OnLevelChangeEnded;

    [SerializeField] private AudioSource changeSound;
    [SerializeField] private Animator darknessAnimator;

    private void OnEnable()
    {
        PlayerHealth.OnRespawnNeeded += RestartDarknessAnimator;
    }

    private void OnDisable()
    {
        PlayerHealth.OnRespawnNeeded -= RestartDarknessAnimator;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        OnLevelChangeStarted?.Invoke();

        RestartDarknessAnimator(Vector3.zero);
        darknessAnimator.Play("BlacknessFadeReverse", 0, 0f);

        changeSound.Play();
        StartCoroutine(ChangeLevelAfterDelay(1.05f));
    }

    private void RestartDarknessAnimator(Vector3 _)
    {
        darknessAnimator.Rebind();
        darknessAnimator.Update(0f);
    }

    private IEnumerator ChangeLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        darknessAnimator.speed = 1f;
        OnLevelChangeEnded?.Invoke();

        GameManager.Instance.LoadNextScene();
    }
}
