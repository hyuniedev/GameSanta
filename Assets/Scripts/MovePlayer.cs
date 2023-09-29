using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    public Text txtCandy;
    public int slCandy = 0;
    public bool bloodPlayer = true;
    private Rigidbody2D rb;
    private Animator animator;
    private float speedMove = 8.5f;
    private float trai_phai;
    private bool seeRight;
    private bool jumped;
    private bool dekiruRun;
    private MoveObject wfly;
    private bool mww;
    private bool complete = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        seeRight = true;
        jumped = false;
        dekiruRun = false;
        mww = false;
        wfly = null;
    }
    void Update()
    {
        if(bloodPlayer)
        {
            Walk();
            Run();
            Jump();
            Slide();
        }
        MoveWithWall();
        Died();
    }
    private void MoveWithWall()
    {
        if (mww&&trai_phai==0&&wfly!=null)
        {
            wfly.diChuyen(this.gameObject);
        }
    }
    public void Revival()
    {
        SceneManager.LoadScene(0);
    }
    public void Died()
    {
        this.animator.SetBool("dead", bloodPlayer);
        if(!bloodPlayer)
        {
            Invoke(nameof(HienMenu), 0.65f);
        }
    }
    private void HienMenu()
    {
        SceneManager.LoadScene(1);
    }
    private void Slide() 
    {
        if (trai_phai != 0)
        {
            if(Input.GetKey(KeyCode.S))
            {
                this.animator.SetFloat("slide", 1.0f);
                jumped = true;
            }else if (Input.GetKeyUp(KeyCode.S))
            {
                jumped=false;
            }
            else
            {
                this.animator.SetFloat("slide", 0.0f);
            }
        }
    }
    private void Walk()
    {
        if (!complete)
        {
            trai_phai = Input.GetAxis("Horizontal");
            this.rb.velocity = new Vector2(trai_phai * speedMove, this.rb.velocity.y);
            swap();
            if (trai_phai == 0)
            {
                this.animator.SetFloat("walk", -1.0f);
            }
            else
            {

                this.animator.SetFloat("walk", Mathf.Abs(trai_phai));
            }
        }
        else
        {
            this.rb.velocity = new Vector2(0, this.rb.velocity.y);
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W)&&!jumped)
        {
            rb.AddForce(new Vector2(rb.velocity.x, 1500));
            this.animator.SetFloat("jump", 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall"|| collision.gameObject.tag == "WallFly")
        {
            jumped=false;
            this.animator.SetFloat("jump", 0);
        }
        if (collision.gameObject.tag == "WallFly")
        {
            mww = true;
            wfly = collision.gameObject.GetComponent<MoveObject>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            bloodPlayer = false;
        }
        if (collision.gameObject.tag == "Candy")
        {
            slCandy++;
            txtCandy.text = "X"+slCandy.ToString();
        }
        if(collision.gameObject.tag == "BabyBoy"&&slCandy!=0)
        {
            complete = true;
            this.animator.SetFloat("walk", -1.0f);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall"|| collision.gameObject.tag == "WallFly")
        {
            jumped = true;
        }
        if(collision.gameObject.tag == "WallFly")
        {
            mww = false;
            wfly = null;
        }
    }
    private void Run()
    {
        if(dekiruRun)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speedMove *= 1.5f;
                this.animator.SetFloat("run", 1.0f);
            }
            else
            {
                speedMove = 4.5f;
                this.animator.SetFloat("run", 0.0f);
            }
        }
    }
    private void swap()
    {
        if (trai_phai < 0 && seeRight || !seeRight && trai_phai > 0)
        {
            seeRight = !seeRight;
            Vector3 v3 = this.transform.localScale;
            v3.x *= -1;
            this.transform.localScale = v3;
        }
    }
}
