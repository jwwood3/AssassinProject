using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Populator : MonoBehaviour
{
    [SerializeField] private GameObject NPC;
    [SerializeField] private GameObject Target;
    [SerializeField] private GameObject Player;
    [SerializeField] private int numNPCs = 25;
    [SerializeField] private TextMeshProUGUI scoreThing;
    public static float timer;
    private float boardX;
    private float boardY;
    // Start is called before the first frame update
    void Start()
    {
        boardX = Statics.getBoard().x;
        boardY = Statics.getBoard().y;
        populate();
        timer = 0.0f;
    }

    void populate()
    {
        if (numNPCs >= 4)
        {
            GameObject camGuy = Instantiate(NPC, getRandomPos(), Quaternion.identity);
            Statics.setCameraGuy(camGuy.GetComponent<NPC>());
            camGuy = Instantiate(NPC, getRandomPos(), Quaternion.identity);
            Statics.setCameraGuy(camGuy.GetComponent<NPC>());
            camGuy = Instantiate(NPC, getRandomPos(), Quaternion.identity);
            Statics.setCameraGuy(camGuy.GetComponent<NPC>());
            camGuy = Instantiate(NPC, getRandomPos(), Quaternion.identity);
            Statics.setCameraGuy(camGuy.GetComponent<NPC>());
        }
        for (int i = 0; i < (numNPCs - 4); i++)
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
        timer += Time.deltaTime;
        if (Statics.shouldReset())
        {
            populate();
            Statics.iDidTheThing();
        }
        scoreThing.text = Statics.getPoints().ToString();
    }
}
