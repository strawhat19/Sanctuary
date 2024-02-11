using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Mask : MonoBehaviour
{
    public float max_scale;     //what is the max scale (99999)
    public float lerp_time;     //how long it takes to lerp

    float cur_time = 0;
    public float cur_scale; //only public for testing reasons
    Vector2 my_scale;

    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        my_scale = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        my_scale.x = my_scale.y = cur_scale;
        rect.sizeDelta = my_scale;
    }

    public void StartTransition()
    {
        transform.parent.SetAsLastSibling();
        StartCoroutine("Transition");
    }
    public void StartTransitionZero()
    {
        transform.parent.SetAsFirstSibling();
        StartCoroutine("TransitionZero");
    }

    public bool transitioning { get { return cur_time > 0 && cur_time < lerp_time; } }
    IEnumerator Transition()
    {
        cur_time = 0;
        while(cur_time < lerp_time)
        {
            cur_scale = cur_time / lerp_time * max_scale;

            cur_time += Time.deltaTime;
            yield return null;
        }

        cur_scale = max_scale;
    }
    IEnumerator TransitionZero()
    {
        cur_time = lerp_time;
        while (cur_time > 0)
        {
            cur_scale = cur_time / lerp_time * max_scale;

            cur_time -= Time.deltaTime;
            yield return null;
        }

        cur_scale = 0;
    }
}
