using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector3 startPosition = new Vector3(0f,0f,0f);
    public bool treasureTaken = false;
    public static bool on = true;
    [SerializeField] Text TextWin, TextLost;
    [SerializeField] Button Replay;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        if (Input.GetKey(KeyCode.Space) && transform.position.x < -5.5)
        {
            GameObject[] rewards = GameObject.FindGameObjectsWithTag("Reward");
            foreach (GameObject reward in rewards)
            {
                reward.SetActive(false);
                treasureTaken = true;
            }
        }
        
        if (transform.position.x > startPosition.x && treasureTaken)
        {
            win();
        }
    }

    private void FixedUpdate()
    {
        if(transform.position.x < -8)
        {
            transform.position = new Vector3(-8.0f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 10)
        {
            transform.position = new Vector3(10.0f, transform.position.y, transform.position.z);
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.RightArrow) && on)
            rb.AddForce(Vector3.left);
        if (Input.GetKey(KeyCode.LeftArrow) && on)
            rb.AddForce(Vector3.right);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Enemy 1" || collision.gameObject.name == "Enemy 2")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.position = startPosition;
            lost();
        }
    }

    void lost()
    {
        treasureTaken = false;
        on = false;
        TextLost.gameObject.SetActive(true);
        Replay.gameObject.SetActive(true);
    }

    void win()
    {
        treasureTaken = false;
        on = false;
        TextWin.gameObject.SetActive(true);
        Replay.gameObject.SetActive(true);
    }
}
