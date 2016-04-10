using UnityEngine;
using System.Collections;

public class loadlvl : MonoBehaviour {

    public GameObject source;
	void Start ()
    {
        
	}

	public void load()
    {
        source.SetActive(true);
        Application.LoadLevel("scene");

    }
}
