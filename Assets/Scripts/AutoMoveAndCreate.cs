using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveAndCreate : MonoBehaviour
{
    public float speed = 7f;
    public float time = 0f;
    public float timeGap = 20f;
    private Vector3 initialPos;
    private Quaternion initialRotate;
    public float pushPower = 10f;
    public AudioClip car_horn_sound;
    private GameObject m;
    public CharacterController player;

    void Start()
    {
        initialPos = transform.position;
        initialRotate = transform.rotation;
        time = 0f;
        car_horn_sound = (AudioClip) Resources.Load<AudioClip>("car_horn");
        m = new GameObject("Music");
        GameObject playerG = GameObject.FindGameObjectWithTag("Player");
        player = playerG.GetComponent<CharacterController>();
    }

    void Awake()
    {
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        time += Time.deltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (time >= timeGap)
        {
            Instantiate(gameObject, initialPos, initialRotate);
            time = 0f;
        }
        float distanceP = Vector3.Distance(transform.position, player.transform.position);
        if (distanceP > 50f)
        {
            Instantiate(gameObject, initialPos, initialRotate);
            Destroy(m);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            CharacterController controller = collision.collider.GetComponent<CharacterController>();
            if (controller)
            {
                ScoringSystem.lives -= 1;
                m.AddComponent<AudioSource>();
                m.GetComponent<AudioSource>().clip = car_horn_sound;
                m.GetComponent<AudioSource>().volume = 0.3f;
                m.GetComponent<AudioSource>().Play();
                Vector3 pushDirection = collision.contacts[0].normal;
                pushDirection.y = 0.0f;
                controller.Move(-pushDirection * pushPower);
            }
        }
    }
}
