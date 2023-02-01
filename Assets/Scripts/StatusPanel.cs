using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* realStatusLive = GameObject.Find("Spawner").GetComponent<Movement>().hearts;
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
                pausePanel.SetActive(true);
                GameObject.Find("Spawner").SetActive(false);
            }
        }
        else if (score >= 20 && realStatusLive > 0)
        {

            statusPanel.SetActive(false);
            gameStatus.text = "Victory!";
            pausePanel.SetActive(true);
        }*/
    }
}
