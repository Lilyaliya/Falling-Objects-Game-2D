using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckStatus : MonoBehaviour
{
    //we need to get realStatusLive (it contains in Movement Script of a Spawner gameobject)
    private int realStatusLive;
    [HideInInspector]
    public int score { get; set; } = 0;
    [SerializeField] private Text realSCore;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject statusPanel;
    [SerializeField] private Text gameStatus; //attached to menuText
    [SerializeField] private Text scoreStatus;//if fails
    [SerializeField] private GameObject spawner;
    //[SerializeField] private Button startGame;
    private static int c = 0;
    //[SerializeField] private Button continueGame;
    //then we disable heartsImages and rewrite a score
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(true);
        statusPanel.SetActive(false);
    }
    public void PlayButton()
    {
        c += 1;
        Restart();
    }

    private void Restart()
    {
        score = 0;
        realStatusLive = 5;
        pausePanel.gameObject.SetActive(false);
        pausePanel.SetActive(false);
        statusPanel.gameObject.SetActive(true);
        statusPanel.SetActive(true);
        if (c>1)
        for (int i = 1; i <= 5; i++)//регенерируем сердечки
        {
            var obj = GameObject.Find("H" + i.ToString());
            if (obj != null)
            {
                GameObject.Find("H" + i.ToString()).GetComponent<Image>().enabled = true;
            }

        }
        spawner.GetComponent<Movement>().enabled = true;
        spawner.GetComponent<Movement>().runSpawn = true;
        spawner.GetComponent<Movement>().hearts = 5;
        spawner.GetComponent<Movement>().score = 0;
        realSCore.text = "0/20";
        scoreStatus.text = "Score: ";
        scoreStatus.enabled = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (spawner.GetComponent<Movement>().enabled)
        {
            realStatusLive = spawner.GetComponent<Movement>().hearts;
            if (score < 20 && realStatusLive > 0)
                realSCore.text = score.ToString() + "/20";
            else if (score < 20 && realStatusLive <= 0)
            {
                statusPanel.SetActive(false);
                gameStatus.text = "Lose!";
                if (!scoreStatus.IsActive())
                {
                    scoreStatus.enabled = true;
                    scoreStatus.text += score.ToString();
                    statusPanel.SetActive(false);
                    DeleteAll();
                    pausePanel.SetActive(true);
                }
            }
            else if (score >= 20 && realStatusLive > 0)
            {

                statusPanel.SetActive(false);
                gameStatus.text = "Victory!";
                DeleteAll();
                pausePanel.SetActive(true);
            }
        }
    }

    private void DeleteAll()
    {
        spawner.GetComponent<Movement>().enabled = false;
        var objs = GameObject.FindGameObjectsWithTag("Respawn");
        for  (int i = 0; i < objs.Length; i++) 
        { 
            Destroy(objs[i]);
        }
        spawner.GetComponent<Movement>().runSpawn = false;
        //spawner.GetComponent<Movement>().CancelInvoke("Spawn");
    }
}
