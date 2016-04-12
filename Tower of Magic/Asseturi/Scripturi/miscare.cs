using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class miscare : MonoBehaviour
{
    private Animator life;
    private Animator animleft;
    private Animator animright;
    private Animator butoncrauci;

    private float iscrouch = 1f;
    public float crouchvalue;

    public bool badman;
    public bool deal = true;
    public int damage = 0;
    public float timer = 0;
    public float startedINVINCIBLE;
    public int debug;
    public float FEEToffsetCROUCHx;
    public float FEEToffsetCROUCHy;
    public float FEEToffsetX;
    public float FEEToffsetY;
    public float leftFEEToffsetCROUCHx;
    public float leftFEEToffsetCROUCHy;
    public float leftFEEToffsetX;
    public float leftFEEToffsetY;
    public bool firsttimer;
    public bool passed = false;
    public bool touchenemy = false;
    public static int lifer = 12;
    public bool left = false;
    public float horizontaloffsetcrouch;
    public float verticaloffsetcrouch;
    public float crouchsize;
    public bool crauci = false;
    public bool crouchdroid = false;
    public bool beginprocedure;
    public AudioSource audioSource;
    public AudioClip Scored;
    private bool android;
    public float AndroidOspeed;
    public float h;
    public Vector2 go;
    public bool george;
    public bool kek;
    public bool sary;
    public bool selected = false;
    public int MoveOtouch; // 1 stanga - 2 dreapta //
    public bool JumpOtouch = false;
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

    public GameObject hearts;
    public GameObject animLEFT;
    public GameObject animRIGHT;
    public GameObject crouchbutton;

    public SpriteRenderer colorredLEFT;
    public SpriteRenderer colorredRIGHT;

    private BoxCollider2D box;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "jumpable")
            lapamant = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "jumpable")
            lapamant = false;
    }

    void DealDamage()
    {
        if (timer > startedINVINCIBLE + 0.75f)
        {
            GlobalSettings.invincible = false;
            colorredLEFT.color = new Color(1f, 0.5f, 0.5f, 1f);
            colorredRIGHT.color = new Color(1f, 0.5f, 0.5f, 1f);
        }
        else
        {
            colorredLEFT.color = new Color(1f, 1f, 1f, 1f);
            colorredRIGHT.color = new Color(1f, 1f, 1f, 1f);
        }

        if (GlobalSettings.invincible == false)
        {
            lifer -= damage;

            if (lifer <= 0)
            {
                GlobalSettings.ded = true;
                Application.LoadLevel("MainMenu");
            }
            startedINVINCIBLE = timer;
            GlobalSettings.invincible = true;
        }

    }

    void Start()
    {
        if (GlobalSettings.ded == true || GlobalSettings.invincible == true || lifer<12)
        {
            GlobalSettings.ded = false;
            GlobalSettings.invincible = false;
            lifer = 12;
        }

        if (GlobalSettings.isonpause == true)
        {
            GlobalSettings.isonpause = false;
            Time.timeScale = 1;
        }
        
        life = hearts.GetComponent<Animator>();

        if (Application.platform == RuntimePlatform.Android) android = true;

        if (!android) slider.value = 0.49f;

        baiet = gameObject.GetComponent<Rigidbody2D>();
        box = gameObject.GetComponent<BoxCollider2D>();

        animright = animRIGHT.GetComponent<Animator>();
        animleft = animLEFT.GetComponent<Animator>();
        butoncrauci = crouchbutton.GetComponent<Animator>();

        colorredLEFT = animLEFT.GetComponent<SpriteRenderer>();
        colorredRIGHT = animRIGHT.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        life.SetInteger("Life", lifer);

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
            animright.SetFloat("Speed", Mathf.Abs(2 * (mover - 0.5f)) * iscrouch);
            animleft.SetFloat("Speed", Mathf.Abs(2 * (mover - 0.5f)) * iscrouch);
        }
        else
        {
            animright.SetFloat("Speed", Mathf.Abs(h) * iscrouch);
            animleft.SetFloat("Speed", Mathf.Abs(h) * iscrouch);
        }
        //ANIMATZIONE END

        //CROUCH BEGIN
        if (!android)
        {
            if (h < 0)
            {
                left = true;

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
                    crauci = false;
                    iscrouch = 1f;
                    //animRIGHT.gameObject.SetActive(false);
                    //animLEFT.gameObject.SetActive(true);
                    animright.SetBool("crouchy", false);
                    animleft.SetBool("crouchy", false);
                }
            }
            if (h >= 0)
            {
                left = false;
                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.DownArrow) || crouchdroid)
                {
                    crauci = true;
                    iscrouch = crouchvalue;
                    animright.SetBool("crouchy", true);
                    animleft.SetBool("crouchy", true);
                    //animRIGHT.gameObject.SetActive(true);
                    //animLEFT.gameObject.SetActive(false);
                }
                else
                {
                    crauci = false;
                    iscrouch = 1f;
                    animright.SetBool("crouchy", false);
                    animleft.SetBool("crouchy", false);
                    //animRIGHT.gameObject.SetActive(true);
                    //animLEFT.gameObject.SetActive(false);
                }
            }
        }
        if (android)
        {
            if (mover >= 0.455f)
            {
                left = false;
                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.DownArrow) || crouchdroid)
                {
                    crauci = true;
                    iscrouch = crouchvalue;
                    animright.SetBool("crouchy", true);
                    animleft.SetBool("crouchy", true);
                    //animRIGHT.gameObject.SetActive(true);
                    //animLEFT.gameObject.SetActive(false);
                }
                else
                {
                    crauci = false;
                    iscrouch = 1f;
                    animright.SetBool("crouchy", false);
                    animleft.SetBool("crouchy", false);
                    //animRIGHT.gameObject.SetActive(true);
                    //animLEFT.gameObject.SetActive(false);
                }
            }

            if (mover < 0.455f)
            {
                left = true;

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
                    crauci = false;
                    iscrouch = 1f;
                    //animRIGHT.gameObject.SetActive(false);
                    //animLEFT.gameObject.SetActive(true);
                    animright.SetBool("crouchy", false);
                    animleft.SetBool("crouchy", false);
                }
            }
        }
        //CROUCH END
    }

    public void changezecrouch() //CROUCH SWITCH WHEN BUTTON PRESS
    {
        crouchdroid = !crouchdroid;
        butoncrauci.SetBool("iscrouci", crouchdroid);
        if (mover >= 0.5f || h >= 0)
        {
            if (crouchdroid)
            {
                iscrouch = crouchvalue;
                left = false;
                crauci = true;
                animright.SetBool("crouchy", true);
                animleft.SetBool("crouchy", true);
                //animRIGHT.gameObject.SetActive(true);
                //animLEFT.gameObject.SetActive(false);
            }
            else
            {
                iscrouch = 1f;
                left = false;
                crauci = false;
                animright.SetBool("crouchy", false);
                animleft.SetBool("crouchy", false);
                //animRIGHT.gameObject.SetActive(true);
                //animLEFT.gameObject.SetActive(false);
            }
        }

        if (mover < 0.5f || h < 0)
        {
            left = true;
            if (crouchdroid || crauci)
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
        if ((crouchdroid && lapamant) || (crauci && lapamant))
        {
            box.size = new Vector2(0.6983392f, crouchsize);

            if (!left)
            {
                box.offset = new Vector2(-0.5f, verticaloffsetcrouch);
            }
            else
            {
                box.offset = new Vector2(horizontaloffsetcrouch, verticaloffsetcrouch);
            }
        }
        else
        {
            box.size = new Vector2(0.6983392f, 1.780104f);
            if (!left)
            {
                box.offset = new Vector2(-0.6f, -0.7063659f);
            }
            else
            {
                box.offset = new Vector2(-0.6f, -0.7063659f);
            }
        }

        //RETURN SLIDER TO 0.5 BEGIN
        if (android)
        {
            if (beginprocedure)
            {
                if (slider.value < 0.5f) slider.value += 0.03f;
                else slider.value -= 0.03f;
                mover = slider.value;

                if (slider.value < 0.55f && slider.value > 0.45f)
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

            if (go.x < -0.03f)
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
        }
        //MOVE ON ANDROID END

        //MOVE ON PC BEGIN
        h = Input.GetAxis("Horizontal");

        if (h > 0)
        {
            if (atingeredematase != 1) baiet.AddForce((Vector2.right * vitezas) * h * iscrouch);
        }
        else
        {
            if (atingeredematase != 2) baiet.AddForce((Vector2.right * vitezas) * h * iscrouch);
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
                audioSource.volume = GlobalSettings.vol * GlobalSettings.peasantvol;
                audioSource.Play();
            }
        }
        //JUMP END
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.tag=="Enemy")
        {
            InvokeRepeating("DealDamage", 0f, 0.1f);
            GlobalSettings.invincible = true;
            
            damage++;
        }

        if (obj.tag == "Enemy2")
        {
            InvokeRepeating("DealDamage", 0f, 0.1f);
            GlobalSettings.invincible = true;

            damage+=2;
        }

        if (obj.tag == "Enemy4")
        {
            InvokeRepeating("DealDamage", 0f, 0.1f);
            GlobalSettings.invincible = true;

            damage+=4;
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if(obj.tag=="Enemy")
        {
            colorredLEFT.color = new Color(1f, 1f, 1f, 1f);
            colorredRIGHT.color = new Color(1f, 1f, 1f, 1f);

            CancelInvoke("DealDamage");
            damage--;
        }

        if (obj.tag == "Enemy2")
        {
            colorredLEFT.color = new Color(1f, 1f, 1f, 1f);
            colorredRIGHT.color = new Color(1f, 1f, 1f, 1f);

            CancelInvoke("DealDamage");
            damage-=2;
        }

        if (obj.tag == "Enemy4")
        {
            colorredLEFT.color = new Color(1f, 1f, 1f, 1f);
            colorredRIGHT.color = new Color(1f, 1f, 1f, 1f);

            CancelInvoke("DealDamage");
            damage-=4;
        }
    }
}