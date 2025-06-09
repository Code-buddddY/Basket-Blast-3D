using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIManager : MonoBehaviour
{
    public Button playButton;
    public Button normalButton;
    public Button mediumButton;
    public Button hardButton;

    void Start()
    {
        // Reconnect button actions (in case they break after scene reload)
        playButton.onClick.AddListener(() => DifficultyManager.Instance.PlayGame());
        normalButton.onClick.AddListener(() => DifficultyManager.Instance.SetNormalMode());
        mediumButton.onClick.AddListener(() => DifficultyManager.Instance.SetMediumMode());
        hardButton.onClick.AddListener(() => DifficultyManager.Instance.SetHardMode());
    }
}
