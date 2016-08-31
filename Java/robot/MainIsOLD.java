package robot;

import jssc.SerialPort;
import jssc.SerialPortException;
import jssc.SerialPortList;
import jssc.SerialPortTimeoutException;

/**
 * Created by kevin on 29-8-2016.
 */
public class MainIsOLD {

    private static String comport;
    private static String resetMessage = "ST\r\n";
    private static boolean recieving = true;
    private static String test = null;
    private static String toPrint = null;

    public static void main(String[] args) {
        String toSplit = "pulse rpm speed*10 distance requested_power energy mm:ss actual_power";
        String[] dataString = toSplit.split("\\s+");
        String[] portNames = SerialPortList.getPortNames();
        for(int i = 0; i < portNames.length; i++){
            System.out.println(portNames[i]);
            comport = portNames[i];
        }
        SerialPort serialPort = new SerialPort(comport);

        try {
            serialPort.openPort();//Open serial port
            System.out.println("Connected!");
            serialPort.setParams(SerialPort.BAUDRATE_9600,
                    SerialPort.DATABITS_8,
                    SerialPort.STOPBITS_1,
                    SerialPort.PARITY_NONE);//Set params. Also you can set params by this string: serialPort.setParams(9600, 8, 1, 0);

          //  byte[] message = resetMessage.getBytes();
            serialPort.writeString(resetMessage);
            System.out.println("listening!");
            for(int j = 0; j < 500;) { //infinite! :P
                while(recieving) {
                    serialPort.writeString(resetMessage);
                    test += serialPort.readString();
                    String[] splittest = test.split("\r");
                    if(splittest != null) {
                        toPrint = splittest[0];
                    }
                    recieving = false;
                }

                if(toPrint != null) {
                    String[] newString = toPrint.split("\\s+");
                    //System.out.println(newString.length);
                    if(newString.length > 1)
                    {
                        newString[2] = ""+Integer.parseInt(newString[2])/10 + " KM/H";
                        System.out.println("------------------------------------");
                        String format = "%-30s%s%n";
                        for (int i = 0; i < newString.length; i++) {
                            if (i < dataString.length) {
                             System.out.printf(format, dataString[i], newString[i]);
                            }
                        }
                        System.out.println("------------------------------------");
                    }
                }

                Thread.sleep(1000);
                recieving = true;
                test = "";
                toPrint = null;
            }
            //System.out.println(test);
            serialPort.closePort();//Close serial port
            System.out.println("closed!");

        }
        catch (SerialPortException ex) {
            System.out.println(ex);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}
