package Meditator.Demo01;

/** * Title:女人类 * Description: */
public class Woman {
	private Matchmaker mat; // 媒人

	public Woman(Matchmaker mat) {
		this.mat = mat;
		mat.registeWoman(this); // 把自己在媒人那里注册(声明)
	}

	/** *考虑是否同意 * @return */
	public boolean thinking(String says) {
		System.out.println("女人考虑:我该不该同意呢???");
		if (says.length() > 5) {
			System.out.println("我同意了");
			return true;
		} else {
			System.out.println("我不同意.");
			return false;
		}
	}

	/** * 提出约会 * 女人提出约会,只需要告诉媒人,由媒人负责跟其他人交互. * @param says */
	public void tryst(String says) {
		System.out.println("女人提出约会请求,说:" + says);
		mat.doWomanTryst(says);
	}
}
