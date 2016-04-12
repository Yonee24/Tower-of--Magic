using UnityEngine;
using System.Collections;

public class cameras : MonoBehaviour
{
    private Vector2 velocity;

    private GameObject jugar;
    public AudioSource sursasonora;
    public float offsetX;
    public float smoothTimeY;
    public float smoothTimeX;

    void Start()
    {
        sursasonora.volume = GlobalSettings.vol * GlobalSettings.musicvols;

        jugar = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, jugar.transform.position.x, ref velocity.x, smoothTimeX);
        //float posY = Mathf.SmoothDamp(transform.position.y, jugar.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX+offsetX, transform.position.y, transform.position.z);
    }
}
