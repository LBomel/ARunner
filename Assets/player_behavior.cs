using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_behavior : MonoBehaviour
{
    private bool canJump = true;
    [SerializeField] float jumpForce = 1;
    private Button jumpButton = null;
   
    void Start()

    {
        Debug.Log("oui");
        jumpButton = GameObject.FindWithTag("jumpButton").GetComponent<Button>();
        jumpButton.onClick.AddListener(jump);
    }
    private void OnDestroy()
    {
        jumpButton.onClick.RemoveListener(jump);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            canJump = true;
        }

        if (collision.gameObject.tag == "obstacle")
        {
            GameObject.FindWithTag("gameStateManager").GetComponent<game_state_manager>().resetGame();

        }
        
    }

    public void jump()
    {
        if (canJump == true)
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody>().AddRelativeForce((Vector3.up * jumpForce)*transform.localScale.y, ForceMode.Impulse);
        }
    }
}
