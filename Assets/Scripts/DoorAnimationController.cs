using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorAnimationController : MonoBehaviour
{
    private GameObject door;
    private Transform t;
    //private Transform player;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //Debug.Log(animator);

    }

    private void Awake()
    {
        t = this.transform;
        //player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            GameObject[] doors = GameObject.FindGameObjectsWithTag("Player");

            float closestDistance = 1.5f;
            GameObject closestObject = null;
            foreach (GameObject obj in doors)
            {
                float distance = Vector3.Distance(transform.position, obj.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestObject = obj;
                }
            }
            

            if (closestObject != null && ScoringSystem.taskDone == true)
            {
                door = closestObject;
                //turn on animation
                animator.SetBool("isOpen", true);
                SceneManager.LoadScene("ScoreBoard");
            }
        }
    }

}
