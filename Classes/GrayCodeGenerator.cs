using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes
{
    class GrayCodeGenerator
    {   // C# program to generate n-bit Gray codes  
        // This function generates all n bit Gray codes and prints the  
        // generated codes  
        public static List<string> arr = new List<string>();
        public static List<string> generateGrayarr(int n)
        {
            arr = new List<string>();
            // base case  
            if (n <= 0)
            {
                return arr = new List<string>();
            }

            // 'arr' will store all generated codes  

            
            // start with one-bit pattern  
            arr.Add("0");
            arr.Add("1");

            // Every iteration of this loop generates 2*i codes from previously  
            // generated i codes.  
            int i, j;
            for (i = 2; i < (1 << n); i = i << 1)
            {
                // Enter the prviously generated codes again in arr[] in reverse  
                // order. Nor arr[] has double number of codes.  
                for (j = i - 1; j >= 0; j--)
                {
                    arr.Add(arr[j]);
                }

                // append 0 to the first half  
                for (j = 0; j < i; j++)
                {
                    arr[j] = "0" + arr[j];
                }

                // append 1 to the second half  
                for (j = i; j < 2 * i; j++)
                {
                    arr[j] = "1" + arr[j];
                }
            }      
            return arr;
        }

      
    }
}
