using System;
using System.Collections.Generic;

namespace BasicThirteen
{
    class Program
    {
        public static void oneto255(){
      for(int val= 1; val <= 255; val++){
                Console.WriteLine(val);
         }
}
        
       public static void Oddoneto255(){
      for(int val= 1; val <= 255; val++){
        if(val % 2 == 1){
           Console.WriteLine(val);

        }
    }
}
        public static void SumoneTo255(){
            int sum = 0;
            for(int val= 1; val <= 255; val++){
                sum += val;
                Console.WriteLine(sum);
            }
        }
        

        
        public static void iterateArray(int[] iterarr) {
            for(int val =0; val < iterarr.Length; val++){
                Console.WriteLine(val);
            }

        }
          public static int findMax(int[] array){
            int max = 0;
            foreach (int num in array){if(num>max){
                max=num;
                }
            }
            return max;
        }

        public static void findAvg(int[] iterarr) {
            int sum = 0;
            for(int i = 0; i < iterarr.Length; i++){
                sum += i;
            }
            int avg = sum / iterarr.Length;

            Console.WriteLine(avg);
        }

      
      
        public static void arrOdd(int[] iterarr) {
            for(int i = 0; i <iterarr.Length; i++){
                if (iterarr[i] % 2 == 1){
                    Console.Write(iterarr[i]);
                }
            }

        }



            public static void GreaterThanY(int[] iterarr, int Y) {
                int Count = 0;
            for(int i = 0; i <iterarr.Length; i++){
                if (iterarr[i] > Y){
                    Count++;
                }

            }
            Console.WriteLine(Count);

        }


            public static void SquareVal(int [] iterarr) {
                for(int i = 0; i < iterarr.Length; i++){
                    iterarr[i] = iterarr[i] * iterarr[i];
                    Console.WriteLine(iterarr[i]);
                }
              
            }

            public static void NoNeg(int [] iterarr){
                for(int i=0; i < iterarr.Length; i++){
                    if(iterarr[i] > 0){
                        Console.WriteLine(iterarr[i]);

                    }
                }
            } 
        public static void MaxMinAvg(int[] iterarr) {
            int sum = 0;
            int min = iterarr[0];
            int max = iterarr[0];
            foreach(int val in iterarr) {
                sum += val;
                if(val < min) {
                    min = val;
                }
                if(val > max) {
                    max = val;
                }
            }
            Console.WriteLine("The max of the array is {0}, the min is {1}, and the average is {2}", max, min, (double)sum/(double)iterarr.Length);
        }

        public static void Shiftarr(int[] iterarr){
            for(int i =0; i< iterarr.Length - 1; i++){
                iterarr[i] += iterarr[i+1];
            }
                iterarr[iterarr.Length-1]= 0;
        }

         public static object[] ReplaceNumberWithString(object[] arr) {
            for(int idx = 0; idx < arr.Length; idx++) {
                if((int)arr[idx] < 0) {
                    arr[idx] = "Dojo";
                }
            }
            return arr;
        }



        static void Main(string[] args)
        {
            oneto255();
            Oddoneto255();
            SumoneTo255();
            int[] iterarr= {-1,3,-5,7,9,13};
            int Y = 7;
            iterateArray(iterarr);
            findMax(iterarr);
            findAvg(iterarr);
            arrOdd(iterarr); 
            GreaterThanY(iterarr, Y);
            SquareVal(iterarr);
            NoNeg(iterarr);
          
            MaxMinAvg(iterarr);
            Shiftarr(iterarr);
            object[] boxedArray = new object[] {-1, 3, 2 -16};
            ReplaceNumberWithString(boxedArray);
            


         

         


           

           

            //min max average

            //shifting the values in an array


            // number to string * make a list

        }
    }
}
