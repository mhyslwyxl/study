package ObserverPattern;

import java.util.Observer;

public class StateMain {
	public static void main(String[] args) {
		Saiya saiya = new Saiya();
		Observer athena = new Athena();
		saiya.addObserver(athena);
		System.out.println("星矢最初的状态是：" + saiya.status());
		for (int i = 0; i < 5; i++) {
			System.out.println("星矢被揍了" + (i + 1) + "次");
			saiya.hit();
			System.out.println("星矢现在的状态是：" + saiya.status());
		}
	}
}
