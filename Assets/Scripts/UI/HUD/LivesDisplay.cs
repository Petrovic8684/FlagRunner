using UnityEngine;

public class LivesDisplay : HUDElement<int>
{
    private void OnEnable()
    {
        PlayerHealth.OnLivesChanged += UpdateText;
    }

    private void OnDisable()
    {
        PlayerHealth.OnLivesChanged -= UpdateText;
    }
}