package Builder;

public class LouFangBuilder implements HouseBuilder {
	private House house = new House();

	public void makeFloor() {
		house.setFloor("Â¥·¿--µØ°å");
	}

	public void makeHouseTop() {
		house.setHousetop("Â¥·¿---ÎÝ¶¥");
	}

	public void makeWall() {
		house.setWall("Â¥·¿---Ç½");
	}

	public House getHouse() {	
		return this.house;
	}
}