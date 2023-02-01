using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    [HideInInspector]
    public int hearts { get; set; } = 5;
    [HideInInspector]

    public int score { get; set; } = 0;
    [HideInInspector]
    public bool runSpawn { get; set; } = true;
    [SerializeField]

    public float delayT;
    public GameObject RightSide;
    public GameObject[] fall_objs;
    [SerializeField]
    public float speed  = 0;
    public void Start()
    {
        InvokeRepeating("Spawn", Time.time, delayT);
    }
   /* private void Update()
    {
        if (hearts <= 0)
            this.gameObject.SetActive(false);
    }*/

    public void Spawn()
    {
        if (runSpawn)//runSpawn = false при поражении и объекты перестают спавниться
        {
            Vector3 newPos = new Vector3(Random.Range(this.gameObject.transform.position.x, RightSide.transform.position.x), 
                gameObject.transform.position.y, gameObject.transform.position.z);
            GameObject fallingObj = fall_objs[Random.Range(0, fall_objs.Length)];
            Instantiate(fallingObj, newPos, fallingObj.transform.rotation);
        }
        else
            return;
    }
}
