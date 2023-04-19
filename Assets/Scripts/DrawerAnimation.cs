using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerAnimation : MonoBehaviour
{
    private GameObject door;
    public GameObject HiddenObject;
    private Transform t;
    private Transform player;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Awake()
    {
        t = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject[] openable = GameObject.FindGameObjectsWithTag("Openable");
            float closestDistance = 1.5f;
            GameObject closestObject = null;
            foreach (GameObject obj in openable)
            {
                float distance = Vector3.Distance(player.position, obj.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestObject = obj;
                }
            }


            if (closestObject != null)
            {
                door = closestObject;
                //turn on animation
                animator.SetBool("isOpen", true);
                StartCoroutine(RevealCoroutine());
                

            }
        }
    }

    IEnumerator RevealCoroutine()
    {
     
        //yield on a new YieldInstruction that waits for # seconds.
        yield return new WaitForSeconds(1);
        HiddenObject.SetActive(true);
    }

}
