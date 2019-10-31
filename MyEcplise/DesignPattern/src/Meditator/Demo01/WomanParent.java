package Meditator.Demo01;

/** * Title: 女方家长类 * Description: */
public class WomanParent {
	private Matchmaker mat; // 媒人类

	public WomanParent(Matchmaker mat) {
		this.mat = mat;
		mat.registerWomanParent(this); // 把自己在媒人那里注册(声明)
	}

	/** *考虑是否同意 * @return */
	public boolean thinking(String says) {
		System.out.println("女方父母考虑:我们做父母的该不该同意呢???");
		if (says.length() > 5) {
			System.out.println("我们做父母的同意了");
			return true;
		} else {
			System.out.println("我们做父母的不同意.");
			return false;
		}
	}
}