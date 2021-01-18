

import java.util.Map;
import java.util.HashMap;
import java.util.PriorityQueue;
import java.util.TreeMap;
import java.util.*;



public class _347_TopKFrequentElements {



    //Runtime: 8 ms, faster than 92.04% of Java online submissions for Top K Frequent Elements.
    //Memory Usage: 41.7 MB, less than 55.67% of Java online submissions for Top K Frequent Elements.
    //
    //// Quickselect is a textbook algorthm typically used to solve the problems "find kth something": kth smallest, kth largest, kth most frequent, kth less frequent, etc. Like quicksort, quickselect was developed by Tony Hoare, and also known as Hoare's selection algorithm.
    ////
    //// !!! It has O(N) average time complexity and widely used in practice. It worth to note that
    // its worth case time complexity is O(N^2)
    ////, although the probability of this worst-case is negligible.
    //
    // Quick Sort 研究詳見 DSAlgo
    // 研究過  Hoare  Lomuto 之後   Sol2的全部技術差異細節都有涵蓋到
    //
    // 這邊Sol 2 在 partition 的說明又對不上  已發issue  明明做的是 Lomuto  卻說是 Hoare
    //
    // 基本上   懂了　QuickSelect 之後  程式碼就是  直接理解  就是這樣做  沒錯
    //
    // Time complexity: O(N) in the average case, O(N^2) in the worst case. T(N) = T(N/2)+N, that
    // results in  O(N) time complexity. That's the case of random pivots.
    //
    // In the worst-case of constantly bad chosen pivots, the problem is not divided by half at
    // each step, it becomes just one element less, that leads to O(N^2) time complexity. That's
    // for example, if at each step you choose the pivot not randomly, but take the rightmost element. For the random pivot choice the probability of having such a worst-case is negligibly small.
    //
    // Space complexity: up to O(N) to store hash map and array of unique elements.
    //
    //
    // Further Discussion: Could We Do Worst-Case Linear Time?
    // In theory, we could, the algorithm is called Median of Medians.
    //
    // This method is never used in practice because of two drawbacks:
    //
    // It's outperformer. Yes, it works in a linear time αN, but the constant α is so large that in practice it often works even slower than N^2
    //
    // It doesn't work with duplicates.
    // https://en.wikipedia.org/wiki/Median_of_medians

    class Solution_Sol2 {
        int[] unique;
        Map<Integer, Integer> count;

        public void swap(int a, int b) {
            int tmp = unique[a];
            unique[a] = unique[b];
            unique[b] = tmp;
        }

        public int partition(int left, int right, int pivot_index) {
            int pivot_frequency = count.get(unique[pivot_index]);
            // 1. move pivot to end
            swap(pivot_index, right);
            int store_index = left;

            // 2. move all less frequent elements to the left
            for (int i = left; i <= right; i++) {
                if (count.get(unique[i]) < pivot_frequency) {
                    swap(store_index, i);
                    store_index++;
                }
            }

            // 3. move pivot to its final place
            swap(store_index, right);

            return store_index;
        }

        public void quickselect(int left, int right, int k_smallest) {
        /*
        Sort a list within left..right till kth less frequent element
        takes its place.
        */

            // base case: the list contains only one element
            if (left == right) return;

            // select a random pivot_index
            Random random_num = new Random();
            int pivot_index = left + random_num.nextInt(right - left);

            // find the pivot position in a sorted list
            pivot_index = partition(left, right, pivot_index);

            // if the pivot is in its final sorted position
            if (k_smallest == pivot_index) {
                return;
            } else if (k_smallest < pivot_index) {
                // go left
                quickselect(left, pivot_index - 1, k_smallest);
            } else {
                // go right
                quickselect(pivot_index + 1, right, k_smallest);
            }
        }

        public int[] topKFrequent(int[] nums, int k) {
            // build hash map : character and how often it appears
            count = new HashMap();
            for (int num: nums) {
                count.put(num, count.getOrDefault(num, 0) + 1);
            }

            // array of unique elements
            int n = count.size();
            unique = new int[n];
            int i = 0;
            for (int num: count.keySet()) {
                unique[i] = num;
                i++;
            }

            // kth top frequent element is (n - k)th less frequent.
            // Do a partial sort: from less frequent to the most frequent, till
            // (n - k)th less frequent element takes its place (n - k) in a sorted array.
            // All element on the left are less frequent.
            // All the elements on the right are more frequent.
            quickselect(0, n - 1, n - k);
            // Return top k frequent elements
            return Arrays.copyOfRange(unique, n - k, n);
        }
    }


    //Runtime: 11 ms, faster than 42.49% of Java online submissions for Top K Frequent Elements.
    //Memory Usage: 41.8 MB, less than 42.52% of Java online submissions for Top K Frequent Elements.
    //
    // Time complexity : O(Nlogk) if k<N and O(N) in the particular case of N=k. That ensures time complexity to be better than O(NlogN).
    //
    // Space complexity : O(N+k) to store the hash map with not more NN elements and a heap with
    // kk elements.
    //
    class Solution_Sol1 {
        public int[] topKFrequent(int[] nums, int k) {
            // O(1) time
            if (k == nums.length) {
                return nums;
            }

            // 1. build hash map : character and how often it appears
            // O(N) time
            Map<Integer, Integer> count = new HashMap();
            for (int n: nums) {
                count.put(n, count.getOrDefault(n, 0) + 1);
            }

            // init heap 'the less frequent element first'
            Queue<Integer> heap = new PriorityQueue<>(
                    (n1, n2) -> count.get(n1) - count.get(n2));

            // 2. keep k top frequent elements in the heap
            // O(N log k) < O(N log N) time
            for (int n: count.keySet()) {
                heap.add(n);
                if (heap.size() > k) heap.poll();
            }

            // 3. build an output array
            // O(k log k) time
            int[] top = new int[k];
            for(int i = k - 1; i >= 0; --i) {
                top[i] = heap.poll();
            }
            return top;
        }
    }


}
