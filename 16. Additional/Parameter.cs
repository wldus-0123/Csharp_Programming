using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._Additional
{
    internal class Parameter  // 상당히많이씀
    {
        // <Named parameter>
        // 함수의 매개변수 순서와 무관하게 이름을 통해 호출

        void Profile(int id, string name, string phone) { }

        void Main1()
        {
            Profile(10, "김감자", "010-7919-2742");
            //함수 호출시 이름을 명명하고 순서와 상관없이 호출 가능
            Profile(phone: "010-2482-3241", id: 1, name: "홍길동");
        }

        // <Optional Parameter>
        // 함수의 매개변수가 초기값을 갖고 있다면, 함수 호출시 생략하는 것을 허용하는 방법

        void AddStudent(string name, string home = "서울", int age = 8) { } // 초기값이 있는 경우 미리 할당
        // void AddStudent(int age = 8, string home = "서울", string name) {} // error : 초기값이 있는 매개변수는 뒤부터 배치해야함
        void Main2()
        {
            AddStudent("철수");
            AddStudent("영희");
            AddStudent("민준");
            AddStudent("미영", "경기도");
            AddStudent("수정", "인천");
            AddStudent("현수", age: 7);
        }

        // <Params Parameter>
        // 매개변수의 갯수가 정해지지 않은 경우, 매개변수의 갯수를 유동적으로 사용하는 방법
        int Sum(params int[] values)
        {
            int sum = 0;
            for (int i = 0; i < values.Length; i++) sum += values[i];
            return sum;
        }

        void Main3()
        {
            Sum(1, 3, 5, 6, 7);
            Sum(3, 5, 6);
            Sum();
        }

        // <out Parameter> ******중요******
        // 매개변수를 출력전용으로 설정
        // 함수의 반환값 외에 추가적인 출력이 필요할 경우 사용
        void Divide(int left, int right, out int quotient, out int remainder)
        {
            quotient = left / right;
            remainder = left % right;

            // 함수의 종료전까지 out 매개변수에 값이 할당 안되는 경우 오류 (무조건 값 할당해줘야함)
        }

        void Main5()
        {
            int quotient; // 변수 먼저 만들고 넣어줘도 되고
            Divide(5, 3, out quotient, out int remainder); // 안에서 바로 만들어도 ㅇㅋ
            Console.WriteLine($"{quotient}, {remainder}");  // output : 1, 2
        }

        // <in Parameter>
        // 매개변수를 입력전용으로 설정
        // 함수의 처음부터 끝까지 동일한 값을 보장하게 됨
        public class Player
        {

        }

        public void Test(in Player player)
        {
            player = null;
        }
        void Main4()
        {
            Player player = new Player();
            Test(in player);
            player;
        }
        int WordCound(in string str)
        {
            return str.Split(' ').Length;
        }


        int Plus(in int left, in int right)
        {
            // left = 20;      // error : 입력전용 매개변수는 변경 불가
            return left + right;
        }

        void Main4()
        {
            int result = Plus(1, 3);
            Console.WriteLine($"{result}");     // output : 4
        }

        // <ref Parameter>
        // 매개변수를 원본참조로 전달
        // 매개변수가 값형식인 경우에도 함수를 통해 원본값을 변경하고 싶을 경우 사용
        void Swap(ref int left, ref int right)
        {
            int temp = left;
            left = right;
            right = temp;
        }

        void Main6()
        {
            int left = 10;
            int right = 20;
            Swap(ref left, ref right);
            Console.WriteLine($"{left}, {right}");      // output : 20, 10
        }
    }
}
