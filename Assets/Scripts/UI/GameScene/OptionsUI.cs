using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }
    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button moveUpButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button interactAlternateButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button gamepadInteractButton;
    [SerializeField] private Button GamepadInteractAlternateButton;
    [SerializeField] private Button GamepadPauseButton;
    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private TextMeshProUGUI musicText;
    [SerializeField] private TextMeshProUGUI moveUpText;
    [SerializeField] private TextMeshProUGUI moveDownText;
    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI moveRightText;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI interactAlternateText;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private TextMeshProUGUI gamepadInteractText;
    [SerializeField] private TextMeshProUGUI gamepadInteractAlternateText;
    [SerializeField] private TextMeshProUGUI gamepadPauseText;
    [SerializeField] private Transform pressToRebindKeyTransform;


    private Action onCloseButtonAction;

    private void Awake()
    {
        Instance = this;
        soundEffectsButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        musicButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        closeButton.onClick.AddListener(() =>
        {
            Hide();
            onCloseButtonAction();
        });
        moveUpButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_Up);
        });
        moveDownButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_Down);
        });
        moveLeftButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_Left);
        });
        moveRightButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_Right);
        });
        interactButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Interact);
        });
        interactAlternateButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.InteractAlternate);
        });
        pauseButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Pause);
        });
    }
    private void Start()
    {
        KitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;
        UpdateVisual();
        Hide();
        HidePressToRebindKey();
    }
    private void OnDestroy()
    {
        KitchenGameManager.Instance.OnGameUnpaused -= KitchenGameManager_OnGameUnpaused;
        soundEffectsButton.onClick.RemoveAllListeners();
        musicButton.onClick.RemoveAllListeners();
        closeButton.onClick.RemoveAllListeners();
        moveUpButton.onClick.RemoveAllListeners();
        moveDownButton.onClick.RemoveAllListeners();
        moveLeftButton.onClick.RemoveAllListeners();
        moveRightButton.onClick.RemoveAllListeners();
        interactButton.onClick.RemoveAllListeners();
        interactAlternateButton.onClick.RemoveAllListeners();
        pauseButton.onClick.RemoveAllListeners();
    }

    private void KitchenGameManager_OnGameUnpaused(object sender, EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual()
    {
        soundEffectsText.text = "Sound Effects: " + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        musicText.text = "Music: " + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);
        moveUpText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.Move_Up);
        moveDownText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.Move_Down);
        moveLeftText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.Move_Left);
        moveRightText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.Move_Right);
        interactText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.Interact);
        interactAlternateText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.InteractAlternate);
        pauseText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.Pause);
        ChangeFontSize(pauseText);
        gamepadInteractText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.Gamepad_Interact);
        gamepadInteractAlternateText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.Gamepad_InteractAlternate);
        gamepadPauseText.text = GameInput.Instance.GetBingdingText(GameInput.Binding.Gamepad_Pause);
        ChangeFontSize(gamepadPauseText);
    }
    public void Show(Action onCloseButtonAction)
    {
        this.onCloseButtonAction = onCloseButtonAction;
        gameObject.SetActive(true);
        soundEffectsButton.Select();
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    private void ShowPressToRebindKey(GameInput.Binding binding)
    {
        pressToRebindKeyTransform.gameObject.SetActive(true);
    }

    private void HidePressToRebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(false);
    }
    private void RebindBinding(GameInput.Binding binding)
    {

        ShowPressToRebindKey(binding);
        GameInput.Instance.RebindBinding(binding, () =>
        {
            HidePressToRebindKey();
            UpdateVisual();
        });

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
