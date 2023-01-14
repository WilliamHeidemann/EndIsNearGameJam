using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float gravity = -9.8f;
    private CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = (transform.forward * vertical) + (transform.right * horizontal);
        Vector3 velocity = direction.normalized * speed;
        
        velocity.y = gravity;
        characterController.Move(velocity * Time.deltaTime);
    }
}
