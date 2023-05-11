using System.Data;

class Programm
{
    static string AnswerPrint(int[] BarCode)
    {
        string answer = "";
        for(int i = 0; i < BarCode.Length; i++)
        {
            answer += BarCode[i];
            if (i < BarCode.Length - 1)
            {
                answer += ", ";
            }
        }
        return answer;
    }

    static void BarCodeAntiRep(string barCode)
    {
        int[] barCodeInt = new int[barCode.Count(s => char.IsNumber(s))];

        int j = 0;
        for(int i=0;i < barCode.Length;i++)
        {
            if (char.IsNumber(barCode[i])) 
            {
                barCodeInt[j] = barCode[i] - 48;
                j++;
            }
        }

        int glass = 0;int k = 0;
        bool isTrue=false;
        Random rnd = new Random();
        do
        {
            k++;
            for (int i = 0; i < barCodeInt.Length; i++)
            {
                if (i != 0 && i != barCodeInt.Length - 1)
                {
                    if (barCodeInt[i] == barCodeInt[i - 1] && barCodeInt[i] != barCodeInt[i + 1])
                    {
                        glass = barCodeInt[i + 1];
                        barCodeInt[i + 1] = barCodeInt[i];
                        barCodeInt[i] = glass;
                    }
                    else if (barCodeInt[i] != barCodeInt[i + 1] && barCodeInt[i] == barCodeInt[i - 1])
                    {
                        glass = barCodeInt[i - 1];
                        barCodeInt[i - 1] = barCodeInt[i];
                        barCodeInt[i] = glass;
                    }
                }
                else
                if (i == 0)
                {
                    if (barCodeInt[i] == barCodeInt[i + 1] && barCodeInt[i] != barCodeInt[i + 2])
                    {
                        glass = barCodeInt[i + 2];
                        barCodeInt[i + 2] = barCodeInt[i];
                        barCodeInt[i] = glass;
                    }
                }
                else
                if (i == barCodeInt.Length - 1)
                {
                    if (barCodeInt[i] == barCodeInt[i - 1] && barCodeInt[i] != barCodeInt[i - 2])
                    {
                        glass = barCodeInt[i - 2];
                        barCodeInt[i - 2] = barCodeInt[i];
                        barCodeInt[i] = glass;
                    }
                }
                else
                {
                    rnd.Next(0, barCodeInt.Length);
                    glass = barCodeInt[Convert.ToInt32(rnd)];
                    barCodeInt[Convert.ToInt32(rnd)] = barCodeInt[rnd.Next(0, barCodeInt.Length)];
                    barCodeInt[Convert.ToInt32(rnd)] = glass;
                }
            }

            for (int i = 0; i < barCodeInt.Length - 1; i++)
            {
                if (barCodeInt[i] == barCodeInt[i + 1])
                {
                    isTrue = false;
                    break;
                }
                if (i == barCodeInt.Length - 2) isTrue = true;
            }
        } while (isTrue == false && k < barCodeInt.Length);

        if (isTrue)
        {
            Console.WriteLine("[ " + AnswerPrint(barCodeInt) + " ]");
        }
        else Console.WriteLine("Ответа не существует!");
    }

    static void Main(string[] args)
    {
        string barCode = "1,2,2,3,3,6,6,1";

        BarCodeAntiRep(barCode);
    }
}