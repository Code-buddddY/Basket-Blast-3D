using System.Collections;
using UnityEngine;

public class PoleMover : MonoBehaviour
{
    private float moveSpeed;
    public float moveRange = 2f;
    private Vector3 startPos;
    private Coroutine moveRoutine;

    private bool isNormalOrMedium =>
        DifficultyManager.Instance != null &&
        (DifficultyManager.Instance.windStrength == 0f || DifficultyManager.Instance.windStrength == 0.4f);

    private bool isHard =>
        DifficultyManager.Instance != null &&
        DifficultyManager.Instance.windStrength == 0.5f;

    void Start()
    {
        startPos = transform.position;
        moveSpeed = DifficultyManager.Instance.poleMoveSpeed;
    }

    void Update()
    {
        moveSpeed = DifficultyManager.Instance.poleMoveSpeed;

        if (isHard && moveSpeed > 0f)
        {
            transform.position = startPos + Vector3.right * Mathf.Sin(Time.time * moveSpeed) * moveRange;
        }
    }

    public void MoveToRandomX()
    {
        if (isNormalOrMedium)
        {
            float randomX = Random.Range(-3f, 3f);

            if (moveRoutine != null)
                StopCoroutine(moveRoutine);

            moveRoutine = StartCoroutine(SmoothMoveX(randomX));
        }
    }

    private IEnumerator SmoothMoveX(float targetX)
    {
        Vector3 start = transform.position;
        Vector3 end = new Vector3(targetX, start.y, start.z);
        float duration = 0.5f;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }

        transform.position = end;
    }
}
