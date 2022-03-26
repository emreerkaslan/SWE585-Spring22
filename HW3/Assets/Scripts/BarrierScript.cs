using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    private string move = "rising";
    public static int difficulty = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (move == "rising")
        {
            transform.Translate(Vector3.up * Time.deltaTime * difficulty, Space.World);
        }
        else if (move == "falling")
        {
            transform.Translate(Vector3.down * Time.deltaTime * difficulty, Space.World);
        }

        if (transform.position.y >= 3.0)
        {
            move = "stopped";
            transform.position = new Vector3(transform.position.x, 2.99f, transform.position.z);
            StartCoroutine(StopRandomly("falling"));

        }
        else if (transform.position.y <= 1.0)
        {
            move = "stopped";
            transform.position = new Vector3(transform.position.x, 1.01f, transform.position.z);
            StartCoroutine(StopRandomly("rising"));
        }
    }

    IEnumerator StopRandomly(string status)
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 5.0f));
        move = status;
    }
}
