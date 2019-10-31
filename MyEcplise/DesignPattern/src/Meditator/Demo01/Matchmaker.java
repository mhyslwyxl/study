package Meditator.Demo01;

/**
 * * Title:媒人类-----中介者 * Description: * @version 1.0
 */
public class Matchmaker {
	private Man man; // 男人
	private Woman woman; // 女人
	private ManParent manp; // 男方父母
	private WomanParent womanp; // 女方父母

	public static void main(String[] args) {
		Matchmaker matchmaker1 = new Matchmaker();
		Man man = new Man(matchmaker1);
		Woman woman = new Woman(matchmaker1);
		ManParent manp = new ManParent(matchmaker1);
		WomanParent womanp = new WomanParent(matchmaker1);

		man.tryst("Hello girl");
	}

	/**
	 * * 媒人处理男人提出的约会, * 男人提出约会,则只需要把该问题告诉媒人, * 由媒人负责去跟其女方,女方父母,男方家长交互
	 * * @param says
	 */
	public void doManTryst(String says) {
		System.out.println("媒人开始处理约会问题开始");
		womanp.thinking(says);
		System.out.println("媒人处理约会问题结束,根据同意的结果做其他处理");
	}

	/**
	 * * 媒人处理女人提出的约会, * 由媒人负责去跟男方,女方父母,男方家长交互 
	 * * @param says
	 */
	public void doWomanTryst(String says) {
		System.out.println("媒人开始处理约会问题开始");
		man.thinking(says);
		manp.thinking(says);
		womanp.thinking(says);
		System.out.println("媒人处理约会问题结束,根据同意的结果做其他处理");
	}

	/** * 处理彩礼等其他问题..... * @param man */
	public void doOther(String says) {
		System.out.println("处理其他问题");
		man.thinking(says);
		woman.thinking(says);
		manp.thinking(says);
		womanp.thinking(says);
	}

	// 以下四个注册方法,可以理解为,男方和女方之间的通讯必须通过媒人
	/** * 注册男人 * @param man */
	public void registeMan(Man man) {
		this.man = man;
	}

	/** * 注册女人 * @param woman */
	public void registeWoman(Woman woman) {
		this.woman = woman;
	}

	/** * 注册男方家长 * @param manp */
	public void registeManParent(ManParent manp) {
		this.manp = manp;
	}

	/** *注册女方家长 * @param womanp */
	public void registerWomanParent(WomanParent womanp) {
		this.womanp = womanp;
	}
}
