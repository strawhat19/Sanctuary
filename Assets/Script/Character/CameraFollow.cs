using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform character, fire_wall, end;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindObjectOfType<Character>().transform;
        fire_wall = GameObject.FindObjectOfType<Firewall>().transform;
        end = GameObject.FindObjectOfType<Level_End>().transform;
    }

    // Update is called once per frame
    Vector3 target_position;
    void LateUpdate()
    {
        target_position = character.position;
        target_position.z = transform.position.z;

        if(Manager_Game.instance.horizontal)
            target_position.x = Mathf.Clamp(target_position.x, fire_wall.position.x + 9.1f, end.position.x - 3f);
        else
            target_position.y = Mathf.Clamp(target_position.y, fire_wall.position.y + 5.11875f, end.position.y - 1f);
        transform.Translate((target_position - transform.position) * Time.deltaTime * 5);
        //transform.position = Vector3.Lerp(transform.position, target_position, .1f);
    }
}
