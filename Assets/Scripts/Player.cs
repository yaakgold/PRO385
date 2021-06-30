using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Created by: Ya'akov Goldberg

public class Player : MonoBehaviour
{
    public float speed = 2;
    public GameObject shot;

    Vector2 input;

    void Start()
    {
        GetComponent<PlayerInput>().onActionTriggered += HandleAction;
    }

    void LateUpdate()
    {
        transform.Translate(input * speed * Time.deltaTime);

        Gamepad gamepad = Gamepad.current;
        if (gamepad == null)
            return;

        if (gamepad.buttonSouth.wasPressedThisFrame)
        {
            OnFire();
        }

        if (Input.anyKey)
            return;
        
        input = gamepad.leftStick.ReadValue();
    }

    public void OnFire()
    {
        Instantiate(shot, transform.position, Quaternion.identity);
    }

    public void OnMove(InputValue val)
    {
        input = val.Get<Vector2>();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        input = ctx.ReadValue<Vector2>();
    }

    private void HandleAction(InputAction.CallbackContext ctx)
    {
        if(ctx.action.name == "Fire")
        {
            OnFire();
        }
        if(ctx.action.name == "Move")
        {
            OnMove(ctx);
        }
    }
}
