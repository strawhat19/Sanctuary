using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_Person : MonoBehaviour
{
    public Dialog_State dialog_State = Dialog_State.Player_Out;
    public GameObject button_Indicator;
    public Speech speech;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Test");
        button_Indicator.SetActive(false);
        dialog_State = Dialog_State.Player_In;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Test_2");
        button_Indicator.SetActive(true);
        dialog_State = Dialog_State.Player_Out;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.X) || Input.GetButtonDown("X")) && dialog_State == Dialog_State.Player_In)
        {
            speech.Next_Page();
        }
    }

    public enum Dialog_State
    { 
       Player_In, Player_Out
    }
}
