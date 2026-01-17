using System;
using System.Collections;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public static event Action OnLevelChangeStarted;
    public static event Action OnLevelChangeEnded;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        OnLevelChangeStarted?.Invoke();

        AudioManager.Instance.Play(SoundType.LevelChange);
        StartCoroutine(ChangeLevelAfterDelay(1.05f));
    }

    private IEnumerator ChangeLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        OnLevelChangeEnded?.Invoke();
        GameManager.Instance.LoadNextScene();
    }
}
