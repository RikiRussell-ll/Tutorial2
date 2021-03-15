using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
 
public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
 
    public float speed;
 
    public Text score;
 
    private int scoreValue = 0;
 
    Animator anim;
     //text stuff
    
    private int lives;

    public Text winText;

    public Text lifeText;

    public AudioClip musicClipOne;

    public AudioClip musicClipTwo;

    public AudioSource musicSource;

    
 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rd2d = GetComponent<Rigidbody2D>();
        score.text = "Score " + scoreValue.ToString();
        //text
        lives = 3;
        winText.text = "";
        lifeText.text = "Lives: 3";

        //music 
        musicSource.clip = musicClipOne;
        musicSource.Play();

    }
    void Update()
    {

        //walking animation
        if (Input.GetKeyDown(KeyCode.A))
        {   
            anim.SetInteger("State",1);
        transform.localScale += new Vector3(-6, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("State",0);
        transform.localScale += new Vector3(6, 0, 0);
        }


 
        //walking animation
         if (Input.GetKeyDown(KeyCode.D))
        {   
            anim.SetInteger("State",1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("State",0);
        }
 

        //exit game
        if (Input.GetKey("escape"))
        {
             Application.Quit();
        }
 
    }
 
    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = "Score " + scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }
        if (scoreValue >= 8)
        {
            winText.text = "You Win! Game made by Riki Russell" ;
        }
        if (scoreValue == 4)
        {
            transform.position = new Vector3(62f,1,0);
        }
 
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }

        if (collision.collider.tag == "Enemy")
        {
            lives -=1;
            lifeText.text = "Lives " + lives.ToString();
            Destroy(collision.collider.gameObject);
            if (lives == 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
 
}
 

