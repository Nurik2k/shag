#region Exercise1
//using System;
//using System.Linq;
//class Program
//{
//    static int[] Exercise1(int[] num)
//    {
//        int n = num.Length;
//        int[] L = Enumerable.Repeat(1, n).ToArray();
//        int[] R = Enumerable.Repeat(1, n).ToArray();

//        for (int i = 1; i < n; i++)
//        {
//            L[i] = L[i - 1] * num[i - 1];
//        }

//        for (int i = n - 2; i >= 0; i--)
//        {
//            R[i] = R[i + 1] * num[i + 1];
//        }

//        int[] ans = new int[n];
//        for (int i = 0; i < n; i++)
//        {
//            ans[i] = L[i] * R[i];
//        }

//        return ans;
//    }
//    static void Main()
//    {
//        int[] num = { 1, 2, 3, 4 };
//        int[] ans = Exercise1(num);
//        Console.WriteLine(string.Join(",", ans));
//    }
//}
//________________________________________________________________________________________________
#endregion

#region Exercise 2
//using System.Collections.Generic;

//class Exercise2
//{
//    public List<int> SpiralOrder(int[][] matrix)
//    {
//        List<int> result = new List<int>();
//        int m = matrix.Length;
//        int n = matrix[0].Length;
//        int row_start = 0;
//        int row_end = m - 1;
//        int col_start = 0;
//        int col_end = n - 1;

//        while (row_start <= row_end && col_start <= col_end)
//        {
//            // traverse right
//            for (int i = col_start; i <= col_end; i++)
//            {
//                result.Add(matrix[row_start][i]);
//            }
//            row_start++;

//            // traverse down
//            for (int i = row_start; i <= row_end; i++)
//            {
//                result.Add(matrix[i][col_end]);
//            }
//            col_end--;

//            // traverse left
//            if (row_start <= row_end)
//            {
//                for (int i = col_end; i >= col_start; i--)
//                {
//                    result.Add(matrix[row_end][i]);
//                }
//                row_end--;
//            }

//            // traverse up
//            if (col_start <= col_end)
//            {
//                for (int i = row_end; i >= row_start; i--)
//                {
//                    result.Add(matrix[i][col_start]);
//                }
//                col_start++;
//            }
//        }
//        return result;
//    }


//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        //int[][] matrix = new int[][] {
//        //    new int[] { 1, 2, 3 },
//        //    new int[] { 4, 5, 6 },
//        //    new int[] { 7, 8, 9 }
//        //};
//        int[][] matrix = new int[][] {
//            new int[] { 1, 2, 3, 4 },
//            new int[] { 5,6,7,8 },
//            new int[] { 9,10,11,12 }
//        };
//        Exercise2 exercise2 = new Exercise2();
//        int[] spiralOrder = exercise2.SpiralOrder(matrix).ToArray();
//        Console.WriteLine("Spiral Order: " + String.Join(",", spiralOrder));
//    }
//}
//________________________________________________________________________________________________________________
#endregion

#region Exercise 3
//using System.Collections.Generic;
//class Exercise3
//{
//    public static int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
//    {
//        Dictionary<int, int> nums1Map = new Dictionary<int, int>();
//        Dictionary<int, int> nums2Map = new Dictionary<int, int>();
//        int count = 0;

//        // populate nums1Map and nums2Map
//        for (int i = 0; i < nums1.Length; i++)
//        {
//            for (int j = 0; j < nums2.Length; j++)
//            {
//                int sum = nums1[i] + nums2[j];
//                if (nums1Map.ContainsKey(sum))
//                {
//                    nums1Map[sum]++;
//                }
//                else
//                {
//                    nums1Map.Add(sum, 1);
//                }
//            }
//        }
//        for (int i = 0; i < nums3.Length; i++)
//        {
//            for (int j = 0; j < nums4.Length; j++)
//            {
//                int sum = nums3[i] + nums4[j];
//                if (nums2Map.ContainsKey(sum))
//                {
//                    nums2Map[sum]++;
//                }
//                else
//                {
//                    nums2Map.Add(sum, 1);
//                }
//            }
//        }

//        // check for tuple (i, j, k, l) such that nums1[i] + nums2[j] + nums3[k] + nums4[l] == 0
//        foreach (int key in nums1Map.Keys)
//        {
//            if (nums2Map.ContainsKey(-key))
//            {
//                count += nums1Map[key] * nums2Map[-key];
//            }
//        }

//        return count;
//    }
//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        int[] nums1 = new int[] { 1, 2 };
//        int[] nums2 = new int[] { -2, -1 };
//        int[] nums3 = new int[] { -1, 2 };
//        int[] nums4 = new int[] { 0, 2 };
//        int count = Exercise3.FourSumCount(nums1, nums2, nums3, nums4);
//        Console.WriteLine("Number of tuples: " + count);
//    }
//}
#endregion