using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject ball = null;
    public int speed = 150;
    private int Xspeed = 0;
    private int Zspeed = 0;

    private float speedRotate = 1.0f;
    private float xAngle = 0.0f;
    private float yAngle = 0.0f;

    void Start() 
    {
    }

    private void keyControllUpdate() {
        Vector3 velocity1 = Zspeed/10 * transform.forward;
        Vector3 velocity2 = Xspeed/10 * transform.right;

        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(velocity1.x + velocity2.x,
                                                                    velocity1.y + velocity2.y,
                                                                    velocity1.z + velocity2.z);

        if (Input.GetKey("w")) Zspeed = speed;
        if (Input.GetKey("s")) Zspeed = -speed;
        if (Zspeed > 0) Zspeed -= 1;
        if (Zspeed < 0) Zspeed += 1;

        if (Input.GetKey("d")) {
            
            Xspeed = speed;
        }
        if (Input.GetKey("a")) Xspeed = -speed;
        if (Xspeed > 0) Xspeed -= 1;
        if (Xspeed < 0) Xspeed += 1;
    }

    private void mouseControllUpdate() {
        if(Input.GetAxis("Mouse X") < 0) {
            xAngle -= speedRotate;
        }
        if(Input.GetAxis("Mouse X") > 0) {
            xAngle += speedRotate;
        }
        if(Input.GetAxis("Mouse Y") < 0) {
            yAngle += speedRotate;
        }
        if(Input.GetAxis("Mouse Y") > 0) {
            yAngle -= speedRotate;
        }
        gameObject.GetComponent<Transform>().eulerAngles = new Vector3(yAngle, xAngle, 0.0f);
    }

    private void generateBallUpdate() {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(ball, new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y, gameObject.GetComponent<Transform>().position.z), transform.rotation);
        }
    }

    void Update()
    {
        keyControllUpdate();
        mouseControllUpdate();
        generateBallUpdate();
    }
}
