using UnityEngine;
using System.Collections;

public class gotooptions : MonoBehaviour
{

    public GameObject source;
    void Start()
    {

    }

    public void load()
    {
        source.SetActive(true);
        Application.LoadLevel("options");

    }
}
