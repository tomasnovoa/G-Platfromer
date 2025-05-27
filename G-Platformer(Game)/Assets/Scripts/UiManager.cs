using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    [Header("General UI Panels")]
    public GameObject mainMenuPanel;
    public GameObject pauseMenuPanel;
    public GameObject gameUIPanel;
   
    public GameObject settingsPanel;

    [Header("Text Elements")]
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public TMP_Text timerText;

    [Header("Sliders")]
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    [Header("Audio Feedback")]
    public AudioSource uiAudioSource;
    public AudioClip clickSound;
    public AudioClip hoverSound;

    [Header("Other Elements")]
    public GameObject loadingSpinner;
    public GameObject fadeOverlay;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        UpdateVolumeUI();
    }

    #region Panel Management

    public void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void HidePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void HideAllPanels()
    {
        GameObject[] panels = { mainMenuPanel, pauseMenuPanel, gameUIPanel, settingsPanel };
        foreach (GameObject panel in panels)
        {
            if (panel != null) panel.SetActive(false);
        }
    }

    #endregion

    #region UI Text Updates

    public void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = $"Score: {score}";
    }

    public void UpdateHighScore(int highScore)
    {
        if (highScoreText != null)
            highScoreText.text = $"High Score: {highScore}";
    }

    public void UpdateTimer(float time)
    {
        if (timerText != null)
            timerText.text = $"Time: {time:0.0}s";
    }

    #endregion

    #region Audio UI

    public void PlayClickSound()
    {
        if (uiAudioSource != null && clickSound != null)
            uiAudioSource.PlayOneShot(clickSound);
    }

    public void PlayHoverSound()
    {
        if (uiAudioSource != null && hoverSound != null)
            uiAudioSource.PlayOneShot(hoverSound);
    }

    #endregion

    #region Volume Control

    public void OnMusicVolumeChanged(float value)
    {
        AudioManager.Instance.SetMusicVolume(value); // Requiere un AudioManager
    }

    public void OnSFXVolumeChanged(float value)
    {
        AudioManager.Instance.SetSFXVolume(value); // Requiere un AudioManager
    }

    public void UpdateVolumeUI()
    {
        if (musicVolumeSlider != null)
            musicVolumeSlider.value = AudioManager.Instance.GetMusicVolume();
        if (sfxVolumeSlider != null)
            sfxVolumeSlider.value = AudioManager.Instance.GetSFXVolume();
    }

    #endregion

    #region Loading / Transition

    public void ShowLoadingSpinner(bool show)
    {
        if (loadingSpinner != null)
            loadingSpinner.SetActive(show);
    }

    public void ShowFadeOverlay(bool show)
    {
        if (fadeOverlay != null)
            fadeOverlay.SetActive(show);
    }

    #endregion
}
