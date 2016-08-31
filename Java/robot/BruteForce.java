package robot;

import jssc.SerialPort;
import jssc.SerialPortException;

import java.util.ArrayList;

/**
 * Created by kevin on 31-8-2016.
 */
public class BruteForce {

    private String comport = "COM3";
    private SerialPort serialPort;
    private String toSend;
    private ArrayList<String> lowcase = new ArrayList<>();
    private ArrayList<String> upcase = new ArrayList<>();

    public static void main(String[] args) {
        new BruteForce();
    }

    public BruteForce()
    {
        fillArray();
        openConnection(this.comport);
        bruteForce();
    }

    private void bruteForce()
    {
        sendString("CM");
        sendString("CM");

        for(String s : lowcase)
            for (String s2 : lowcase) {
                toSend = s + s2 + "\r\n";
                sendString(toSend);
                pause();
                readSerialConnection();
            }
    }

    private synchronized void pause() {
        try {
            this.wait(100);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    public void readSerialConnection()
    {
        String msg;
        try {
            msg = serialPort.readString();
            if(msg != null) {
                if (!(msg.contains("ERROR")) && !(msg.contains("ERR2003"))) {
                    String temp = msg.replace("\r\n", "");
                    System.out.println(temp + " -> combi : " + toSend);
                }
            }
        } catch (SerialPortException e) {
            e.printStackTrace();
        }

    }

    public void openConnection(String comport) {
        serialPort = new SerialPort(comport);
        try {
            serialPort.openPort();
            serialPort.setParams(SerialPort.BAUDRATE_9600,
                    SerialPort.DATABITS_8,
                    SerialPort.STOPBITS_1,
                    SerialPort.PARITY_NONE);
        } catch (SerialPortException e) {
            e.printStackTrace();
        }
    }

    public void sendString(String s)
    {
        try {
            serialPort.writeString(s);

        } catch (SerialPortException e) {
            e.printStackTrace();
        }
    }

    public void fillArray()
    {
        String alfabetlow = "abcdefghijklmnopqrstuvwxyz";
        String alfabetup = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        for (int i = 0; i < alfabetlow.length(); i++) {
            String deel = alfabetlow.substring(i, i + 1);
            lowcase.add(deel);
        }
        for (int i = 0; i < alfabetup.length(); i++) {
            String deel = alfabetup.substring(i, i + 1);
            upcase.add(deel);
        }
    }
}
