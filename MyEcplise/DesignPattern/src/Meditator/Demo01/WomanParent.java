package Meditator.Demo01;

/** * Title: Ů���ҳ��� * Description: */
public class WomanParent {
	private Matchmaker mat; // ý����

	public WomanParent(Matchmaker mat) {
		this.mat = mat;
		mat.registerWomanParent(this); // ���Լ���ý������ע��(����)
	}

	/** *�����Ƿ�ͬ�� * @return */
	public boolean thinking(String says) {
		System.out.println("Ů����ĸ����:��������ĸ�ĸò���ͬ����???");
		if (says.length() > 5) {
			System.out.println("��������ĸ��ͬ����");
			return true;
		} else {
			System.out.println("��������ĸ�Ĳ�ͬ��.");
			return false;
		}
	}
}