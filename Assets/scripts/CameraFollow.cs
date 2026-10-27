using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 8f, -7f);
    public float smoothing = 5f;

    void LateUpdate()
    {
        // If the target is empty or switched off (for example when you swap to
        // the Rigidbody player), follow whichever active object is tagged Player.
        if (target == null || !target.gameObject.activeInHierarchy)
        {
            GameObject found = GameObject.FindGameObjectWithTag("Player");
            if (found == null)
            {
                return;
            }
            target = found.transform;
        }

        Vector3 wanted = target.position + offset;
        transform.position = Vector3.Lerp(
            transform.position, wanted, smoothing * Time.deltaTime);
        transform.LookAt(target);
    }
}
