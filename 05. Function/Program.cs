namespace _05.Function
{
    internal class Program
    {
        /****************************************************************
        * 함수 (Function) : 입력이 있으면 출력도 있음
        *
        * 미리 정해진 동작을 수행하는 코드 묶음
        * 어떤 처리를 미리 함수로 만들어 두면 다시 반복적으로 사용 가능
        ****************************************************************/

        // <함수 구성> :  출력 이름 (입력들) { 동작 }
        // 함수 이름은 앞자리만 대문자가 국룰
        // 일련의 코드를 하나의 이름 아래에 묶음 (C#은 생성 위치 상관 없음)
        // 반환형 함수이름<출력> + 함수 이름 + (매개변수목록<입력들>) + { 함수내용 }
        // 입력이 없어도 됨. 그때는 괄호 안을 입력식 대신 공란으로 남겨놓으면 됨

        // <함수 사용>
        // 함수로 구성해둔 코드를 이름으로 불러 사용함


        // <반환형 (Return Type)>
        // 함수의 결과(출력) 데이터의 자료형
        // 함수가 끝나기 전까지 반드시 return으로 반환형에 맞는 데이터를 출력해야함
        // 함수 진행 중 return을 만나는 경우 그 즉시 결과 데이터를 반환하고 함수가 종료됨
        // 함수의 결과(출력)이 없는 경우 반환형은 void이며 return을 생략 가능
        // void는 출력할 내용이 없다 라는 의미, 실행만 함


        // <매개변수 (Parameter)>
        // 함수에 추가(입력)할 데이터의 자료형과 변수명
        // 같은 함수에서도 매개변수 입력이 다름에 따라 다른 처리가 가능

        static int Minus(int left, int right)
        {
            // 함수의 입력으로 넣어준 매개변수  left, right에 따라 함수가 동작
            return left - right;
        }

        static void PrintProfile(string name, string phone) // return이 없어도 됨
        {
            Console.WriteLine($"이름 : {name}");
            Console.WriteLine($"번호 : {phone}");

        }


        static int Plus(int left, int right) //지금 당장은 static 붙이긴 하는데 투명인간 취급하셈
        {
            Console.WriteLine($"Input : {left},{right}");
            int result = left + right;
            Console.WriteLine($"Output : {result}");
            return result; //return 값을 출력
        }

        // <함수 호출 순서>
        // 함수는 호출되었을 때 해당 함수 블록으로 제어가 전송되며 완료되었을 때 원위치로 제어가 전송됨


        // <함수 오버로딩> *****중요
        // 같은 이름의 함수를 매개변수를 달리하여 다른 함수로 재정의하는 기술
        // 같은 이름의 함수를 호출하여도 매개변수의 자료형에 따라 함수를 달리 호출할 수 있음




        int Multi(int left, int right) { return left * right; }
        float Multi(float left, float right) { return left * right; }
        double Multi(double left, double right) { return left * right; }

        static int TripleShot()
        {

            int damage = 0;
            damage += Attack();
            damage += Attack();
            damage += Attack();
            return damage;


        }

        static int Attack()
        {
            Console.WriteLine("공격!");
            return 10;
        }


        static void Main(string[] args)
        {

            int totalDamage = TripleShot();

        }
    }
}
