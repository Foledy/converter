Console.WriteLine(ConvertToDouble(Console.ReadLine()));

double ConvertToDouble(string input)
{
    double result;
    double fractionalPart;
    int? dotIndex = GetDotIndex(input);
    int length = input.Length;
    bool isNegative = input[0] == '-';

    if (isNegative)
    {
        if (dotIndex.HasValue && dotIndex == 1)
        {
            throw new ArgumentException("Вы ввели число не правильно!");
        }
    }
    else
    {
        if (dotIndex.HasValue && dotIndex == 0)
        {
            throw new ArgumentException("Вы ввели число не правильно!");
        }
    }

    if (dotIndex.HasValue)
    {
        if (isNegative == false)
        {
            result = StringToDouble(input, 0, dotIndex.Value);
            fractionalPart = StringToDouble(input, dotIndex.Value + 1, length);

            result += (fractionalPart / MultiToTen(10, length - 1 - dotIndex.Value));
        }
        else
        {
            result = StringToDouble(input, 1, dotIndex.Value);
            fractionalPart = StringToDouble(input, dotIndex.Value + 1, length);

            result += (fractionalPart / MultiToTen(10, length - 2 - dotIndex.Value)) * (-1);
        }
    }
    else
    {
        
        if (isNegative == true)
        {
            result = StringToDouble(input, 1, length) * (-1);
        }
        else
        {
            result = StringToDouble(input, 0, length);
        }        
    }

    return result;
}

double StringToDouble(string input, int start, int end)
{
    double result = 0;

    for (int i = start; i < end; i++)
    {
        switch (input[i])
        {
            case '0':
                result = result * 10;
                break;
            case '1':
                result = result * 10 + 1;
                break;
            case '2':
                result = result * 10 + 2;
                break;
            case '3':
                result = result * 10 + 3;
                break;
            case '4':
                result = result * 10 + 4;
                break;
            case '5':
                result = result * 10 + 5;
                break;
            case '6':
                result = result * 10 + 6;
                break;
            case '7':
                result = result * 10 + 7;
                break;
            case '8':
                result = result * 10 + 8;
                break;
            case '9':
                result = result * 10 + 1;
                break;

            default:
                throw new ArgumentException("Вы ввели число некорректно!\nЧисло не может иметь 2 точки/запятые в записи или иные символы");
        }
    }

    return result;
}

int? GetDotIndex(string input)
{
    for(int i = 0; i < input.Length; i++)
    {
        if (input[i] == '.' || input[i] == ',')
        {
            return i;
        }
    }

    return null;
}

double MultiToTen(double input, int amount)
{
    for(int i = 0; i < amount; i++)
    {
        input *= 10;
    }

    return input;
}