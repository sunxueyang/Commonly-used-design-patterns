using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csun.组合模式
{

    /*
   * 组合模式—— 始终一致地对待简单对象和复合对象的操作
   * 
   * 组合模式——
   *   用户希望对一个简单对象和复合对象（由简单对象组成）进行始终统一的操作，所以，简单对象和复合对象所继承的接口必须完全一致。
   *   复合对象复杂的行为可以单独在自己的对象里面进行定义。
   *   
   *   
   * 优点：
   *   1、组合模式使得客户端代码可以一致地处理对象和对象容器，无需关系处理的单个对象，还是组合的对象容器。
   *   2、将”客户代码与复杂的对象容器结构“解耦。
   *   3、可以更容易地往组合对象中加入新的构件。
   * 缺点：
   *   1、使得设计更加复杂。客户端需要花更多时间理清类之间的层次关系。（这个是几乎所有设计模式所面临的问题）。
   *   
   *   
   * 使用场景：
   *   1、需要表示一个对象整体或部分的层次结构。
   *   2、希望用户忽略组合对象与单个对象的不同，用户将统一地使用组合结构中的所有对象。
   */


    /// <summary>
    /// 图形抽象类，
    /// </summary>
    public abstract class Graphics
    {
        public string Name { get; set; }
        public Graphics(string name)
        {
            this.Name = name;
        }

        public abstract void Draw();
        // 移除了Add和Remove方法
        // 把管理子对象的方法放到了ComplexGraphics类中进行管理
        // 因为这些方法只在复杂图形中才有意义
    }

    /// <summary>
    /// 简单图形类——线
    /// </summary>
    public class Line : Graphics
    {
        public Line(string name)
            : base(name)
        { }

        // 重写父类抽象方法
        public override void Draw()
        {
            Console.WriteLine("画  " + Name);
        }
    }

    /// <summary>
    /// 简单图形类——圆
    /// </summary>
    public class Circle : Graphics
    {
        public Circle(string name)
            : base(name)
        { }

        // 重写父类抽象方法
        public override void Draw()
        {
            Console.WriteLine("画  " + Name);
        }
    }

    /// <summary>
    /// 复杂图形，由一些简单图形组成,这里假设该复杂图形由一个圆两条线组成的复杂图形
    /// </summary>
    public class ComplexGraphics : Graphics
    {
        private List<Graphics> complexGraphicsList = new List<Graphics>();
        public ComplexGraphics(string name)
            : base(name)
        { }

        /// <summary>
        /// 复杂图形的画法
        /// </summary>
        public override void Draw()
        {
            foreach (Graphics g in complexGraphicsList)
            {
                g.Draw();
            }
        }

        public void Add(Graphics g)
        {
            complexGraphicsList.Add(g);
        }
        public void Remove(Graphics g)
        {
            complexGraphicsList.Remove(g);
        }
    }
}
