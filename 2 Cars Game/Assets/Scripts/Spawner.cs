using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Spawnertype
{
    BlueLeft,BlueRight,RedLeft,RedRight
}

public class Spawner : MonoBehaviour
{
    public Spawnertype spawnertype;
    public GameObject[] objects;
    public float delaytime = 2f;
    public float spwanrate = 1f;

    private float spawntime;
  //  private GameObject go;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > spawntime)
        {
           if (spawnertype == Spawnertype.BlueLeft && GameManager.BlueLeftTimer <= 0f)
            {
                Spawners();
                GameManager.BlueRightTimer = 2f;
            }
           if (spawnertype == Spawnertype.BlueRight  && GameManager.BlueRightTimer <= 0f)
            {
                Spawners();
                GameManager.BlueLeftTimer = 2f;
            }
           if (spawnertype == Spawnertype.RedLeft && GameManager.RedLeftTimer <= 0f)
            {
                Spawners();
                GameManager.RedRightTimer = 2f;
            }
           if (spawnertype == Spawnertype.RedRight && GameManager.RedRightTimer <= 0f)
            {
                Spawners();
                GameManager.RedLeftTimer = 2f;
            }
        }
		
	}
    private void Spawners()
    {
        float randomness = spwanrate * Time.deltaTime;
        if (randomness < Random.value)
        {
            int spawnnumber = Random.Range(0, 2);
            GameObject go = Instantiate(objects[spawnnumber]) as GameObject;
            go.transform.position = this.transform.position;
            go.transform.parent = GameObject.Find("SpwanObjects").transform;
        }
        NextLoadTime();
    }

    void onDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, 0.6f);
    }

    void NextLoadTime()
    {
        spawntime = Time.time + delaytime;
    }
}
