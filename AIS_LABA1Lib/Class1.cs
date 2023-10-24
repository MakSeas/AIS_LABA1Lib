using System;

namespace AIS_LABA1Lib
{
    public abstract class Class
    {     
        public void DoAlgorithm(int[] array, int n)
        {
            array = new int[n];

            InitializeArray(array);

            Console.WriteLine("Массив содержит следующие элементы: ");
            ShowArrayElements(array);

            int index = TheOperation1(array);
            int C=SummNeighbors(array, index);

            Console.WriteLine($"Число C = {C}");

            int result = TheOperation2(array, C);
        }

        int SummNeighbors(int[] array, int index)
        {
            int result=0;

            if (array.Length > 1)
            {
                if (index == 0)
                {
                    result = array[index + 1];
                }
                else if(index == array.Length-1)
                {
                    result = array[index-1];
                }
                else
                {
                    result = array[index-1]+array[index+2];
                }
            }

            return result;
        }

        void InitializeArray(int[] array)
        {
            System.Random randomInstance = new System.Random();

            for(int i=0;i<array.Length; i++)
            {
                array[i] = randomInstance.Next();
            }
        }

        void ShowArrayElements(int[] array)
        {
            for(int i=0;i<array.Length;i++)
            {
                Console.WriteLine($"{i} элемент: {array[i]}");
            }
        }

        public abstract int TheOperation1(int[] array);
        public abstract int TheOperation2(int[] array, int c);
    }

    public class ClassA:Class
    {
        public override int TheOperation1(int[] array)
        {
            int index=0;
            int min = int.MaxValue;

            for (int i=0;i<array.Length;i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    index = i;
                }
            }

            Console.WriteLine($"index = {index}");

            return index;
        }

        public override int TheOperation2(int[] array, int c)
        {
            int result = 0;
            bool summing=false;

            for(int i = 0; i < array.Length; i++)
            {
                if(summing)
                    result+= Math.Abs(array[i]);

                if (array[i]>c&&!summing)
                    summing = true;
            }

            return result;
        }
    }

    public class ClassB : Class
    {
        public override int TheOperation1(int[] array)
        {
            int index = 0;
            int max = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    index = i;
                }
            }

            Console.WriteLine($"index = {index}");

            return index;
        }

        public override int TheOperation2(int[] array, int c)
        {
            int result = 0;
            bool summing = false;


            for (int i = 0; i < array.Length; i++)
            {
                if (summing)
                    result *= array[i];

                if (array[i] < c && !summing)
                    summing = true;
            }

            Console.WriteLine($"result = {result}");

            return result;
        }
    }
}