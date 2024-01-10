﻿namespace _12._Generic
{
    internal class Program
    {
        /********************************************************************************************
        * 일반화 (Generic)
        * 
        * 클래스 또는 함수가 코드에 의해 선언되고 인스턴스화될 때까지 형식의 사양을 연기(뒤로 미룸)하는 디자인
        * 기능을 구현한 뒤 자료형을 사용 당시에 지정해서 사용한다.
        ********************************************************************************************/

        // <일반화 함수> : 일반화가 없는 경우 자료형마다 함수를 작성함
        // 일반화를 이용하면 다른 자료형의 함수 또한 호환하도록 구현할 수 있음
        // 함수나 클래스 이름 다음에 < 이름아무거나 > (매개변수) 로 만들수있음
        public static void ArrayCopy<T>(T[] source, T[] output) // < > 안 이름은 자유 보통 T나 Type씀
        {
            for (int i = 0; i < source.Length; i++)
            {
                output[i] = source[i];
            }
        } // 자료형만 다르고 기능은 똑같은 걸 만들고 싶을때 사용하는듯?

        void Main1()
        {
            int[] iSrc = { 1, 2, 3, 4, 5 };
            int[] iOut = new int[5];

            ArrayCopy<int>(iSrc, iOut);  //< >안에 사용하고 싶은 자료형 써주면 됨 : 자료형을 함수 호출 당시에 결정함

            float[] fSrc = { 1.0f, 2.0f, 3.0f, 4.5f, 5.1f };
            float[] fOut = new float[5];

            ArrayCopy(fSrc, fOut); // 일반화 자료형이 매개변수의 자료형으로 추측이 가능한 경우에는 생략도 가능함

            char[] cSrc = { 'a', 'b', 'c', };
            char[] cOut = new char[3];

            ArrayCopy<char>(cSrc, cOut);
        }

        // < 일반화 클래스 >
        // 클래스에 필요한 자료형을 일반화하여 구현
        // 이후 클래스 인스턴스를 생성할 때 자료형을 지정하여 사용

        public class SafeArray<T>
        {
            T[] array;

            public SafeArray(int size)
            {
                array = new T[size];
            }

            public void Set(int index, T value)
            {
                if (index < 0 || index >= array.Length)
                    return;

                array[index] = value;
            }

            public T Get(int index)
            {
                if (index < 0 || index >= array.Length)
                    return default(T);      // default : T 자료형의 기본값

                return array[index];
            }
        }

        void Main2()
        {
            SafeArray<int> intArray = new SafeArray<int>(10);
            SafeArray<float> floatArray;
        }

        // < 일반화 자료형 제약 >
        // 일반화 자료형을 선언할 때 제약조건을 선언하여, 사용 당시 쓸 수 있는 자료형을 제한

        class StructT<T> where T : struct { }           // T는 구조체만 사용 가능
        class ClassT<T> where T : class { }             // T는 클래스만 사용 가능
        class NewT<T> where T : new() { }               // T는 매개변수 없는 생성자가 있는 자료형만 사용 가능

        class ParentT<T> where T : Parent { }           // T는 Parent 파생클래스만 사용 가능
        class InterfaceT<T> where T : IComparable { }   // T는 인터페이스를 포함한 자료형만 사용 가능

        void Main2()
        {
            StructT<int> structT = new StructT<int>();          // int는 구조체이므로 struct 제약조건이 있는 일반화 자료형에 사용 가능
            // ClassT<int> classT = new ClassT<int>();          // error : int는 구조체이므로 class 제약조건이 있는 일반화 자료형에 사용 불가
            NewT<int> newT = new NewT<int>();                   // int는 new int() 생성자가 있으므로 사용 가능

            ParentT<Parent> parentT = new ParentT<Parent>();    // Parent는 Parent 파생클래스이므로 사용 가능
            ParentT<Child> childT = new ParentT<Child>();       // Child는 Parent 파생클래스이므로 사용 가능
            InterfaceT<int> interT = new InterfaceT<int>();     // int는 IComparable 인터페이스를 포함하므로 사용 가능
        }

        public static Type Bigger<Type>(Type left, Type right) where Type : IComparable // 비교할 수 있는 애들만 쓸 수 있어 : 자료형에 제약사항을 걸어둠(클래스나 구조체도 올 수 있음)
        {
            if (left.CompareTo(right) < 0)  //비교가 불가능한 자료형이 올 수 있어서 직접 비교는 안됨
            {
                return left;
            }
            else
            {
                return right;
            }
        }

        class Player { }

        void Main3()
        {
            int intBigger = Bigger<int>(3, 5);
            float floatBigger = Bigger<float>(2.1f, 3.8f);

            bool boolBigger = Bigger<bool>(true, false); //bool도 비교가능 true가 false보다 큼


        }

        // <일반화 제약 용도>
        // 일반화 자료형에 제약조건이 있다면 포함가능한 자료형의 기능을 사용할 수 있음
        public class BaseClass
        {
            public void Start()
            {
                Console.WriteLine("Start");
            }
        }

        public void Main3<T>(T param) where T : BaseClass
        {
            param.Start();      // 일반화 자료형의 제약조건이 BaseClass 클래스이므로, BaseClass의 기능을 사용 가능 
        }

    }
}
