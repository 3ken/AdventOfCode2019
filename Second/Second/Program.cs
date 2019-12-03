using System;

namespace Second
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var one = 0; one < 100; one++)
            {
                for (var two = 0; two < 100; two++)
                {
                    var array = GetArray();
                    array[1] = one;
                    array[2] = two;

                    for (var i = 0; i < array.Length; i += 4)
                    {
                        var valueToStore = 0;
                        switch (array[i])
                        {
                            case 99:
                                if(array[0] == 19690720)
                                {
                                    Console.WriteLine($"1:{array[1]} 2:{array[2]}");
                                    Console.ReadLine();
                                }
                                break;
                            case 1:
                                valueToStore = (array[array[i + 1]]) + (array[array[i + 2]]);
                                break;
                            case 2:
                                valueToStore = (array[array[i + 1]]) * (array[array[i + 2]]);
                                break;
                        }

                        if (i + 4 >= array.Length) 
                            continue;
                        
                        array[array[i + 3]] = valueToStore;
                    }
                }
            }
            Console.WriteLine("Hittade inget");
            Console.ReadLine();
        }

        public static void PrintArray(int[] array)
        {
            for(var i = 0; i < array.Length; i += 4)
            {
                if(i + 3 <= array.Length)
                    Console.WriteLine(array[i] + "," + array[i+1] + "," + array[i+2] + "," + array[i+3] + ",");
                else if(i + 2 <= array.Length)
                    Console.WriteLine(array[i] + "," + array[i+1] + "," + array[i+2] + ",");
                else if(i + 1 <= array.Length)
                    Console.WriteLine(array[i] + "," + array[i+1] + ",");
                else
                    Console.WriteLine(array[i]);
            }
        }
        
        public static int[] GetArray()
        {
            return new[]
            {
                1,0,0,3,
                1,1,2,3,
                1,3,4,3,
                1,5,0,3,
                2,10,1,19,
                1,19,9,23,
                1,23,13,27,
                1,10,27,31,
                2,31,13,35,
                1,10,35,39,
                2,9,39,43,
                2,43,9,47,
                1,6,47,51,
                1,10,51,55,
                2,55,13,59,
                1,59,10,63,
                2,63,13,67,
                2,67,9,71,
                1,6,71,75,
                2,75,9,79,
                1,79,5,83,
                2,83,13,87,
                1,9,87,91,
                1,13,91,95,
                1,2,95,99,
                1,99,6,0,
                99,
                2,14,0,0
            };
        }
    }
}

