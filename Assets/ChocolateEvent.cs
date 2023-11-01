using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChocolateEvent : MonoBehaviour
{
    public static event Action EatChocolate;    // EatChocolate이라는 반환값 없는 델리게이트 타입인 Action 선	

    public static void RunEatChocolate()    
    {
        if (EatChocolate != null)   //이벤트를 받는 곳이 null이 아닐 때 이벤트가 호출되도록 하는 메소드 정의 
        {
            EatChocolate();
        }
    }
  
}
