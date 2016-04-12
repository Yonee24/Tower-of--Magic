using UnityEngine;
using System.Collections;

public class sariodata : MonoBehaviour
{
    public miscare jugar;

	void Start()
    {
        
        jugar = gameObject.GetComponentInParent<miscare>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="jumpable")
            jugar.lapamant = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "jumpable")
            jugar.lapamant = false;
    }
}
