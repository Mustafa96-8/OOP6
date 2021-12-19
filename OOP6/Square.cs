using System;
using System.Drawing;


namespace OOP6
{
    public class Square : Base
    {
        private int a;

        public override char getCode()
        {
            return 'S';
        }

        public override void initcomp()
        {
            base.initcomp();
            a = 25;
        }

        public Square(int x, int y, Mylist mylist, int width, int height)
        {

            initcomp();
            if ((x + a / 2 < width) && (y + a / 2 < height) && (x - a / 2 > 0) && (y - a / 2 > 0))//если есть место для объекта создаём
            {
                this.x = x;
                this.y = y;
                refreshSelected(mylist);
                Selected = true;
                mylist.add(this);
            }
        }

        public Square(Square copy)
        {
            initcomp();
            x = copy.x;
            y = copy.y;
            a = copy.a;
            Selected = copy.Selected;
        }

        public override bool isClick(int x, int y, bool isCtrl, Mylist mylist)
        {
            if ((x > (this.x - (a / 2))) && (x < (this.x + (a / 2))) && (y > (this.y - (a / 2))) && (y < (this.y + (a / 2))))
            {
                toSelect(isCtrl, mylist);
                return true;
            }
            return false;
        }

        public void drawRectangle(Graphics gr)
        {
            gr.FillRectangle(br, x - a / 2, y - a / 2, a, a);
            gr.DrawRectangle(blackpen, x - a / 2, y - a / 2, a, a);
        }
        public void drawSelectedRectangle(Graphics gr)
        {
            gr.DrawRectangle(redpen, x - a / 2, y - a / 2, a, a);
        }
        public override void print(Graphics gr)
        {
            drawRectangle(gr);
            if (Selected)
            {
                drawSelectedRectangle(gr);
            }
        }

        public override void move(int x_, int y_, int i_, int width, int height)
        {
            if ((x + a / 2 + x_ + 4 < width) && (y + a / 2 + y_ + 4 < height) && (x - a / 2 + x_ - 4 > 0) && (y - a / 2 + y_ - 4 > 0))
            {
                x += x_;
                y += y_;
            }
        }
        public override void changesize(int size, int i_, int width, int height)
        {
            if ((x + a / 2 + size + 4 < width) && (y + a / 2 + size + 4 < height) && (x - a / 2 -size - 4 > 0) && (y - a / 2 - size - 4 > 0))
            {
                a += size * 2;
            }
        }



    }
}
