package Meditator.Demo01;

/** * Title:Ů���� * Description: */
public class Woman {
	private Matchmaker mat; // ý��

	public Woman(Matchmaker mat) {
		this.mat = mat;
		mat.registeWoman(this); // ���Լ���ý������ע��(����)
	}

	/** *�����Ƿ�ͬ�� * @return */
	public boolean thinking(String says) {
		System.out.println("Ů�˿���:�Ҹò���ͬ����???");
		if (says.length() > 5) {
			System.out.println("��ͬ����");
			return true;
		} else {
			System.out.println("�Ҳ�ͬ��.");
			return false;
		}
	}

	/** * ���Լ�� * Ů�����Լ��,ֻ��Ҫ����ý��,��ý�˸���������˽���. * @param says */
	public void tryst(String says) {
		System.out.println("Ů�����Լ������,˵:" + says);
		mat.doWomanTryst(says);
	}
}
