using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class miscare : MonoBehaviour
{
    private Animator animleft;
    private Animator animright;
    private Animator butoncrauci;

    private float iscrouch = 1f;
    public float crouchvalue;

    public float FEEToffsetCROUCHx;
    public float FEEToffsetCROUCHy;
    public float FEEToffsetX;
    public float FEEToffsetY;
    public float leftFEEToffsetCROUCHx;
    public float leftFEEToffsetCROUCHy;
    public float leftFEEToffsetX;
    public float leftFEEToffsetY;

    public bool left=false;
    public float horizontaloffsetcrouch;
    public float verticaloffsetcrouch;
    public float crouchsize;
    public bool crauci;
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

    public GameObject animLEFT;
    public GameObject animRIGHT;
    public GameObject crouchbutton;

    private BoxCollider2D box;
    public BoxCollider2D feet;

    void Start()
    {
        baiet = gameObject.GetComponent<Rigidbody2D>();
        box = gameObject.GetComponent<BoxCollider2D>();

        animright = animRIGHT.GetComponent<Animator>();
        animleft = animLEFT.GetComponent<Animator>();
        butoncrauci =crouchbutton.GetComponent<Animator>();
    }

    void Update()
    {
        if (left)
        {
            turnonLEFT();
            turnoffRITE();
        }
        else
        {
            turnoffLEFT();
            turnonRITE();
        }

        //ANIMATZIONE BEGIN
        animright.SetBool("Pamantpe", lapamant);
        animleft.SetBool("Pamantpe", lapamant);

        if (android)
        {
            animright.SetFloat("Speed", Mathf.Abs(2 * (mover - 0.5f))*iscrouch);
            animleft.SetFloat("Speed", Mathf.Abs(2 * (mover - 0.5f))*iscrouch);
        }
        else
        {
            animright.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
            animleft.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        }
            //ANIMATZIONE END

            //CROUCH BEGIN
            if (Input.GetAxis("Horizontal") < -0.1f || mover< 0.5f)
            {
                
                left = true;
                crauci = true;
                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.DownArrow) || crouchdroid)
                 {
                    iscrouch = crouchvalue;
                    crauci = true;
                    animright.SetBool("crouchy", true);
                    animleft.SetBool("crouchy", true);

                    //animRIGHT.gameObject.SetActive(false);
                    //animLEFT.gameObject.SetActive(true);
                 }
                 else
                 {
                iscrouch = 1f;
                //animRIGHT.gameObject.SetActive(false);
                //animLEFT.gameObject.SetActive(true);
                animright.SetBool("crouchy", false);
                     animleft.SetBool("crouchy", false);
                  }
            }

        if (Input.GetAxis("Horizontal") > 0.1f || mover>= 0.5f)
        {
            left = false;
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.DownArrow) || crouchdroid)
            {
                iscrouch = crouchvalue;
                animright.SetBool("crouchy", true);
                animleft.SetBool("crouchy", true);
                //animRIGHT.gameObject.SetActive(true);
                //animLEFT.gameObject.SetActive(false);
            }
            else
            {
                iscrouch = 1f;
                animright.SetBool("crouchy", false);
                animleft.SetBool("crouchy", false);
                //animRIGHT.gameObject.SetActive(true);
                //animLEFT.gameObject.SetActive(false);
            }
        }
        //CROUCH END
    }

    public void changezecrouch() //CROUCH SWITCH WHEN BUTTON PRESS
    {
        crouchdroid = !crouchdroid;
        butoncrauci.SetBool("iscrouci", crouchdroid);
        if (mover >= 0.5f)
        {
            if (crouchdroid)
            {
                iscrouch = crouchvalue;
                left = false;
                animright.SetBool("crouchy", true);
                animleft.SetBool("crouchy", true);
                //animRIGHT.gameObject.SetActive(true);
                //animLEFT.gameObject.SetActive(false);
            }
            else
            {
                iscrouch = 1f;
                left = false;
                animright.SetBool("crouchy", false);
                animleft.SetBool("crouchy", false);
                //animRIGHT.gameObject.SetActive(true);
                //animLEFT.gameObject.SetActive(false);
            }
        }

        if(mover<0.5f)
        {
            left = true;
            if (crouchdroid)
            {
                iscrouch = crouchvalue;
                animright.SetBool("crouchy", true);
                animleft.SetBool("crouchy", true);
                //animRIGHT.gameObject.SetActive(false);
                //animLEFT.gameObject.SetActive(true);
            }
            else
            {
                iscrouch = 1f;
                left = true;
                animright.SetBool("crouchy", false);
                animleft.SetBool("crouchy", false);
                //animRIGHT.gameObject.SetActive(false);
                //animLEFT.gameObject.SetActive(true);
            }
        }
        
    }

    private void turnoffRITE()
    {
        animRIGHT.transform.localScale = new Vector2(0f, 1f);
    }
    private void turnonRITE()
    {
        animRIGHT.transform.localScale = new Vector2(1f, 1f);
    }
    private void turnoffLEFT()
    {
        animLEFT.transform.localScale = new Vector2(0f, 1f);
    }
    private void turnonLEFT()
    {
        animLEFT.transform.localScale = new Vector2(1f, 1f);
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
        
        if(crouchdroid && lapamant)
        {
            box.size = new Vector2(0.6983392f, crouchsize);

            if (!left)
            {
                box.offset = new Vector2(-0.5f, verticaloffsetcrouch);
                feet.offset = new Vector2(FEEToffsetCROUCHx, FEEToffsetCROUCHy);
            }
            else
            {
                box.offset = new Vector2(horizontaloffsetcrouch, verticaloffsetcrouch);
                feet.offset = new Vector2(leftFEEToffsetCROUCHx, leftFEEToffsetCROUCHy);
            }
        }
        else
        {
            box.size = new Vector2(0.6983392f, 1.780104f);
            if (!left)
            {
                box.offset = new Vector2(-0.6f, -0.7063659f);
                feet.offset = new Vector2(FEEToffsetX, FEEToffsetY);
            }
            else
            {
                box.offset = new Vector2(-0.24f, -0.7063659f);
                feet.offset = new Vector2(leftFEEToffsetX, leftFEEToffsetY);
            }
        }

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
            if (atingeredematase != 1) baiet.AddForce(AndroidOspeed * go * iscrouch, 0);
        }

        if(go.x < -0.03f)
        {
            if (atingeredematase != 2) baiet.AddForce(AndroidOspeed * go * iscrouch, 0);
        }

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.DownArrow) || crouchdroid)
        {
            iscrouch = crouchvalue;
            animright.SetBool("crouchy", true);
            animleft.SetBool("crouchy", true);
        }
        else
        {
            iscrouch = 1f;
            animright.SetBool("crouchy", false);
            animleft.SetBool("crouchy", false);
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