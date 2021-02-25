using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    Rigidbody rb;
    bool scoreIsAdded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rb.IsSleeping() && Ball.Instance.GetThrown() && !scoreIsAdded)
        {
            ScoreManager.Instance.AddToScore(1);
            scoreIsAdded = true;
            
        }

        if (Ball.Instance.GetEnd() && scoreIsAdded && Ball.Instance.GetNumInRound() == 1)
        {
            DestroyPin();
        }

        
    }

    void DestroyPin()
    {
        Destroy(gameObject);
    }

}
