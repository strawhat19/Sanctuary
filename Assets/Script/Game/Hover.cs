using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public float height = .1f, speed = 5f;
    float offset;
    Vector2 start_pos;
    // Start is called before the first frame update
    void Start()
    {
        start_pos = transform.position;
        offset = Random.Range(0f, 360f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = start_pos + Vector2.up * height * Mathf.Sin((Time.time + offset)  * speed);
    }
}
