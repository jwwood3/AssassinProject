using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 dest;
    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;
    private Rigidbody rb;
    private float boardX;
    private float boardY;
    // Start is called before the first frame update
    void Start()
    {
        boardX = Statics.getBoard().x;
        boardY = Statics.getBoard().y;
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            rb.MovePosition(transform.position + (transform.forward * speed * Time.fixedDeltaTime));
        }
        if (Input.GetKey("a"))
        {
            transform.RotateAround(transform.position, Vector3.up, -rotSpeed * Time.fixedDeltaTime);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(30, Vector3.up), rotSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey("d"))
        {
            transform.RotateAround(transform.position, Vector3.up, rotSpeed * Time.fixedDeltaTime);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(-30, Vector3.up), rotSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.MovePosition(transform.position - (transform.forward * speed * Time.fixedDeltaTime));
        }
    }


}
