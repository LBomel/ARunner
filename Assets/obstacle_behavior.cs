using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_behavior : MonoBehaviour
{
    [SerializeField] float speed = 1;

    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * speed,ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Destroy(collision.gameObject);
        }
    }
}
