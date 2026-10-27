using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    public float speed = 6f;
    public float gravity = -20f;

    CharacterController controller;
    float verticalSpeed = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // No keyboard (e.g. a phone) or the game is frozen on the end screen.
        if (Keyboard.current == null || Time.timeScale == 0f)
        {
            return;
        }

        float x = 0f;
        float z = 0f;
        if (Keyboard.current.aKey.isPressed) { x = -1f; }
        if (Keyboard.current.dKey.isPressed) { x = 1f; }
        if (Keyboard.current.sKey.isPressed) { z = -1f; }
        if (Keyboard.current.wKey.isPressed) { z = 1f; }

        Vector3 direction = new Vector3(x, 0f, z).normalized;

        // Face the direction of travel.
        if (direction != Vector3.zero)
        {
            transform.forward = direction;
        }

        if (controller.isGrounded && verticalSpeed < 0f)
        {
            verticalSpeed = -2f;
        }
        verticalSpeed = verticalSpeed + gravity * Time.deltaTime;

        Vector3 move = direction * speed;
        move.y = verticalSpeed;
        controller.Move(move * Time.deltaTime);
    }
}
