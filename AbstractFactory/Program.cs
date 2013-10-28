using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    internal class Program
    {
        private static void Main(string[] args)
        {
        }
    }

    #region Hamburg

    public abstract class Hamburg
    {
        private string mName = string.Empty;
        public Bun mBun = null;
        public Sauce mSauce = null;
        public Onion mOnion = null;
        public Pork mPork = null;
        public Beef mBeef = null;

        public abstract void prepare();

        internal void cook()
        {
        }

        internal void assembly()
        {
        }

        internal void box()
        {
        }

        private void setName(string name)
        {
            mName = name;
        }
    }

    public class PorkHamburg : Hamburg
    {
        public override void prepare()
        {
            throw new NotImplementedException();
        }
    }

    public class BeefHamburg : Hamburg
    {
        public override void prepare()
        {
            throw new NotImplementedException();
        }
    }

    public class SweetBeefHamburg : Hamburg
    {
        public override void prepare()
        {
            throw new NotImplementedException();
        }
    }

    public class SweetPorkHamburg : Hamburg
    {
        private HamburgIngredientFactory mFactory = null;

        public SweetPorkHamburg(HamburgIngredientFactory factory)
        {
            this.mFactory = factory;
        }

        public override void prepare()
        {
            mBun = mFactory.createBun();
            mSauce = mFactory.createSauce();
            mOnion = mFactory.createOnion();
            mPork = mFactory.createPork();
        }
    }

    #endregion Hamburg

    #region Store

    public abstract class HamburgStore
    {
        public Hamburg orderHamburg(string type)
        {
            Hamburg ham = null;
            ham = createHamburg(type);
            ham.prepare();
            ham.cook();
            ham.assembly();
            ham.box();
            return ham;
        }

        public abstract Hamburg createHamburg(string type);
    }

    public class TaipeiHamburgStore : HamburgStore
    {
        public override Hamburg createHamburg(string type)
        {
            Hamburg ham = null;
            switch (type)
            {
                case "pork":
                    ham = new PorkHamburg();
                    break;

                case "beef":
                    ham = new BeefHamburg();
                    break;

                default:
                    throw new Exception();
                    break;
            }

            return ham;
        }
    }

    public class TainanHamburgStore : HamburgStore
    {
        public override Hamburg createHamburg(string type)
        {
            Hamburg ham = null;
            HamburgIngredientFactory factory = new TainanHamburgIngredientFactory();
            switch (type)
            {
                case "pork":
                    ham = new SweetPorkHamburg(factory);
                    break;

                case "beef":
                    ham = new SweetBeefHamburg();
                    break;

                default:
                    throw new Exception();
                    break;
            }

            return ham;
        }
    }

    #endregion Store

    #region HamburgIngredient

    public class TainanHamburgIngredientFactory : HamburgIngredientFactory
    {
        public Bun createBun()
        {
            return new RiceBun();
        }

        public Sauce createSauce()
        {
            return new MaynonnaiseSauce();
        }

        public Onion createOnion()
        {
            return new FreahOnion();
        }

        public Pork createPork()
        {
            return new BlackPork();
        }

        public Beef createBeef()
        {
            return new TWBeef();
        }
    }

    public interface HamburgIngredientFactory
    {
        Bun createBun();

        Sauce createSauce();

        Onion createOnion();

        Pork createPork();

        Beef createBeef();
    }

    #endregion HamburgIngredient

    #region Ingredient

    public interface Bun
    {
    }

    public class RiceBun : Bun
    {
    }

    public class Wheatbun : Bun
    {
    }

    public interface Sauce
    {
    }

    public class TomatoSauce : Sauce
    {
    }

    public class MaynonnaiseSauce : Sauce
    {
    }

    public interface Onion
    {
    }

    public class FreahOnion : Onion
    {
    }

    public class FrozenOnion : Onion
    {
    }

    public interface Pork
    {
    }

    public class BlackPork : Pork
    {
    }

    public class WhitePork : Pork
    {
    }

    public interface Beef
    {
    }

    public class TWBeef : Beef
    {
    }

    public class USBeef : Beef
    {
    }

    #endregion Ingredient
}