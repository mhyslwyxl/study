package Strategy;

public class Strategy {
    private Encrypt encrypt;

    public Strategy(Encrypt encrypt) {
        this.encrypt = encrypt;
    }

    public void encrypt(){
        this.encrypt.encrypt();
    }
}
