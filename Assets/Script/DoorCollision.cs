using UnityEngine;

public class DoorCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 캐릭터인 경우
        if (collision.gameObject.CompareTag("Student")|| collision.gameObject.CompareTag("Monster"))
        {

            print("속도 0으로 만들기");
            // 캐릭터의 이동을 막기 위해 이동 속도를 0으로 설정
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.velocity = Vector2.zero;

        }
    }
}
