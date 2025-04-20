using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class InputFieldUI : MonoBehaviour
{
    public event EventHandler<int> InputFieldUI_OnValueChanged;
    [SerializeField] private Button decreaseButton;
    [SerializeField] private Button increaseButton;

    [SerializeField] private TMP_InputField inputField;
    private void Awake()
    {
        decreaseButton.onClick.AddListener(() =>
        {
            // Decrease the value of the input field
            DecreaseValue();

        });
        increaseButton.onClick.AddListener(() =>
        {
            // Increase the value of the input field
            IncreaseValue();
        });
        inputField.onValueChanged.AddListener((a) =>
        {
            if (int.TryParse(a, out int value))
            {
                value = value > 0 ? value : 0;
                inputField.text = value.ToString();
                if (value > 0)
                    InputFieldUI_OnValueChanged?.Invoke(this, value);
            }
            else
            {
                inputField.text = "0"; // Reset to 0 if the input is not a valid integer
                value = 0;
                InputFieldUI_OnValueChanged?.Invoke(this, value);
            }
        });
        inputField.onEndEdit.AddListener((a) =>
        {
            if (int.TryParse(a, out int value))
            {
                value = value > 0 ? value : 0;
                inputField.text = value.ToString();
                if (value > 0)
                    InputFieldUI_OnValueChanged?.Invoke(this, value);
            }
            else
            {
                inputField.text = "0"; // Reset to 0 if the input is not a valid integer
                value = 0;
                InputFieldUI_OnValueChanged?.Invoke(this, value);
            }
        });
    }
    private void Start()
    {
        inputField.text = "0"; // Initialize the input field with a default value
        PurchaseUI.Instance.OnPurchaseSuccess += PurchaseUI_OnPurchaseSuccess;
    }

    

    private void OnDestroy()
    {
        PurchaseUI.Instance.OnPurchaseSuccess -= PurchaseUI_OnPurchaseSuccess;
        decreaseButton.onClick.RemoveAllListeners();
        increaseButton.onClick.RemoveAllListeners();
        inputField.onValueChanged.RemoveAllListeners();
        inputField.onEndEdit.RemoveAllListeners();
    }

    private void PurchaseUI_OnPurchaseSuccess(object sender, EventArgs e)
    {
        inputField.text = "0"; // Reset the input field when a purchase is made
        InputFieldUI_OnValueChanged?.Invoke(this, 0); // Notify listeners of the reset value
    }


    private void IncreaseValue()
    {
        SoundManager.Instance.PlayCountdownSound();
        if (int.TryParse(inputField.text, out int currentValue))
        {
            currentValue++;
            inputField.text = currentValue.ToString();
        }
    }

    private void DecreaseValue()
    {
        SoundManager.Instance.PlayCountdownSound();
        if (int.TryParse(inputField.text, out int currentValue))
        {
            if (currentValue <= 0)
            {
                return;
            }
            currentValue--;
            inputField.text = currentValue.ToString();
        }
    }

}
