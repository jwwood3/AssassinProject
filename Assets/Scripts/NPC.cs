using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private bool isOnRoute = false;
    private bool isFindingRoute = false;
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
        newDest();
        isFindingRoute = true;
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    void newDest()
    {
        dest = new Vector2(Random.Range(-0.5f * boardX, 0.5f * boardX), Random.Range(-0.5f * boardY, 0.5f * boardY));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOnRoute)
        {
            if(Mathf.Abs(this.transform.position.x-dest.x)<1 && Mathf.Abs(this.transform.position.z - dest.y) < 1)
            {
                isOnRoute = false;
            }
            else
            {
                rb.MovePosition(transform.position + new Vector3(dest.x - this.transform.position.x, 0.0f, dest.y - this.transform.position.z).normalized*speed*Time.fixedDeltaTime);
                Vector3 towardGoal = new Vector3(dest.x - transform.position.x, 0.0f, dest.y - transform.position.z);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(towardGoal.normalized), rotSpeed*Time.fixedDeltaTime);
            }
        }
        else if (isFindingRoute)
        {
            Vector3 towardGoal = new Vector3(dest.x - transform.position.x, 0.0f, dest.y - transform.position.z);
            if (Quaternion.Angle(transform.rotation, Quaternion.LookRotation(towardGoal.normalized))<5)
            {
                isFindingRoute = false;
                isOnRoute = true;
            }
            else
            {
                print("moving");
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(towardGoal.normalized), rotSpeed*Time.fixedDeltaTime);
            }
        }
        else
        {
            newDest();
            isFindingRoute = true;
        }
    }
}
