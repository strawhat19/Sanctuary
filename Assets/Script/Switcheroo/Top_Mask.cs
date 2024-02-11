using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Top_Mask : MonoBehaviour
{

    Image im;
    Transform cameras, wall;
    // Start is called before the first frame update
    void Start()
    {
        im = GetComponent<Image>();
        cameras = GameObject.FindObjectOfType<CameraFollow>().transform;
        wall = GameObject.FindObjectOfType<Firewall>().transform;

    }

    float screen_ratio;
    // Update is called once per frame
    void Update()
    {
        if (!Manager_Game.instance.horizontal)
        {
            im.fillMethod = Image.FillMethod.Vertical;
            im.fillOrigin = 1;
        }

        if (Manager_Game.instance.horizontal)
            screen_ratio = ((cameras.position.x - wall.position.x) / 17.666f) + .5f;
        else
            screen_ratio = ((cameras.position.y - wall.position.y) / 9.937123f) + .5f;
        im.fillAmount = screen_ratio;
    }
}
