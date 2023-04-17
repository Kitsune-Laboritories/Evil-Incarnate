using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveAndCreate : MonoBehaviour
{
    public GameObject car;
    public float speed = 15f;
    public float distance = 10f;
    private Vector3 initialPos;
    private Quaternion initialRotate;
    private float currentDistance;
    public float pushPower = 10f;
    public AudioClip car_horn_sound;
    private GameObject m;

    void Start()
    {
        initialPos = transform.position;
        initialRotate = transform.rotation;
        currentDistance = 0f;
        car_horn_sound = (AudioClip) Resources.Load<AudioClip>("car_horn");
        m = new GameObject("Music");
    }

    void Update()
    {
        if (currentDistance < distance)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            currentDistance += speed * Time.deltaTime;
        }
        else
        {
            Instantiate(car, initialPos, initialRotate);
            currentDistance = 0f;
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
