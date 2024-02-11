using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Object : MonoBehaviour
{
    //public GameObject[] alive_gameobjects, dead_gameobjects;
    public Collider2D[] alive_Collider2Ds, dead_Collider2Ds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Transition_To_Alive()
    {
        //foreach(GameObject g in alive_gameobjects)
        //{
        //    g.SetActive(true);
        //}
        //foreach (GameObject g in dead_gameobjects)
        //{
        //    g.SetActive(false);
        //}


        foreach (Collider2D c in alive_Collider2Ds)
        {
            c.enabled = true;
        }
        foreach (Collider2D c in dead_Collider2Ds)
        {
            c.enabled = false;
        }
    }

    public void Transition_To_Dead()
    {
        //foreach (GameObject g in alive_gameobjects)
        //{
        //    g.SetActive(false);
        //}
        //foreach (GameObject g in dead_gameobjects)
        //{
        //    g.SetActive(true);
        //}


        foreach (Collider2D c in alive_Collider2Ds)
        {
            c.enabled = false;
        }
        foreach (Collider2D c in dead_Collider2Ds)
        {
            c.enabled = true;
        }
    }
}
