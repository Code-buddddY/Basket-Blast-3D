using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections;


public class ScoreManager : MonoBehaviour
{
    public int score = 0;                 // Player's current score
    public float gameTime = 60f;          // Total game time in seconds

    public TMP_Text scoreText;            // UI text element to display score
    public TMP_Text timerText;            // UI text element to display timer
    public GameObject endGamePanel;       // UI panel shown at the end of the game
    public TMP_Text finalScoreText;       // UI text element to display final score

    public TMP_Text scoreMessageText;     // Reference to the "Wow!" text message for scoring feedback

    private bool isGameActive = true;     // Flag to track if the game is currently active or ended

    public PoleMover poleMover;
    void Update()
    {
        // Only update timer and UI if the game is active
        if (isGameActive)
        {
            gameTime -= Time.deltaTime;   // Decrease game timer by the time passed since last frame
            UpdateUI();                   // Update score and timer display

            // Check if time has run out
            if (gameTime <= 0)
            {
                gameTime = 0;             // Clamp timer to zero
                isGameActive = false;     // Mark game as ended
                EndGame();                // Trigger end game sequence
            }
        }
    }

    // Method to trigger the score message display coroutine
    void ShowScoreMessage()
    {
        StartCoroutine(ShowMessageCoroutine());
    }

    // Coroutine to show the score message ("Wow!") for 2 seconds then hide it
    IEnumerator ShowMessageCoroutine()
    {
        scoreMessageText.gameObject.SetActive(true);  // Show the message
        yield return new WaitForSeconds(2f);           // Wait for 2 seconds
        scoreMessageText.gameObject.SetActive(false); // Hide the message
    }

    // Public method to add to the player's score

    public void AddScore(int amount)
    {
        if (isGameActive)
        {
            score += amount;
            UpdateUI();
            ShowScoreMessage();

            // Move pole to random X in normal and medium
            if (poleMover != null)
            {
                poleMover.MoveToRandomX();
            }
        }
    }


    // Update the score and timer text on the UI
    void UpdateUI()
    {
        scoreText.text = "Score: " + score;                 // Display current score
        timerText.text = "Time: " + Mathf.CeilToInt(gameTime) + "s"; // Display remaining time rounded up
    }

    // Handle end of the game: show end panel, unlock cursor, and disable camera movement
    void EndGame()
    {
        endGamePanel.SetActive(true);                        // Show end game UI panel
        finalScoreText.text = "Your Score: " + score;       // Display final score on end panel

        Cursor.lockState = CursorLockMode.None;              // Unlock the mouse cursor
        Cursor.visible = true;                                // Make the cursor visible

        // Disable player camera movement by finding MouseLook script and setting its gameActive flag to false
        FindObjectOfType<MouseLook>().isGameActive = false;
    }

    // Restart the current scene to replay the game
    public void RestartGame()
    {
        Debug.Log("RestartGame called");                      // Log restart action
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }

    // Go back to the Main Menu scene
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("UI"); 
    }

    // Quit the application/game
    public void ExitGame()
    {
        Debug.Log("ExitGame called");                         // Log exit action
        Application.Quit();                                   // Close the application (works only in build)
    }
    
    

}
