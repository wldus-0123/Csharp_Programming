namespace _03.Conditional
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /****************************************************************
             * 조건문 (Conditional)
             *
             * 조건에 따라 실행이 달라지게 할 때 사용하는 문장
             ****************************************************************/

            /****************************************************************
            * if 조건문
            *
            * 조건식의 true, false에 따라 실행할 블록을 결정하는 조건문
            ****************************************************************/

            //<if 조건문 기본>

            int playerHP = 100;
            int monsterAtk = 20;


            if (/*조건식*/playerHP > monsterAtk)
            {
                //조건식의 결과가 true라면 실행됨
                Console.WriteLine("플레이어가 데미지를 받습니다.");
                playerHP -= monsterAtk;
            }

            else
            {
                //조건식의 결과가 false라면 실행됨
                Console.WriteLine("플레이어가 쓰러집니다.");
                playerHP = 0;
            }

            bool isJumpPressed = true;
            bool isGround = true;
            if (isJumpPressed && isGround)
            {
                Console.WriteLine("점프한다.");
            }
            /*else // 생략 가능 (필수는 아님) 
            {
                //아무 것도 안함      
            } */

            string input = "바위";        // 가위, 바위, 보
            if (input == "가위") //만약에...
            {
                Console.WriteLine("입력한 값이 가위일 때 처리");
            }
            else if (input == "바위") //아니면...
            {
                Console.WriteLine("입력한 값이 바위일 때 처리");
            }
            else if (input == "보") //아니면...
            {
                Console.WriteLine("입력한 값이 보일 때 처리");
            }
            else //위에꺼 다 아니면...
            {
                Console.WriteLine("입력한 값이 셋 다 아닐 때 처리");
            }


            int score = 87; // 60이하 아이언, 61~70 브론즈, 71~80 실버, 81~90 골드, 91~100 플레
            if (score <= 60)
            {
                Console.WriteLine("아이언");
            }
            else if (score <= 70) // 위에서 걸러져서 굳이 위에 체크한 사항은 재입력하지 않아도 됨
            {
                Console.WriteLine("브론즈");
            }

            //순서 중요! 앞에 내용에 해당되면 뒤의 내용에 해당되더라도 뒤의 계산식 생략하고 앞의 결과를 출력하게됨


            /****************************************************************
             * switch 조건문
             *
             * 조건값에 따라 실행할 시작지점을 결정하는 조건문
             ****************************************************************/

            // <switch 조건문 기본>
            char c = 'B';

            switch (c)  // 조건값을 지정함 (조건식이 아님)
            {   // 맞는 부분 찾아서 실행시키고 break 만나면 끝남

                case 'A': //case와 판단할 값을 입력
                    Console.WriteLine("조건값이 A인 경우 실행");
                    break; //break 입력 (나가기)
                case 'B':
                    Console.WriteLine("조건값이 A인 경우 실행");
                    break;
                case 'C':
                    Console.WriteLine("조건값이 A인 경우 실행");
                    break;
            }

            // 조건값이 일치하는 case가 없는 경우 default가 실행지점이 됨
            int value = 7;
            switch (value)
            {
                case 1: //case와 판단할 값을 입력
                    Console.WriteLine("조건값이 1인 경우 실행");
                    break; //break 입력 (나가기)
                case 2: //case와 판단할 값을 입력
                    Console.WriteLine("조건값이 1인 경우 실행");
                    break; //break 입력 (나가기)

                default: // 조건값이 case에 일치한 적이 없으니 defaul가 실행됨
                    Console.WriteLine("값은 그 외");
                    break;
            }

            //switch문은 조건값에 따라 동일한 실행이 필요한 경우 묶어서 사용 가능
            char key = 'w';
            switch (key)
            {
                case 'w':
                case 'W':
                case 'ㅈ':
                    Console.WriteLine("위쪽으로 이동");
                    break;
                case 'a':
                case 'A':
                case 'ㅁ':
                    Console.WriteLine("왼쪽으로 이동");
                    break;
                case 's':
                case 'S':
                case 'ㄴ':
                    Console.WriteLine("아래쪽으로 이동");
                    break;
                case 'd':
                case 'D':
                case 'ㅇ':
                    Console.WriteLine("오른쪽으로 이동");
                    break;
                default:
                    Console.WriteLine("이동하지 않음");
                    break;
            }

            /****************************************************************
            * 삼항연산자
            *
            * 간단한 조건문을 빠르게 작성 - 대신 간단한 것만 하셈
            ****************************************************************/
            int left = 11;
            int right = 22;

            int bigger = left > right ? left : right;

            //위의 식과 아래식은 똑같음

            int bigger;
            if (left > right)
            {
                bigger = left;
            }
            else
            {
                bigger = right;
            }


            // <삼항 연산자 기본>
            // 조건식 ? true인 경우 값 : false인 경우 값
            int big = 20 > 10 ? 20 : 10;      // 조건이 true이니 20
            int small = 20 < 10 ? 20 : 10;      // 조건이 false이니 10

        }
    }
}
