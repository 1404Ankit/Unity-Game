using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {
    public float speed;
    public GameManager gamemanager;

     void Awake()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
		
	}
    private void OnCollisionEnter2D(Collision2D col)
    {
        if ((this.gameObject.tag == "BlueCircle" || this.gameObject.tag == "RedCircle") && (col.gameObject.tag == "LeftCar" || col.gameObject.tag == "RightCar"))
        {
            gamemanager.ScoreUpdate();
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Destroyer")
        {
            Destroy(this.gameObject);
        }
        if ((this.gameObject.tag == "BlueSquare" || this.gameObject.tag == "RedSquare") && (col.gameObject.tag == "LeftCar" || col.gameObject.tag == "RightCar"))
        {
            gamemanager.Death();
        }
    }

  
}
