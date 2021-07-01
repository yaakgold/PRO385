using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    #region Singleton
    static TouchManager _instance;
    public static TouchManager Instance 
    { 
        get 
        {
            if (_instance == null)
                _instance = FindObjectOfType<TouchManager>();

            return _instance; 
        }
    }

    private void Awake()
    {
        _instance = this;

        input = new TouchControls();
    }
    #endregion

    public delegate void TouchDelegate(Vector2 pos);

    public event TouchDelegate TouchStartEvent;
    public event TouchDelegate TouchStopEvent;
    public event TouchDelegate TouchUpdateEvent;

    TouchControls input;
    bool touchedMyTraLaLa = false;

    public Vector2 Position { get => input.Touch.TouchPosition.ReadValue<Vector2>(); }

    // Start is called before the first frame update
    void Start()
    {
        input.Touch.TouchPress.started += TouchPress_Started;
        input.Touch.TouchPress.canceled += TouchPress_Canceled;
    }

    // Update is called once per frame
    void Update()
    {
        if(touchedMyTraLaLa)
        {
            TouchUpdateEvent?.Invoke(Position);
        }
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void TouchPress_Started(InputAction.CallbackContext ctx)
    {
        //print($"Start: {Position}");
        TouchStartEvent?.Invoke(Position);
        touchedMyTraLaLa = true;
    }

    private void TouchPress_Canceled(InputAction.CallbackContext ctx)
    {
        //print($"UnStarted: {Position}");
        TouchStartEvent?.Invoke(Position);
        touchedMyTraLaLa = false;
    }
}
