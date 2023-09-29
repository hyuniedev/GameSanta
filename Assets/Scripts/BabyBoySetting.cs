using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBoySetting : MonoBehaviour
{
    public GameObject winnn;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (MovePlayer.slCandy!=0)
            {
                animator.SetFloat("winner", 1);
                Invoke("ChienThang", 2.7f);
            }
        }
    }
    private void ChienThang()
    {
        winnn.GetComponent<GameController>().setWin();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            animator.SetFloat("winner", 0);
        }
    }
}
