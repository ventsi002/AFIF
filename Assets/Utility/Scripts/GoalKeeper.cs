using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeper : MonoBehaviour
{

    private Animator animator;
    private bool _hasAnimator;
    [SerializeField] Transform ball;

    // Start is called before the first frame update
    void Start()
    {
        _hasAnimator = TryGetComponent(out animator);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            if(ball.position.z > 0)
            {
                animator.Play("Block-Right");    
            }
            else
            {
                animator.Play("Block");
            }
        }
    }

}
