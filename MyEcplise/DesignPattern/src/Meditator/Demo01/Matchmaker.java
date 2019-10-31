package Meditator.Demo01;

/**
 * * Title:ý����-----�н��� * Description: * @version 1.0
 */
public class Matchmaker {
	private Man man; // ����
	private Woman woman; // Ů��
	private ManParent manp; // �з���ĸ
	private WomanParent womanp; // Ů����ĸ

	public static void main(String[] args) {
		Matchmaker matchmaker1 = new Matchmaker();
		Man man = new Man(matchmaker1);
		Woman woman = new Woman(matchmaker1);
		ManParent manp = new ManParent(matchmaker1);
		WomanParent womanp = new WomanParent(matchmaker1);

		man.tryst("Hello girl");
	}

	/**
	 * * ý�˴������������Լ��, * �������Լ��,��ֻ��Ҫ�Ѹ��������ý��, * ��ý�˸���ȥ����Ů��,Ů����ĸ,�з��ҳ�����
	 * * @param says
	 */
	public void doManTryst(String says) {
		System.out.println("ý�˿�ʼ����Լ�����⿪ʼ");
		womanp.thinking(says);
		System.out.println("ý�˴���Լ���������,����ͬ��Ľ������������");
	}

	/**
	 * * ý�˴���Ů�������Լ��, * ��ý�˸���ȥ���з�,Ů����ĸ,�з��ҳ����� 
	 * * @param says
	 */
	public void doWomanTryst(String says) {
		System.out.println("ý�˿�ʼ����Լ�����⿪ʼ");
		man.thinking(says);
		manp.thinking(says);
		womanp.thinking(says);
		System.out.println("ý�˴���Լ���������,����ͬ��Ľ������������");
	}

	/** * ����������������..... * @param man */
	public void doOther(String says) {
		System.out.println("������������");
		man.thinking(says);
		woman.thinking(says);
		manp.thinking(says);
		womanp.thinking(says);
	}

	// �����ĸ�ע�᷽��,�������Ϊ,�з���Ů��֮���ͨѶ����ͨ��ý��
	/** * ע������ * @param man */
	public void registeMan(Man man) {
		this.man = man;
	}

	/** * ע��Ů�� * @param woman */
	public void registeWoman(Woman woman) {
		this.woman = woman;
	}

	/** * ע���з��ҳ� * @param manp */
	public void registeManParent(ManParent manp) {
		this.manp = manp;
	}

	/** *ע��Ů���ҳ� * @param womanp */
	public void registerWomanParent(WomanParent womanp) {
		this.womanp = womanp;
	}
}
