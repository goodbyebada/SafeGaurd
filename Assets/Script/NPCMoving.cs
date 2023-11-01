using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class NPCMoving : MonoBehaviour
{
	
	public Vector3 direction;
	public float moveSpeed = 4.2f;
	public Vector3 default_direction;
	private Vector3 newPosition;

	public Tilemap tilemap;



	void setRandomDirection()
	{
		// 자동으로 움직일 방향 벡터
		default_direction.x = Random.Range(0, 1.0f); // 0~1.0f 랜덤한 값 direction이 
		default_direction.y = Random.Range(0, 1.0f);
	}


	private void Awake()
	{
		//tilemap = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<Tilemap>();
	}
	void Start()
	{

		setRandomDirection();

	}

	Vector3 getNextPosition()
	{
		//return transform.position + default_direction * moveSpeed * Time.deltaTime;

		return new Vector3(transform.position.x + (default_direction.x * moveSpeed * Time.deltaTime),
												   transform.position.y,
												   transform.position.z);
		//x축으로만 이동하는 getNewPosition
	}


	void Update()
	{


		newPosition = getNextPosition(); //default_direction 방향으로 이동 -> start에서 default_direction.x,default_direction.y 랜덤 0~1.0의 값을 가지고 있음
										 //x축 방향으로만 이동

		//newPosition = new Vector3(transform.position.x ,
		//								   transform.position.y + +(default_direction.y * moveSpeed * Time.deltaTime),
		//								   transform.position.z);	


		Vector3Int cellPosition = tilemap.WorldToCell(newPosition); // cell화 시킨 cellPosition -> tilemap에 있는지 확인
		if (tilemap.HasTile(cellPosition))
		{
			print("tilemap has Tile");
			transform.position = newPosition; //tilemap 안에 있다면 현재 위치가 됨 -> 

		}
		else
		{
			print("	타일에 없다면 반대 방향으로 이동해");
			//setRandomDirection(); //같은 랜덤 값 반환하느라 움직이지 않음 -> 계속 tilemap에 없는 값 반환 -> 다시 랜덤 무한반복 -> 안움직임 
			default_direction.x = -default_direction.x;

			//타일에 없다면 x축으로 반대 방향으로 이동 

		}

	}








	private void OnDrawGizmosSelected()
	{

		//Gizmos.color = Color.blue;
		//Gizmos.DrawWireSphere(transform.position, chasingDistance);
	}

}

