using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance;

    [Header("Difficulty Settings")]
    public float windStrength = 0f;     
    public bool windTrailsEnabled = false;
    public float poleMoveSpeed = 0f;

    [Header("Wind Trail Prefab")]
    public GameObject windTrails;

    private bool isDifficultySet = false; // Track if user selected a difficulty

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetNormalMode()
    {
        windStrength = 0f;
        windTrailsEnabled = false;
        poleMoveSpeed = 0f;
        isDifficultySet = true;
        ApplyDifficulty();
    }

    public void SetMediumMode()
    {
        windStrength = 0.4f;
        windTrailsEnabled = true;
        poleMoveSpeed = 0f;
        isDifficultySet = true;
        ApplyDifficulty();
    }

    public void SetHardMode()
    {
        windStrength = 0.5f;
        windTrailsEnabled = true;
        poleMoveSpeed = 1f;
        isDifficultySet = true;
        ApplyDifficulty();
    }

    void ApplyDifficulty()
    {
        if (windTrails != null)
            windTrails.SetActive(windTrailsEnabled);
    }

    public void PlayGame()
    {
        if (!isDifficultySet)
            SetNormalMode();

        SceneManager.LoadScene("SampleScene");
    }
}
