package ObserverPattern.Demo01;

/**
 * �۲���ģʽ�ͻ��˴���
 * 
 * @author liu yuning
 *
 */
public class ObserverClient {
	public static void main(String[] args) {
		ConcreteSubject concreteSubject = new ConcreteSubject();

		concreteSubject.attach(new ConcreteObserver(concreteSubject, "X"));
		concreteSubject.attach(new ConcreteObserver(concreteSubject, "Y"));
		concreteSubject.attach(new ConcreteObserver(concreteSubject, "Z"));

		concreteSubject.setSubjectState("ABC");
		concreteSubject.notifyObserver();
		concreteSubject.setSubjectState("123");
		concreteSubject.notifyObserver();
		concreteSubject.setSubjectState("456");
		concreteSubject.notifyObserver();
	}
}