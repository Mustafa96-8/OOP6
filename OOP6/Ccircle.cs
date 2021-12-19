using System;
using System.Drawing;

namespace OOP6
{

    public class CCircle : Base
    {
        private int R;

        public override char getCode()
        {
            return 'C';
        }
        public override void initcomp()
        {
            base.initcomp();
            R = 20;
        }
        public CCircle(int x, int y, Mylist mylist, int width, int height)
        {

            initcomp();
            if (((x + R < width) && (y + R < height) && (x - R > 0) && (y - R > 0)))//Проверяем не уйдёт ли часть объекта за рамки если есть место для объекта создаём
            {
                this.x = x;
                this.y = y;
                refreshSelected(mylist);
                Selected = true;
                mylist.add(this);
            }
        }
        public CCircle(CCircle copy)
        {
            initcomp();
            x = copy.x;
            y = copy.y;
            Selected = copy.Selected;
        }
        
        public override bool isClick(int x,int y, bool isCtrl, Mylist mylist)
        {
            double tmp = Math.Pow(this.x-x, 2) + Math.Pow(this.y - y, 2);
            if (tmp < (R * R))
            {
                toSelect(isCtrl, mylist);
                return true;
            }
            return false;
        }
        
        
        public void drawCircle(Graphics gr)//Вывод просто вершины(круга)
        {
            gr.FillEllipse(br, (x - R), (y - R), 2 * R, 2 * R);
            gr.DrawEllipse(blackpen, (x - R), (y - R), 2 * R, 2 * R);
        }
        
        public void drawSelectedVert(Graphics gr)//Внутренний вывод выбранной
        {
            gr.DrawEllipse(redpen, (x - R), (y - R), 2 * R, 2 * R);
        }

        public override void print(Graphics gr)//Вывод круга
        {
            drawCircle(gr);
            if (Selected)
            {
                drawSelectedVert(gr);
            }
        }

        public override void move(int x_, int y_,int i_,int width, int height/*, Mylist mylist*/)//Передвижение объекта/ов
        {
            if ((x + x_+R<width)&&(y+y_+R<height)&& (x + x_-R >0)&&(y + y_ - R >0))//Проверяем не выйдем ли мы за границу Бокса
            {
                /*double tmp;
                bool flag=true;
                for (int i = 0; i < mylist.getSize(); i++)
                {
                    if (i != i_)
                    {
                        tmp = Math.Pow((((CCircle)mylist.getObj(i)).x-(x+x_)), 2) + Math.Pow(((CCircle)mylist.getObj(i)).y-(y+ y_), 2);
                        if (tmp <= (4*R * R))
                        {
                            flag = false; ЛИШНИЙ КОД, НО ОН ПРОВЕРЯЕТ НЕ КОСНУТЬСЯ ЛИ КРУГИ ПРИ ПЕРЕМЕЩЕНИИ
                            break;
                        }
                    }
                }
                if (flag)
                {*/
                x += x_;
                y += y_;
                //}
                
            }
        }

        public override void changesize(int size, int i_, int width, int height/*, Mylist mylist*/)
        {
            if ((x + R+size < width) && (y + size + R < height) && (x - size - R > 0) && (y -size - R > 0))
            {
                R += size;
            } 
        }

    }
}
