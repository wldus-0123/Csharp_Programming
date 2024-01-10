namespace _07._Class
{
    internal class Program
    {
        // 구조체와 클래스는 차이가 거의 없음, 둘 다 변수와 함수를 담을 수 있음
        // 하지만 클래스는 참조형식, 구조체는 값형식 ( 가장 큰 차이 )

        // 구조체 : 데이터가 중요할 때 사용
        // 클래스 : 원본 자체(객체)가 중요할 때 사용

        /***********************************************************************
        * 클래스 (class)
        * 
        * 데이터와 관련 기능을 캡슐화할 수 있는 참조 형식
        * 객체지향 프로그래밍에 객체를 만들기 위한 설계도
        * 클래스는 객체를 만들기 위한 설계도(붕어빵틀)이며, 만들어진 객체(붕어빵)는 인스턴스라 함
        * 참조 : 원본을 가리키고 있음 == 원본의 주소를 가지고 있음 (실제로 값을 들고 있는 것이 아님)
        ***********************************************************************/

        // < 클래스 구성 >
        // class 클래스 이름 { 클래스 내용 } 
        // 클래스 내용으로는 변수와 함수가 포함 가능하다
        class Student
        {
            public string name;
            public int math;
            public int english;
            public int science;

            public float GetAverage()
            {
                return (math + english + science) / 3f;
            }
        }

        void Main1()
        {
            Student kim = new Student(); //class를 사용할 변수 선언
            kim.name = "김감자"; // 변수 . 클래스변수
            kim.math = 10;
            kim.english = 10;
            kim.science = 100;

            float average = kim.GetAverage();
        }


        // < 클래스 생성자 >
        // 반환형이 없는 클래스이름의 함수를 생성자라고 하며 클래스의 인스턴스(객체)를 만들 때 호출되는 역할로 사용
        // 인스턴스의 생성자는 new 키워드를 통해서 사용

        class Car //설계도 작성...
        {
            public string name;
            public string color;
            public int year;

            public Car()
            {

            }

            public Car(string name, string color) // 값을 세팅하는게 아닌 객체를 만드는 행위
            {
                this.name = name;
                this.color = color;
            }

            public Car(string name, string color, int year) : this(name, color)  // 생성자 위임
            {
                this.year = year;
            }
        }

        void Main2()
        {
            //class는 따로 저장소를 만들어서 빈값을 가진 항목과 주소지만 들고 있음 구조체는 여러가지 데이터 값들을 갖고있음
            //따라서 class는 초기화가 아닌 class를 이용하여 새로운 무언가를 만드는 것

            Car truck = new Car("트럭", "파란색"); //설계도 사용해서 새로운 차(객체) 만들기
            Console.WriteLine($"{truck.name},{truck.color}");

            Car sportCar = new Car() { name = "스포츠카" };
        }

        // < 클래스 얕은 복사 >
        // 클래스에 대입연산자(=)를 통해 같은 인스턴스(객체)를 참조함

        class MyClass
        {
            public int value1;
            public int value2;
        }

        void Main3()
        {
            MyClass s = new MyClass();
            s.value1 = 1;
            s.value2 = 2;

            MyClass t = s; // s와 t는 똑같은 주소지 사용, class의 경우 주소지(원본)의 값을 변경하는 것
            t.value1 = 3;

            Console.WriteLine(s.value1); //3 - 주소지(원본)의 값이 바뀌었기 때문에, s값이 t값으로 인해 영향을 받음 (구조체의 경우 s는 t에 영향을 받지 않음)
            Console.WriteLine(s.value2); //2

            Console.WriteLine(t.value1); //3
            Console.WriteLine(t.value2); //2

        }


        /*******************************************
         * 값형식, 참조형식 (중요!!!!!!!!!!!!!!)
         * 
         * 값형식 (Value type) : 
         * 복사할 때 실제값이 복사됨 (깊은 복사) - 실제로 데이터 자체를 갖고있음
         * 구조체는 값형식
         * boxing
         * 
         * 참조형식 (Reference type) : 
         * 복사할 때 객체주소가 복사됨 (얕은 복사) - 주소를 가리킴
         * 클래스는 참조형식
         * unboxing
         ********************************************/
        // < 값형식과 참조형식의 차이 ?
        // 값형식: 데이터가 중요한 경우 사용, 값이 복사됨
        // 참조형식 : 객체가 중요한 경우 사용, 객체주소가 복사됨

        struct ValueType
        {
            public int value;
        }

        class RefType
        {
            public int value;
        }

        void Main4()
        {
            ValueType valueType1 = new ValueType() { value = 10 }; // 값을 10으로 설정 (초기화)
            ValueType valueType2 = valueType1;      // 값이 복사
            valueType2.value = 20;                  // 값을 대입해도 원본에는 영향 없음
            Console.WriteLine(valueType1.value);    // output : 10

            RefType refType1 = new RefType() { value = 10 }; // new RefType()의 주소값을 반환
            RefType refType2 = refType1;            // 객체주소가 복사 (현재 둘이 같은 주소를 갖고있음)
            refType2.value = 20;                    // 값을 대입하는 경우 원본 데이터를 변경
            Console.WriteLine(refType1.value);      // output : 20
        }

        // <값에 의한 호출, 참조에 의한 호출>
        // 값에 의한 호출 (Call by value) : 
        // 값형식의 데이터가 전달되며 데이터가 복사되어 전달됨
        // 함수의 매개변수로 전달하는 경우 복사한 값이 전달되며 원본은 유지됨 (값만 복사해온 거라서)
        void Swap(ValueType left, ValueType right)
        {
            int temp = left.value;
            left.value = right.value;
            right.value = temp;
        }

        // 참조에 의한 호출 (Call by reference) :
        // 참조형식의 데이터가 전달되며 주소가 복사되어 전달됨
        // 함수의 매개변수로 전달하는 경우 주소가 전달되며 주소를 통해 접근하기 때문에 원본을 전달하는 효과
        void Swap(RefType left, RefType right)
        {
            int temp = left.value;
            left.value = right.value;
            right.value = temp;
        }

        void Main5()
        {
            ValueType leftValue = new ValueType() { value = 10 };
            ValueType rightValue = new ValueType() { value = 20 };
            Swap(leftValue, rightValue);    // 데이터의 복사본이 함수로 들어가기 때문에 원본이 바뀌지 않음
            Console.WriteLine($"{leftValue.value}, {rightValue.value}");    // output : 10, 20

            RefType leftRef = new RefType() { value = 10 };
            RefType rightRef = new RefType() { value = 20 };
            Swap(leftRef, rightRef);        // 원본의 주소가 함수로 들어가기 때문에 원본이 바뀜
            Console.WriteLine($"{leftRef.value}, {rightRef.value}");        // output : 20, 10
        }

        // <얕은복사, 깊은복사>
        // 얕은복사 (Shallow copy) : 객체를 복사할 때 주소값만을 복사하여 같은 원본을 가리키게 함 (내용물을 복사하는 것이 아님)
        // 깊은복사 (Deep copy) : 객체를 복사할 때 주소값 안의 원본을 복사하여 다른 객체를 가지고 가리키게 함 (내용물을 그대로 복사함)


        class CopyConstructor
        {
            public RefType shallow;
            public RefType deep;

            public CopyConstructor(CopyConstructor other)
            {
                // 얕은복사
                this.shallow = other.shallow;

                // 깊은복사
                this.deep = new RefType(); //새로운 객체 생성
                this.deep.value = other.deep.value; //새로운 객체에 값 대입
            }
        }


        static void Main(string[] args)
        {

        }
    }
}
