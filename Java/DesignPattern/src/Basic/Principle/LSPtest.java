package Basic.Principle;

public class LSPtest {
	public static void main(String[] args) {
		Bird bird1 = new Swallow();
		Bird bird2 = new BrownKiwi();
		bird1.setSpeed(120);
		bird2.setSpeed(120);
		System.out.println("�������300���");
		try {
			System.out.println("���ӽ�����" + bird1.getFlyTime(300) + "Сʱ.");
			System.out.println("��ά�񽫷���" + bird2.getFlyTime(300) + "Сʱ��");
		} catch (Exception err) {
			System.out.println("����������!");
		}
	}
}

// ����
class Bird {
	double flySpeed;

	public void setSpeed(double speed) {
		flySpeed = speed;
	}

	public double getFlyTime(double distance) {
		return (distance / flySpeed);
	}
}

// ������
class Swallow extends Bird {
}

// ��ά����
class BrownKiwi extends Bird {
	public void setSpeed(double speed) {
		flySpeed = 0;
	}
}
