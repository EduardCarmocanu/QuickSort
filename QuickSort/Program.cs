using System;


namespace QuickSort
{
	class Program
	{
		static void Main(string[] args)
		{
			Random rnd = new Random();
			IComparable[] a = new IComparable[] {'K', 'R', 'A', 'T', 'E', 'L', 'E', 'P', 'U', 'I', 'M', 'Q', 'C', 'X', 'O', 'S' };

			Sort(a);

			foreach (var item in a)
			{
				Console.WriteLine(item);
			}
		}

		public static void Sort(IComparable[] a)
		{
			Shuffle(a);
			Sort(a, 0, a.Length - 1);
		}

		private static void Sort(IComparable[] a, int lo, int hi)
		{
			if (hi <= lo) return;
			int j = partition(a, lo, hi);
			Sort(a, lo, j - 1);
			Sort(a, j + 1, hi);
		}

		private static void Shuffle(IComparable[] a)
		{
			Random rnd = new Random();
			for (int i = 0; i < a.Length; i++)
			{
				Swap(a, i, rnd.Next(0, a.Length));
			}
		}

		private static int partition (IComparable[] a, int lo, int hi)
		{
			int i = lo, j = hi + 1;
			while (true)
			{
				while (Less(a[++i], a[lo]))
				{
					if (i == hi) break;
				}
				while (Less(a[lo], a[--j]))
				{
					if (j == lo) break;
				}

				if (i >= j) break;
				Swap(a, i, j);
			}
			Swap(a, lo, j);
			return j;
		}

		private static bool Less (IComparable v, IComparable w)
		{
			return v.CompareTo(w) < 0;
		}
		private static void Swap (IComparable[] a, int i, int j)
		{
			IComparable swap = a[i];
			a[i] = a[j];
			a[j] = swap;
		}
	}
}
