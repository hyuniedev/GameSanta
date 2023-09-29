using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speedMove = 0.005f;
    public float timeMove = 3.0f;
    private float chuyen = -1.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(chuyenHuong), 0.0f, timeMove);
    }

    // Update is called once per frame
    void Update()
    {
        diChuyen(this.gameObject);
    }
    public void diChuyen(GameObject gobj)
    {
        Vector3 vector = gobj.transform.position;
        vector.x = vector.x + speedMove * chuyen;
        gobj.transform.position = vector;
    }
    private void chuyenHuong()
    {
        chuyen *= -1.0f;
    }
}
