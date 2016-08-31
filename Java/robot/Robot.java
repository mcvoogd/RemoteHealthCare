package robot;

import jssc.SerialPort;
import jssc.SerialPortException;
import jssc.SerialPortList;
import jssc.SerialPortTimeoutException;

import java.awt.geom.Point2D;
import java.util.ArrayList;

/**
 * Created by kevin on 29-8-2016.
 */
public class Robot {

    private String comport = "COM3";
    private SerialPort serialPort;
    private String resetMessage = "ST\r\n";
    private boolean recieving = true;
    private String test = null;
    private String toPrint = null;
    private String[] dataString;
    private boolean running = true;
    private ArrayList<Point2D> savedData = new ArrayList<>();
    private int teller = 0;

    public static void main(String[] args) {
       new Robot();
    }

    public Robot()
    {
        InitMain();
        GUI gui = new GUI();
        while(true) {
            if (running) {
                teller+=10;
                while (recieving) {
                    sendString(resetMessage);
                    test += readString();
                    String[] splittest = test.split("\r");
                    if (splittest != null) {
                        toPrint = splittest[0];
                    }
                    recieving = false;
                }
                if (toPrint != null) {
                    String[] newString = toPrint.split("\\s+");
                    if (newString.length > 2) {
                        newString[2] = "" + Integer.parseInt(newString[2]) / 10 + " KM/H";
                        String format = "%-30s%s%n";
                        for (int i = 0; i < newString.length; i++) {
                            if (i < dataString.length) {
                                System.out.printf(format, dataString[i], newString[i]);
                            }
                        }
                        int y = Integer.parseInt(newString[1]);
                        savedData.add(new Point2D.Double(teller, y));
                        System.out.println("------------------------------------");
                    }
                    gui.fillArrayList(savedData);
                }
                reset();
                sleep();
            }
        }
    }

    public void startMonitoring()
    {
        if(!running){running = true;}
    }

    public void stopMonitoring()
    {
        if(running){running = false;}
    }

    private void InitMain() {
        String toSplit = "pulse rpm speed*10 distance requested_power energy mm:ss actual_power";
        dataString = toSplit.split("\\s+");
        serialPort = new SerialPort(comport);
        try {
            serialPort.openPort();//Open serial port
            serialPort.setParams(SerialPort.BAUDRATE_9600,
                    SerialPort.DATABITS_8,
                    SerialPort.STOPBITS_1,
                    SerialPort.PARITY_NONE);
        } catch (SerialPortException e) {
            e.printStackTrace();
        }
    }

    public void closeConnection()
    {
        try {
            serialPort.closePort();
        } catch (SerialPortException e) {
            e.printStackTrace();
        }
    }

    private void sendString(String msg)
    {
        try {
            serialPort.writeString(msg + "\r\n");
        } catch (SerialPortException e) {
            e.printStackTrace();
        }
    }

    private String readString()
    {
        String returnString = null;
        try {
            returnString  = serialPort.readString();
        } catch (SerialPortException e) {
            e.printStackTrace();
        }

        return returnString;
    }

    private void sleep()
    {
        try {
            Thread.sleep(1000);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    private void reset()
    {
        recieving = true;
        test = "";
        toPrint = null;
    }

    private void resetBike()
    {
        sendString("RS");
    }
}
