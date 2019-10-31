package ObserverPattern;

public class NormalState extends SaiyaState {
	/**
	 * @param saiya
	 */
	public NormalState(Saiya saiya) {
		super(saiya);
	}

	/*
	 * С���汬��״̬�������l��״̬
	 *
	 */
	public void hit() {
		saiya.setState(saiya.DYING);
	}
	
	public String status() {
		return "����״̬";
	}
}
