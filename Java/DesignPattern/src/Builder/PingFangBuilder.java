package Builder;

public class PingFangBuilder implements HouseBuilder {
	private House house = new House();

	public void makeFloor() {
		house.setFloor("ƽ��--�ذ�");
	}

	public void makeHouseTop() {
		house.setHousetop("ƽ��---�ݶ�");
	}

	public void makeWall() {
		house.setWall("ƽ��---ǽ");
	}

	public House getHouse() {	
		return this.house;
	}
}