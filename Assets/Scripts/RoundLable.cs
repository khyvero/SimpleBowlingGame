using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundLable : MonoBehaviour
{
    Text roundLabel;

    // Start is called before the first frame update
    void Start()
    {
        roundLabel = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLabel();
    }

    void UpdateLabel()
    {
        roundLabel.text = "Round :" + RoundManager.Instance.GetRound().ToString();
    }
}
