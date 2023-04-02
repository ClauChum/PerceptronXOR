using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOR
{
    class Program

    {
        class obtener
        {
            public static double sigmoide(double x)
            {
                return 1.0 / (1.0 + Math.Exp(-x));
            }
            public static double salidDev(double x)
            {
                return x * (1 - x);
            }
        }

        class Neurona
        {
            public double[] inputs1 = new double[2];
            public double[] weights1 = new double[2];
            public double error;

            private double biasWeight;

            private Random r = new Random();

            public double output
            {
                get { return obtener.sigmoide(weights1[0] * inputs1[0] + weights1[1] * inputs1[1] + biasWeight); }
            }

            public void pesosrandom()
            {
                weights1[0] = r.NextDouble();
                weights1[1] = r.NextDouble();
                biasWeight = r.NextDouble();
            }

            public void peso2()
            {
                weights1[0] += error * inputs1[0];
                weights1[1] += error * inputs1[1];
                biasWeight += error;
            }
        }
        static void Main(string[] args)
        {
            double[,] valores = { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 } };
            double[] resul = { 0, 1, 1, 0 };


            Neurona val1 = new Neurona();
            Neurona val2 = new Neurona();
            Neurona out1 = new Neurona();


            val1.pesosrandom();
            val2.pesosrandom();
            out1.pesosrandom();
            int cont = 0;
         Promg:
            cont++;
            for (int i = 0; i < 4; i++)
            {


                val1.inputs1 = new double[] { valores[i, 0], valores[i, 1] };
                val2.inputs1 = new double[] { valores[i, 0], valores[i, 1] };

                out1.inputs1 = new double[] { val1.output, val2.output };

                Console.WriteLine("{0} x o r {1} = {2}", valores[i, 0], valores[i, 1], out1.output);


                out1.error = obtener.salidDev(out1.output) * (resul[i] - out1.output);
                out1.peso2();


                val1.error = obtener.salidDev(val1.output) * out1.error * out1.weights1[0];
                val2.error = obtener.salidDev(val2.output) * out1.error * out1.weights1[1];

                val1.peso2();
                val2.peso2();
            }

            if (cont < 5)
                goto Promg;
            Console.ReadLine();
        }
    }

}
            
        