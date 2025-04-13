using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyMoveUpText;
    [SerializeField] private TextMeshProUGUI keyMoveDownText;
    [SerializeField] private TextMeshProUGUI keyMoveLeftText;
    [SerializeField] private TextMeshProUGUI keyMoveRightText;
    [SerializeField] private TextMeshProUGUI keyInteractText;
    [SerializeField] private TextMeshProUGUI keyInteractAlternateText;
    [SerializeField] private TextMeshProUGUI keyPauseText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractAlternateText;
    [SerializeField] private TextMeshProUGUI keyGamepadPauseText;
    private void Start()
    {
        GameInput.Instance.OnBindingRebind += GameInput_OnBindingRebind;
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
        UpdateVisual();
        Show();
    }

    private void KitchenGameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (KitchenGameManager.Instance.IsCountdownToStartActive())
        {
            Hide();
        }
    }

    private void GameInput_OnBindingRebind(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        keyMoveUpText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.Move_Up);
        keyMoveDownText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.Move_Down);
        keyMoveLeftText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.Move_Left);
        keyMoveRightText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.Move_Right);
        keyInteractText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.Interact);
        keyInteractAlternateText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.InteractAlternate);
        keyPauseText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.Pause);
        ChangeFontSize(keyPauseText);
        keyGamepadInteractText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.Gamepad_Interact);
        keyGamepadInteractAlternateText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.Gamepad_InteractAlternate);
        keyGamepadPauseText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.Gamepad_Pause);
        ChangeFontSize(keyGamepadPauseText);
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    private void ChangeFontSize(TextMeshProUGUI textMeshPro)
    {
        float fontSize = textMeshPro.fontSize;
        if (textMeshPro.text.Length > 3)
        {
            if (textMeshPro.text == "Escape")
            {
                textMeshPro.text = "Esc";
            }
            else
            {
                textMeshPro.fontSize = fontSize / (textMeshPro.text.Length - 2) + 7.5f;
            }
        }
    }
}
