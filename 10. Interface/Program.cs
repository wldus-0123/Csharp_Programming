namespace _10._Interface
{
    internal class Program
    {
        /***************************************************************************
        * 인터페이스 (Interface) : 무언가끼리 상호작용하기 위한 수단
        * 
        * 인터페이스는 맴버를 가질 수 있지만 직접 구현하지 않음 단지 정의만을 가짐
        * 인터페이스를 가지는 클래스에서 반드시 인터페이스의 정의를 구현해야함
        * 이를 반대로 표현하자면 인터페이스를 포함하는 클래스는
        * 반드시 인터페이스의 구성 요소들을 구현했다는 것을 보장함
        * Can-a 관계 : 클래스가 해당 행동을 할 수 있는 경우 적합함 , 이 행동을 할 수 있느냐 없느냐
        * 
        * 
        * + 상속이랑 인터페이스 동시에 사용이 가능함 ( 부모클래스에 인터페이스 달면 자식클래스도 사용가능)
        ***************************************************************************/

        // < 인터페이스 정의 > : 키워드 = interface
        //일반적으로 인터페이스의 이름은 'I'로 시작함 - 국룰
        //인터페이스의 함수는 직접 구현하지 않고 정의만 진행

        public interface IEnterable
        {
            public void Enter();  // 직접 구현하지 않고 정의만 진행 : 추상클래스랑 거의 똑같은데 왜 상속이랑 인터페이스랑 따로 있을까????
        }

        //++ 추상클래스와 인터페이스의 용도 차이

        public interface IOpenable
        {
            public void Open();
        }

        // < 인터페이스 포함 >
        // 상속처럼 정의한 인터페이스를 '클래스 :' 분여서 사용
        // 인터페이스는 여러개 포함이 가능하다
        // 인터페이스를 포함하는 경우 반드시 인터페이스에서 정의한 함수를 구현해야만 함

        // 상속은 기본적으로 하나만 가능 , 다중상속 불가능

        public class Box : IOpenable, IDamagable
        {
            public void Open() // 반드시 인터페이스에서 정의한 함수를 구현해줘야함
            {
                Console.WriteLine("박스가 열립니다.");
                Console.WriteLine("아이템이 나옵니다.");
            }
            public void TakeHit(int damage)
            {
                Console.WriteLine("박스가 부셔집니다.");
                Console.WriteLine("아이템이 손상되었습니다.");
            }
        }

        public class Door : IOpenable, IEnterable, IDamagable // 인터페이스는 여러개 포함 가능
        {
            public void Open()
            {
                Console.WriteLine("문을 엽니다.");
            }
            public void Enter()
            {
                Console.WriteLine("들어갑니다.");
            }
            public void TakeHit(int damage)
            {
                Console.WriteLine("문이 부셔집니다.");
            }

        }

        public class Town : IEnterable
        {
            public void Enter()
            {
                Console.WriteLine("마을에 진입합니다.");
            }
        }

        public interface IDamagable
        {
            public void TakeHit(int damage);

        }

        // <인터페이스 사용>
        // 인터페이스를 이용하여 기능을 구현할 경우 클래스의 상속관계와 무관하게, 행동의 가능여부로 상호작용 가능

        public class Player
        {
            public void Open(IOpenable openable)
            {
                Console.Write("플레이어가 대상을 열기 시도합니다.");
                openable.Open();
            }
            public void Enter(IEnterable enterable)
            {
                Console.WriteLine("플레이어가 대상에 들어가기 시도합니다.");
                enterable.Enter();
            }
            public void Attack(IDamagable damagable)
            {
                Console.WriteLine("플레이어가 대상을 공격하기 시도합니다.");
                damagable.TakeHit(10);
            }
        }

        public class Monster : IDamagable
        {
            public int hp;
            public void TakeHit(int damage)
            {
                hp -= damage;
                Console.WriteLine("공격받았습니다.");
            }
        }

        static void Main(string[] args)
        {
            Player player = new Player();
            Box box = new Box();
            Town town = new Town();

            player.Open(box);
            player.Enter(town);

            Door door = new Door();

            player.Open(door);
            player.Enter(door);

            Monster monster = new Monster();
            player.Attack(monster); // 인터페이스가 들어있는 클래스는 인터페이스를 대상으로 하는 함수 사용 가능
            player.Attack(door);
            player.Attack(box);
        }
    }
}
