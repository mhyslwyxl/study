package ObserverPattern;

import java.util.Observable;
import java.util.Observer;

public class Athena implements Observer {
	/*
	 * �����ŵ��� ���ǹ۲���
	 *
	 */
	public void update(Observable arg0, Object arg1) {
		System.out.println("�ŵ���˵����ʸ���Ͱ�!!!");
	}
}
