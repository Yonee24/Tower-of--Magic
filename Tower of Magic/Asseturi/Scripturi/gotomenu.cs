using UnityEngine;
using System.Collections;

public class gotomenu : MonoBehaviour
{

    public GameObject source;
    void Start()
    {

    }

    public void load()
    {
        source.SetActive(true);
        Application.LoadLevel("MainMenu");

    }
}
