using UnityEngine;

public class WindController : MonoBehaviour
{
    public static WindController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public Vector3 GetWindForce()
    {
        float windStrength = DifficultyManager.Instance.windStrength;
        return new Vector3(windStrength, 0, 0); // X-axis wind
    }
}
