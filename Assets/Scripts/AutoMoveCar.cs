using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveCar : MonoBehaviour
{
    public float speed = 7f;
    private float time = 0f;
    public float pushPower = 10f;
    public AudioClip car_horn_sound;
    private GameObject m;
    public CharacterController player;
    private Vector3 initialPos;
    private Quaternion initialRotate;

    void Start()
    {
        car_horn_sound = (AudioClip) Resources.Load<AudioClip>("car_horn");
        m = new GameObject("Music");
        initialPos = transform.position;
        initialRotate = transform.rotation;
        GameObject playerG = GameObject.FindGameObjectWithTag("Player");
        player = playerG.GetComponent<CharacterController>();
    }

    void Awake()
    {
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        time += Time.deltaTime;

        float distanceP = Vector3.Distance(transform.position, player.transform.position);
        if (distanceP > 50f)
        {
            Instantiate(gameObject, initialPos, initialRotate);
            Destroy(m);
            Destroy(gameObject);
        }

        float maxDistance = 2.0f;

        GameObject[] turnsLeft = GameObject.FindGameObjectsWithTag("TurnLeft");
        GameObject[] turnsRight = GameObject.FindGameObjectsWithTag("TurnRight");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] allHits = new GameObject[turnsLeft.Length + turnsRight.Length + players.Length];
        turnsLeft.CopyTo(allHits, 0);
        turnsRight.CopyTo(allHits, turnsLeft.Length);
        int length = turnsRight.Length + turnsLeft.Length;
        players.CopyTo(allHits, length);

        float closestDistance = float.MaxValue;
        GameObject closestObject = null;
        foreach (GameObject obj in allHits)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if (distance < closestDistance && distance < maxDistance)
            {
                closestDistance = distance;
                closestObject = obj;
            }
        }
        if (closestObject != null && time >= 0.3f)
        {
            if (closestObject.CompareTag("TurnLeft"))
            {
                // StartCoroutine(TurnAfterDelay(0.1f, Vector3.down));
                transform.rotation = closestObject.transform.rotation;
            }
            else if (closestObject.CompareTag("TurnRight"))
            {
                // StartCoroutine(TurnAfterDelay(0.1f, Vector3.up));
                transform.rotation = closestObject.transform.rotation;
            }
            else if (closestObject.CompareTag("Player"))
            {
                ScoringSystem.lives -= 1;
                m.AddComponent<AudioSource>();
                m.GetComponent<AudioSource>().clip = car_horn_sound;
                m.GetComponent<AudioSource>().volume = 0.15f;
                m.GetComponent<AudioSource>().Play();
                Vector3 throwDirection = transform.position - closestObject.transform.position;
                throwDirection.y = 0f;
                throwDirection.Normalize();
                player.Move(-throwDirection * pushPower);

            }
            time = 0f;
        }
    }

    IEnumerator TurnAfterDelay(float delay, Vector3 direction)
    {
        yield return new WaitForSeconds(delay);
        transform.Rotate(direction, 90.0f);
    }

}
