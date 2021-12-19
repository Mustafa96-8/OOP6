using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP6
{
    public partial class Form1 : Form
    {
        Mylist lists;
        bool isCTRL;
        Bitmap bitmap;
        Graphics gr ;
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gr = Graphics.FromImage(bitmap);
            
            lists = new Mylist();
            isCTRL = false;
            pictureBox1.Image = GetBitmap();
        }

        public void createCCircle(int x, int y)
        {
            clearSheet();
            CCircle circle = new CCircle(x,y,lists, pictureBox1.Width, pictureBox1.Height);
            PaintDraw();
            pictureBox1.Image = GetBitmap();
        }
        public void createRectangle(int x,int y)
        {
            clearSheet();
            Rectangle rectangle = new Rectangle(x, y, lists, pictureBox1.Width, pictureBox1.Height);
            PaintDraw();
            pictureBox1.Image = GetBitmap();
        }
        public void createSquare(int x, int y)
        {
            clearSheet();
            Square square = new Square(x, y, lists, pictureBox1.Width, pictureBox1.Height);
            PaintDraw();
            pictureBox1.Image = GetBitmap();
        }
        public void createTriangle(int x,int y)
        {
            clearSheet();
            Triangle square = new Triangle(x, y, lists, pictureBox1.Width, pictureBox1.Height);
            PaintDraw();
            pictureBox1.Image = GetBitmap();
        }
        public void CreateObj(object sender, MouseEventArgs e)
        {
            bool flag=false;
            int i=0;
            char code;
            int size = lists.getSize();
            for(i = 0; i < size && (!flag); i++)
            {
                code = lists.getObj(i).getCode();
                switch (code)
                {
                    case 'C':
                        flag = ((CCircle)lists.getObj(i)).isClick(e.X, e.Y,isCTRL,lists);    
                        break;
                    case 'R':
                        flag = ((Rectangle)lists.getObj(i)).isClick(e.X, e.Y,isCTRL, lists);
                        break;
                    case 'S':
                        flag = ((Square)lists.getObj(i)).isClick(e.X, e.Y, isCTRL, lists);
                        break;
                    case 'T':
                        flag = ((Triangle)lists.getObj(i)).isClick(e.X, e.Y, isCTRL, lists);
                        break;
                }
            }

            if (!flag) {
                switch (listBox1.SelectedItem.ToString())
                {
                    case "Circle":
                        createCCircle(e.X, e.Y);
                        break;
                    case "Rectangle":
                        createRectangle(e.X, e.Y);
                        break;
                    case "Square":
                        createSquare(e.X, e.Y);
                        break;
                    case "Triangle":
                        createTriangle(e.X, e.Y);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                PaintAll();
            }
        }

        private void PaintAll()
        {
            clearSheet();
            PaintDraw();
            pictureBox1.Image = GetBitmap();
            
        }

        public void clearSheet()
        {
            gr.Clear(Color.White);
        }

        public void PaintDraw()//отрисовка всех объектов
        {
            if (lists.getSize() == 0)
                return;
            for (int i = 0; i < lists.getSize(); i++)
            {
                lists.getObj(i).print(gr);
            }
            
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        private void btnChangeColor(object sender, EventArgs e)
        {
            isCTRL = false;
            for (int i = 0; i < lists.getSize(); i++)
            {
                if (lists.getObj(i).getSelect())
                {
                    lists.getObj(i).setBrush(listColor.SelectedItem.ToString());
                }
            }
            PaintAll();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int value = 1;
            if (e.Shift)
            {
                value = 10;
            }
            if (e.Control)
            {
                isCTRL = true;
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        for (int j = lists.getSize() - 1; j >= 0; j--)
                        {
                            lists.getObj(j).deleteSelected(lists);
                        }
                        lists.getObj(0).setSelect(true);
                        break;
                    case Keys.Left:

                        for (int i = 0; i < lists.getSize(); i++)
                        {
                            if (lists.getObj(i).getSelect())
                            {
                                lists.getObj(i).move(-value, 0, i, pictureBox1.Width, pictureBox1.Height);
                            }
                        }
                        break;
                    case Keys.Right:
                        for (int i = 0; i < lists.getSize(); i++)
                        {
                            if (lists.getObj(i).getSelect())
                            {
                                lists.getObj(i).move(value, 0, i, pictureBox1.Width, pictureBox1.Height);
                            }
                        }
                        break;
                    case Keys.Up:
                        for (int i = 0; i < lists.getSize(); i++)
                        {
                            if (lists.getObj(i).getSelect())
                            {
                                lists.getObj(i).move(0, -value, i, pictureBox1.Width, pictureBox1.Height);
                            }
                        }
                        break;
                    case Keys.Down:
                        for (int i = 0; i < lists.getSize(); i++)
                        {
                            if (lists.getObj(i).getSelect())
                            {
                                lists.getObj(i).move(0, value, i, pictureBox1.Width, pictureBox1.Height/*, lists*/);
                            }
                        }
                        break;
                    case Keys.OemMinus:
                        for (int i = 0; i < lists.getSize(); i++)
                        {
                            if (lists.getObj(i).getSelect())
                            {
                                lists.getObj(i).changesize(-value, i, pictureBox1.Width, pictureBox1.Height/*, lists*/);
                            }
                        }
                        break;
                    case Keys.Oemplus:
                        for (int i = 0; i < lists.getSize(); i++)
                        {
                            if (lists.getObj(i).getSelect())
                            {
                                lists.getObj(i).changesize(+value, i, pictureBox1.Width, pictureBox1.Height/*, lists*/);
                            }
                        }
                        break;
                    
                }
                PaintAll();
                isCTRL = false;
            }
            
        }

        private void listColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBrush.Enabled = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Enabled = true;
        }
    }
}
