using UnityEngine;

public class DarknessEffect : MonoBehaviour
{
    [SerializeField] private Animator darknessAnimator;

    private void OnEnable()
    {
        LevelChanger.OnLevelChangeStarted += RestartDarknessAnimator;
        LevelChanger.OnLevelChangeStarted += PlayDarkness;
        LevelChanger.OnLevelChangeEnded += InitDarknessAnimatorSpeed;
        PlayerHealth.OnRespawnNeeded += RestartDarknessAnimator;
    }

    private void OnDisable()
    {
        PlayerHealth.OnRespawnNeeded -= RestartDarknessAnimator;
        LevelChanger.OnLevelChangeStarted -= RestartDarknessAnimator;
        LevelChanger.OnLevelChangeStarted -= PlayDarkness;
        LevelChanger.OnLevelChangeEnded -= InitDarknessAnimatorSpeed;
    }

    private void PlayDarkness()
    {
        darknessAnimator?.Play("BlacknessFadeReverse", 0, 0f);
    }

    private void RestartDarknessAnimator()
    {
        darknessAnimator?.Rebind();
        darknessAnimator?.Update(0f);
    }

    private void InitDarknessAnimatorSpeed()
    {
        darknessAnimator.speed = 1f;
    }
}
