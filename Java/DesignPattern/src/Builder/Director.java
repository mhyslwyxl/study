package Builder;

public class Director {
	public Director(HouseBuilder builder) {
		builder.makeFloor();
		builder.makeHouseTop();
		builder.makeWall();
	}

}
