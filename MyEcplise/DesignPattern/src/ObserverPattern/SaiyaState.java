package ObserverPattern;
//正常--挨打--瀕死--挨打--小宇宙爆发--挨打--瀕死--挨打--女神护体--挨打(星矢无敌了，打也没用，战斗结束)--正常
public abstract class SaiyaState {
	protected Saiya saiya;

	public SaiyaState(Saiya saiya) {
		this.saiya = saiya;
	}

	public String status() {
		String name = getClass().getName();
		//System.out.println(name);
		return name.substring(name.lastIndexOf(".") + 1);
	}

	// 星矢被打了
	public abstract void hit();
}