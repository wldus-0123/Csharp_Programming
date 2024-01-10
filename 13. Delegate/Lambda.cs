using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._Delegate
{
    /*************************************************************************
     * 무명메서드와 람다식  -- 연차 쌓이면 필수로 써야함 + linQ도
     * 
     * 델리게이트 변수에 할당하기 위한 함수를 소스코드 구문에서 생성하여 전달
     * 전달하기 위한 함수가 간단하고 일회성으로 사용될 경우에 간단하게 작성
     *************************************************************************/

    internal class Lambda
    {
        void Main()
        {
            Action<string> action;

            // <함수를 통한 할당>
            // 클래스에 정의된 함수를 직접 할당
            // 클래스의 멤버함수로 연결하기 위한 기능이 있을 경우 적합
            action = Message;

            // <무명메서드> : 잠시 쓰고 버리기 위한 함수
            // 함수를 통한 연결은 함수가 직접적으로 선언되어 있어야 사용 가능
            // 할당하기 위한 함수가 간단하고 자주 사용될수록 비효율적
            // 간단한 표현식을 통해 함수를 즉시 작성하여 전달하는 방법
            // 전달하기 위한 함수가 간단하고 일회성으로 사용될 경우에 적합
            action = delegate (string str) { Console.WriteLine(str); };
            action("메세지");


            // <람다식>
            // 무명메서드의 간단한 표현식
            action = (str) => { Console.WriteLine(str); }; //(매개변수)=>{험수식}
            action = str => Console.WriteLine(str);

            action = null; // 이제 안쓸거야~ 라는 뜻
        }

        static void Main(string[] args)
        {
            int[] array = { 2, 5, -4, 3, 10, -9, -8 };
            int[] find = Array.FindAll(array, value => Math.Abs(value) < 5); //5보다 작은 수들 찾기 , Math.Abs = 절대값
            Array.Sort(array, Comparer<int>.Create((a, b) => { return b - a; })); //내림차순 정렬

        }


        void Message(string message)
        {
            Console.WriteLine(message);
        }

        /* bool Less1(int value)
        {
            return value < 1;
        }
        bool Less2(int value)
        {
            return value < 2; */ // 너무 비효율적
    }
}
