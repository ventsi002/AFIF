using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform transformPlayer;
    private bool stick;
    private Transform ballPosition;
    float speed;
    Vector3 previousLocation;
    ThirdPersonController scriptPlayer;

    public bool Stick{get => stick; set => stick = value; }

    // Start is called before the first frame update
    void Start()
    {
        ballPosition = transformPlayer.Find("Geometry").Find("BallPosition");
        scriptPlayer = transformPlayer.GetComponent<ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!stick)
        {
            float distanceToPlayer = Vector3.Distance(transformPlayer.position, transform.position);
            if(distanceToPlayer < 0.5)
            {
                Stick = true;
                scriptPlayer.BallAttachedToPlayer = this;
            }
        }
        else
        {
            Vector2 currentLocation = new Vector2(transform.position.x, transform.position.z);
            speed = Vector2.Distance(currentLocation, previousLocation)/Time.deltaTime;
            transform.position = ballPosition.position;
            transform.Rotate(new Vector3(transformPlayer.right.x, 0, transformPlayer.right.z), speed, Space.World);
            previousLocation = currentLocation;
        }
        
    }
}
