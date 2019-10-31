package ObserverPattern;
//����--����--�l��--����--С���汬��--����--�l��--����--Ů����--����(��ʸ�޵��ˣ���Ҳû�ã�ս������)--����
public abstract class SaiyaState {
	protected Saiya saiya;

	public SaiyaState(Saiya saiya) {
		this.saiya = saiya;
	}

	public String status() {
		String name = getClass().getName();
		//System.out.println(name);
		return name.substring(name.lastIndexOf(".") + 1);
	}

	// ��ʸ������
	public abstract void hit();
}