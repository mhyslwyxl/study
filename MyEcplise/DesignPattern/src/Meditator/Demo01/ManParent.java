package Meditator.Demo01;

/** * Title: 男方家长类 * Description: * @version 1.0 */
public class ManParent {
	private Matchmaker mat; // 媒人类

	public ManParent(Matchmaker mat) {
		this.mat = mat;
		mat.registeManParent(this);		// 把自己在媒人那里注册(声明)
	}

	/** *考虑是否同意 * @return */
	public boolean thinking(String says) {
		System.out.println("男方父母考虑:我们做父母的该不该同意呢???");
		if (says.length() > 5) {
			System.out.println("我们做父母的同意了");
			return true;
		} else {
			System.out.println("我们做父母的不同意.");
			return false;
		}
	}
}