using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Manager : MonoBehaviour
{
    public static Switch_Manager instance { get { return _instance; } }
    static Switch_Manager _instance;


    public bool showing_alive;
    public Switch_Mask mask_alive, mask_dead;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;

        mask_dead.StartTransition();
        mask_alive.StartTransition();
        showing_alive = true;
        TurnAllAlive();
        Invoke("StopDeadTransition", mask_alive.lerp_time);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("P"))
        {
            if(showing_alive && !mask_alive.transitioning)
            {
                mask_dead.StartTransition();
                showing_alive = false;
                TurnAllDead();
                Invoke("StopAliveTransition", mask_dead.lerp_time);
            }
            else if (!showing_alive && !mask_dead.transitioning)
            {
                mask_alive.StartTransition();
                showing_alive = true;
                TurnAllAlive();
                Invoke("StopDeadTransition", mask_alive.lerp_time);
            }
        }
    }

    Switch_Object[] switch_objects;
    void TurnAllDead()
    {
        switch_objects = GameObject.FindObjectsOfType<Switch_Object>();
        foreach(Switch_Object so in switch_objects)
        {
            so.Transition_To_Dead();
        }
    }
    void TurnAllAlive()
    {
        switch_objects = GameObject.FindObjectsOfType<Switch_Object>();
        foreach (Switch_Object so in switch_objects)
        {
            so.Transition_To_Alive();
        }
    }
}
