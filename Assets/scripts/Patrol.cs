using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Vector3 direction = new Vector3(1f, 0f, 0f);
    public float distance = 10f;
    public float speed = 2f;

    Vector3 startPos;
    Rigidbody rb;
    float timer = 0f;

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate + Rigidbody.MovePosition keeps the moving trigger in sync
    // with the physics system, so the damage zone is never missed.
    void FixedUpdate()
    {
        timer = timer + Time.fixedDeltaTime;
        float t = Mathf.PingPong(timer * speed, distance);
        Vector3 newPos = startPos + direction.normalized * t;

        if (rb != null)
        {
            rb.MovePosition(newPos);
        }
        else
        {
            transform.position = newPos;
        }
    }
}
