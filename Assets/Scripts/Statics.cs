using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statics : MonoBehaviour
{
    [SerializeField] private static Vector2 board = new Vector2(100,100);
    [SerializeField] private static int score = 0;

    public static Vector2 getBoard()
    {
        return board;
    }

    public static void scorePoints(int points)
    {
        score += points;
    }

    public static int getPoints()
    {
        return score;
    }
}
