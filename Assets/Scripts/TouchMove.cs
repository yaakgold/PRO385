using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove : MonoBehaviour
{
    private void OnEnable()
    {
        TouchManager.Instance.TouchUpdateEvent += OnMove;
    }

    private void OnDisable()
    {
        TouchManager.Instance.TouchUpdateEvent -= OnMove;
    }

    private void OnMove(Vector2 pos)
    {
        Vector3 screen = new Vector3(pos.x, pos.y, 10);
        Vector3 world = Camera.main.ScreenToWorldPoint(screen);

        transform.position = world;
    }
}
