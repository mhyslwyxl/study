package ObserverPattern;

public class GoddessState extends SaiyaState {
	/**
	 * @param saiya
	 */
	public GoddessState(Saiya saiya) {
		super(saiya);
	}

	/*
	 * 小宇宙爆发状态被打进入瀕死状态
	 *
	 */
	public void hit() {
		saiya.setState(saiya.NORMAL);
	}
	
	public String status() {
		return "女神保佑状态";
	}
}
