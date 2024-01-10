using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._Delegate
{
    /*******************************************************************************
        * 콜백함수 - 단축키 만들 때 유용
        * 
        * 델리게이트를 이용하여 특정조건에서 반응하는 함수를 구현
        * 함수의 호출(Call)이 아닌 역으로 호출받을 때 반응을 참조하여 역호출(Callback) - 상대가 원하는 타이밍에 호출당함
        *******************************************************************************/

    internal class Callback // 호출당한다
    {
        public class Player
        {
            public void Jump() { Console.WriteLine("점프한다"); }
            public void Dash() { Console.WriteLine("대시한다"); }
        }
        void Main()
        {
            Player player = new Player();

            Button jumpButton = new Button(player.Jump);
            // jumpButton.OnClick == player.Jump; :호출 당할 놈 지정
            jumpButton.Click();

            Button dashButton = new Button(player.Dash);
            // dashButton.OnClick == player.Dash;
            dashButton.Click();
        }
        public class Button
        {
            public Action OnClick;
            public Button(Action Onclick) 
            {
                this.OnClick = Onclick;
            }

            public virtual void Click()
            {
                if (OnClick != null) OnClick();  //null = 없다 (참조변수가 가리키고 있는게 아무것도 없다)
            }
        }

    }
}
