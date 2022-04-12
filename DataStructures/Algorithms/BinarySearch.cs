using System.Collections.Generic;
using System.Collections;
namespace DataStructures.Algorithms{
    public class BinarySearch{
        public int Rank<T>(T key, IList<T> a) where T : IComparer<T>{
            int lo = 0;
            int hi = a.Count - 1;
            while(lo <= hi){
                int mid = lo + (hi - lo) / 2;
                if(key.Compare(key, a[mid]) <  0) hi = mid - 1;
                else if(key.Compare(key, a[mid]) >  0) lo = mid + 1;
                else return mid;
            }
            return -1;
        }
    }
}