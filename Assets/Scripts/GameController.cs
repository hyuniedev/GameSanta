using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private bool Win = false;
    private static int scenePlay = 2;
    public GameObject tuyet;
    private GameObject tuyetRoi;
    public GameObject player;
    private List<GameObject> dsTuyet;
    private float xMin, xMax, yMin, yMax;
    // Start is called before the first frame update
    void Start()
    {
        dsTuyet = new List<GameObject>();
        xMin = -19;
        xMax = 80;
        yMin = 10;
        yMax = 24;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Random.Range(xMin, xMax);
        float y = Random.Range(yMin, yMax);
        if(tuyet!=null&&dsTuyet.Count<1500)
        { 
            tuyetRoi = Instantiate(tuyet, new Vector2(x, y),Quaternion.identity);
            dsTuyet.Add(tuyetRoi);
        }
        if (Win)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void setWin()
    {
        Win = true;
    }
    public void Restart()
    {
        Win= false;
        MovePlayer.slCandy = 0;
        Debug.Log(scenePlay);
        SceneManager.LoadScene(scenePlay);
    }
    public void NextScene()
    {
        Win = false;
        MovePlayer.slCandy = 0;
        Debug.Log(scenePlay);
        scenePlay++;
        SceneManager.LoadScene(scenePlay);
    }
}
