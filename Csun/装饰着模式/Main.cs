using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csun.装饰着模式
{

    /*
    * 装饰着模式—— 动态地给一个对象添加额外的职责
    * 
    * 装饰着模式——
    *   通过把原先对象及行为抽象出来固话之后，将新增的装饰行为进行抽象继承原先对象，新增的行为扩展在装饰行为里面。
    *   调用装饰行为实例，则对原先行为和新增装饰行为进行逐一调用，实现动态添加额外职责。
    *   
    *   
    * 优点：
    *   1、装饰者模式和继承的目的都是扩展对象的功能，但装饰者模式比继承更灵活。
    *   2、通过使用不同的具体装饰类以及这些类的排列组合，设计师可以创造出很多不同行为的组合。
    *   3、装饰者模式有很好地可扩展性。
    * 缺点：
    *   1、装饰者模式会导致设计中出现许多小对象，如果过度使用，会让程序变的更复杂。并且更多的对象会是的差错变得困难，特别是这些对象看上去都很像。
    *   
    *   
    * 使用场景：
    *   1、需要扩展一个类的功能或给一个类增加附加责任。
    *   2、需要动态地给一个对象增加功能，这些功能可以再动态地撤销。
    *   3、需要增加由一些基本功能的排列组合而产生的非常大量的功能。
    */



    /// <summary>
    /// 手机抽象类，即装饰者模式中的抽象组件类
    /// </summary>
    public abstract class Phone
    {
        public abstract void Print();
    }

    /// <summary>
    /// 苹果手机，即装饰着模式中的具体组件类
    /// </summary>
    public class ApplePhone : Phone
    {
        /// <summary>
        /// 重写基类方法
        /// </summary>
        public override void Print()
        {
            Console.WriteLine("开始执行具体的对象——苹果手机");
        }
    }

    /// <summary>
    /// 装饰抽象类,要让装饰完全取代抽象组件，所以必须继承自Photo
    /// </summary>
    public abstract class Decorator : Phone
    {
        private Phone phone;

        public Decorator(Phone p)
        {
            this.phone = p;
        }

        public override void Print()
        {
            if (phone != null)
            {
                phone.Print();
            }
        }
    }

    /// <summary>
    /// 贴膜，即具体装饰者
    /// </summary>
    public class Sticker : Decorator
    {
        public Sticker(Phone p)
            : base(p)
        {
        }

        public override void Print()
        {
            base.Print();

            // 添加新的行为
            AddSticker();
        }

        /// <summary>
        /// 新的行为方法
        /// </summary>
        public void AddSticker()
        {
            Console.WriteLine("现在苹果手机有贴膜了");
        }
    }

    /// <summary>
    /// 手机挂件
    /// </summary>
    public class Accessories : Decorator
    {
        public Accessories(Phone p)
            : base(p)
        {
        }

        public override void Print()
        {
            base.Print();

            // 添加新的行为
            AddAccessories();
        }

        /// <summary>
        /// 新的行为方法
        /// </summary>
        public void AddAccessories()
        {
            Console.WriteLine("现在苹果手机有漂亮的挂件了");
        }
    }
}
