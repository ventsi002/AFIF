using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    [SerializeField]public Transform ballTransform;
    public Vector3 offset;
    public Vector3 cam;
    private Quaternion desiredRotation;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    
        transform.position = ballTransform.position + offset;
        transform.rotation = Quaternion.LookRotation(cam);
    }
}
