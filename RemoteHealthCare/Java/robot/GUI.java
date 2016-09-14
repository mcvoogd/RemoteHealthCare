package robot;

import javax.swing.*;
import java.awt.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.Iterator;

/**
 * Created by kevin on 29-8-2016.
 */
public class GUI extends JFrame {
    private JPanel contentpanel = new JPanel();
    private GraphPanel graph;
    private ArrayList<Point2D> dataPoints = new ArrayList<>();
    public static void main(String[] args) {
        new GUI();
    }

    public GUI() {
        setContentPane(contentpanel);
        setVisible(true);
        setSize(1000, 1000);
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
        contentpanel.setLayout(new BorderLayout());
        initGUI();

    }

    public void initGUI()
    {
        GraphPanel graph = new GraphPanel();
        contentpanel.add(graph, BorderLayout.CENTER);
    }
    public void fillArrayList(ArrayList<Point2D> p)
    {
        dataPoints.clear();
        dataPoints.addAll(p);
    }
    class GraphPanel extends JPanel
    {


        public GraphPanel()
        {
            Timer t = new Timer(100, e -> {repaint();});
            t.start();
        }

        public void paintComponent(Graphics g)
        {
            Graphics2D g2 = (Graphics2D) g;
          //  g2.fillRect(getWidth()/2-50,getHeight()/2-50,100,100);
            g2.setFont(new Font("TimesRoman", Font.PLAIN, 32));
            g2.drawString("RPM : " , 500, 50);
            Iterator p = dataPoints.iterator();
            while(p.hasNext())
            {
                Point2D point = (Point2D) p.next();
                g2.fillOval((int) point.getX() + 20, (-(int) point.getY())+ 500, 5, 5);
            }

            for(int i = 0; i < dataPoints.size()-1; i++)
            {
                g2.drawLine((int)dataPoints.get(i).getX() + 20, (-(int) dataPoints.get(i).getY()) + 500,
                        ((int)dataPoints.get(i+1).getX() + 20), (-(int) dataPoints.get(i+1).getY()) + 500);
            }
        }


    }
}
