using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public static Ball Instance;
    public float minX, maxX;
    private Vector3 ballPos;
    public float speed;
    Rigidbody rb;
    bool thrown = false;
    bool end = false;
    public float horizontalSpeed;
    int numInRound = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
        ballPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);  
    }

    // Update is called once per frame
    void Update()
    {
        BallMovement();
        BallWeight();
    }

    void BallMovement()
    {
        if (!thrown)
        {
            float xAxis = Input.GetAxis("Horizontal");
            Vector3 position = transform.position;
            position.x = xAxis * horizontalSpeed;
            transform.position = position;

            ballPos.x = Mathf.Clamp(xAxis, minX, maxX);
            transform.localPosition = ballPos;
        }

        if (!thrown && Input.GetKey(KeyCode.Space) && speed <= 30)
        {
            speed += 1;
        }

        if (!thrown && Input.GetKeyUp(KeyCode.Space))
        {
            thrown = true;
            numInRound++;
            rb.isKinematic = false;
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    void BallWeight()
    {
        if (!thrown && Input.GetKeyDown(KeyCode.Alpha7))
        {
            rb.mass = 8;
        }
        if (!thrown && Input.GetKeyDown(KeyCode.Alpha8))
        {
            rb.mass = 9;
        }
        if (!thrown && Input.GetKeyDown(KeyCode.Alpha9))
        {
            rb.mass = 12;
        }
    }

    private void FixedUpdate()
    {
        if (thrown && rb.IsSleeping() && numInRound == 1)
        {
            thrown = false;
            end = true;
            transform.position = new Vector3(0, 0, 0);
        }

        if (thrown && rb.IsSleeping())
        {
            if (numInRound == 2 || IsAnyPinThere())
            {
                RoundManager.Instance.AddToRound(1);
                SceneManager.LoadScene("Game");
            }
        }
    }

    bool IsAnyPinThere()
    {
        return GameObject.Find("Pin") != null;
    }

    public bool GetEnd()
    {
        return end;
    }

    public bool GetThrown()
    {
        return thrown;
    }

    public int GetNumInRound()
    {
        return numInRound;
    }
}
