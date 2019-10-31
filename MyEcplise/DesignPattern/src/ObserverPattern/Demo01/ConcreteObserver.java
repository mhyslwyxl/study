package ObserverPattern.Demo01;

/**
 * ����۲���
 * 
 * @author liu yuning
 *
 */
public class ConcreteObserver extends Observer {

	private String name;
	private String observerState;
	private ConcreteSubject concreteSubject;

	public ConcreteObserver(ConcreteSubject concreteSubject, String name) {
		this.setName(name);
		this.setConcreteSubject(concreteSubject);
	}

	@Override
	public void update() {
		this.setObserverState(concreteSubject.getSubjectState());
		System.out.println("�۲���" + this.getName() + "����״̬��" + this.getObserverState());
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getObserverState() {
		return observerState;
	}

	public void setObserverState(String observerState) {
		this.observerState = observerState;
	}

	public ConcreteSubject getConcreteSubject() {
		return concreteSubject;
	}

	public void setConcreteSubject(ConcreteSubject concreteSubject) {
		this.concreteSubject = concreteSubject;
	}

}
