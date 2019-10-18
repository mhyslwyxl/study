package Builder;

public class LouFangBuilder implements HouseBuilder {
	private House house = new House();

	public void makeFloor() {
		house.setFloor("¥��--�ذ�");
	}

	public void makeHouseTop() {
		house.setHousetop("¥��---�ݶ�");
	}

	public void makeWall() {
		house.setWall("¥��---ǽ");
	}

	public House getHouse() {	
		return this.house;
	}
}