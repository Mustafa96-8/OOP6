using System;
using System.Drawing;

namespace OOP6
{
    public class Triangle:Base
    {
        private int a;
        private double h;
        private PointF[] points=new PointF[4];

        public override char getCode()
        {
            return 'T';
        }

        public void initPoint()
        {
            h = a * 0.866;
            points[0].X = x + a / 2;
            points[0].Y = y + (float)h - (float)2 / 3 * (float)h;
            points[3] = points[0];

            points[1].X = x - a / 2;
            points[1].Y = y + (float)h -(float)2 / 3 * (float)h;

            points[2].X = x;
            points[2].Y = y-(float)2/3*(float)h;
        }
        public override void initcomp()
        {
            base.initcomp();
            a = 40;
            initPoint();
        }

        public Triangle(int x, int y, Mylist mylist, int width, int height)
        {
            initcomp();
            if ((x-a/2-4>0) && (x+a/2+4<width) && (y-(float)2/3*0.866*a-4>0)&&(y+ (float)1 / 3 * 0.866 * a + 4<height))//если есть место для объекта создаём
            {
                this.x = x;
                this.y = y;
                initPoint();
                refreshSelected(mylist);
                Selected = true;
                mylist.add(this);
            }
        }
        public Triangle(Triangle copy)
        {
            initcomp();
            x = copy.x;
            y = copy.y;
            a = copy.a;
            initPoint();
            Selected = copy.Selected;
        }

        public override bool isClick(int x, int y, bool isCtrl, Mylist mylist)
        {
            initPoint();
            if ((points[2].Y < y && points[0].Y>y)&&(x-points[2].X>(points[2].Y-(float)y)/ 1.732) && (x - points[2].X < -(points[2].Y-(float)y) / 1.732))
            {
                toSelect(isCtrl, mylist);
                return true;
            }
            return false;
        }

        public void drawTriangle(Graphics gr)
        {
            gr.FillPolygon(br, points);
            gr.DrawLines(blackpen, points);
            
        }

        public void drawSelectedTriangle(Graphics gr) 
        {
            gr.DrawLines(redpen, points);
        }

        public override void print(Graphics gr)
        {
            drawTriangle(gr);
            if (Selected)
            {
                drawSelectedTriangle(gr);
            }
        }
        public override void move(int x_, int y_, int i_, int width, int height)
        {
            initPoint();
            if ((points[0].X+x_< width-4) && ( points[0].Y+y_< height-4) && (points[1].X+ x_ > 4) && (points[2].Y + y_ > 4))
            {
                x += x_;
                y += y_;
                initPoint();
            }
        }
        public override void changesize(int size, int i_, int width, int height)
        {
            
            if ((points[0].X+size+4< width) && (points[0].Y + size + 4 < height) && (points[1].X - size - 4 > 0) && (points[2].Y - size - 4 > 0))
            {
                a += size;
                initPoint();
            }
        }

    }
}
