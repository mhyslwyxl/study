package ObserverPattern;

import java.util.Observer;

public class StateMain {
	public static void main(String[] args) {
		Saiya saiya = new Saiya();
		Observer athena = new Athena();
		saiya.addObserver(athena);
		System.out.println("��ʸ�����״̬�ǣ�" + saiya.status());
		for (int i = 0; i < 5; i++) {
			System.out.println("��ʸ������" + (i + 1) + "��");
			saiya.hit();
			System.out.println("��ʸ���ڵ�״̬�ǣ�" + saiya.status());
		}
	}
}
