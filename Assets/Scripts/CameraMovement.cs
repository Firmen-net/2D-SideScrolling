using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distanceAhead;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    private void Start()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);

        lookAhead = Mathf.Lerp(lookAhead, (distanceAhead * player.localScale.x), Time.deltaTime * cameraSpeed);
    }
}