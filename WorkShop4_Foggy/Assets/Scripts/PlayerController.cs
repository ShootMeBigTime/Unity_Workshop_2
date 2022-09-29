using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody player;
    private float x;
    private float y;
    private int enemyNearby;

    // Start is called before the first frame update
    void Awake()
    {
        player = gameObject.GetComponent<Rigidbody>();
        enemyNearby = 0;
    }
    void FixedUpdate()
    {
        Vector3 movement = transform.forward * y * 10;
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, x * 100, 0) * Time.fixedDeltaTime);
        player.MoveRotation(gameObject.GetComponent<Rigidbody>().rotation * deltaRotation);
        player.velocity = movement;
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        x = movementVector.x;
        y = movementVector.y;
    }
}
