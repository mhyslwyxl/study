package Builder;

public class MainClass {
	public static void main(String[] args) {
		// House house = new House();
		// house.setFloor("µØ°å");
		// house.setWall("Ç½");
		// house.setHousetop("ÎÝ¶¥");

		// HouseBuilder builder = new PingFangBuilder();
		// builder.makeFloor();
		// builder.makeHouseTop();
		// builder.makeWall();
		// House pf = builder.getHouse();
		
		HouseBuilder pfBuilder = new PingFangBuilder();
		Director director = new Director(pfBuilder);
		House house = pfBuilder.getHouse();
		System.out.println(house.getFloor());
		System.out.println(house.getWall());
		System.out.println(house.getHousetop());
		
		HouseBuilder lfBuilder = new LouFangBuilder();
		Director director2 = new Director(lfBuilder);

		House house2 = lfBuilder.getHouse();
		System.out.println(house2.getFloor());
		System.out.println(house2.getWall());
		System.out.println(house2.getHousetop());
	}
}
