using System;

namespace laba9
{
    public delegate void Delegate(string message);
    public delegate void my_delegate(string message);
    public class Boss
    {
        public event my_delegate my_event;        
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
        public void end_event(string message)
        {
            my_event?.Invoke(message);
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
            Cyborg cyborg1 = new Cyborg();
            cyborg1.my_event += cyborg1.Show_end_Message;
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
            cyborg1.end_event("Конец настройки киборга.");
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
            cyborg1.end_event("Конец настройки робота.");
        }
        


    }
}
