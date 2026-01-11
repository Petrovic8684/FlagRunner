using UnityEngine;
using TMPro;
using System;
using System.Threading.Tasks;

public abstract class HUDElement<T> : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI elementText;

    protected void UpdateText(T newValue)
    {
        elementText.text = newValue.ToString();
    }
}