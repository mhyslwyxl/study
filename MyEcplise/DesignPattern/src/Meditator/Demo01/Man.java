package Meditator.Demo01;


public class Man {
	private Matchmaker mat; // ý��

	public Man(Matchmaker mat) {
		this.mat = mat;
		mat.registeMan(this);// ���Լ���ý������ע��(����)
	}

	/** *�����Ƿ�ͬ�� * @return */
	public boolean thinking(String says) {
		System.out.println("���˿���:�Ҹò���ͬ����???");
		if (says.length() > 5) {
			System.out.println("��ͬ����");
			return true;
		} else {
			System.out.println("�Ҳ�ͬ��.");
			return false;
		}
	}

	/** * ���Լ�� * �������Լ��,ֻ��Ҫ����ý��,��ý�˸���������˽���. * @param says */
	public void tryst(String says) {
		System.out.println("�������Լ������,˵:" + says);
		mat.doManTryst(says);
	}
}
