using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionBar : MonoBehaviour
{

    public Transform fire_wall, end;
    Vector3 start_pos, end_pos;


    public Slider slider;
    private ParticleSystem particleSys;
    public float FillSpeedProgression = 0.5f;

    private float targetProgress = 0;

    private Vector3 char_start;


    private void Awake() {
        slider = gameObject.GetComponent<Slider>();
        particleSys = GameObject.Find("Progress Bar Particles").GetComponent<ParticleSystem>();
        char_start = GameObject.FindObjectOfType<Character>().transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        start_pos = fire_wall.position;
        end_pos = end.position;

        //IncrementProgress(1f);
    }

    // Update is called once per frame
    void Update()
    {
        float start_to_end_distance = (end_pos - char_start).magnitude;
        float start_to_fire_distance = (fire_wall.position - char_start).magnitude;
        float fire_to_end_distance = (end_pos - fire_wall.position).magnitude;
        if (Manager_Game.instance.horizontal)
        {
            start_to_end_distance = end_pos.x - char_start.x;
            start_to_fire_distance = fire_wall.position.x - char_start.x;
            fire_to_end_distance = end_pos.x - fire_wall.position.x;
        }
        else
        {
            start_to_end_distance = end_pos.y - char_start.y;
            start_to_fire_distance = fire_wall.position.y - char_start.y;
            fire_to_end_distance = end_pos.y - fire_wall.position.y;
        }

        if (Mathf.Abs(fire_to_end_distance) > Mathf.Abs(start_to_end_distance))
            slider.value = 0;
        else
            slider.value = start_to_fire_distance / start_to_end_distance;



    //    if (slider.value < targetProgress) {
    //       slider.value += FillSpeedProgression * Time.deltaTime;
    //          if (!particleSys.isPlaying)
    //           particleSys.Play();
    //}
    //    else {
    //       particleSys.Stop();
    //    }
        
    }

    //public void IncrementProgress(float newProgress) {
    //    targetProgress = slider.value + newProgress;
    //}




}
