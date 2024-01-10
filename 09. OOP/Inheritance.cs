using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._OOP
{
    internal class Inheritance
    {
        /**********************************************************************************
         * 상속 (Inheritance)
         *
         * 부모클래스의 모든 기능을 가지는 자식클래스를 설계하는 방법
         * is-a 관계 : 부모클래스가 자식클래스를 포함하는 상위개념일 경우 상속관계가 적합함
         **********************************************************************************/

        // <상속>
        // 부모클래스를 상속하는 자식클래스에게 부모클래스의 모든 기능을 부여
        // class 자식클래스이름 : 부모클래스이름

        public class Monster
        {
            protected string name;
            protected int hp;

            public void Move()
            {
                Console.WriteLine($"{name} 이/가 움직입니다.");
            }

            public void TakeHit(int damage)
            {
                hp -= damage;
                Console.WriteLine($"{name} 이/가 {damage} 를 받아 체력이 {hp} 이 되었습니다.");
            }
        }

        public class Dragon : Monster
        {
            public Dragon()
            {
                name = "드래곤";
                hp = 100;
            }

            public void Breath()
            {
                Console.WriteLine($"{name} 이/가 브레스를 뿜습니다.");
            }
        }

        public class Slime : Monster
        {
            public Slime()
            {
                name = "슬라임";
                hp = 10;
            }

            public void Split()
            {
                Console.WriteLine($"{name} 이/가 분열합니다.");
            }
        }


        public class Hero
        {
            int damage = 3;

            public void Attack(Monster monster)
            {
                monster.TakeHit(damage);
            }
        }

        static void Main()
        {
            Dragon dragon = new Dragon();
            dragon.TakeHit(10);
            dragon.Breath();

            Slime slime = new Slime();
            slime.TakeHit(10);
            slime.Split();

            Hero hero = new Hero();
            hero.Attack(dragon);
            hero.Attack(slime);

            // 업캐스팅 : 자식클래스를 부모위치에 보관 (묵시적)
            Monster monster1 = new Dragon();
            Monster monster2 = new Slime();

            monster1.TakeHit(10); // 부모의 기능만 사용 가능
            // monster1.Breath(); // 본인의 기능 사용할 수 없음

            // 위험부담이 있는 다운캐스팅 : 부모클래스를 자식클래스에 보관 - 형변환 직접 해줘야함
            Dragon dra = (Dragon)monster1; // 100%인 경우 (명시적)
            // Slime slim = (Slime)monster1; // error

            if (monster1 is Dragon)
            {
                Dragon d = (Dragon)monster1;
                Console.WriteLine("monster1은 드래곤입니다.");
            }
            else
            {
                Console.WriteLine("monster1은 드래곤이 아닙니다.");
            }

            if (monster2 is Dragon)
            {
                Dragon d = (Dragon)monster2;
                Console.WriteLine("monster1은 드래곤입니다.");
            }
            else
            {
                Console.WriteLine("monster1은 드래곤이 아닙니다.");
            }

            Dragon asDragon = monster1 as Dragon; // as는 되면 바꿔주고 안되면 null
            Slime asSlime = monster1 as Slime;
        }

        // <상속 사용의미 1>
        // 상속을 진행하는 경우 부모클래스의 소스가 자식클래스에서 모두 적용됨
        // 부모클래스와 자식클래스의 상속관계가 적합한 경우 부모클래스에서의 기능 구현이 자식클래스에서도 어울림
        class Fruit
        {
            // 부모클래스에서 기능을 구현할 경우 모든 부모를 상속하는 자식클래스에 기능을 구현하는 효과
        }

        class Apple : Fruit
        {
            // 자식클래스에서 자식클래스만의 기능을 구현
        }


        // <상속 사용의미 2>
        // 업캐스팅을 통해 자식클래스는 부모클래스로 형변환이 가능함
        // 자식클래스는 부모클래스를 요구하는 곳에서 동일한 기능을 수행할 수 있음
        class Parent
        {
            public void Func() { }
        }
        class Child1 : Parent { }
        class Child2 : Parent { }
        class Child3 : Parent { }

        void UseParent(Parent parent) { parent.Func(); }
        void Main2()
        {
            Child1 child1 = new Child1();
            Child2 child2 = new Child2();
            Child3 child3 = new Child3();

            UseParent(child1);
            UseParent(child2);
            UseParent(child3);
        }
    }
}
