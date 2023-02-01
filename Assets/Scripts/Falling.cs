using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Falling : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject statusPanel;
    //[HideInInspector]
    public int score;//сколько очков начисляет предмет (если score =0, это плохой предмет, отбирает жизнь)
    private float v;
    [HideInInspector]
    public bool IsOver { get; set; } =false;
    //[ExecuteInEditMode]
    private GameObject bottom;
    private float bottomY;
    void Start()
    {
        if (bottom == null)
            bottom = GameObject.Find("Bottom");
        v = GameObject.Find("Spawner").GetComponent<Movement>().speed;
        bottomY = bottom.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOver)
            Destroy(gameObject);
        CheckBottom();
        
    }
    private void OnMouseDown()
    {
        if (score == 0)
        {
            MinusLive();
            Destroy(gameObject);
        }
        else if (score > 0)
        {
            GameObject.Find("Game").GetComponent<CheckStatus>().score += score;
            Destroy(this.gameObject);
        }
    }
    private void CheckBottom()
    {
        if (gameObject.transform.position.y <= bottomY)
        {
            if (score > 0)
                MinusLive();
            Destroy(this.gameObject);
        }    
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - (0.03f*v), gameObject.transform.position.z);

    }
    private void MinusLive()
    {

        int health = GameObject.Find("Spawner").GetComponent<Movement>().hearts -= 1;
        GameObject.Find("H" + (5 - health).ToString()).GetComponent<Image>().enabled = false;
    }
}
