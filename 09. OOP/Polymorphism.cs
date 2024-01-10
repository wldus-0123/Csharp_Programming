using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _09._OOP
{
    internal class Polymorphism
    {
        /***************************************************************************
        * 다형성 (Polymorphism)
        *
        * 객체의 속성이나 기능이 상황에 따라 여러가지 형태를 가질 수 있는 성질
        ****************************************************************************/

        // <다형성>
        // 부모클래스의 멤버를 자식클래스가 상황에 따라 여러가지 형태를 가질 수 있는 성질
        // 변수는 값만 바꿔주면 됨

        class Car
        {
            protected string name;
            protected int speed;

            public void Move()
            {
                Console.WriteLine($"{name} 이/가 {speed} 의 속도로 이동합니다.");
            }
        }

        class Truck : Car
        {
            public Truck()
            {
                name = "트럭";
                speed = 30;
            }
        }

        class SportCar : Car
        {
            public SportCar()
            {
                name = "스포츠카";
                speed = 100;
            }
        }

        void Main1()
        {
            Car car1 = new Truck();
            Car car2 = new SportCar();

            car1.Move();    // 트럭 이/가 30 의 속도로 이동합니다.
            car2.Move();    // 스포츠카 이/가 100 의 속도로 이동합니다.
        }


        // < 가상함수와 오버라이딩 > ++ 오버로딩 오버라이딩 하이딩이라는 것도 있으니까 참고~~
        // 함수는 값만 바꾸면 안되고 가상함수 지정 후 오버라이딩 해야함
        // 가상함수 : 부모클래스의 함수 중 자식클래스에 의해 재정의 할 수 있는 함수를 지정
        // 오버라이딩(덮어쓰기) : 부모클래스의 가상함수를 같은 함수이름과 같은 매개변수로 재정의하여 자식만의 반응을 구현 (가상함수가 아니면 오버라이드 할 수 없음)
        public class Skill
        {
            protected float coolTime;

            public virtual void Execute() // 가상 함수 설정
            {
                Console.WriteLine("스킬 재사용 대기시간을 진행시킴");
            }
        }

        public class FireBall : Skill
        {
            public FireBall()
            {
                coolTime = 3f;
            }

            public override void Execute() //자식에서 다른 방식으로 기능 구현 - 자식에 작성한 내용으로 바뀜(함수 내용을 재정의)
            {
                Console.WriteLine("스킬 재사용 대기시간을 진행시킴");
                Console.WriteLine("불덩이 날리기");
            }
        }

        public class Heal : Skill
        {
            public Heal()
            {
                coolTime = 15f;
            }

            public override void Execute() //자식에서 다른 방식으로 기능 구현 - 자식에 작성한 내용으로 바뀜(함수 내용을 재정의)
            {
                Console.WriteLine("스킬 재사용 대기시간을 진행시킴");
                Console.WriteLine("체력 회복");
            }
        }

        static CodeIdentifier Main()
        {
            Skill fireBall = new FireBall();
            Skill heal = new Heal();

            fireBall.Execute();
            heal.Execute();

            //+가상함수테이블
            //+base 부모함수를 가리킴 (부모함수에 적혀있는 내용도 사용하고 싶을때 사용)


            // < 다형성 사용의미 1>
            // 새로운 클래스를 추가하거나 확장할 때 기존 코드에 영향을 최소화함

            // < 다형성 사용의미 2>
            // 
        }
    }
}
