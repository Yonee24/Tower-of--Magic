using UnityEngine;
using System.Collections;

public class turnoffSaidObject : MonoBehaviour {

    public GameObject target;
    
    public void turnoff()
    {
        SwitcherKeep.raj = false;
        target.transform.localScale = new Vector2(0f, 1f);
    }

    public void turnon()
    {
        SwitcherKeep.raj = true;
        target.transform.localScale = new Vector2(1f, 1f);
    }
}
