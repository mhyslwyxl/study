package Basic.Principle;

public class DIPtest {
	public static void main(String[] args) {
		Customer wang = new Customer();
		System.out.println("顾客购买以下商品：");
		wang.shopping(new LuBaiShop());
		wang.shopping(new WuyuanShop());
	}
}

// 商店
interface Shop {
	public String sell(); // 卖
}

// 鲁百
class LuBaiShop implements Shop {
	public String sell() {
		return "鲁百土特产：香菇、木耳……";
	}
}

// 婺源网店
class WuyuanShop implements Shop {
	public String sell() {
		return "婺源土特产：绿茶、酒糟鱼……";
	}
}

// 顾客
class Customer {
	public void shopping(Shop shop) {
		// 购物
		System.out.println(shop.sell());
	}
}