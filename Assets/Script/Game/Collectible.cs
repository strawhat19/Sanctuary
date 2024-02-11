using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    bool gathered = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gathered)
        {
            //only count if the player
            if (collision.tag == "Player")
            {
                gathered = true;
                Manager_Game.instance.GetCollectible();
                Die();
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
