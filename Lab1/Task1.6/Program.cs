using System;

namespace Task1_6
{
    interface IThinking
    {
        void thinking_behavior();
    }
    interface IIntelligent
    {
        void intelligent_behavior();
    }
    interface IAbility : IThinking, IIntelligent
    {

    }
    public class Mamal
    {
        public string characteristics;
        public Mamal(string characteristics)
        {
            this.characteristics = characteristics;
        }
    }
    public class Whale : Mamal
    {
        public Whale(string name) : base(name)
        {

        }
    }
    public class Human : Mamal, IAbility
    {
        public Human(string name) : base(name)
        {

        }
        public void thinking_behavior()
        {
            Console.WriteLine("Think about their life");
        }
        public void intelligent_behavior()
        {
            Console.WriteLine("Know the 2+2 Math");
        }
    }
    class Programs
    {
        private static void Main(string[] args)
        {
            Human a = new Human("Phan Van Dai");
            a.thinking_behavior();
            a.intelligent_behavior();
        }

    }

}