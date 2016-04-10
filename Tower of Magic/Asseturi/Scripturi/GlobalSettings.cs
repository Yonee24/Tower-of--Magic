using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalSettings : MonoBehaviour {

    public static bool lefty=false;
    public float movejoystickX;
    public float movejumboX;
    public float movecrouchbuttonY;

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

    public void changeLefty()
    {
        lefty = !lefty;
    }

    void Update()
    {
        if (tag == "switch")
        {
            //gameObject.SetActive(lefty);
        }
    }
}
