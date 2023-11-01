using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5.5f; // 이동 속도
    public Tilemap tilemap; // 타일맵
    public int health = 3;
    public GameObject ForDestroy;
    public  bool BoardCollision = false;
    private Quaternion previousRotation;


    public GameObject BoardType1_1, BoardType1_2, BoardType2_1, BoardType3_1, BoardType3_2, teacherOfficeBoard;
    public GameObject panel1, panel2, panel3, panel4, panel5, teacherOfficePanel;
    private GameObject[] panels = new GameObject[6];
    private GameObject[] Boards = new GameObject[6];

    //public GameObject mainChar;
    //private bool canMove = true;


    private void Awake()
    {
        SetPanelArray();
        setBoardArray();
    }


    void Start()
    {
        ForDestroy = GameObject.FindGameObjectWithTag("Choco");


        //ForDestroy1 = GameObject.FindGameObjectWithTag("Item");
        //ForDestroy2 = GameObject.FindGameObjectWithTag("Item2");



    }
    private void Update()

    {
       
            MainPlayerMoving();


            print("현재 player moveSpeed:  " + moveSpeed);




            print("현재 player moveSpeed:  " + moveSpeed);
            

       
    }


    private void MainPlayerMoving()
    {
        //수평 방향 입력 받기
        float horizontalInput = Input.GetAxis("Horizontal");
        // 수직 방향 입력 받기
        float verticalInput = Input.GetAxis("Vertical");

        // 이동 방향 계산
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        //현재 위치와 이동 방향을 기반으로 새로운 위치 계산
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;

        // 새로운 위치가 타일맵 내에 있는지 검사
        Vector3Int cellPosition = tilemap.WorldToCell(newPosition);


        if (tilemap.HasTile(cellPosition))
        {

            // 타일맵 내에 있다면 캐릭터 이동
            print("move");
           transform.position = newPosition;
        }

    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Choco"))
        {
            moveSpeed += 1.0f;
            Destroy(ForDestroy);
            print("초콜릿 찾았다 ! ");
        }

        if (collision.gameObject.CompareTag("Monster"))
        {
            // 플레이어와 충돌한 경우 처리
            print("경비원이다 ! ");
            health--;
            //print("health :" + health);
            moveSpeed -= 0.5f;

        }



        //if (collision.gameObject.CompareTag("Tilemap"))
        //{
        //    // 플레이어와 충돌한 경우 처리


        //    print("벽이랑 부딪혔다 ");


        //}


        //if (collision.gameObject.CompareTag("LockedDoor"))
        //{
        //    // 플레이어와 충돌한 경우 처리


        //    print("문이 잠겨있다");
        //    canMove = false;

        //}

        int boardIndex = getBoardIndex(collision.gameObject);
        print(boardIndex);
        if(boardIndex != -1)
        {

            print( boardIndex.ToString() + " 번째 보드와 충돌 ");
            // -1이 아니면 보드와 충돌
            if (panels[boardIndex].activeSelf == false)
            {
                panels[boardIndex].SetActive(true);
            }
            previousRotation = transform.rotation;
        }

        //if (collision.gameObject.CompareTag("Board"))
        //{
        //    print("Collsion With Board  ");
        //    BoardCollision = true;
        //    //칠판 화면 띄우기

        //    previousRotation = transform.rotation;
        //}

    }




    /// <summary>
    /// 계속 연속적으로 부딪혀도 돌아가지 않게 함
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay2D(Collision2D collision)
    {
        //ShowBoard(collision.gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Board"))
        //{
        //    print("Collision with Board Exit");
            
        //}
    }


    private int getBoardIndex(GameObject collisionObject)
    {
        for (int i = 0; i < 6; i++)
        {
            print("colli tag = " + collisionObject.tag + "///// boardTag == " + Boards[i].tag);
            if (collisionObject.CompareTag(Boards[i].tag))
            {
                return i;
            }
        }
        return -1;
    }
    //public void ShowBoard(GameObject collisionObject)
    //{

    //    //if( System.Object.ReferenceEquals(collisionObject, ))

    //    for(int i = 0; i< 6; i++)
    //    {
    //        if (System.Object.ReferenceEquals(collisionObject, Boards[i]))
    //        {
    //            panels[i].SetActive(true);
    //            break;
    //        }
    //    }


    //}

    public void SetPanelArray()
    {
        panels[0] = panel1;
        panels[1] = panel2;
        panels[2] = panel3;
        panels[3] = panel4;
        panels[4] = panel5;
        panels[5] = teacherOfficePanel;
    }

    public void setBoardArray()
    {

        
        Boards[0] = BoardType1_1;
        Boards[1] = BoardType1_2;
        Boards[2] = BoardType2_1;
        Boards[3] = BoardType3_1;
        Boards[4] = BoardType3_2;
        Boards[5] = teacherOfficeBoard;

    }
}


