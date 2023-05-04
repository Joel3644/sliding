using System;
using System.Collections.Generic;
using System.Linq;

public static class LargestSeriesProduct {
    public static long GetLargestProduct(string digits, int span) {
        var things = new List<int>();

        if(span > 0 && digits.Length == 0)
            throw new System.ArgumentException();
        if(span == 0 || digits.Length == 0)
            return 1;
        if(digits.Length - span < 0 || span < 0)
            throw new System.ArgumentException();

        foreach( char c in digits ){
            if(!char.IsNumber(c)){
                throw new System.ArgumentException();
            }
        }

        for(int i = 0; i <= digits.Length - span; i++){
            string fullNum = digits.Substring(i, span);
            int product = 1;

            foreach(char c in fullNum){
                product *= int.Parse(c.ToString());
            }
            things.Add(product);
        }
        return things.Max();
    }
}