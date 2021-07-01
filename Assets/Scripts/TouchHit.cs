using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHit : MonoBehaviour
{
    private void OnEnable()
    {
        TouchManager.Instance.TouchStartEvent += OnTouch;
    }

    private void OnDisable()
    {
        if (TouchManager.Instance == null)
            return;

        TouchManager.Instance.TouchStartEvent -= OnTouch;
    }

    private void OnTouch(Vector2 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.collider.gameObject == gameObject)
            {
                GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
            }
        }
    }
}
