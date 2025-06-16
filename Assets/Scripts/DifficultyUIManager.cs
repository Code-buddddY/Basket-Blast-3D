using UnityEngine;
using UnityEngine.UI;

public class DifficultyUIManager : MonoBehaviour
{
    public Button normalButton;
    public Button mediumButton;
    public Button hardButton;
    public Button playButton;

    void Start()
    {
        // Link buttons dynamically to DifficultyManager methods
        normalButton.onClick.AddListener(() => DifficultyManager.Instance.SetNormalMode());
        mediumButton.onClick.AddListener(() => DifficultyManager.Instance.SetMediumMode());
        hardButton.onClick.AddListener(() => DifficultyManager.Instance.SetHardMode());
        playButton.onClick.AddListener(() => DifficultyManager.Instance.PlayGame());
    }
}
