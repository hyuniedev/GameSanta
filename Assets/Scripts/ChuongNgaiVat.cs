using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChuongNgaiVat : MonoBehaviour
{
    public GameObject player;
    public GameObject nv1;
    public GameObject nv2;
    public GameObject nv3;
    public GameObject nv3_1;
    public GameObject nv3_2;
    public GameObject nv4;
    public GameObject nv5;
    public GameObject wallhide;
    // Start is called before the first frame update
    void Start()
    {
        nv1.SetActive(false);
        nv2.SetActive(false);
        nv3.SetActive(false);
        nv3_1.SetActive(false);
        nv3_2.SetActive(false);
        nv4.SetActive(false);
        nv5.SetActive(false);
        wallhide.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Crystal")
        {
            if(collision.transform.parent.gameObject.name == "NV1")
            {
                nv1.SetActive(true);
            }
            if (collision.transform.parent.gameObject.name == "NV2")
            {
                nv2.SetActive(true);
            }
            if(collision.transform.parent.gameObject.name == "NV3")
            {
                nv3.SetActive(true);
                nv3_1.SetActive(true);
                nv3_2.SetActive(true);
            }
            if(collision.transform.parent.gameObject.name == "NV4")
            {
                nv4.SetActive(true);
            }
            if (collision.transform.parent.gameObject.name == "NV5")
            {
                nv5.SetActive(true);
            }
        }
        if (collision.gameObject.tag == "WallHide")
        {
            wallhide.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Crystal")
        {
            this.GetComponent<MovePlayer>().bloodPlayer = false;
        }
    }
}
