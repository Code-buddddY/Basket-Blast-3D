using System.Collections.Generic;
using UnityEngine;

public class HoopTrigger : MonoBehaviour
{
    public enum TriggerType { Upper, Lower }
    public TriggerType triggerType;

    public ScoreManager scoreManager;

    // Keep track of which balls entered which trigger
    private static HashSet<GameObject> upperTriggered = new HashSet<GameObject>();
    private static HashSet<GameObject> lowerTriggered = new HashSet<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("ball")) return;

        if (triggerType == TriggerType.Upper)
        {
            upperTriggered.Add(other.gameObject);

            // Check if ball already entered the lower trigger too
            if (lowerTriggered.Contains(other.gameObject))
            {
                RegisterGoal(other.gameObject);
            }
        }
        else if (triggerType == TriggerType.Lower)
        {
            lowerTriggered.Add(other.gameObject);

            // Check if ball already entered the upper trigger too
            if (upperTriggered.Contains(other.gameObject))
            {
                RegisterGoal(other.gameObject);
            }
        }
    }

    void RegisterGoal(GameObject ball)
    {
        // Prevent double scoring
        if (upperTriggered.Contains(ball) && lowerTriggered.Contains(ball))
        {
            scoreManager.AddScore(1);

            upperTriggered.Remove(ball);
            lowerTriggered.Remove(ball);
        }
    }
}
