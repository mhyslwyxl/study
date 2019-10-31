package Basic.Principle;

public class ISPtest {
	public static void main(String[] args) {
		InputModule input = StuScoreList.getInputModule();
		CountModule count = StuScoreList.getCountModule();
		PrintModule print = StuScoreList.getPrintModule();
		input.insert();
		count.countTotalScore();
		print.printStuInfo();
		// print.delete();
		System.out.println(input);
		System.out.println(count);
		System.out.println(print);
	}
}

// ����ģ��ӿ�
interface InputModule {
	void insert();

	void delete();

	void modify();
}

// ͳ��ģ��ӿ�
interface CountModule {
	void countTotalScore();

	void countAverage();
}

// ��ӡģ��ӿ�
interface PrintModule {
	void printStuInfo();

	void queryStuInfo();
}

// ʵ����
class StuScoreList implements InputModule, CountModule, PrintModule {
	private StuScoreList() {
	}

	public static InputModule getInputModule() {
		return (InputModule) new StuScoreList();
	}

	public static CountModule getCountModule() {
		return (CountModule) new StuScoreList();
	}

	public static PrintModule getPrintModule() {
		return (PrintModule) new StuScoreList();
	}

	public void insert() {
		System.out.println("����ģ���insert()���������ã�");
	}

	public void delete() {
		System.out.println("����ģ���delete()���������ã�");
	}

	public void modify() {
		System.out.println("����ģ���modify()���������ã�");
	}

	public void countTotalScore() {
		System.out.println("ͳ��ģ���countTotalScore()���������ã�");
	}

	public void countAverage() {
		System.out.println("ͳ��ģ���countAverage()���������ã�");
	}

	public void printStuInfo() {
		System.out.println("��ӡģ���printStuInfo()���������ã�");
	}

	public void queryStuInfo() {
		System.out.println("��ӡģ���queryStuInfo()���������ã�");
	}
}