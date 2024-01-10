namespace _13._Delegate
{
    internal class Program
    {
        /****************************************************************
         * 대리자 (Delegate) : 대신 함수를 호출시켜주는 역할을 함 (함수를 담을 수 있는 변수라고 생각하면 됨)
         * 
         * 특정 매개 변수 목록 및 반환 형식이 있는 함수에 대한 참조 : 함수를 보관하는 변수
         * 대리자 인스턴스를 통해 함수를 호출 할 수 있음
         ****************************************************************/

        // < 델리게이트 정의 >
        // delegate 반환형 델리게이트 이름(매개변수들);
        public delegate float Delegate1(float left, float right);  //float로 만들었으니까 float반환형과 float매개변수를 사용하는 애들만 사용가능
        public delegate void Delegate2(string str);

        public static float Add(float left, float right)
        {
            return left + right;
        }

        public float Minus(float left, float right)
        {
            return left - right;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }


        // <델리게이트 사용>
        // 반환형과 매개변수가 일치하는 함수를 델리게이트 변수에 할당
        // 델리게이트 변수에 참조한 함수를 대리자를 통해 호출 가능
        void Main1()
        {

            Delegate1 delegate1 = new Delegate1(Add); // 델리게이트 인스턴스 생성 - 정석
            float result = delegate1(1.2f, 3.4f);   // Add(1.2f,3.4f) == 4.6f

            delegate1 = Minus;
            result = delegate1(3.4f, 1.2f);         // Minus(3.4f, 1.2f) == 2.2f

            //delegate1 = Message; // 델리게이트는 반환형과 매개변수가 일치하지 않으면 참조가 불가능함
            Delegate2 delegate2 = Message;  // 현실적인 사용법
            delegate2("메세지");
        }


        static void Main(string[] args)
        {

        }
    }
}
