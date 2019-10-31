package ObserverPattern;

public class DyingState extends SaiyaState {
	/**
	 * @param saiya
	 */
	public DyingState(Saiya saiya) {
		super(saiya);
	}

	/*
	 * С���汬��״̬�������l��״̬
	 *
	 */
	private int hitNumber = 1;

	public void hit() {
		if (hitNumber == 1) {
			hitNumber++;
			saiya.setState(saiya.UNIVERSE);
		} else {
			saiya.setState(saiya.GODDESS);
		}
	}
	
	public String status() {
		return "Ƶ��״̬";
	}
}
