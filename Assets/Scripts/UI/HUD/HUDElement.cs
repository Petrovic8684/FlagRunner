using UnityEngine;
using TMPro;

public abstract class HUDElement<T> : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI elementText;

    protected void UpdateText(T newValue)
    {
        elementText.text = newValue.ToString();
    }
}