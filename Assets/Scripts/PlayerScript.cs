using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    public SoundManager audioSource;
    public float moveForce = 40f;
    public float jumForce = 400f;
    //tốc độ tối thiểu
    public float maxVelocity = 4f;
    //animation 
    private Animator anim;
    //giridbody
    private Rigidbody2D myBody;
    bool grounded;

    //ban
    public GameObject bullet;
    public GameObject bullet2;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;

    //mau
    public Slider mau;
    public float maxMau;
    float CurrentMau;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();   
    }
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
        CurrentMau = maxMau;
        mau.maxValue = maxMau;
        mau.value = maxMau;
    }
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.F))
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }
    private void FixedUpdate()
    {
        RunPlayer();
    }

    void RunPlayer()
    {
        float forceX = 0f;
        float forceY = 0f;
      
        float vel = Mathf.Abs(myBody.velocity.x);//tinh van toc hien tai

        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0)
        {
            //neu van toc hien tai nho hon van toc toi thiểu
            if (vel < maxVelocity)
            {
                //neu cham dat tag ground
                if (grounded)
                {
                    //set forcex
                    forceX = moveForce;
                }
                else
                {
                    forceX = moveForce * 1.1f;
                }
            }
            Vector3 scale = transform.localScale;
            //1f là qua phải , -1f thì ngược lại
            scale.x = 1f;
            transform.localScale = scale;
        }
        else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                if (grounded)
                {
                    forceX = -moveForce;
                }
                else
                {
                    forceX = -moveForce * 1.1f;
                }
            }
            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            audioSource.Playsound("jump");
            if (grounded)
            {
                //xet độ nhảy
                forceY = jumForce;
                //grounded = false
                grounded = false;

                anim.SetBool("jump", true);

            }
        }
        Vector3 temp = transform.position;
        myBody.AddForce(new Vector2(forceX, forceY));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            //có va chạm với ground => true
            grounded = true;
            anim.SetBool("jump", false);


        }
        else if(collision.gameObject.tag == "Dead")
        {
            // nhân vật hs
            //transform.position = new Vector3(-8, 4, 0);
            audioSource.Playsound("destroy");
            Destroy(gameObject);

            if (BntPause.insance != null)
            {
                BntPause.insance.panelDead.SetActive(true);
            }
            Time.timeScale = 0;
            if (PlayerPrefs.HasKey("highscore"))
            {
                if (PlayerPrefs.GetFloat("highscore") < CountCoin.instance.Total_coin)
                {
                    PlayerPrefs.SetFloat("highscore", CountCoin.instance.Total_coin);
                }
            }
            else
            {
                PlayerPrefs.SetFloat("highscore", CountCoin.instance.Total_coin);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dan")
        {
            CurrentMau -= 1;
            mau.value = CurrentMau;
            if (CurrentMau <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void Fire()
    {
        bulletPos = transform.position;
        bulletPos += new Vector2(+0.6f, -0.5f);
        Instantiate(bullet, bulletPos, Quaternion.identity);
        Instantiate(bullet2, transform.position, Quaternion.identity);
    }

}
