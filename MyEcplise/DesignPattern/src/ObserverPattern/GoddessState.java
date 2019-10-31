package ObserverPattern;

public class GoddessState extends SaiyaState {
	/**
	 * @param saiya
	 */
	public GoddessState(Saiya saiya) {
		super(saiya);
	}

	/*
	 * С���汬��״̬�������l��״̬
	 *
	 */
	public void hit() {
		saiya.setState(saiya.NORMAL);
	}
	
	public String status() {
		return "Ů����״̬";
	}
}
