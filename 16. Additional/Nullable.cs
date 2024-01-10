using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._Additional
{
    internal class Nullable
    {
        public class Item
        {
            public string name;
            public void Use() { }
        }
        static void main()
        {

            //<Nullable 타입>
            //값형식의 자료형들은 null을 가질 수 없음
            //값형식에도 null을 할당할 수 있는 Nullable 타입을 지원

            int? value = null;
            bool? b = null;

            if (value != null) Console.WriteLine(value);
            if (b.HasValue) Console.WriteLine(b.Value);





            // <Null 조건연산자>
            // ? 앞의 객체가 null인 경우 null 반환
            // ? 앞의 객체가 null이 아닌 경우 접근
            /* if(item != null)
             {
                 string name = item.name;
             }
             if(item!=null)
             {
                 item.Use();
             }

             item = new Item() { name = "포션" };
             string name = item?.name;
             item?.Use(); */

            Item item = null;
            Console.WriteLine(item?.name);
            item?.Use();

            item = new Item() { name = "포션" };
            Console.WriteLine(item?.name);
            item?.Use();


            // < Null 병합연산자 >
            // ?? 앞의 객체가 null인 경우 ?? 뒤의 객체 반환
            // ?? 앞의 객체가 null이 아닌 경우 앞의 객체 반환

            int[] array = null;
            int length = array?.Length ?? 0; // 배열이 null인 경우 0반환, 아닌경우 배열의 크기 반환



            // <Null 병합할당연산자>
            // ??= 앞의 객체가 null 인 경우 ??= 뒤의 객체를 할당
            // ??= 앞의 객체가 null 인 아닌경우 ??= 뒤의 객체를 할당하지 않음
            NullClass nullClass = null;
            nullClass ??= new NullClass();          // nullClass 가 null이므로 새로운 인스턴스 할당
            nullClass ??= new NullClass();          // nullClass 가 null이 아니므로 새로운 인스턴스 할당이 되지 않음

        }

        public class NullClass
        {
            public int value = 5;

            public void Func() { }
        }
    }
}
