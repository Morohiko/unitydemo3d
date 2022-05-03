using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private int speed = 50;
    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
    // Update is called once per frame
    void Update()
    {
    }

}
