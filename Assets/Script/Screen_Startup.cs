using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen_Startup : MonoBehaviour
{

    public GameObject Fade_1;
    public GameObject Fade_2;


    bool fade_1_out = false;
    public bool fade_1_in = false;
    bool fade_2_out = false;
    bool fade_2_in = false;


    private float fade_1_Delay_Max = 1;
    private float fade_1_Delay_Current = 0;

    private float fade_2_Delay_Max = 1;
    private float fade_2_Delay_Current = 0;

    public Manager_Ui manager_Ui;


    // Update is called once per frame
    void Update()
    {
        if (fade_1_in  == true)
        {
            Color curColor_1i = Fade_1.GetComponent<Image>().color;
            float alphaDiff_1i = Mathf.Abs(curColor_1i.a - 1);

            if (curColor_1i.a < .9f)
            {
                curColor_1i.a = Mathf.Lerp(curColor_1i.a, 1, 1f * Time.deltaTime);
                Fade_1.GetComponent<Image>().color = curColor_1i;
            }
            else
            {
                curColor_1i.a = 1f;
                fade_1_in = false;
                fade_1_Delay_Current = fade_1_Delay_Max;
            }
        }

        if (fade_1_Delay_Current > 0)
        {
            fade_1_Delay_Current -= Time.deltaTime;
            if (fade_1_Delay_Current < 0)
            {
                fade_1_out = true;
            }
        }


        if (fade_1_out == true)
        {
            Color curColor_1o = Fade_1.GetComponent<Image>().color;
            float alphaDiff_1o = Mathf.Abs(curColor_1o.a - 0);

            if (curColor_1o.a > .1)
            {
                curColor_1o.a = Mathf.Lerp(curColor_1o.a, 0, 1 * Time.deltaTime);
                Fade_1.GetComponent<Image>().color = curColor_1o;
            }
            else
            {
                curColor_1o.a = 0f;
                Fade_1.GetComponent<Image>().color = curColor_1o;
                fade_1_out = false;
                fade_2_in = true;
            }
        }

        if (fade_2_in == true)
        {
            Color curColor_2i = Fade_2.GetComponent<Image>().color;
            float alphaDiff_2i = Mathf.Abs(curColor_2i.a - 1);

            if (curColor_2i.a < .9f)
            {
                curColor_2i.a = Mathf.Lerp(curColor_2i.a, 1, 1 * Time.deltaTime);
                Fade_2.GetComponent<Image>().color = curColor_2i;
            }
            else
            {
                curColor_2i.a = 1f;
                fade_2_in = false;
                fade_2_Delay_Current = fade_2_Delay_Max;
            }
        }

        if (fade_2_Delay_Current > 0)
        {
            fade_2_Delay_Current -= Time.deltaTime;
            if (fade_2_Delay_Current < 0)
            {
                fade_2_out = true;
            }
        }

        if (fade_2_out == true)
        {
            Color curColor_2o = Fade_2.GetComponent<Image>().color;
            float alphaDiff_2o = Mathf.Abs(curColor_2o.a - 0);

            if (curColor_2o.a > .05)
            {
                curColor_2o.a = Mathf.Lerp(curColor_2o.a, 0, 1 * Time.deltaTime);
                Fade_2.GetComponent<Image>().color = curColor_2o;
            }
            else
            {
                curColor_2o.a = 0f;
                Fade_2.GetComponent<Image>().color = curColor_2o;
                fade_2_out = false;
                manager_Ui.Screen_Start();
            }
        }
    }

}
