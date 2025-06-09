using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody rb;
    private bool isHeld = true;
    public float followDistance = 2f;

    private float throwTimer = 0f;          // Timer to track how long since ball was thrown
    private float maxLifeAfterThrow = 5f;   // Max time allowed before force-destroy

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        transform.position = Camera.main.transform.position + Camera.main.transform.forward * followDistance;
    }

    void Update()
    {
        if (isHeld)
        {
            Transform cam = Camera.main.transform;
            transform.position = cam.position + cam.forward * followDistance;

            if (Input.GetMouseButtonDown(0))
            {
                rb.useGravity = true;
                rb.AddForce(cam.forward * UIForceControl.CurrentThrowForce, ForceMode.Impulse);
                isHeld = false;
                throwTimer = 0f;  // Reset timer on throw
            }
        }
        else
        {
            // Apply wind after the throw
            rb.AddForce(WindController.Instance.GetWindForce(), ForceMode.Force);

            // Count up the time since the throw
            throwTimer += Time.deltaTime;

            // Force destroy after 5 seconds if no ground hit
            if (throwTimer >= maxLifeAfterThrow)
            {
                DestroyBall();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isHeld && collision.gameObject.CompareTag("Ground"))
        {
            Invoke("DestroyBall", 2f);
        }
    }

    void DestroyBall()
    {
        if (BallSpawner.Instance != null)
            BallSpawner.Instance.SpawnNewBall();

        Destroy(gameObject);
    }
}
