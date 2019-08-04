
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Consumer_Problem
{

    class CNum
    {

        static int _num;
        public int p = 1;
        public int seq = 0;
        public bool Flag1; public bool flag2; public bool flag3;
        public CNum()
        {
            _num = 0; Flag1 = true; flag2 = true; flag3 = true;
        }
        public void setNum(int i)
        {
            _num = i;
        }
        public int getNum()
        {
            return _num;
        }
    }
    class GeneratNum
    {
        private CNum cnum;
        private object common_lock;
        public GeneratNum(CNum cnum, object common_lock)
        {
            // TODO: Complete member initialization
            this.cnum = cnum;
            this.common_lock = common_lock;
        }

        public void Generate()
        {
            int count = 1;
            //for (int i = 1; i <= 11; i++)
            while(true)
            {
                    lock (common_lock)
                    {

                      //  Console.Write("Produce Chnace ");
                        //Console.Write(" f1=" + cnum.Flag1 + " f2=" + cnum.flag2 + " seq=" + cnum.seq + " p =" + cnum.p);
                        if (cnum.p == 2 || cnum.p == 3 ||cnum.p==4||cnum.p==5 || (!cnum.Flag1 && !cnum.flag2 && !cnum.flag3))
                        {
                            //   Console.Write(" producer wating ");
                            Monitor.PulseAll(common_lock);
                            Monitor.Wait(common_lock);
                        }
                        else
                        {
                            cnum.setNum(count);
                            if (count == 11)
                            {
                                Console.ReadKey();
                                Environment.Exit(0);
                            }
                            Console.Write("\n " + cnum.getNum());
                            count = count + 1;
                            cnum.Flag1 = false;
                            cnum.p = 2;
                    
                        }

                        
                }

            }
        }
    }
    class Consumer//consumer 1//even
    {
        private CNum cnum;
        private object common_lock;

        public Consumer(CNum cnum, object common_lock)
        {
            // TODO: Complete member initialization
            this.cnum = cnum;
            this.common_lock = common_lock;
        }
        public void Consume()
        {
            //for (int i = 1; i <= 11; i++)
            while(true)
            {
                lock (common_lock)
                {

                    //Console.Write("Consumer1 Chnace ");
                    //Console.Write(" f1=" + cnum.Flag1 + " f2=" + cnum.flag2 + " seq=" + cnum.seq + " p =" + cnum.p);

                    if (cnum.p == 3 || cnum.p == 4 || cnum.p == 1 ||cnum.p==5|| (cnum.Flag1 && !cnum.flag2 && !cnum.flag3))
                    {
                      //  Console.Write(" Consumer1 wating ");
                        Monitor.PulseAll(common_lock);
                        Monitor.Wait(common_lock);
                    }
                    else {
                        Console.Write("\t  " + (cnum.getNum()%2==0));
                        cnum.Flag1 = true;
                        cnum.flag2 = false;
                        cnum.p = 3;
                    }


                }
  
            }
        }
    }
    class Consumer1//consumer 2//odd number
    {
        private CNum cnum;
        private object common_lock;

        public Consumer1(CNum cnum, object common_lock)
        {
            // TODO: Complete member initialization
            this.cnum = cnum;
            this.common_lock = common_lock;
        }
        public void Consume()
        {
          //  for (int i = 1; i <= 11; i++)
            while(true)
            {
                lock (common_lock)
                {

                    //Console.Write("Consumer2 Chnace ");
                    //Console.Write(" f1=" + cnum.Flag1 + " f2=" + cnum.flag2 + " seq=" + cnum.seq + " p =" + cnum.p);

                    if (cnum.p == 1 ||cnum.p==2||cnum.p==4||cnum.p==5 || (!cnum.Flag1 && cnum.flag2 && !cnum.flag3))
                    {
                        // Console.Write(" Consumer2 wating ");
                        Monitor.PulseAll(common_lock);
                        Monitor.Wait(common_lock);
                    }
                    else
                    {
                        Console.Write("\t  " + (cnum.getNum() % 2 != 0));
                    
                       // Console.Write("\t consume2 " + cnum.getNum());
                        //cnum.Flag1 = true;
                        cnum.flag2 = true;
                        cnum.flag3 = false;
                        cnum.p = 4;
                    }
                }


            }
        }
    }
    class Consumer2//consumer 3//prime number
    {
        private CNum cnum;
        private object common_lock;

        public Consumer2(CNum cnum, object common_lock)
        {
            // TODO: Complete member initialization
            this.cnum = cnum;
            this.common_lock = common_lock;
        }
        public void Consume()
        {
            //  for (int i = 1; i <= 11; i++)
            while (true)
            {
                lock (common_lock)
                {

                    //Console.Write("Consumer3 Chnace ");
                    //Console.Write(" f1=" + cnum.Flag1 + " f2=" + cnum.flag2 + " seq=" + cnum.seq + " p =" + cnum.p);

                    if (cnum.p == 1 || cnum.p == 2 ||cnum.p==3||cnum.p==5 || (!cnum.Flag1 && !cnum.flag2 && cnum.flag3 ))
                    {
                        // Console.Write(" Consumer2 wating ");
                        Monitor.PulseAll(common_lock);
                        Monitor.Wait(common_lock);
                    }
                    else
                    {
                        //Console.Write("\t consume3 " + cnum.getNum());
                        int n=cnum.getNum();
                        bool prime = true;
                        
                            for (int i = 2; i <= n / 2; i++)
                            {
                                if (n % i == 0)
                                {
                                    prime = false; break;
                                }
                            }
                            if (n == 1)
                            { prime = false; }
                        
                       
                         Console.Write("\t  " + prime);
                        
                        cnum.Flag1 = false;
                        cnum.flag2 = true;
                        cnum.p = 5;
                    }
                }


            }
        }
    }
    class Consumer3//consumer 4//Fabonacci number
    {
        private CNum cnum;
        private object common_lock;

        public Consumer3(CNum cnum, object common_lock)
        {
            // TODO: Complete member initialization
            this.cnum = cnum;
            this.common_lock = common_lock;
        }
        public void Consume()
        {
            //  for (int i = 1; i <= 11; i++)
            while (true)
            {
                lock (common_lock)
                {

                    //Console.Write("Consumer4 Chnace ");
                    //Console.Write(" f1=" + cnum.Flag1 + " f2=" + cnum.flag2 + " seq=" + cnum.seq + " p =" + cnum.p);

                    if (cnum.p == 1 || cnum.p == 2 ||cnum.p==3||cnum.p==4 || (cnum.Flag1 && !cnum.flag2 && cnum.flag3))
                    {
                        // Console.Write(" Consumer4 wating ");
                        Monitor.PulseAll(common_lock);
                        Monitor.Wait(common_lock);
                    }
                    else
                    {
                        int a = 0, b = 1, c, n = cnum.getNum(); bool fab = false;
                        for (int i = 1; i <= n; i++)
                        {
                            c = a + b; a = b; b = c;
                        if (c == n) { fab = true; }
                        }
                        Console.Write("\t    " + fab);

                        cnum.Flag1 = true;
                        cnum.flag2 = true;
                        cnum.flag3 = true;
                        cnum.p = 1;
                    }
                }


            }
        }
    }

    class Program
    {
        public static void Main(string[] str)
        {
            CNum cnum = new CNum();
            Object common_lock = new Object();
            GeneratNum genrate = new GeneratNum(cnum, common_lock);
            Consumer consum = new Consumer(cnum, common_lock);//0

            Consumer1 consum1 = new Consumer1(cnum, common_lock);

            Consumer2 consum2 = new Consumer2(cnum, common_lock);
            Consumer3 consum3 = new Consumer3(cnum, common_lock);

            Thread t1 = new Thread(genrate.Generate);
            Thread t2 = new Thread(consum.Consume);
            Thread t3 = new Thread(consum1.Consume);

            Thread t4 = new Thread(consum2.Consume);
            Thread t5 = new Thread(consum3.Consume);
            Console.WriteLine(" Number\t  Even    Odd \t  Prime\t    Fabonacci");
            t1.Start(); //Thread.Sleep(1000);
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
            Console.ReadKey();
        }
    }

}
