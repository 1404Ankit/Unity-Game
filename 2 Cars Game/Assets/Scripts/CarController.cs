using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    private float middlepoint;
    public bool IsthecaronLeft;

	// Use this for initialization
	void Start () {
        middlepoint = Screen.width / 2;
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckMousePress();
	}

    private void CheckMousePress()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x < middlepoint && this.gameObject.tag == "LeftCar")
            {
                MoveCar();
            }

            if (Input.mousePosition.x > middlepoint && this.gameObject.tag == "RightCar")
            {
                MoveCar();
            }
        }
    }

    private void MoveCar()
    {
        if (IsthecaronLeft)
        {
            IsthecaronLeft = false;
            this.transform.Translate(Vector3.right * 1.8f);
        }
        else if (IsthecaronLeft == false)
        {
            this.transform.Translate(Vector3.left * 1.8f);
            IsthecaronLeft = true;
        }
    }
        

   
}
