using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroTilt : MonoBehaviour
{
    private void OnEnable()
    {
        GyroManager.Instance.GyroUpdateEvent += Tilt;
    }

    private void OnDisable()
    {
        if (GyroManager.Instance == null)
            return;

        GyroManager.Instance.GyroUpdateEvent -= Tilt;
    }

    private void Tilt(Quaternion rot)
    {
        transform.rotation = rot;
    }
}
