using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;
    public Transform spr;
    public bool spawnSubAsteroids = false;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 30);

        speed = Random.Range(4, 7);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
        spr.Rotate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnDestroy()
    {
        if(spawnSubAsteroids)
        {
            //Spawn in the smaller asteroid

        }
    }
}
