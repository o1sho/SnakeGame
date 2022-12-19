using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] GameObject _snake;
    IControllable _snakeIC;

    private void Start()
    {
        _snakeIC = GetComponent<IControllable>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) Snake.MoveDirection(Vector2.up);
        if (Input.GetKeyDown(KeyCode.A)) Snake.MoveDirection(Vector2.left);
        if (Input.GetKeyDown(KeyCode.S)) Snake.MoveDirection(Vector2.down);
        if (Input.GetKeyDown(KeyCode.D)) Snake.MoveDirection(Vector2.right);
    }


}
