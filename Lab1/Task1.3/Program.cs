using System;
using System.Data;
using System.Globalization;
using Microsoft.VisualBasic;

namespace Myproject_Lab1
{
    class CustomDataType
    {
        public int[] array = new int[100];
        public string[] strings = new string[100];
        public float[] floats = new float[100];
        public int type;
        public int Max(int[] array)
        {
            int maxValue = -Int32.MaxValue;
            for (int i = 0; i < array.Length; ++i)
            {
                maxValue = Math.Max(maxValue, array[i]);
            }
            return maxValue;
        }
        public float Max(float[] floats)
        {
            float maxValue = -float.MaxValue;
            for (int i = 0; i < floats.Length; ++i)
                maxValue = Math.Max(maxValue, floats[i]);
            return maxValue;
        }
        public string Max(string[] strings)
        {
            string maxValue = "";
            for (int i = 0; i < strings.Length; ++i)
                if (maxValue.Length < strings[i].Length)
                    maxValue = strings[i];
            return maxValue;
        }
        public int Min(int[] array)
        {
            int minValue = Int32.MaxValue;
            for (int i = 0; i < array.Length; ++i)
            {
                minValue = Math.Min(minValue, array[i]);
            }
            return minValue;
        }
        public float Min(float[] floats)
        {
            float minValue = -float.MinValue;
            for (int i = 0; i < floats.Length; ++i)
                minValue = Math.Min(minValue, floats[i]);
            return minValue;
        }
        public string Min(string[] strings)
        {
            string minValue = "";
            for (int i = 0; i < strings.Length; ++i)
                if (minValue.Length < strings[i].Length)
                    minValue = strings[i];
            return minValue;
        }
        public void Input(int n, string[] temp)
        {
            if (type == 1)
                for (int i = 0; i < n; ++i)
                    array[i] = int.Parse(temp[i]);
            else if (type == 2)
                for (int i = 0; i < n; ++i)
                    floats[i] = float.Parse(temp[i]);
            else
                strings = temp;
        }
    }
    class Program
    {
        static public void Main(string[] args)
        {
            Find_Max_Min();
        }
        static public void Find_Max_Min()
        {
            CustomDataType A = new CustomDataType();

            Console.WriteLine("*/ 1. Mang kieu so nguyen");
            Console.WriteLine("  2. Mang kieu so thuc");
            Console.WriteLine("  3. Mang kieu string /*");

            Console.Write("Chon kieu du lieu: ");
            string readData = Console.ReadLine();

            A.type = int.Parse(readData);

            Console.Write("So luong phan tu: ");
            readData = Console.ReadLine();

            int n = int.Parse(readData);

            Console.Write("Nhap " + n + " phan tu: ");
            string data = Console.ReadLine();

            string[] temp = data.Split(" ");
            A.Input(n, temp);

            Console.Write("1 de tim Max, 2 de tim Min: ");
            readData = Console.ReadLine();

            int request = int.Parse(readData);
            if (request == 1)
            {
                if (A.type == 1)
                    Console.WriteLine(A.Max(A.array));
                else if (A.type == 2)
                    Console.WriteLine(A.Max(A.floats));
                else
                    Console.WriteLine(A.Max(A.strings));
            }
            else
            {
                if (A.type == 1)
                    Console.WriteLine(A.Min(A.array));
                else if (A.type == 2)
                    Console.WriteLine(A.Min(A.floats));
                else
                    Console.WriteLine(A.Min(A.strings));
            }
        }
    }
}
