using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector2 movement = new Vector2();
    Vector2 rotate = new Vector2();
    public float speed = 5f;
    public float rspeed = 5f;
    public float fspeed = 1f;
    private float dist;
    Animator animator;
    private bool isGround=true;
    private bool isHuman = true;

    public GameObject Human1;
    public GameObject Human2;
    public GameObject Eagle;
    public Rigidbody rb;


    private void Start()
    {
        animator = GetComponent<Animator>();
        Eagle.SetActive(false);
        Human1.SetActive(true);
        Human2.SetActive(true);
    }
    private void Update()
    {
        UpdateState();
        Planecheck();
        Changestate();
    }
    void FixedUpdate()
    {
        if (isHuman) Move_human();
        else Move_Eagle();

    }

    private void UpdateState()
    {
        if (movement.x != 0||movement.y!=0)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
    private void Planecheck()
    {
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.direction = Vector3.down;
        RaycastHit Hit;
        if (Physics.Raycast(ray, out Hit) == true)
        {
            if (Hit.collider.tag == "terrain")
            {
                if (Hit.distance < 0.5f)
                {
                    isGround = true;
                }
                else
                {
                    isGround = false;
                }
            }

        }

    }
    private void Changestate()
    {
        if (Input.GetKeyDown("c"))
        {
            isHuman = !isHuman;
            Eagle.SetActive(!isHuman);
            Human1.SetActive(isHuman);
            Human2.SetActive(isHuman);
        }
        
    }

    private void Move_human()
    {
        Vector3 dir = transform.localRotation * Vector3.forward;
        Vector3 dir2 = transform.localRotation * Vector3.right;
        movement.x = 0;
        movement.y = 0;
        rotate.x = 0;
        movement.x = Input.GetAxis("Horizontal") * speed;
        movement.y = Input.GetAxis("Vertical") * speed;
        rotate.x = Input.GetAxis("Mouse X") * rspeed;
        rotate.x = Mathf.Clamp(rotate.x, -80, 80);

        transform.position += (dir * movement.y) * Time.deltaTime;
        transform.position += (dir2 * movement.x) * Time.deltaTime;

        transform.eulerAngles += new Vector3(0, rotate.x, 0);
    }
    private void Move_Eagle()
    {
        Vector3 dir = transform.localRotation * Vector3.forward;
        Vector3 dir2 = transform.localRotation * Vector3.right;
        movement.x = 0;
        movement.y = 0;
        rotate.x = 0;
        movement.x = Input.GetAxis("Horizontal") * speed;
        movement.y = Input.GetAxis("Vertical") * speed;
        rotate.x = Input.GetAxis("Mouse X") * rspeed;
        rotate.x = Mathf.Clamp(rotate.x, -80, 80);

        transform.position += (dir * movement.y) * Time.deltaTime;
        transform.position += (dir2 * movement.x) * Time.deltaTime;

        transform.eulerAngles += new Vector3(0, rotate.x, 0);

        if (Input.GetKey("space"))
        {
            if (transform.position.y < 30)
            {
                rb.velocity += new Vector3(0f, fspeed, 0f);
            }
                    }
        else if(!isGround)
        {
            //transform.position += new Vector3(0, -fspeed, 0);
        }
    }

}
