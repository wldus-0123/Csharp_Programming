﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._Delegate
{
    internal class Chain
    {
        /***************************************************
        * 델리게이트 체인 : 델리게이트는 여러개의 함수를 동시에 가질 수도 있음
        * 
        * 델리게이트 변수에 여러개의 함수를 참조하는 방법
        ***************************************************/

        // <델리게이트 체인>
        // 하나의 델리게이트 변수에 여러개의 함수를 할당하는 것이 가능
        // +=,-=연산자를 통해 할당을 추가하고 제거할 수 있음
        // = 연산자를 통해 할당할 경우 이전의 다른 함수들을 할당한 상황이 사라짐

        void Main()
        {
            Action action;
            action = Func2; // 델리게이트 인스턴스를 Func2로 초기화
            action += Func1; // 델리게이트 인스턴스에 Func1 추가 참조
            action += Func3; // 델리게이트 인스턴스에 Func3 추가 참조
            action(); // Func2,1,3이 호출됨

            action -= Func1; // 델리게이트 인스턴스에 Func1 참조 제거
            if (action != null)// 델리게이트 인스턴스에서 참조를 제거할 경우 참조하고 있는 함수가 없는 경우를 조심해야함
                action();    // Func2,3이 호출됨

            action += Func2;   // 같은 함수를 여러번 참조한 경우 여러번 호출됨
            action += Func2;
            action();

            action -= Func1;    // 델리게이트 인스턴스에 참조되지 않은 함수를 제거할 경우 해당 작업이 무시됨

            action = Func1;     // 델리게이트 인스턴스에 =을 통해 할당할 경우 이전의 참조된 상황이 사라짐
            action();           // Func1 이 호출됨


            // 한번만 할당하고 싶을때는 한번 뺀 다음 붙이는 습관을 들이면 됨
            action -= Func2;
            action += Func2; //요렇게

        }

        void Func1() { Console.WriteLine("Func1"); }
        void Func2() { Console.WriteLine("Func2"); }
        void Func3() { Console.WriteLine("Func3"); }
    }
}
