package ObserverPattern;

public class DyingState extends SaiyaState {
	/**
	 * @param saiya
	 */
	public DyingState(Saiya saiya) {
		super(saiya);
	}

	/*
	 * Ğ¡ÓîÖæ±¬·¢×´Ì¬±»´ò½øÈëlËÀ×´Ì¬
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
		return "ÆµËÀ×´Ì¬";
	}
}
