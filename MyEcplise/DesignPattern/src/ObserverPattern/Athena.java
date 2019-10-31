package ObserverPattern;

import java.util.Observable;
import java.util.Observer;

public class Athena implements Observer {
	/*
	 * 我是雅典娜 我是观察者
	 *
	 */
	public void update(Observable arg0, Object arg1) {
		System.out.println("雅典娜说：星矢加油啊!!!");
	}
}
