using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Input : MonoBehaviour
{
    public Manager_Ui manager_Ui ;

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

    public void click_Start_Game()
    {
        //manager_Ui.Screen_Off();
        SceneManager.LoadScene(1);
    }

    public void click_Try_Again()
    { 
    
    }
}
