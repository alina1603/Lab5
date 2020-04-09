using System;

namespace Lab5
{
    /// <summary>
    /// Абстрактный класс для всех оберток и оборачиваемых объектов
    /// </summary>
    public abstract class Component
    {
        /// <summary>
        /// обращение к операции обертывания
        /// </summary>
        public abstract string Operation();
    }
    /// <summary>
    /// Конкретный компонент, определяющий класс оборачиваемых объектов
    /// </summary>
    class ConcreteComponent : Component
    {
        public override string Operation()
        {
            return "Вывод результата";
        }
    }
    /// <summary>
    /// Базовый декоратор, хранящий ссылку на вложенный объект-компонент
    /// </summary>
    abstract class Decorator : Component
    {
        protected Component compa;

        public Decorator(Component component)
        {
            this.compa = component;
        }

        // Декоратор делегирует всю работу обёрнутому компоненту.
        public override string Operation()
        {
            if (this.compa != null)
            {
                return this.compa.Operation();
            }
            else
            {
                return string.Empty;
            }
        }
    }
    /// <summary>
    /// Вариант декоратора,содержащий добавочное поведение
    /// </summary>
    class Shifrator : Decorator
    {
        public Shifrator(Component comp) : base(comp)
        {
        }

        public override string Operation()
        {
            return $"Шифрование результата({base.Operation()})";
        }
    }

/// <summary>
/// Вариант декоратора,содержащий добавочное поведение
/// </summary>
class Sghimator : Decorator
    {
        public Sghimator(Component comp) : base(comp)
        {
        }

        public override string Operation()
        {
            return $"Сжатие результата({base.Operation()})";
        }
    }
    /// <summary>
    /// Класс основной программы
    /// </summary>
    class Program
    {
        public static void ClientCode(Component component)
        {
            Console.WriteLine("RESULT: " + component.Operation());
        }
        static void Main(string[] args)
        {
            var simple = new ConcreteComponent();
            Shifrator decorator1 = new Shifrator(simple);
            Sghimator decorator2 = new Sghimator(decorator1);
            string number;
            int prov;
            Console.WriteLine("Введите нужный Вам уровень защиты данных при пересылке" +
                ":\r\n1. Простая пересылка\r\n2. Шифрование пересылаемой строки\r\n3. Сжатие зашифрованной строки");
            number = Console.ReadLine();
            /*Проверка на корректность введенных данных.*/
            try
            {
                prov = Convert.ToInt32(number);
            }
            catch
            {
                Console.WriteLine("Ошибка при выборе уровня!");
                Console.ReadLine();
                return;
            }
            if (prov > 3)
            {
                Console.WriteLine("Такого уровня не существует!");
                Console.ReadLine();
                return;
            }

            switch (number) /*В зависимости от числа определяется, к какому уровню нужен доступ.*/
            {
                case "1":
                    ClientCode(simple);
                    break;
                case "2":
                    ClientCode(decorator1);
                    break;
                case "3":
                    ClientCode(decorator2);
                    break;
            }
            Console.ReadLine();
        }
    }
}