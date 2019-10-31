package Basic.Principle;

public class DIPtest {
	public static void main(String[] args) {
		Customer wang = new Customer();
		System.out.println("�˿͹���������Ʒ��");
		wang.shopping(new LuBaiShop());
		wang.shopping(new WuyuanShop());
	}
}

// �̵�
interface Shop {
	public String sell(); // ��
}

// ³��
class LuBaiShop implements Shop {
	public String sell() {
		return "³�����ز����㹽��ľ������";
	}
}

// ��Դ����
class WuyuanShop implements Shop {
	public String sell() {
		return "��Դ���ز����̲衢�����㡭��";
	}
}

// �˿�
class Customer {
	public void shopping(Shop shop) {
		// ����
		System.out.println(shop.sell());
	}
}