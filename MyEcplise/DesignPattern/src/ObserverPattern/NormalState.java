package ObserverPattern;

public class NormalState extends SaiyaState {
	/**
	 * @param saiya
	 */
	public NormalState(Saiya saiya) {
		super(saiya);
	}

	/*
	 * 小宇宙爆发状态被打进入瀕死状态
	 *
	 */
	public void hit() {
		saiya.setState(saiya.DYING);
	}
	
	public String status() {
		return "正常状态";
	}
}
