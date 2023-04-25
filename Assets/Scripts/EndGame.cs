using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private Transform t;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        t = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        GameObject[] exit = GameObject.FindGameObjectsWithTag("Exit");
        float closestDistance = 0.5f;
        foreach (GameObject obj in exit)
        {
            float distance = Vector3.Distance(player.position, obj.transform.position);
            if (distance < closestDistance && ScoringSystem.taskCity == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        
    }
}
