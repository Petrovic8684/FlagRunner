using UnityEngine;

public class ScoreDisplay : HUDElement<int>
{
    private void OnEnable()
    {
        PlayerScore.OnScoreChanged += UpdateText;
    }

    private void OnDisable()
    {
        PlayerScore.OnScoreChanged -= UpdateText;
    }
}