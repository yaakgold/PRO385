using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GyroManager : MonoBehaviour
{
    #region Singleton
    static GyroManager _instance;
    public static GyroManager Instance 
    { 
        get 
        {
            if (_instance == null)
                _instance = FindObjectOfType<GyroManager>();

            return _instance; 
        }
    }

    private void Awake()
    {
        _instance = this;

        input = new GyroControls();
    }
    #endregion

    public delegate void GyroDelegate(Quaternion rot);

    public event GyroDelegate GyroUpdateEvent;

    GyroControls input;
    bool touchedMyTraLaLa = false;

    public Quaternion Rotation { get => input.Gyro.Attitude.ReadValue<Quaternion>(); }

    // Update is called once per frame
    void Update()
    {
        if(touchedMyTraLaLa)
        {
            GyroUpdateEvent?.Invoke(Rotation);
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
}
