using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statics : MonoBehaviour
{
    [SerializeField] private static Vector2 board = new Vector2(100,100);
    [SerializeField] private static int score = 0;
    [SerializeField] private static NPC[] cameraGuys = new NPC[4];
    [SerializeField] private static Rect[] camSpace = { new Rect(0.0f, 0.0f, 0.5f, 0.5f), new Rect(0.0f, 0.5f, 0.5f, 0.5f), new Rect(0.5f, 0.0f, 0.5f, 0.5f), new Rect(0.5f, 0.5f, 0.5f, 0.5f) };
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

    public static NPC[] getCameraGuys()
    {
        return cameraGuys;
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
        /*if (cameraGuy == null)
        {
            cameraGuy = newGuy;
        }
        else
        {
            cameraGuy.cameraOff();
            cameraGuy = newGuy;
        }
        cameraGuy.cameraOn();*/
        if (hasPOV(newGuy))
        {
            return;
        }
        for(int i = 0; i < cameraGuys.Length; i++)
        {
            if(cameraGuys[i] == null)
            {
                cameraGuys[i] = newGuy;
                cameraGuys[i].cameraOn();
                cameraGuys[i].cam.rect = camSpace[i];
                return;
            }
        }
        newGuy.cameraOn();
        newGuy.cam.rect = cameraGuys[0].cam.rect;
        cameraGuys[0].cameraOff();
        for(int i = 0; i < (cameraGuys.Length-1); i++)
        {
            cameraGuys[i] = cameraGuys[i + 1];
        }
        cameraGuys[cameraGuys.Length-1] = newGuy;

    }

    public static void chooseRandomCamGuy()
    {
        foreach (GameObject npc in GameObject.FindGameObjectsWithTag("NPC"))
        {
            if (!hasPOV(npc.GetComponent<NPC>()))
            {
                setCameraGuy(npc.GetComponent<NPC>());
                break;
            }
        }
    }

    public static void removeCamGuy(NPC guy)
    {
        for(int i = 0; i < cameraGuys.Length; i++)
        {
            if (cameraGuys[i].GetInstanceID() == guy.GetInstanceID())
            {
                cameraGuys[i].cameraOff();
                cameraGuys[i] = null;
                return;
            }
        }
    }

    public static bool hasPOV(NPC guy)
    {
        for(int i = 0; i < cameraGuys.Length; i++)
        {
            if(cameraGuys[i] != null && cameraGuys[i].GetInstanceID() == guy.GetInstanceID())
            {
                return true;
            }
        }
        return false;
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
