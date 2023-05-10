using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI goal;
    [SerializeField] private Transform transformPlayer;
    [SerializeField] private TextMeshProUGUI clock;
    private bool stick;
    [SerializeField] private Transform ball;
    private Transform ballPosition;
    float speed;
    Vector3 previousLocation;
    ThirdPersonController scriptPlayer;
    public int awayScore, homeScore;
    public float fadeTime = 1f;
    public bool playerReset = false;
    private AudioSource cheer;
    int seconds;
    float timer;
    

    public bool PlayerReset{get => playerReset; set => playerReset = value; }

    public bool Stick{get => stick; set => stick = value; }

    // Start is called before the first frame update
    void Start()
    {
        ballPosition = transformPlayer.Find("Geometry").Find("BallPosition");
        scriptPlayer = transformPlayer.GetComponent<ThirdPersonController>();
        scriptPlayer.PlayerReset = playerReset;
        cheer = GameObject.Find("Sound/Crowd").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)timer % 60;
        clock.text = seconds.ToString();

        if(!stick)
        {
            scriptPlayer.PlayerReset = playerReset;
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
        if(goal.alpha > 0)
        {
            goal.alpha -= Time.deltaTime/fadeTime;
            goal.fontSize = 200 - (Time.deltaTime * 1-0);
        }
    }
    public void AwayScore()
    {            
        awayScore++;
        Score();
        ResetBall();
    }
    public void HomeScore()
    {
        homeScore++;
        Score();
        ResetBall();
        
    }

    public void Score()
    {
        PlayerReset = true;
        cheer.Play();
        textScore.text = "Home  " + homeScore.ToString() + "    " + awayScore.ToString() + "  Away";
        goal.text = "Goal!";
        goal.alpha = 1f;
    }

    public void ResetBall()
    {
        scriptPlayer.BallAttachedToPlayer = null;
        stick = false;
        ball.position = new Vector3(0f, 5.19f, 0f);
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }
}
