using UnityEngine;
using System.Collections;

public class demataseSTANGA : MonoBehaviour
{
    public miscare scriptsursa;
    
	void Start ()
    {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
            scriptsursa.atingeredematase = 1;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
            scriptsursa.atingeredematase = 0;
    }
}
