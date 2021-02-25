using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static RoundManager Instance;
    private static int round;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        Instance = this;

        ResetRound();
    }

    public void ResetRound()
    {
        round = 1;
    }

    public void AddToRound(int toAdd)
    {
        round += toAdd;
    }

    public int GetRound()
    {
        return round;
    }
}
