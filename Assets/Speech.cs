using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speech : MonoBehaviour
{
    public int current_page = 0;
    public GameObject[] Dialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next_Page()
    {
        if (current_page < Dialog.Length)
        {
            if(current_page != 0)
            Dialog[current_page -1].SetActive(false);

            current_page++;
            Dialog[current_page -1].SetActive(true);
        }
        else
        {
            foreach (GameObject go in Dialog)
            {
                go.SetActive(false);
            }
            current_page = 0;
        }

        if (current_page == 0)
            this.gameObject.SetActive(false);
        else
            this.gameObject.SetActive(true);

    }


}
