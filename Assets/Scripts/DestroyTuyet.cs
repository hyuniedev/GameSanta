using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTuyet : MonoBehaviour
{
    private Vector3 positionOld;
    private Rigidbody2D rgb;
    private float tocDoRoi = -20;
    // Start is called before the first frame update
    private void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
        Invoke("thayDoiTocDo", 1.0f);
    }
    void thayDoiTocDo()
    {
        tocDoRoi = -1;
    }
    void Start()
    {
        positionOld = this.transform.position;
    }

    private void Update()
    {
        rgb.velocity = new Vector3(0,tocDoRoi,0);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Restart();
    }
    void Restart()
    {
        this.transform.position = positionOld;
    }
}
