package ObserverPattern;

import java.util.Observable;

//正常--挨打--瀕死--挨打--小宇宙爆发--挨打--瀕死--挨打--女神护体--挨打(星矢无敌了，打也没用，战斗结束)--正常
public class Saiya extends Observable {
	// 定义星矢的四种状态
	public final SaiyaState NORMAL = new NormalState(this);

	public final SaiyaState DYING = new DyingState(this);

	public final SaiyaState GODDESS = new GoddessState(this);

	public final SaiyaState UNIVERSE = new UniverseState(this);

	private SaiyaState state = NORMAL;

	private SaiyaState laststate = null;

	public void hit() {
		// 调用当前状态的被打方法 反过来改变自己的状态
		state.hit();
	}

	public String status() {
		// 当前状态名
		return state.status();
	}

	protected void setState(SaiyaState state) {
		laststate = this.state;
		this.state = state;
		// 观察者模式
		setChanged();
		notifyObservers("星矢状态变化");
	}

	public String getlastStatus() {
		return laststate.status();
	}
}