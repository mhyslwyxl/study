package Meditator.Demo01;

/** * Title: �з��ҳ��� * Description: * @version 1.0 */
public class ManParent {
	private Matchmaker mat; // ý����

	public ManParent(Matchmaker mat) {
		this.mat = mat;
		mat.registeManParent(this);		// ���Լ���ý������ע��(����)
	}

	/** *�����Ƿ�ͬ�� * @return */
	public boolean thinking(String says) {
		System.out.println("�з���ĸ����:��������ĸ�ĸò���ͬ����???");
		if (says.length() > 5) {
			System.out.println("��������ĸ��ͬ����");
			return true;
		} else {
			System.out.println("��������ĸ�Ĳ�ͬ��.");
			return false;
		}
	}
}