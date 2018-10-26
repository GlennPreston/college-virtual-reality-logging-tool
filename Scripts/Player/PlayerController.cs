using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// Move player based on input
public class PlayerController : MonoBehaviour {

    public float speed;

    Vector3 movement;

    // Called multiple times per frame
    void FixedUpdate()
    {
        // Get input
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Call Move
        Move(h, v);
    }

    // Move player based on input
    void Move(float h, float v)
    {
        // Check what direction to move player
        if (h != 0f || v != 0f)
        {
            // Move player in correct direction
            movement.Set(h, 0f, v);
            Vector3 dir = movement.normalized;
            dir = Camera.main.transform.TransformDirection(dir);
            dir.y = 0.0f;
            transform.Translate(dir * speed * Time.deltaTime);
        }
    }
}