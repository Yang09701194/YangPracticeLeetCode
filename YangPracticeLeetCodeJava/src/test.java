import java.io.IOException;

public class test {


    public static void main (String[] args) throws IOException {

        Solution_V4 v = new Solution_V4();

        System.out.println(v.eatenApples(new int[]{1,2,3,5,2}, new int[]{3,2,1,4,2}));
        System.out.println(v.eatenApples(new int[]{3,0,0,0,0,2}, new int[]{3,0,0,0,0,2}));
        System.in.read();

    }

}
