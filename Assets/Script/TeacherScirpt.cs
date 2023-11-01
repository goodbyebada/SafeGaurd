using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherScirpt : MonoBehaviour
{
    private bool meetCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (meetCheck)
        {
            print("사람을 때리면 안된다, 소화기 여기있어  ");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            // 플레이어와 충돌한 경우 처리


            print("보건 선생님과 충돌 ");
            meetCheck = true;

}
    }
}
