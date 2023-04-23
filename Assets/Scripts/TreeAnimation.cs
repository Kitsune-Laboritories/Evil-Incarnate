using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnimation : MonoBehaviour
{
    public GameObject HiddenObject;
    private Transform t;
    private Transform player;
    public int count;
    private int reveal;
    GameObject closestObject;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        reveal = count;
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
            StartCoroutine(ShakeIt());
            GameObject[] hidden = GameObject.FindGameObjectsWithTag("Hidden");
            float maxDistance = 2.0f;
            float closestDistance = 1.5f;
            foreach (GameObject obj in hidden)
            {
                float distance = Vector3.Distance(player.position, obj.transform.position);
                if (distance < closestDistance && distance < maxDistance)
                {
                    closestDistance = distance;
                    closestObject = obj;
                }
            }
            if (closestObject != null)
            {
                count -= 1;
            }
        }

        if (count == 0)
        {
            HiddenObject.SetActive(true);
        }

        IEnumerator ShakeIt()
        {
            animator.SetBool("ShakeIt", true);
            animator.SetBool("StopIt", false);
            //yield on a new YieldInstruction that waits for # seconds.
            yield return new WaitForSeconds(1);
            animator.SetBool("ShakeIt", false);
            animator.SetBool("StopIt", true);

        }



    }
}
