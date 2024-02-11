using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Manager_Game : MonoBehaviour
{
    public static Manager_Game instance { get { return _instance; } }
    static Manager_Game _instance;
    public int next_level;
    public bool horizontal;
    public bool test_end = false;
    public float test_percentage;

    public bool show_animation;
    public Switch_Mask mask_alive, mask_dead;

    Collectible[] collectibles;
    int gathered_collectibles;
    Transform cameras, wall;

    public bool game_over;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        collectibles = GameObject.FindObjectsOfType<Collectible>();
        gathered_collectibles = 0;
        cameras = GameObject.FindObjectOfType<CameraFollow>().transform;
        wall = GameObject.FindObjectOfType<Firewall>().transform;

        start_pos = cameras.position;
        end_pos = GameObject.FindObjectOfType<Level_End>().transform.position;


        if (test_end)
            FinishLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void Restart()
    {
        if (!game_over)
        {
            game_over = true;
            mask_alive.StartTransitionZero();
            mask_dead.StartTransitionZero();
            Invoke("LoadSelfScene", 1);
        }
    }

    void LoadSelfScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GetCollectible()
    {
        gathered_collectibles++;
        Debug.Log("Gathered Collectible");
    }

    float collectible_percentage;
    public void FinishLevel()
    {
        mask_alive.StartTransition();
        game_over = true;
        collectible_percentage = test_end ? test_percentage : (float)gathered_collectibles / collectibles.Length;
        Debug.Log(collectible_percentage);
        if(show_animation)
        {
            StartCoroutine("Final_Animation");
        }
        else
        {
            StartCoroutine("No_Animation");
        }
    }

    Vector3 start_pos, end_pos, target_pos;
    IEnumerator Final_Animation()
    {
        //disable the auto-moving scripts
        cameras.GetComponent<CameraFollow>().enabled = false;
        wall.GetComponent<Firewall>().enabled = false;

        float speed = (end_pos - start_pos).magnitude / 5;

        //move to the end pos
        target_pos = end_pos;
        target_pos.z = cameras.position.z;

        float temp = 0;
        Vector3 end_wall_position = Manager_Game.instance.horizontal ?
            end_pos + (Vector3.left * 4) :
            end_pos + (Vector3.down * 3);

        end_wall_position.z = wall.position.z;
        while (temp < 1)//Vector3.SqrMagnitude(cameras.position - target_pos) > .05f)
        {
            temp += Time.deltaTime;
            //cameras.Translate((target_pos - cameras.position).normalized * Time.deltaTime);
            wall.position = Vector3.Lerp(wall.position, end_wall_position, temp);
            cameras.position = Vector3.Lerp(cameras.position, target_pos, temp);
            yield return null;
        }
        cameras.position = target_pos;
        wall.position = end_wall_position;


        target_pos = start_pos;
        end_wall_position = ((start_pos - cameras.position) * collectible_percentage) + wall.position;
        end_wall_position.z = wall.position.z;
        while (Vector3.SqrMagnitude(wall.position - end_wall_position) > .05f && Vector3.SqrMagnitude(cameras.position - target_pos) > .05f)
        {
            //TODO MAKE IT NOT GO SIDEWAYS WHEN
            cameras.Translate((target_pos - cameras.position).normalized * Time.deltaTime * speed, Space.World);
            wall.Translate((target_pos - cameras.position).normalized * Time.deltaTime * speed, Space.World);
            //wall.position = new Vector3(cameras.position.x, wall.position.y, wall.position.z);
            yield return null;
        }
        while (Vector3.SqrMagnitude(cameras.position - target_pos) > .05f)
        {
            cameras.Translate((target_pos - cameras.position).normalized * Time.deltaTime * speed);
            if(Manager_Game.instance.horizontal)
                wall.position = new Vector3(wall.position.x, cameras.position.y, wall.position.z);
            else
                wall.position = new Vector3(cameras.position.x, wall.position.y, wall.position.z);
            yield return null;
        }
        cameras.position = target_pos;
        yield return new WaitForSeconds(2);

        mask_alive.StartTransitionZero();
        mask_dead.StartTransitionZero();

        yield return new WaitForSeconds(2);
        Go_To_Level(next_level);
    }
    IEnumerator No_Animation()
    {
        //disable the auto-moving scripts
        cameras.GetComponent<CameraFollow>().enabled = false;
        wall.GetComponent<Firewall>().enabled = false;

        yield return new WaitForSeconds(2);

        mask_alive.StartTransitionZero();
        mask_dead.StartTransitionZero();

        yield return new WaitForSeconds(2);
        Go_To_Level(next_level);
    }

    public void Go_To_Level(int x)
    {
        SceneManager.LoadScene(x);
    }
}
