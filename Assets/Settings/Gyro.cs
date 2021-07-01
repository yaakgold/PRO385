// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Gyro.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Gyro : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Gyro()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Gyro"",
    ""maps"": [
        {
            ""name"": ""GyroMap"",
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
        // GyroMap
        m_GyroMap = asset.FindActionMap("GyroMap", throwIfNotFound: true);
        m_GyroMap_Attitude = m_GyroMap.FindAction("Attitude", throwIfNotFound: true);
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

    // GyroMap
    private readonly InputActionMap m_GyroMap;
    private IGyroMapActions m_GyroMapActionsCallbackInterface;
    private readonly InputAction m_GyroMap_Attitude;
    public struct GyroMapActions
    {
        private @Gyro m_Wrapper;
        public GyroMapActions(@Gyro wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attitude => m_Wrapper.m_GyroMap_Attitude;
        public InputActionMap Get() { return m_Wrapper.m_GyroMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GyroMapActions set) { return set.Get(); }
        public void SetCallbacks(IGyroMapActions instance)
        {
            if (m_Wrapper.m_GyroMapActionsCallbackInterface != null)
            {
                @Attitude.started -= m_Wrapper.m_GyroMapActionsCallbackInterface.OnAttitude;
                @Attitude.performed -= m_Wrapper.m_GyroMapActionsCallbackInterface.OnAttitude;
                @Attitude.canceled -= m_Wrapper.m_GyroMapActionsCallbackInterface.OnAttitude;
            }
            m_Wrapper.m_GyroMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Attitude.started += instance.OnAttitude;
                @Attitude.performed += instance.OnAttitude;
                @Attitude.canceled += instance.OnAttitude;
            }
        }
    }
    public GyroMapActions @GyroMap => new GyroMapActions(this);
    public interface IGyroMapActions
    {
        void OnAttitude(InputAction.CallbackContext context);
    }
}
