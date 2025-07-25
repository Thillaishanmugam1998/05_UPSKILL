using System;

class ArraysDemo
{
    static void Main()
    {
        Console.WriteLine("=== ARRAYS DEMO ===\n");

        // 1. Single-dimensional arrays
        Console.WriteLine("1. Single-dimensional arrays:");

        // Declaration and initialization - Method 1
        int[] numbers1 = new int[5]; // Creates array of 5 integers (all 0)
        numbers1[0] = 10;
        numbers1[1] = 20;
        numbers1[2] = 30;
        numbers1[3] = 40;
        numbers1[4] = 50;

        // Declaration and initialization - Method 2
        int[] numbers2 = new int[] { 100, 200, 300, 400, 500 };

        // Declaration and initialization - Method 3 (most common)
        int[] numbers3 = { 1000, 2000, 3000, 4000, 5000 };

        // Displaying array elements
        Console.WriteLine("Numbers1 array:");
        for (int i = 0; i < numbers1.Length; i++)
        {
            Console.WriteLine($"numbers1[{i}] = {numbers1[i]}");
        }

        Console.WriteLine("\nNumbers2 array (using foreach):");
        foreach (int num in numbers2)
        {
            Console.Write($"{num} ");
        }
        Console.WriteLine();

        // 2. Multi-dimensional arrays (2D)
        Console.WriteLine("\n2. Multi-dimensional arrays (2D Matrix):");

        // 3x4 matrix  (row coloumn)
        int[,] matrix = {
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9, 10, 11, 12}
        };

        Console.WriteLine("Matrix contents:");
        for (int row = 0; row < matrix.GetLength(0); row++) // GetLength(0) = rows
        {
            for (int col = 0; col < matrix.GetLength(1); col++) // GetLength(1) = columns
            {
                Console.Write($"{matrix[row, col]:D3} ");
            }
            Console.WriteLine();
        }

        // 3. Three-dimensional array
        Console.WriteLine("\n3. Three-dimensional array:");
        int[,,] cube = new int[2, 2, 2] {
            { {1, 2}, {3, 4} },
            { {5, 6}, {7, 8} }
        };

    //[
    //    [1 2]
    //    [3 4],

    //    [5 6]
    //    [7 8]
    //           ]
    //000 = 1, 001 = 2, 010 = 3, 011 =4

        for (int x = 0; x < cube.GetLength(0); x++)
        {
            Console.WriteLine($"Layer {x}:");
            for (int y = 0; y < cube.GetLength(1); y++)
            {
                for (int z = 0; z < cube.GetLength(2); z++)
                {
                    Console.Write($"{cube[x, y, z]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // 4. Jagged arrays (arrays of arrays)
        Console.WriteLine("4. Jagged arrays:");

        int[][] jaggedArray = new int[3][];
        jaggedArray[0] = new int[] { 1, 2 };
        jaggedArray[1] = new int[] { 3, 4, 5, 6 };
        jaggedArray[2] = new int[] { 7, 8, 9 };

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            Console.Write($"Row {i}: ");
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write($"{jaggedArray[i][j]} ");
            }
            Console.WriteLine();
        }

        // 5. Array operations
        Console.WriteLine("\n5. Array operations:");

        int[] operationArray = { 5, 2, 8, 1, 9, 3 };

        Console.WriteLine("Original array:");
        PrintArray(operationArray);

        // Sorting
        Array.Sort(operationArray);
        Console.WriteLine("After sorting:");
        PrintArray(operationArray);

        // Reversing
        Array.Reverse(operationArray);
        Console.WriteLine("After reversing:");
        PrintArray(operationArray);

        // Finding elements
        int searchValue = 8;
        int index = Array.IndexOf(operationArray, searchValue);
        Console.WriteLine($"Index of {searchValue}: {index}");

        // Array statistics
        Console.WriteLine($"Array length: {operationArray.Length}");
        Console.WriteLine($"First element: {operationArray[0]}");
        Console.WriteLine($"Last element: {operationArray[operationArray.Length - 1]}");
    }

    // Helper method to print array
    static void PrintArray(int[] arr)
    {
        foreach (int element in arr)
        {
            Console.Write($"{element} ");
        }
        Console.WriteLine();
    }
}