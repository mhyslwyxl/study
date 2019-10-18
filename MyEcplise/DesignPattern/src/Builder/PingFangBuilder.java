package Builder;

public class PingFangBuilder implements HouseBuilder {
	private House house = new House();

	public void makeFloor() {
		house.setFloor("平房--地板");
	}

	public void makeHouseTop() {
		house.setHousetop("平房---屋顶");
	}

	public void makeWall() {
		house.setWall("平房---墙");
	}

	public House getHouse() {	
		return this.house;
	}
}