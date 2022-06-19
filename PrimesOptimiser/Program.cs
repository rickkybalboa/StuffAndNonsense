class PrimesOptimiser
{
    static TimeSpan GetPrimes(double limit)
    {

        var primes = new List<int>();

        var timer = new System.Diagnostics.Stopwatch(); timer.Start();

        //Method 1
        for (int i = 1; i <= limit; i++)
        {
            if (i == 2)
                primes.Add(i);
            else
            {
                // If a number is not prime it can be factored into n = a * b.
                // At least one of a or b must be less than sqrt(n), else sqrt(a) * sqrt(b) > n.
                // Hence if no factors less than or equal to sqrt(n), n == prime. This radically lowers computation time.
                var m = (int)Math.Sqrt(i);

                // the switch block further reduces calculation time by half:
                switch (i % 2 == 0 || i == 1 && i!=2)
                {
                    case true:
                        break;

                    case false:
                        primes.Add(i);

                        for (int j = m; j > 1; j--)
                        {
                            if (i%j == 0)
                            {
                                _=primes.Remove(i);

                                // This break further reduces calculation time scaling with limit:
                                break;
                            }
                        }
                        break;
                }
            }

        }


        timer.Stop(); var time = timer.Elapsed; Console.WriteLine(time);

        //for (int k = 0; k < primes.Count; k++)
        //    Console.WriteLine(primes[k]);
        Console.WriteLine($"Number of primes is {primes.Count}");

        return time;
    }

    static void Main()
    {

        Console.WriteLine(GetPrimes(1E6));
    }

}