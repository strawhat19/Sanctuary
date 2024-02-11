using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Ui : MonoBehaviour
{

    public GameObject screen_Start;
    public GameObject screen_End;
    public Screen_Startup screen_Startup ;


    void Awake()
    {
        //DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Screen_Start()
    {
        screen_Startup.gameObject.SetActive(false);
        screen_Start.SetActive(true);
        screen_End.SetActive(false);
    }

    public void Screen_Off()
    {
        screen_Startup.gameObject.SetActive(false);
        screen_Start.SetActive(false);
        screen_End.SetActive(false);
    }
}
