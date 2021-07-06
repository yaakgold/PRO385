using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour
{
    public GameObject bg;

    private void OnTriggerExit2D(Collider2D collision)
    {
        Instantiate(bg, transform.position, Quaternion.identity);
    }
}
