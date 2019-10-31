package ObserverPattern;

public class UniverseState extends SaiyaState {
	/**
	 * @param saiya
	 */
	public UniverseState(Saiya saiya) {
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
		return "С���汬��״̬";
	}
}
