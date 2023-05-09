using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{

    [SerializeField] private GameObject playerCam;
    private bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        playerCam.SetActive(flag);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))   
        {
            flag = !flag;
            playerCam.SetActive(flag);
        }
    }
}
