using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Populator : MonoBehaviour
{
    [SerializeField] private GameObject NPC;
    [SerializeField] private GameObject Target;
    [SerializeField] private GameObject Player;
    [SerializeField] private int numNPCs = 25;
    private float boardX;
    private float boardY;
    // Start is called before the first frame update
    void Start()
    {
        boardX = Statics.getBoard().x;
        boardY = Statics.getBoard().y;
        for(int i = 0; i < numNPCs; i++)
        {
            Instantiate(NPC, getRandomPos(), Quaternion.identity);
        }
        Instantiate(Player, getRandomPos(), Quaternion.identity);
        Instantiate(Target, getRandomPos(), Quaternion.identity);
    }

    Vector3 getRandomPos()
    {
        return new Vector3(Random.Range(-0.5f*boardX, 0.5f*boardX), 2.0f, Random.Range(-0.5f*boardY, 0.5f*boardY));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
