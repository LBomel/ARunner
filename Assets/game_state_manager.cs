using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_state_manager : MonoBehaviour
{
    [SerializeField] GameObject groundPrefab = null;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void resetGame()
    {
        Destroy(GameObject.FindWithTag("ground"));
        Instantiate(groundPrefab, gameObject.transform);
    }
}
