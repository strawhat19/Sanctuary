using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour
{
    public GameObject[] to_deactivate, to_activate;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject g in to_deactivate)
        {
            g.SetActive(true);
        }
        foreach (GameObject g in to_activate)
        {
            g.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void TriggerEffect()
    {
        foreach(GameObject g in to_deactivate)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in to_activate)
        {
            g.SetActive(true);
        }
    }
}
