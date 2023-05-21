using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class TargetControll : MonoBehaviour
{
    float moveX, moveY;
    [SerializeField][Range(3f, 10f)] float moveSpeed = 5f;

    //애니메이션을 위한 변수
    private Animator animator;
    private bool isRun;
    private int turn = 1;

    private float ScaleVal_X;   //스케일 값은 float로 되어있음
    private float ScaleVal_Y;

    private void Start(){
        //애니메이터 변수 초기화
        animator = GetComponent<Animator>();
        ScaleVal_X = transform.localScale.x;
        ScaleVal_Y = transform.localScale.y;
    }
    

    // Update is called once per frame
    private void Update()
    {

        //방향키로 움직임 설정
        isRun = false;
        moveX = 0;
        moveY = 0;
        if (Input.GetKey("right"))
        {
            moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

            //회전 및 애니메이션 키  설정
            isRun = true;
            turn = -1;
        }
        if(Input.GetKey("left"))
        {
            moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            
            //회전 및 애니메이션 키  설정
            isRun = true;
            turn = 1;
        }
        if (Input.GetKey("up"))
        {
            moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            isRun = true;
        }
        if(Input.GetKey("down"))
        {
            moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            isRun = true;
        }
        transform.position = new Vector2(transform.position.x + moveX, transform.position.y + moveY);
        animator.SetBool("isRun", isRun);
        transform.localScale = new Vector3(ScaleVal_X*turn, ScaleVal_Y, 1);
    }
}
