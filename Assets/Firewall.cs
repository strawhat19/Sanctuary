using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Firewall : MonoBehaviour
{

    Transform cameras;
    public float wallAcceleration = 1f;
   




    // Start is called before the first frame update
    void Start()
    {
        cameras = GameObject.FindObjectOfType<CameraFollow>().transform;   
    }


     void Update() {

        moveWall(new Vector2());
        if(Manager_Game.instance.horizontal)
            transform.position = new Vector3(transform.position.x, cameras.position.y, transform.position.z);
        else
            transform.position = new Vector3(cameras.position.x, transform.position.y, transform.position.z);
    }


    void moveWall(Vector2 direction) {
        transform.Translate (wallAcceleration * Time.deltaTime, 0, 0);
    }

 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(!Manager_Game.instance.game_over)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }





}
