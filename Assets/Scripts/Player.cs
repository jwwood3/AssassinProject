using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;
    [SerializeField] private Rigidbody rb;
    private RaycastHit find;
    private RaycastHit hit;
    private float boardX;
    private float boardY;
    // Start is called before the first frame update
    void Start()
    {
        boardX = Statics.getBoard().x;
        boardY = Statics.getBoard().y;
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print("buttonHit");
            if(Physics.Raycast(transform.position, transform.forward, out find, 5.0f)) {
                print("hitSomething: " + find.collider.tag);
                if (find.collider.tag == "NPC")
                {
                    print("hitNPC");
                    Statics.setCameraGuy(find.collider.gameObject.GetComponent<NPC>());
                }
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            }
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5.0f, Color.white);

        }
        if (Input.GetKeyDown("return"))
        {
            print("Gun fired");
            if(Physics.Raycast(transform.position, transform.forward, out hit, 3.0f))
            {
                print("Killed Someone: " + hit.collider.tag);
                if(hit.collider.tag == "NPC")
                {
                    NPC npc = hit.collider.gameObject.GetComponent<NPC>();
                    Statics.scorePoints(Statics.getNPCScore());
                    if(Statics.hasPOV(npc))
                    {
                        //Statics.removeCamGuy(npc);
                        //Statics.chooseRandomCamGuy();
                    }
                    Destroy(hit.collider.gameObject);
                }
                else if(hit.collider.tag == "Target")
                {
                    Statics.scorePoints(Statics.getTargetScore());
                    Statics.reset();
                }
            }
        }
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
