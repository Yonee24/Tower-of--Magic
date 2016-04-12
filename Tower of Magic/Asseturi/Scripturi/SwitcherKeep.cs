using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwitcherKeep : MonoBehaviour
{
    public static bool affectedlefty;
    public static bool raj = true;
    public static bool affectedmute;
    public static float peasantvolume=1f;
    public static float musicvolume=1f;
    public static float volume=1f;
    public Slider slider;

    void Start()
    {
        
        if (tag == "volslider")
        {
            slider.value = volume;
        }

        if(tag== "peasantSOUNDSslider")
        {
            slider.value = peasantvolume;
        }

        if (tag == "musicSLIDER")
        {
            slider.value = musicvolume;
        }
    }
	void Update ()
    {
        if (tag == "ded")
        {
            if (GlobalSettings.ded)
                gameObject.transform.localScale = new Vector2(1f, 1f);
        }

        if (tag=="unpaused")
        {
            if (GlobalSettings.isonpause==false)
            {
                gameObject.transform.localScale = new Vector2(1f, 1f);
            }
            else
            {
                gameObject.transform.localScale = new Vector2(0f, 1f);
            }
        }
        if(tag=="pauser")
        {
            if(GlobalSettings.isonpause)
            {
                gameObject.transform.localScale = new Vector2(1f, 1f);
            }
            else
            {
                gameObject.transform.localScale = new Vector2(0f, 1f);
            }
        }
        if (raj)
        {
            if (tag == "lefter")
            {
                if (affectedlefty)
                {
                    transform.localScale = new Vector2(1f, 1f);
                }
                else
                {
                    transform.localScale = new Vector2(0f, 1f);
                }
            }
        }
        if (tag=="lefthand")
        {
            if (affectedlefty)
                transform.localScale = new Vector2(1f, 1f);
            else
                transform.localScale = new Vector2(0f, 1f);
        }

        if (tag=="mute")
        {
            if (affectedmute)
                transform.localScale = new Vector2(1f, 1f);
            else
                transform.localScale = new Vector2(0f, 1f);
        }
    }
}
