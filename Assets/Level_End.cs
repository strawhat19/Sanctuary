using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_End : MonoBehaviour
{

    bool finished = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!finished)// && Switch_Manager.instance.showing_alive)
        {
            finished = true;
            Manager_Game.instance.FinishLevel();
            GetComponent<Collider2D>().enabled = false; //cannot hit again
            collision.GetComponent<Character>().CompleteLevel();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!finished)// && Switch_Manager.instance.showing_alive)
        {
            finished = true;
            Manager_Game.instance.FinishLevel();
            GetComponent<Collider2D>().enabled = false; //cannot hit again
            collision.GetComponent<Character>().CompleteLevel();
        }
    }
}
