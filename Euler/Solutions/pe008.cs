﻿namespace Euler
{
    using System;

    public class Problem8 : IProblem
    {
        public void Pose()
        {
            string q = @"
PROBLEM 8:
The four adjacent digits in the 1000-digit number that have the greatest product are 9 x 9 x 8 x 9 = 5832.

			73167176531330624919225119674426574742355349194934
			96983520312774506326239578318016984801869478851843
			85861560789112949495459501737958331952853208805511
			12540698747158523863050715693290963295227443043557
			66896648950445244523161731856403098711121722383113
			62229893423380308135336276614282806444486645238749
			30358907296290491560440772390713810515859307960866
			70172427121883998797908792274921901699720888093776
			65727333001053367881220235421809751254540594752243
			52584907711670556013604839586446706324415722155397
			53697817977846174064955149290862569321978468622482
			83972241375657056057490261407972968652414535100474
			82166370484403199890008895243450658541227588666881
			16427171479924442928230863465674813919123162824586
			17866458359124566529476545682848912883142607690042
			24219022671055626321111109370544217506941658960408
			07198403850962455444362981230987879927244284909188
			84580156166097919133875499200524063689912560717606
			05886116467109405077541002256983155200055935729725
			71636269561882670428252483600823257530420752963450
		
Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            int n = 13;
            string giant =
            "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843" +
            "8586156078911294949545950173795833195285320880551112540698747158523863050715693290963295227443043557" +
            "6689664895044524452316173185640309871112172238311362229893423380308135336276614282806444486645238749" +
            "3035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776" +
            "6572733300105336788122023542180975125454059475224352584907711670556013604839586446706324415722155397" +
            "5369781797784617406495514929086256932197846862248283972241375657056057490261407972968652414535100474" +
            "8216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586" +
            "1786645835912456652947654568284891288314260769004224219022671055626321111109370544217506941658960408" +
            "0719840385096245544436298123098787992724428490918884580156166097919133875499200524063689912560717606" +
            "0588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";

            string[] children = giant.Split('0');
            double max = 0;
            foreach (string child in children)
            {
                double tmp = 1;
                for (int i = 0; i < Math.Min(n, child.Length); i++)
                {
                    tmp = tmp * Convert.ToInt32(child[i].ToString());
                }

                if (tmp > max)
                {
                    max = tmp;
                }

                if (child.Length > n)
                {
                    for (int j = n; j < child.Length; j++)
                    {
                        tmp = tmp * Convert.ToInt32(child[j].ToString()) / Convert.ToInt32(child[j - n].ToString());
                        if (tmp > max)
                        {
                            max = tmp;
                        }
                    }
                }
            }

            return max.ToString();
        }
    }
}
