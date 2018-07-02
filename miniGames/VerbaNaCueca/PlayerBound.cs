using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBound : MonoBehaviour {

    public float minX, maxX;

    private void Start()
    {
        //Vector3 coor = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)); // x,y e z da tela
        minX = -43;
        maxX = 67;
    }

    private void Update()
    {
        Vector3 temp = transform.position;
        if (temp.x > maxX)
        {
            temp.x = maxX;
        }
        if  (temp.x < minX)
        {
            temp.x = minX;
        }

        transform.position = temp;

        }


}// class
