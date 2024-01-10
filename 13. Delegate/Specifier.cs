using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._Delegate
{
    internal class Specifier
    {
        /*******************************************************************
        * 지정자 (Specifier) 너무 어려우면 우선 넘어갈 것
        * 
        * 델리게이트를 사용하여 미완성 상태의 함수를 구성
        * 매개변수로 전달한 지정자를 기준으로 함수를 완성하여 동작시킴
        * 기준을 정해주는 것으로 다양한 결과가 나올 수 있는 함수를 구성가능
        ********************************************************************/

        // <델리게이트를 지정자로 사용해주는 방법>
        // 매개변수로 함수에 필요한 기준을 전달
        // 전달한 기준을 통해 결과를 도출


        public class Item
        {
            public string name;
            public int level;
            public float weight;

            public Item(string name, int level, float weight)
            {
                this.name = name;
                this.level = level;
                this.weight = weight;
            }
        }

        void Main1()
        {
            Item[] inventory = new Item[5];
            inventory[0] = new Item("포션", 3, 3.2f);
            inventory[1] = new Item("갑옷", 2, 1.2f);
            inventory[2] = new Item("무기", 1, 4.5f);
            inventory[3] = new Item("방패", 8, 8.8f);
            inventory[4] = new Item("폭탄", 6, 12.6f);
            /*
            int findIndex = -1;
            //1. 이름으로 찾기
            string findName = "방패";
            for(int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].name == findName) // 찾는 조건 --- 얘만 바꾸면 다른 거 찾을 수도 있음
                {
                    findIndex = i;
                    break;
                }
            }

            //2. 레벨로 찾기
            int findLevel = 8;
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].level == findLevel)
                {
                    findIndex = i;
                    break;
                }
            }

            //3. 무게로 찾기
            float findWeight = 12.6f;
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].weight == findWeight)
                {
                    findIndex = i;
                    break;
                }
            } */

            int index1 = FindIndex(inventory, (item) => { return item.level >= 3; }); // 아이템의 레벨이 3 이상인 것 찾기 -- 이건 람다식이래요 머라는겨

            int index2 = FindIndex(inventory, FindWeight6);

        }

        public static bool FindByName(Item item)
        {
            return item.name == "방패";
        }

        public static bool FindWeight6(Item item)
        {
            return item.weight == 6;
        }

        public static int FindIndex(Item[] inventory, Predicate<Item> predicate) // 대상, 지시자 매개변수 설정..?
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (predicate(inventory[i]))
                {
                    return i;
                }
            }
            return -1; // 끝낸다 0이면 에러없이 잘 했다, 다른 숫자면 에러났다 잘 안됐다. 근데 국룰은 보통 -1을 쓴다!
        }

        void Main2()
        {
            int[] array = { 3, -2, 1, -4, 9, -8, 7, -6, 5 };  //내가 원하는 값을 찾아보쟈

            int value = -6; //찾고싶은값
            int findIndex = -1; // 의미없는 값임 일단

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    findIndex = i;
                    break;
                }
            }
        }
    }
}
