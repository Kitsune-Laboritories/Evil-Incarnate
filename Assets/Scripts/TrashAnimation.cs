using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashAnimation : MonoBehaviour
{
    Animator animator;
    private Transform t;
    private Transform player;
    public int count;
    public GameObject HiddenObject;
    GameObject closestObject;
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
            GameObject[] hidden = GameObject.FindGameObjectsWithTag("Trash");
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
                StartCoroutine(KnockIt());
            }
        }

        
    }

    IEnumerator KnockIt()
    {
        animator.SetBool("KnockOver", true);
        yield return new WaitForSeconds(1);
        HiddenObject.SetActive(true);
    }


}
