using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 10f;
    private Vector3 initialPos;
    private bool movingForward = true;
    public CharacterController player;
    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingForward)
        {
            if (Vector3.Distance(transform.position, initialPos) < distance)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                movingForward = false;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, initialPos) >= 5f)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else
            {
                movingForward = true;
            }
        }
        Vector2 lightPos = new Vector2(transform.position.x, transform.position.z);
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.z);

        time += Time.deltaTime;

        if (Vector2.Distance(playerPos, lightPos) < 5f && time >= 1.5f)
        {
            TimerCountdown.timeValue -= 10f;
            time = 0f;
        }
    }
}
