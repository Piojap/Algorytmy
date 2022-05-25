using System;

namespace CubicSolver
{
    class Values
    {
        double a, b, c, d, w, p, q, u, v, dlt, phi;
        string x1, x2, x3;


        public void CubicEquation()
        {
            Console.WriteLine("Enter the coefficients of the cubic equation.");
            Console.WriteLine("Enter the a coefficient.");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the b coefficient.");
            b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the c coefficient.");
            c = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the d coefficient.");
            d = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"You have entered the following expression: {a}x^3 + {b}x^2 + {c}x + {d}");
        }

        public void Calculations()
        {
            w = -b / (3 * a);
            p = ((3 * a * Math.Pow(w, 2)) + (2 * b * w) + c) / a;
            q = ((a * Math.Pow(w, 3)) + (b * Math.Pow(w, 2)) + (c * w) + d) / a;
            dlt = (Math.Pow(q, 2) / 4) + (Math.Pow(p, 3) / 27);
        }

        public void DeltaChoice()
        {
            switch (dlt)
            {
                case > 0:
                    PositiveDelta();
                    break;

                case 0:
                    ZeroDelta();
                    break;

                case < 0:
                    NegativeDelta();
                    break;
            }
        }

        public void PositiveDelta()
        {
            u = Math.Cbrt(-q / 2 + Math.Sqrt(dlt));
            v = Math.Cbrt(-q / 2 - Math.Sqrt(dlt));

            x1 = "" + Math.Round(u + v + w, 5);

            x2 = "" + Math.Round((-((u + v) / 2) + w), 5);
            x2 += " + " + Math.Round((Math.Sqrt(3) / 2) * (u - v), 5);

            x3 = "" + Math.Round((-((u + v) / 2) + w), 5);
            x3 += " - " + Math.Round((Math.Sqrt(3) / 2) * (u - v), 5);
            Console.WriteLine($"The roots of the equation are: x1 = {x1}, x2 = {x2}i, x3 = {x3}i.");
        }

        public void ZeroDelta()
        {
            x1 = "" + (w - 2 * Math.Cbrt(q / 2.0));
            x2 = "" + (w + Math.Cbrt(q / 2.0));
            Console.WriteLine($"The roots of the equation are: x1 = {x1}, x2 = {x2}, x3 = {x2}.");
        }

        public void NegativeDelta()
        {
            double pi = Math.PI;
            phi = Math.Acos(3 * q / (2 * p * Math.Sqrt(-p / 3.0)));
            x1 = "" + Math.Round(w + (2 * Math.Sqrt(-p / 3.0) * Math.Cos(phi / 3)), 5);
            x2 = "" + Math.Round(w + (2 * Math.Sqrt(-p / 3.0) * Math.Cos(phi / 3 * (2 / 3 * pi))), 5);
            x3 = "" + Math.Round(w + (2 * Math.Sqrt(-p / 3.0) * Math.Cos(phi / 3 * (4 / 3 * pi))), 5);
            Console.WriteLine($"The roots of the equation are: x1 = {x1}, x2 = {x2}, x3 = {x3}.");
        }
    }

    class Execute
    {
        static void Main()
        {
            Values data = new Values();
            data.CubicEquation();
            data.Calculations();
            data.DeltaChoice();
        }
    }

}
