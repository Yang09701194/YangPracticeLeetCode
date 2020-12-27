import java.util.Map;
import java.util.HashMap;
import java.util.PriorityQueue;
import java.util.TreeMap;



//Runtime: 4 ms, faster than 100.00% of Java online submissions for Maximum Number of Eaten Apples.
//Memory Usage: 40.8 MB, less than 100.00% of Java online submissions for Maximum Number of Eaten Apples.
class Solution_V4 {
    public int eatenApples(int[] apples, int[] days) {
        int n = apples.length;
        int[] applesExpiry = new int[n + 20001];
        int count = 0;
        int lastDay = n;
        int latestExpiryPointer = 0;

        for (int currentDay = 0; currentDay < lastDay; currentDay++) {
            // calculate the expiry of apples received on currentDay and update map
            if (currentDay < n) {
                int currentExpiry = days[currentDay] + currentDay;
                applesExpiry[currentExpiry] += apples[currentDay];
                if (currentExpiry < latestExpiryPointer) latestExpiryPointer = currentExpiry;
                // update last day if current expiry is greater
                if (currentExpiry > lastDay) lastDay = currentExpiry;
            }
            while ((latestExpiryPointer <= currentDay ||
                    applesExpiry[latestExpiryPointer] == 0) &&
                    latestExpiryPointer < lastDay) {
                latestExpiryPointer++;
            }
            // eat an apple on current day
            if (applesExpiry[latestExpiryPointer] != 0) {
                applesExpiry[latestExpiryPointer]--;
                count++;
            }
        }
        return count;
    }
}




//Runtime: 111 ms, faster than 16.67% of Java online submissions for Maximum Number of Eaten Apples.
//Memory Usage: 41.8 MB, less than 50.00% of Java online submissions for Maximum Number of Eaten Apples.
class Solution_V3 {
    public int eatenApples(int[] apples, int[] days) {
        TreeMap<Integer, Integer> map = new TreeMap<>();
        int count = 0;
        for (int currentDay = 0; currentDay < apples.length || !map.isEmpty(); currentDay++) {
            // calculate the expiry of apples received on currentDay and update map
            if (currentDay < apples.length) {
                int currentExpiry = currentDay + days[currentDay];
                map.put(currentExpiry, map.getOrDefault(currentExpiry, 0) + apples[currentDay]);
            }
            // remove from map until if the expiry days have passed current day
            while (!map.isEmpty() && map.firstEntry().getKey() <= currentDay) {
                map.remove(map.firstEntry().getKey());
            }
            // eat an apple on current day
            if (!map.isEmpty()) {
                Integer latestExpiryDay = map.firstEntry().getKey();
                count++;
                if (map.get(latestExpiryDay) > 1)
                    map.put(latestExpiryDay, map.get(latestExpiryDay) - 1);
                else
                    map.remove(latestExpiryDay);
            }
        }
        return count;
    }
}



// Runtime: 168 ms, faster than 16.67% of Java online submissions for Maximum Number of Eaten Apples.
//Memory Usage: 45.4 MB, less than 16.67% of Java online submissions for Maximum Number of Eaten Apples.
class Solution_V2 {
    public int eatenApples(int[] apples, int[] days) {
        TreeMap<Integer, Integer> map = new TreeMap<>();
        int count = 0;
        for (int currentDay = 0; currentDay < apples.length || map.higherKey(currentDay) != null; currentDay++) {
            // calculate the expiry of apples received on currentDay and update map
            if (currentDay < apples.length) {
                int currentExpiry = currentDay + days[currentDay];
                map.put(currentExpiry, map.getOrDefault(currentExpiry, 0) + apples[currentDay]);
            }
            // eat an apple on current day
            Integer latestExpiryDay = map.higherKey(currentDay);
            if (latestExpiryDay != null) {
                count++;
                if (map.get(latestExpiryDay) > 1)
                    map.put(latestExpiryDay, map.get(latestExpiryDay) - 1);
                else
                    map.remove(latestExpiryDay);
            }
        }
        return count;
    }
}






//Runtime: 67 ms, faster than 91.67% of Java online submissions for Maximum Number of Eaten Apples.
//Memory Usage: 44.8 MB, less than 16.67% of Java online submissions for Maximum Number of Eaten Apples.
class Solution_V1 {
    public int eatenApples(int[] apples, int[] days) {
        Map<Integer, Integer> applesExpiry = new HashMap<>();
        PriorityQueue<Integer> queue = new PriorityQueue<>();

        int count = 0;
        for (int currentDay = 0; currentDay < apples.length || !queue.isEmpty(); currentDay++) {
            // calculate the expiry of apples received on currentDay and update map and queue
            if (currentDay < apples.length) {
                int currentExpiry = currentDay + days[currentDay];
                if (!applesExpiry.containsKey(currentExpiry)) {
                    queue.offer(currentExpiry);
                }
                applesExpiry.put(currentExpiry, applesExpiry.getOrDefault(currentExpiry, 0) + apples[currentDay]);
            }
            // remove from queue until if the expiry days have passed current day
            while (!queue.isEmpty() && queue.peek() <= currentDay) {
                queue.poll();
            }
            if (!queue.isEmpty()) {
                // eat an apple on current day
                int latestExpiryDay = queue.peek();
                count++;
                applesExpiry.put(latestExpiryDay, applesExpiry.get(latestExpiryDay) - 1);
                if (applesExpiry.get(latestExpiryDay) == 0) {
                    queue.poll();
                    applesExpiry.remove(latestExpiryDay);
                }
            }
        }
        return count;
    }
}

