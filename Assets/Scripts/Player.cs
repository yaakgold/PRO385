using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

//Created by: Ya'akov Goldberg

public class Player : MonoBehaviour
{
    public float speed = 2;
    public float shotCooldown, timeSinceShot = 0;
    public GameObject shot;

    private bool canFire = true;
    private Image timerForShoot;

    Vector2 input;
    Vector2 clampedPos = new Vector2();

    void Start()
    {
        GetComponent<PlayerInput>().onActionTriggered += HandleAction;
        timerForShoot = GameObject.FindGameObjectWithTag("Timer")?.GetComponent<Image>();
    }

    private void Update()
    {
        canFire = timeSinceShot >= shotCooldown;

        if(!canFire)
        {
            timeSinceShot += Time.deltaTime;
            timerForShoot.gameObject.SetActive(true);
            timerForShoot.fillAmount = 1 - (timeSinceShot / shotCooldown);
        }
        else
        {
            timerForShoot.gameObject.SetActive(false);
        }
    }

    void LateUpdate()
    {
        transform.Translate(input * speed * Time.deltaTime);
        clampedPos.x = Mathf.Clamp(transform.position.x, -7, 5);
        clampedPos.y = Mathf.Clamp(transform.position.y, -3, 3);
        transform.position = clampedPos;

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
        if(canFire)
        {
            Instantiate(shot, transform.position, Quaternion.identity);
            canFire = false;
            timeSinceShot = 0;
        }
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
