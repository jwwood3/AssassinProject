using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statics : MonoBehaviour
{
    [SerializeField] private static Vector2 board = new Vector2(100,100);
    [SerializeField] private static int score = 0;
    [SerializeField] private static NPC cameraGuy;
    [SerializeField] private static int NPCScore = -5;
    [SerializeField] private static int TargetScore = 25;
    [SerializeField] private static bool resetPlease = false;
    

    public static Vector2 getBoard()
    {
        return board;
    }

    public static int getNPCScore()
    {
        return NPCScore;
    }

    public static int getTargetScore()
    {
        return TargetScore;
    }

    public static NPC getCameraGuy()
    {
        return cameraGuy;
    }

    public static void scorePoints(int points)
    {
        score += points;
    }

    public static int getPoints()
    {
        return score;
    }

    public static void setCameraGuy(NPC newGuy)
    {
        if (cameraGuy == null)
        {
            cameraGuy = newGuy;
        }
        else
        {
            cameraGuy.cameraOff();
            cameraGuy = newGuy;
        }
        cameraGuy.cameraOn();
    }

    public static void chooseRandomCamGuy()
    {
        foreach (GameObject npc in GameObject.FindGameObjectsWithTag("NPC"))
        {
            if (npc.GetInstanceID() != cameraGuy.gameObject.GetInstanceID())
            {
                setCameraGuy(npc.GetComponent<NPC>());
                break;
            }
        }
    }

    public static bool shouldReset()
    {
        return resetPlease;
    }

    public static void iDidTheThing()
    {
        resetPlease = false;
    }

    public static void reset()
    {
        foreach (GameObject npc in GameObject.FindGameObjectsWithTag("NPC"))
        {
            Destroy(npc);
        }
        foreach (GameObject target in GameObject.FindGameObjectsWithTag("Target"))
        {
            Destroy(target);
        }
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            Destroy(player);
        }
        resetPlease = true;
    }
}
