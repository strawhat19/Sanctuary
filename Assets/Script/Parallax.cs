using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Vector2 parallax_scale;
    //public bool horizontal, vertical;
    public Vector2 mins;
    Transform cameras;
    Vector3 camera_start_pos, start_pos;

    // Start is called before the first frame update
    void Start()
    {
        cameras = GameObject.FindObjectOfType<CameraFollow>().transform;
        camera_start_pos = cameras.position;
        start_pos = transform.position;
        offset = Vector2.zero;
    }

    Vector3 target_pos;
    Vector2 offset;
    // Update is called once per frame
    void Update()
    {
        target_pos = (cameras.position - camera_start_pos) * parallax_scale;

        target_pos.z = start_pos.z;
        if (parallax_scale.x == 0)
            target_pos.x = start_pos.x;
        if (parallax_scale.y == 0)
            target_pos.y = start_pos.y;

        while (cameras.position.x - (target_pos.x + offset.x) > mins.x)
            offset.x += mins.x;
        while (cameras.position.x - (target_pos.x + offset.x) < -mins.x)
            offset.x -= mins.x;
        while (cameras.position.y - (target_pos.y + offset.y) > mins.y)
            offset.y += mins.y;
        while (cameras.position.y - (target_pos.y + offset.y) < -mins.y)
            offset.y -= mins.y;

        target_pos.x += offset.x;
        target_pos.y += offset.y;

        transform.position = target_pos;
    }
}
