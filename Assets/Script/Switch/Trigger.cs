using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public static float effect_distance = 2f;
    float effect_distance_squared;
    bool Launch_Effect = false;
    public GameObject[] go_Lauch_Effect;

    public Receiver[] receivers;
    // Start is called before the first frame update
    void Start()
    {
        effect_distance_squared = effect_distance * effect_distance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O) || Input.GetButtonDown("O"))
        {
            if(Vector3.SqrMagnitude(Character.instance.transform.position - transform.position) < effect_distance_squared)
            {
                ActivateTrigger();
                Launch_Effect = true;
            }
        }

        if (Launch_Effect == true)
        {

            float step = 2 * Time.deltaTime; // calculate distance to move
            for (int x = 0; x < go_Lauch_Effect.Length; x++)
            {
                go_Lauch_Effect[x].SetActive(true);
                //if (Vector2.Distance(go_Lauch_Effect[x].transform.position, receivers[x].transform.position) > .0001f)
                    go_Lauch_Effect[x].transform.position = Vector2.MoveTowards(go_Lauch_Effect[x].transform.position,receivers[x].transform.position , step);
            }

           
        }
    }

    public void ActivateTrigger()
    {
        foreach(Receiver r in receivers)
        {
            r.TriggerEffect();
        }
    }
}
