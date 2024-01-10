namespace _06.UserDefineType //기존에 있던 자료형 뿐만 아니라 본인이 필요한거 만들어서도 사용해보자
{
    internal class Program
    {
        /********************************************************************
        * 열거형 (Enum)
        * 
        * 기본 정수 숫자의 형식의 명명된 상수 집합에 의해 정의되는 값 형식
        * 열거형 멤버의 이름으로 관리되어 코드의 가독성적인 측면에 도움이 됨
        ********************************************************************/

        // < 열거형 기본사용 >
        // enum 열거형 이름 { 멤버이름, 멤버이름, ...}
        enum Direction { Up, Down, Left, Right }// 각각의 순서대로 0,1,2,3,,,, 의 값을 부여함
        enum Week { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday } //와 같이 갯수가 정해져 있는 여러 경우가 있을 때 사용한다

        static void Main1()
        {
            // 방향 자료형 : 위쪽, 아래쪽, 왼쪽, 오른쪽
            Direction input = Direction.Down;
            switch (input)
            {
                case Direction.Up: //0을 넣어도 동작
                    Console.WriteLine("위로 이동");
                    break;
                case Direction.Down: // 1을 넣어도 동작
                    Console.WriteLine("아래로 이동");
                    break;
                case Direction.Left: // 2를 넣어도 동작
                    Console.WriteLine("왼쪽으로 이동");
                    break;
                case Direction.Right: // 3을 넣어도 동작
                    Console.WriteLine("오른쪽으로 이동");
                    break;
            }
        }


        // < 열거형 변환 >
        enum Season
        {
            Spring,
            Semmer,
            Autumn = 20, // 다른 값으로 사용하고 싶을 때 직접 지정하는 것도 가능함
            Wubter // 위의 숫자 따라서 바뀜
        }

        static void Main2()
        {
            Season season1 = Season.Spring;
            int value1 = (int)Season.Spring; //  int로 형변환이 가능함 Spring의 경우 0 - 열거형변수를 int로 형변환이 가능하다

            Season season2 = (Season)0; //  Spring과 같음
            Season season3 = (Season)11; // 없는 값이 들어갈 경우, 그냥 값 자체가 대입된 값이 됨
        }

        /**************************************************
       * 구조체 (Struct)
       * 
       * 데이터와 관련 기능을 캡슐화할 수 있는 값 형식
       * 데이터를 저장하기 보관하기 위한 단위용도로 사용 (많은 변수 및 기능들을 한번에 관리가능)
       **************************************************/

        // < 구조체 구성 >
        // struct 구조체 이름 { 구조체내용 }
        // 구조체 내용으로는 변수와 함수가 포함 가능

        struct MonsterStat //얘가 가질 수 있는 자료들을 작성
        {
            public int hp; //우선은 public 다 붙이기
            public int mp;
            public int level;
            public float speed;
            public float range;
            public int Getsum()
            {
                return hp + mp;
            } // 함수 기능도 만들어서 묶을 수 있음

            public float GetAverage()
            {
                return (hp + mp + level) / 3.0f;
            }

        }

        static void Main3()
        {
            MonsterStat stat; // 구조체 변수 선언
            stat.hp = 10; // 구조체 내 변수에 접근하기 위해 구조체에 .을 붙여 사용 (함수도 마찬가지임)
            stat.mp = 5;
            stat.level = 1; //변수를 만들자마자 초기화 하는 경우
            stat.speed = 1.6f;
            stat.range = 3.5f;
        }

        void Attack(MonsterStat stat)
        {

        }




        // < 구조체 초기화 >
        // 반환형이 없는 구조체이름의 함수를 초기화라 함
        //구조체 안의 변수를 초기화하기 위해서
        //매개변수가 있는 초기화를 정의하여 구조체 변수의 값을 설정하기 위한 용도로 사용

        struct Point
        {
            public int x;
            public int y;

            //초기화 함수 만들기

            // 기본 초기롸  - 굳이 만들 필요는 없을지도? 자동생성 커스텀이 가능해진 것 뿐임
            public Point()  // 매개변수가 없는 입력
            {
                this.x = 0;
                this.y = 0;
            }
            //혹은 
            public Point(int _x, int _y) //똑같은 이름 중 매개변수에는 언더바 붙이는게 국룰이래
            {
                x = _x; // 혹은 this.x=x;로도 표현 가능 this 역할 찾아보기
                y = _y; // this.y=y; (자기 자신<구조체에서 선언된 변수>으로 초기화하는거임)
            }


        }

        void Main4()
        {
            Point point1;
            point1.x = 1;
            Console.WriteLine(point1.x);
            Console.WriteLine(point1.y); // 초기화 하지 않은 변수는 사용할 수 없음

            Point point2 = new Point(2, 3);
            Console.WriteLine($"{point2.x}, {point2.y}");
        }


        struct PlayerStat
        {
            public int hp;
            public int mp;
            public float range;
            public float speed;

            public PlayerStat(Job job)
            {
                if (job == Job.Archor)
                {
                    hp = 50;
                    mp = 30;
                    range = 200;
                    speed = 100;
                }

            }

        }

        enum Job { Archor, Mage, knight }

        static void Main5()
        {
            Console.WriteLine("직업을 선택하세요 : ");
            Job job = Job.Archor;

            PlayerStat playerStat = new PlayerStat(Job.Archor);
        }

        struct Vector3
        {
            public float x;
            public float y;
            public float z;

            public Vector3(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public string ToString()
            {
                return $"({x},{y},{z})";
            }
        }


        // < 구조체 복사 >
        // 깊은 복사 : 구조체 변수끼리 대입하면 안의 내용물까지 같이 복사됨 - 구조체에 대입연산자(=)을 통해 구조체 내 모든 변수들의 값이 복사됨

        static void Main6()
        {
            Vector3 source = new Vector3(1, 2, 3);

            Vector3 dest = source;

            Console.WriteLine(source.ToString());
            Console.WriteLine(dest.ToString());

            source.y = 10;

            Console.WriteLine(source.ToString()); // source의 y값은 10으로 바뀜
            Console.WriteLine(dest.ToString()); // dest는 안바뀜
        }

        // < 튜플 >: 쓰지말고 구조체 만들 것 - > 나중에 관리가 어려움

        static void Main7()
        {
            (int min, int max) value;
            value.min = -10;
            value.max = 10;

            (int x, int y) position;
            position = value; // 값이 대입되어 버림 - 안좋은 상황
        }

        static void Main(string[] args)
        {

        }
    }
}
