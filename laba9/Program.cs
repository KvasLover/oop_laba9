using System;
using System.Text.RegularExpressions;

namespace laba9
{
    public delegate void Delegate(string message);
    public delegate void my_delegate(string message);
    public class Boss
    {
        public my_delegate delegate_helper = (string message) => Console.WriteLine(message);
        public bool Activated { get; set; } = false;
        public int level = 1;
        public bool is_working = true;
        public event Delegate Turn_on_ev;
        public event Delegate Upgrade_ev;
        public void Start_event(string message, bool flag)
        {
            if(flag)
                Turn_on_ev?.Invoke(message);
            else
                Upgrade_ev?.Invoke(message);
        }
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        public void Show_end_Message(string message)
        {
            Console.WriteLine(message);
        }        
    }
    public class Cyborg:Boss
    {
        public const int max_level = 2;
        public void Turn_on()
        {
            if (Activated == false && is_working == true)
            {
                Activated = true;
                Start_event("Попытка включить киборга: киборг был включён.", true);
            }
            else if (Activated == true && is_working == true)
            {
                Start_event("Попытка включить киборга: киборг уже включён.", true);
            }
            else
            {
                Start_event("Попытка включить киборга: киборг сломан.", true);
            }
        }
        public void Upgrade()
        {
            if (is_working == false)
            {
                Start_event("Попытка увеличить уровень киборга: киборг поломан.", false);
            }
            else if (Activated == false)
            {
                Start_event("Попытка увеличить уровень киборга: киборг выключен.", false);
            }
            else if (level > max_level)
            {
                is_working = false;
                Start_event("Попытка увеличить уровень киборга: превышен максимальный уровень киборга, он поломался.", false);
            }
            else
            {
                level++;
                Start_event("Попытка увеличить уровень киборга: уровень киборга был повышен, текущий - " + level, false);
            }              

        }
    }
    public class Robot:Boss
    {
        public const int max_level = 3;
        public void Turn_on()
        {
            if (Activated == false && is_working == true)
            {
                Activated = true;
                Start_event("Попытка включить робота: робот был включён.", true);
            }
            else if (Activated == true && is_working == true)
            {
                Start_event("Попытка включить робота: робот уже включён.", true);
            }
            else
            {
                Start_event("Попытка включить робота: робот сломан.", true);
            }
        }
        public void Upgrade()
        {
            if (is_working == false)
            {
                Start_event("Попытка увеличить уровень робота: робот поломан.", false);
            }
            else if (Activated == false)
            {
                Start_event("Попытка увеличить уровень робота: робот выключен.", false);
            }
            else if (level > max_level)
            {
                is_working = false;
                Start_event("Попытка увеличить уровень робота: превышен максимальный уровень робота, он поломался.", false);
            }
            else
            {
                level++;
                Start_event("Попытка увеличить уровень киборга: уровень робота был повышен, текущий - " + level, false);
            }

        }
    }
    class Program
    {       
        static void Main(string[] args)
        {
            /*Cyborg cyborg1 = new Cyborg();            
            cyborg1.Turn_on_ev += cyborg1.ShowMessage;
            cyborg1.Upgrade_ev += cyborg1.ShowMessage;

            cyborg1.Upgrade();
            cyborg1.Turn_on();
            cyborg1.Turn_on();
            cyborg1.Turn_on();
            cyborg1.Turn_on();
            cyborg1.Upgrade();
            cyborg1.Upgrade();
            cyborg1.Upgrade();
            cyborg1.Upgrade();
            cyborg1.Upgrade();
            cyborg1.delegate_helper("Конец настройки киборга.");
            Console.WriteLine();

            Robot robot1 = new Robot();
            robot1.Turn_on_ev += cyborg1.ShowMessage;
            robot1.Upgrade_ev += cyborg1.ShowMessage;

            robot1.Upgrade();
            robot1.Turn_on();
            robot1.Turn_on();
            robot1.Turn_on();
            robot1.Turn_on();
            robot1.Upgrade();
            robot1.Upgrade();
            robot1.Upgrade();
            robot1.Upgrade();
            robot1.Upgrade();
            robot1.delegate_helper("Конец настройки робота.");*/

            //2)

            string String = "Первое предложение. Один: два, три - четыре. Третье...";           
                    
            Action<string> one;
            one = String_Computing.Delete_punctuation;
            one(String);

            int num = 3;
            string String2 = " ВСТАВКА ";
            Func<string, string, int, string> two;
            two = String_Computing.Add_symbol;
            Console.WriteLine( two(String, String2, num) );

            one = String_Computing.To_upper_case;
            one(String);

            Func<string, string> three;
            three = String_Computing.Remove_spaces;
            Console.WriteLine( three(String) );

            Action<string, string> four;
            four = String_Computing.To_unite;
            four(String," ДОБАВЛЕНИЕ");
        }    
    }
    public class String_Computing
    {        
        public static void Delete_punctuation(string String)
        {     
            Console.WriteLine( Regex.Replace(String, "[-.?!)(,:]", "") );
        }
        public static string Add_symbol(string String, string symb, int num)
        {            
            return String.Insert(num, symb);
        }
        public static void To_upper_case(string String)
        {
            for(int i = 0; i < String.Length; i++)
            {
                Console.Write(String.ToUpper()[i]);
            }
            Console.WriteLine();
        }
        public static string Remove_spaces(string String)
        {            
            return Regex.Replace(String, " ", "");
        }
        public static void To_unite(string String, string String2)
        {
            Console.WriteLine(String + String2);
        }
    }
}
