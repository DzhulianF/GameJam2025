using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    private Vector3 offset = new Vector3(6f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform playerPosition;

    // Update is called once per frame
    private void Start()
    {
        
    }
    void FixedUpdate()
    {
        followPhoenix();
    }

   private void followPhoenix()
    {
        Vector3 playerPositionAvecOffset = playerPosition.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, playerPositionAvecOffset, ref velocity, smoothTime);


    }

   

}

