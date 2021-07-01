// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Gyro Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GyroControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GyroControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Gyro Controls"",
    ""maps"": [
        {
            ""name"": ""Gyro"",
            ""id"": ""2b45dbbe-6a12-40e0-a3fc-d44838731007"",
            ""actions"": [
                {
                    ""name"": ""Attitude"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a8b1d60c-414a-4038-8c0f-7b07ed4d8099"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d708ac7b-9ef0-404d-a247-ecaab338b995"",
                    ""path"": ""<AttitudeSensor>/attitude"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attitude"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gyro
        m_Gyro = asset.FindActionMap("Gyro", throwIfNotFound: true);
        m_Gyro_Attitude = m_Gyro.FindAction("Attitude", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gyro
    private readonly InputActionMap m_Gyro;
    private IGyroActions m_GyroActionsCallbackInterface;
    private readonly InputAction m_Gyro_Attitude;
    public struct GyroActions
    {
        private @GyroControls m_Wrapper;
        public GyroActions(@GyroControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attitude => m_Wrapper.m_Gyro_Attitude;
        public InputActionMap Get() { return m_Wrapper.m_Gyro; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GyroActions set) { return set.Get(); }
        public void SetCallbacks(IGyroActions instance)
        {
            if (m_Wrapper.m_GyroActionsCallbackInterface != null)
            {
                @Attitude.started -= m_Wrapper.m_GyroActionsCallbackInterface.OnAttitude;
                @Attitude.performed -= m_Wrapper.m_GyroActionsCallbackInterface.OnAttitude;
                @Attitude.canceled -= m_Wrapper.m_GyroActionsCallbackInterface.OnAttitude;
            }
            m_Wrapper.m_GyroActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Attitude.started += instance.OnAttitude;
                @Attitude.performed += instance.OnAttitude;
                @Attitude.canceled += instance.OnAttitude;
            }
        }
    }
    public GyroActions @Gyro => new GyroActions(this);
    public interface IGyroActions
    {
        void OnAttitude(InputAction.CallbackContext context);
    }
}
