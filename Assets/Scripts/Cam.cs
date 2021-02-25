using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{

    public float distance;
    public float height;
    public GameObject objectToFollow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(objectToFollow == null)
        {
            return;
        }

        Vector3 destination = objectToFollow.transform.position;
        destination.x = 0f;
        destination.y += height;
        destination.z += distance;

        transform.position = destination;
    }
}
