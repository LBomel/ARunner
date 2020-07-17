using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_behavior : MonoBehaviour
{
    [SerializeField] float speed = 1;

    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddRelativeForce((Vector3.left * speed)*transform.localScale.x,ForceMode.VelocityChange);
    }

}
