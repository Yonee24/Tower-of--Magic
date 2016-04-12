using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalSettings : MonoBehaviour
{
    public static bool invincible = false;

    public static bool ded;
    public static bool lefty=false;
    public static float vol;
    public static bool mute = false;
    public static float peasantvol;
    public static float musicvols;
    public static bool isonpause = false;
    public GameObject handle;
    private Animator handleANIM;
    public Slider volslider;
    public float movejoystickX;
    public float movejumboX;
    public float movecrouchbuttonY;
    public SwitcherKeep scriptafectat;

    void Start ()
    {
        
        
        if (lefty && tag == "joystick")
        {
            gameObject.transform.localPosition = new Vector2(movejoystickX, gameObject.transform.localPosition.y);
        }

        if (lefty && tag == "jumbo-matic")
        {
            gameObject.transform.localPosition = new Vector2(movejumboX, gameObject.transform.localPosition.y);
        }

        if (lefty && tag == "crouchbutton")
        {
            gameObject.transform.localPosition = new Vector2(gameObject.transform.localPosition.x, movecrouchbuttonY);
        }
    }

    public void pauser()
    {
        isonpause = !isonpause;
        if(isonpause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void changeLefty()
    {
        lefty = !lefty;
        SwitcherKeep.affectedlefty = lefty;
    }

    public void changevolume()
    {
        SwitcherKeep.volume = vol;
        vol = volslider.value;
        handleANIM = handle.GetComponent<Animator>();
        handleANIM.SetFloat("volume", vol);
    }

    public void changepeasantvol()
    {
        SwitcherKeep.peasantvolume = peasantvol;
        peasantvol = volslider.value;
        handleANIM = handle.GetComponent<Animator>();
        handleANIM.SetFloat("volume", peasantvol);
    }

    public void changemusicvol()
    {
        SwitcherKeep.musicvolume = musicvols;
        musicvols = volslider.value;
        handleANIM = handle.GetComponent<Animator>();
        handleANIM.SetFloat("volume", musicvols);
    }
}
