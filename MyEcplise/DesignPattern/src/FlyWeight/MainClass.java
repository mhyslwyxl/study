package FlyWeight;

public class MainClass {

	public static void main(String[] args) {
		MyCharacter mc1 = new MyCharacter('a');
		// MyCharacter mc2 = new MyCharacter('b');
		MyCharacter mc3 = new MyCharacter('c');
		MyCharacter mc4 = new MyCharacter('d');
		MyCharacter mc5 = new MyCharacter('a');
		// MyCharacter mc6 = new MyCharacter('b');
		MyCharacter mc7 = new MyCharacter('c');
		MyCharacterFactory mcf = new MyCharacterFactory();
		// MyCharacter mc1 = mcf.getMyCharacter('a');
		MyCharacter mc2 = mcf.getMyCharacter('b');
		// MyCharacter mc3 = mcf.getMyCharacter('c');
		// MyCharacter mc4 = mcf.getMyCharacter('d');
		// MyCharacter mc5 = mcf.getMyCharacter('a');
		MyCharacter mc6 = mcf.getMyCharacter('b');
		// MyCharacter mc7 = mcf.getMyCharacter('c');

		mc1.diaplay();
		mc2.diaplay();
		mc3.diaplay();
		mc4.diaplay();
		mc5.diaplay();
		mc6.diaplay();
		mc7.diaplay();
		System.out.println(mc1 == mc5);
		System.out.println(mc2 == mc6);
	}

}
