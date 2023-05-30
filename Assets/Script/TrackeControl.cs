using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class TrackeControl : MonoBehaviour
{
    
    Rigidbody2D rb;
    Transform target;

    [Header("�߰� �ӵ�")]
    [SerializeField] [Range(1f, 4f)] float moveSpeed = 3f;

    [Header("�����Ÿ�")]
    [SerializeField] [Range(0f, 3f)] float contactDistance = 1f;

    bool follow = false;

    //애니메이션을 위한 변수
    private Animator animator;
    private bool isRun;
    private int turn = 1;

    private float ScaleVal_X;   //스케일 값은 float로 되어있음
    private float ScaleVal_Y;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ScaleVal_X = transform.localScale.x;
        ScaleVal_Y = transform.localScale.y;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        FollowTarget();
        follow = true;
    }
    void FollowTarget()
    {
        isRun = false;
        if (Vector2.Distance(transform.position, target.position) > contactDistance && follow){
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            isRun = true;
            
        }
        else{
            rb.velocity = Vector2.zero;
        }

        if (target.position.x > transform.position.x)
            turn = -1;
        else
            turn = 1;
        animator.SetBool("isRun", isRun);
        transform.localScale = new Vector3(ScaleVal_X * turn, ScaleVal_Y, 1);
    }

    
 
}
