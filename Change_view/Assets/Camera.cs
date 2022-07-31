using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Vector2 rotate = new Vector2();
    public float speed = 5;
    private float first;

    private void Start()
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rotate.y = Input.GetAxis("Mouse Y") * speed;
        rotate.y = Mathf.Clamp(rotate.y, -10, 10);
        transform.eulerAngles += new Vector3(-rotate.y,0, 0);
    }
}
