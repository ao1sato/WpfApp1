namespace lib__4
{
    public class Class1
    {
        public static void InitMas (out int[] mas, int column, int randMax)
        {
            Random rnd = new Random();
            mas = new Int32[column];
            for (int i = 0; i < column; i++)
                mas[i] = rnd.Next(randMax);
        }

        public static double miner(int[] mas)
        {
            double rez = 0;
            for (int i = 0; i < mas.Length; i++)
                if (mas[i] > 0)
                {
                    rez = Math.Sqrt(mas[i]);
                    return rez;
                }
            return rez;
        }
    }
}
