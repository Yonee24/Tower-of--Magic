using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class miscare : MonoBehaviour
{
    private Animator anim;

    public bool crouchdroid = false;
    public bool beginprocedure;
    public AudioSource audioSource;
    public AudioClip Scored;
    public bool android;
    public float AndroidOspeed;
    public float h;
    public Vector2 go;
    public bool george;
    public bool kek;
    public bool sary;
    public bool selected = false;
    public int MoveOtouch; // 1 stanga - 2 dreapta //
    public bool JumpOtouch=false;
    public int move;
    public int atingeredematase; // 0 nimic - 1 stanga - 2 dreapta //
    public bool up = false;
    public bool lapamant = false;
    public float TopSpeed = 3;
    public float vitezas = 50f;
    public float puteredesaritura = 150f;
    public Rigidbody2D baiet;

    public float mover = 0.5f;
    public Slider slider;

    void Start()
    {
        baiet = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        //ANIMATZIONE BEGIN
        anim.SetBool("Pamantpe", lapamant);
        if (android)
        {
            anim.SetFloat("Speed", Mathf.Abs(2 * (mover - 0.5f)));
        }
        else anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        //ANIMATZIONE END
        
        //CROUCH BEGIN
        if (Input.GetAxis("Horizontal") < -0.1f || mover< 0.5f)
        {
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.DownArrow) || crouchdroid)
            {
                transform.localScale = new Vector3(-1, 0.6f, 1);
            }
            else transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1f || mover>= 0.5f)
        {
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.DownArrow) || crouchdroid)
            {
                transform.localScale = new Vector3(1, 0.6f, 1);
            }
            else transform.localScale = new Vector3(1, 1, 1);
        }
        //CROUCH END
    }

    public void changezecrouch() //CROUCH SWITCH WHEN BUTTON PRESS
    {
        crouchdroid = !crouchdroid;
        if (mover >= 0.5f)
        {
            if(crouchdroid)
            {
                transform.localScale = new Vector3(-1, 0.6f, 1);
            }
            else transform.localScale = new Vector3(-1, 1, 1);
        }

        if(mover<0.5f)
        {
            if (crouchdroid)
            {
                transform.localScale = new Vector3(1, 0.6f, 1);
            }
            else transform.localScale = new Vector3(1, 1, 1);
        }
        
    }

    public void joystickmovement() //ASSIGN SLIDER VALUE WHEN SLIDER IS MOVED
    {
        mover = slider.value;
    }

    public void reset() //BEGIN SLIDER RETURN TO 0.5 AFTER FINGER LIFT
    {
        beginprocedure = true;
    }

    public void sari() //STOP JUMPING WHEN BUTTON IS NO LONGER PRESSED
    {
        sary = false;
    }

    public void nusari() //START JUMPING WHEN BUTTON IS BEING HELD
    {
        sary = true;
    }

    public void jumbo() //JUMBO
    {
        if (lapamant)
        {
            baiet.velocity = new Vector2(baiet.velocity.x, puteredesaritura);
            audioSource.clip = Scored;
            audioSource.Play();
        }
    }

    void FixedUpdate()
    {
        //RETURN SLIDER TO 0.5 BEGIN
        if (beginprocedure)
        {
            if (slider.value < 0.5f) slider.value += 0.03f;
            else slider.value -= 0.03f;
            mover = slider.value;

            if(slider.value<0.55f && slider.value>0.45f)
            {
                beginprocedure = false;
                mover = 0.5f;
                slider.value = 0.5f;
            }
        }
        //RETURN SLIDER TO 0.5 END

        //MOVE ON ANDROID BEGIN
        go = new Vector2(mover - 0.5f, 0);

        if (go.x > 0.03f)
        {
            if (atingeredematase != 1) baiet.AddForce(AndroidOspeed * go, 0);
        }

        if(go.x < -0.03f)
        {
            if (atingeredematase != 2) baiet.AddForce(AndroidOspeed * go, 0);
        }

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.DownArrow) || crouchdroid)
        {
            transform.localScale = new Vector3(1, 0.6f, 1);
        }
        //MOVE ON ANDROID END

        //MOVE ON PC BEGIN
         h = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Horizontal") > 0)
        {
            if (atingeredematase != 1) baiet.AddForce((Vector2.right * vitezas) * h);
        }
        else
        {
            if (atingeredematase != 2) baiet.AddForce((Vector2.right * vitezas) * h);
        }
        //MOVE ON PC END

        //SET TOP SPEED BEGIN
        if (baiet.velocity.x > TopSpeed)
        {
            baiet.velocity = new Vector2(TopSpeed, baiet.velocity.y);
        }

        if (baiet.velocity.x < -TopSpeed)
        {
            baiet.velocity = new Vector2(-TopSpeed, baiet.velocity.y);
        }

        //SET TOP SPEED END

        //JUMP BEGIN
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || sary)
        {
            if (lapamant)
            {
                baiet.velocity = new Vector2(baiet.velocity.x, puteredesaritura);
                audioSource.clip = Scored;
                audioSource.Play();
            }
        }
        //JUMP END
    }
}