using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._Additional
{
    internal class Property  // 상당히 많이씀
    {
        public class Player
        {
            private int hp;      //외부에서 확인은 가능하지만 수정은 불가능하게 만들어야함


            // <Getter Setter>
            // 멤버변수가 외부객체와 상호작용하는 경우 Get & Set 함수를 구현해 주는 것이 원칙
            // 1. Get&Set 함수의 접근제하한자를 설정하여 외부에서 멤버변수의 접근을 캡슐화함
            // 2. Get&Set 함수를 거쳐 멤버변수에 접근할 경우 호출스택에 함수가 추가되어 변경시점을 확인 가능
            public int Gethp()          // 외부에서 확인도 불가능하게 하려면 private로 만들면 됨
            {
                return hp;
            }

            private void SetHP(int hp)  // 외부에서 수정도 가능하게 할라면 public 으로 바꿔주면 됨
            {
                this.hp = hp;
            }

            //<속성 (Property)>
            //Get & Set 함수의 선언을 간소화
            public event Action<int> OnChangeMp;
            private int mp;
            public int Mp      //Mp 멤버변수의 Get & Set속성
            {
                get { return mp; }  //get : Get함수와 역할동일
                set { mp = value; OnChangeMp(mp); } //set : Set함수와 역할동일, 매개변수는 value
            }

            public int Ap { get; set; } //AP 멤버변수를 선언과 동시에 Get&Set속성
            public int Dp { get; set; } //get이나 set앞에 접근제한자를 추가로 붙일 수 있음 (속성의 접근제한자를 통한 캡슐화)
            public int Sp { get; } = 10; //읽기전용 속성(상수처럼 사용 가능)
            public int Hp => Gethp();    //읽기전용 속성(람다처럼 사용 가능)
        }

        void Main()
        {
            Player player = new Player();
            int playerHp = player.Gethp();
            player.SetHP(playerHp - 100);

            int playerMp = player.Mp;
            player.Mp = 10;

            int playerAp = player.Ap;
            player.Ap = 10;

        }
    }
}
